using Jasonphos.SharedUtil.Data;

namespace Jasonphos.TwitterSampleFeedGUI {
    public partial class Main : Form
    {
        ConfigData _configData;
        public Main()
        {
            InitializeComponent();
            _configData = new ConfigData(null);
            PopulateFormFromConfig(_configData,this);
            btnStart.Click += new EventHandler(btnStart_click);

        }

        private void PopulateFormFromConfig(ConfigData configData, Control control) {
            foreach(Control child in control.Controls) {
                if((child.GetType() == typeof(TextBox) || child.GetType() == typeof(ComboBox)) && child.Name.StartsWith("cfg_")) { //We only auto-load config for keys whose name begins with "ui_"
                    child.Text = configData.GetValue(child.Name);
                } else {
                    PopulateFormFromConfig(configData,child); //Do it for any children. Probably won't apply for the Jack Henry project at this time, but could be useful for future enhancements, so I want to show off a little recursion scenario!
                }
            }
        }

        private void PopulateConfigFromForm(ConfigData configData, Control control) {
            foreach (Control child in control.Controls) {
                if( (child.GetType() == typeof(TextBox) || child.GetType() == typeof(ComboBox)) && child.Name.StartsWith("cfg_")) {
                    configData.SetValue(child.Name,child.Text);
                }
            }
        }

        private void StartProcess_Click(object sender,EventArgs e) {
            SaveBearerToken();
            StartProcess();
        }

        public void SetBearerToken(String value) {
            cfg_TwitterAPIBearerToken.Text = value;
        }

        /// <summary>
        /// Overwrites the Bearer Token every time we Start. Note: Could do it differently, such as only if the file doesn't exist, but
        /// for now this seems the simplest user interface and the simplest way to code.
        /// </summary>
        public void SaveBearerToken() {
            try {
                String nl = System.Environment.NewLine;

                String bearerToken = cfg_TwitterAPIBearerToken.Text;
                String toWrite = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + nl + "<appSettings>" + nl + "\t" +
                    @"<add key = ""cfg_TwitterAPIBearerToken"" value = """ + bearerToken + @""" />" + nl +
                    @"</appSettings>";
                File.WriteAllText("Secrets.config", toWrite);
            } catch (Exception e) {
                _configData.Logger.LogException(e);
            }
        }

        private void StartProcess() {
            if (IsFormValid()) {
                SaveBearerToken();
                PopulateConfigFromForm(_configData,this);
                Dashboard viewForm = new Dashboard(_configData);
                viewForm.Show();
            }
        }

        private bool IsFormValid() {
            if (this.cfg_TwitterAPIBearerToken.Text.Length == 0) {
                System.Windows.Forms.MessageBox.Show("Cannot Start: Bearer Token field is empty");
                return false;
            }
            return true;
        }

        private void btnStart_click(object? sender,EventArgs e) {
            StartProcess();
        }

    }
}