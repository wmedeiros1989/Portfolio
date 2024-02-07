using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace InventoryTrackingSoftware
{
    public partial class MainForm : Form
    {
        private GoogleAuthenticator _authenticator;
        private DriveService _driveService;
        private SheetsService _sheetsService;
        private InventoryUploader _uploader;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _authenticator = new GoogleAuthenticator();
            _authenticator.Authenticate();

            _driveService = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = _authenticator.Credential,
                ApplicationName = Constants.ApplicationName
            });

            _sheetsService = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = _authenticator.Credential,
                ApplicationName = Constants.ApplicationName
            });

            _uploader = new InventoryUploader(_driveService, _sheetsService);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var items = new List<InventoryItem>
            {
                new InventoryItem { Name = "Item 1", Quantity = 10 },
                new InventoryItem { Name = "Item 2", Quantity = 20 },
                new InventoryItem { Name = "Item 3", Quantity = 30 }
            };

            _uploader.UploadInventory(items);

            MessageBox.Show("Inventory uploaded successfully.");
        }
    }

    public static class Constants
    {
        public const string ApplicationName = "Inventory Tracking Software";
    }

    class GoogleAuthenticator
    {
        private static readonly string[] Scopes = { DriveService.Scope.Drive, SheetsService.Scope.Spreadsheets };
        private static readonly string CredentialsPath = "credentials.json";
        private static readonly string TokenPath = "token.json";

        public UserCredential Credential { get; private set; }

        public void Authenticate()
        {
            using var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read);
            var credentialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), TokenPath);

            Credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credentialPath, true)).Result;
        }
    }

    class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    class InventoryUploader
    {
        private readonly DriveService _driveService;
        private readonly SheetsService _sheetsService;

        public InventoryUploader(DriveService driveService, SheetsService sheetsService)
        {
            _driveService = driveService;
            _sheetsService = sheetsService;
        }

        public void UploadInventory(IEnumerable<InventoryItem> items)
        {
            var spreadsheetId = CreateSpreadsheet("Inventory", "Item Name", "Quantity");

            var valueRange = new ValueRange();
            valueRange.Range = "Sheet1!A1:B" + (items.Count() + 1).ToString();

            var values = new List<IList<object>>();
            values.Add(new List<object> { "Item Name", "Quantity" });
            foreach (var item in items)
            {
                values.Add(new List<object> { item.Name, item.Quantity });
            }
            valueRange.Values = values;

            var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRange, spreadsheetId, valueRange.Range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest.Execute();
        }

        private string CreateSpreadsheet(string title, params string[] headers)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = title,
                MimeType = "application/vnd.google-apps.spreadsheet"
            };

            var request = _driveService.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();

            var valueRange = new ValueRange
            {
                Values = new List<IList<object>> { headers }
            };

            var range = "Sheet1!A1:" + Convert.ToChar('A' + headers.Length - 1) + "1";
            var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRange, file.Id, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest.Execute();

            return file.Id;
        }
    }
}

