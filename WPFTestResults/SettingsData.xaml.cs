using System.Windows;
using System.Xml;
using GeneralFunctionality;

namespace WPFTestResults
{
    /// <summary>
    /// Interaction logic for SettingsData.xaml
    /// </summary>
    public partial class SettingsData : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public SettingsData()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OverallSettings.ShowDataSettings();

            var settingsSettingsDir = OverallSettings.SettingsSettingsDir;
            var settingsDataDir = OverallSettings.SettingsDataDir;

            TextBoxSettingsDir.Text = settingsSettingsDir;
            TextBoxDataDir.Text = settingsDataDir;
        }

        private void ButtonSaveConfig_Click(object sender, RoutedEventArgs e)
        {
            var settingsXML = new XmlWriterSettings();
            settingsXML.Indent = true;
            settingsXML.OmitXmlDeclaration = true;
            settingsXML.IndentChars = "\t";

            using (XmlWriter writer =
                XmlWriter.Create("settings.xml", settingsXML))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("settings");
                writer.WriteElementString("settingsdir", TextBoxSettingsDir.Text );
                writer.WriteElementString("datadir", TextBoxDataDir.Text);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            MessageBox.Show(
                "Overall settings are saved!!!",
                "Message",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            this.Close();
        }
    }
}
