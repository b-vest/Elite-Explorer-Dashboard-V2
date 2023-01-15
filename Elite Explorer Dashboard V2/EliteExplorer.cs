namespace Elite_Explorer_Dashboard_V2
{
    public partial class EliteExplorer : Form
    {
        public EliteExplorer()
        {
            InitializeComponent();
        }
        private void EliteExplorer_Load(object sender, EventArgs e)
        {
            listBoxDebugOutput.Items.Add("Run Load");
            readSettings();
        }

        private void readSettings()
        {
            listBoxDebugOutput.Items.Add(Properties.Settings.Default.LogPath.Contains("\\"));
            if (Properties.Settings.Default.LogPath.Contains("\\") == false)
            {
                textBoxLogFilePath.Text = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
                Properties.Settings.Default.LogPath = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
            }
            else
            {
                listBoxActiveLogPath.Items.Add(textBoxLogFilePath.Text);
            }
        }
            private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}