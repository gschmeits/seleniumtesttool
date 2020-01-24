﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using DataStorage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using MessageBox = System.Windows.MessageBox;
using TreeView = System.Windows.Controls.TreeView;

namespace WPFTestResults
{
    using System.Xml;

    using GeneralFunctionality;

    /// <summary>
    ///     Interaction logic for ScriptScreen.xaml
    /// </summary>
    public partial class ScriptScreen : Window
    {
        private static IWebDriver driver;

        // a set of all selected items
        private readonly Dictionary<TreeViewItem, string> selectedItems =
            new Dictionary<TreeViewItem, string>();

        private readonly Dictionary<TreeViewItem, string> selectedItems2 =
            new Dictionary<TreeViewItem, string>();

        private readonly List<TreeViewItem> selectedTreeViewItemList = new List<TreeViewItem>();
        private readonly List<TreeViewItem> selectedTreeViewItemList2 = new List<TreeViewItem>();

        public ScriptScreen()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            var screen = Screen.PrimaryScreen.WorkingArea;
            var w = Width >= screen.Width ? screen.Width : screen.Width * 0.65;
            var h = Height >= screen.Height ? screen.Height : screen.Height * 0.60;
            Width = w;
            Height = h;
            TreeView1.Height = h * 0.6;
            TreeView2.Height = h * 0.6;
            TreeView1.Width = w * 0.35;
            TreeView2.Width = w * 0.35;

            ButtonAllBack.IsEnabled = false;
            ButtonOneBack.IsEnabled = false;

            GetScripts();
        }

        private static string melding { get; set; }

        private static List<Scripts1> TestScripts { get; set; }
        private static List<ScriptDetails> TestScriptsDetails { get; set; }

        private static string machinestatic { get; set; }
        private DateTime BeginDateTime { get; set; }
        private int RadioButton { get; set; }

        /// <summary>
        ///     Gets or sets the results count.
        /// </summary>
        /// <value>The results count.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ResultsCount
        private static List<TestResultsFactory.ResultsCount> ResultsCount { get; set; }

        /// <summary>
        ///     Gets or sets the test results.
        /// </summary>
        /// <value>The test results.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestResults
        private static List<TestResultsFactory.TestResults> TestResults { get; set; }

        /// <summary>
        ///     Gets or sets the testresults fact.
        /// </summary>
        /// <value>The testresults fact.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestresultsFact
        private static List<TestResultsFactory.TestResultsSelect> TestresultsFact { get; set; }

        // true only while left ctrl key is pressed
        private bool CtrlPressed => Keyboard.IsKeyDown(Key.LeftCtrl);

        private void GetScripts()
        {
            ComboBoxLoadScripts.Items.Clear();
            TestScripts = ScriptsDataFactory.GetScripts();

            ComboBoxLoadScripts.ItemsSource = TestScripts;
            ComboBoxLoadScripts.DisplayMemberPath = "name";
            ComboBoxLoadScripts.SelectedValuePath = "id";


            if (ComboBoxLoadScripts.Items.Count > 0) ComboBoxLoadScripts.IsEnabled = true;
        }

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            GetBestanden();
            TreeView2.Items.Clear();
            GridBrowser.Visibility = Visibility.Hidden;
        }

        private void GetBestanden()
        {
            var dirs = Directory.GetFiles(GeneralFunctionality.Functions.GetCurrentDir(1), "*.xml");

            TreeView1.Items.Clear();
            foreach (var dir1 in dirs)
            {
                var bestandsnaam = GeneralFunctionality.Functions.SplitBestand(dir1);
                var item = new TreeViewItem();
                item.Header = bestandsnaam;

                var credits = GeneralFunctionality.Functions.GetCredentials(bestandsnaam);
                item.ItemsSource = new[] {bestandsnaam, credits.Url, credits.Application, credits.Page};

                TreeView1.Items.Add(item);
            }
        }

        // deselects the tree item
        private void Deselect(TreeViewItem treeViewItem)
        {
            treeViewItem.Background = Brushes.White; // change background and foreground colors
            treeViewItem.Foreground = Brushes.Black;
            selectedItems.Remove(treeViewItem); // remove the item from the selected items set
        }

        // changes the state of the tree item:
        // selects it if it has not been selected and
        // deselects it otherwise
        private void ChangeSelectedState(TreeViewItem treeViewItem)
        {
            if (!selectedItems.ContainsKey(treeViewItem))
            {
                // select
                treeViewItem.Background = Brushes.Black; // change background and foreground colors
                treeViewItem.Foreground = Brushes.White;
                selectedItems.Add(treeViewItem, null); // add the item to selected items
            }
            else
            {
                // deselect
                Deselect(treeViewItem);
            }
        }

        private void ChangeSelectedState2(TreeViewItem treeViewItem)
        {
            if (!selectedItems2.ContainsKey(treeViewItem))
            {
                // select
                treeViewItem.Background = Brushes.Black; // change background and foreground colors
                treeViewItem.Foreground = Brushes.White;
                selectedItems2.Add(treeViewItem, null); // add the item to selected items
            }
            else
            {
                // deselect
                Deselect(treeViewItem);
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var tv = (TreeView) sender;

            var treeViewItem = tv.SelectedItem as TreeViewItem;

            if (treeViewItem == null)
                return;

            // prevent the WPF tree item selection 
            treeViewItem.IsSelected = false;

            treeViewItem.Focus();

            if (!CtrlPressed)
            {
                //selectedTreeViewItemList = new List<TreeViewItem>();
                foreach (var treeViewItem1 in selectedItems.Keys) selectedTreeViewItemList.Add(treeViewItem1);

                foreach (var treeViewItem1 in selectedTreeViewItemList) Deselect(treeViewItem1);
            }

            ChangeSelectedState(treeViewItem);
        }

        private void ButtonAllTo_Click(object sender, RoutedEventArgs e)
        {
            TreeView2.Items.Clear();

            foreach (TreeViewItem node in TreeView1.Items)
            {
                var item = new TreeViewItem();
                item.Header = node.Header;
                item.ItemsSource = node.ItemsSource;

                TreeView2.Items.Add(item);
            }

            ButtonOneBack.IsEnabled = true;
            ButtonAllBack.IsEnabled = true;
            ButtonExecute.IsEnabled = true;
            TextBoxSaveAs.IsEnabled = true;
            CheckItems();
        }

        private void CheckItems()
        {
            if (TreeView2.Items.Count > 0)
            {
                TextBoxSaveAs.IsEnabled = true;
                ButtonSaveAs.IsEnabled = true;
            }
            else
            {
                TextBoxSaveAs.IsEnabled = true;
                ButtonSaveAs.IsEnabled = true;
            }
        }

        private void TreeView_SelectedItemChanged2(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var tv = (TreeView) sender;

            var treeViewItem = tv.SelectedItem as TreeViewItem;

            if (treeViewItem == null)
                return;


            if (treeViewItem.IsSelected)
            {
                ButtonOneBack.IsEnabled = true;
                ButtonExecute.IsEnabled = true;
            }
            else
            {
                ButtonOneBack.IsEnabled = false;
                ButtonExecute.IsEnabled = false;
            }

            // prevent the WPF tree item selection 
            treeViewItem.IsSelected = false;

            treeViewItem.Focus();

            if (!CtrlPressed)
            {
                //var selectedTreeViewItemList2 = new List<TreeViewItem>();
                foreach (var treeViewItem2 in selectedItems2.Keys) selectedTreeViewItemList2.Add(treeViewItem2);

                foreach (var treeViewItem2 in selectedTreeViewItemList2) Deselect(treeViewItem2);
            }

            ChangeSelectedState2(treeViewItem);
        }

        private void ButtonAllBack_Click(object sender, RoutedEventArgs e)
        {
            TreeView2.Items.Clear();
            ButtonOneBack.IsEnabled = false;
            ButtonAllBack.IsEnabled = false;
            ButtonExecute.IsEnabled = false;
            TextBoxSaveAs.IsEnabled = false;
            CheckItems();
        }

        private void ButtonOneTo_Click(object sender, RoutedEventArgs e)
        {
            foreach (TreeViewItem node in TreeView1.Items)
            foreach (var gdd in selectedItems)
                if (gdd.Key.Header == node.Header)
                {
                    var item = new TreeViewItem();
                    item.Header = node.Header;
                    item.ItemsSource = node.ItemsSource;

                    TreeView2.Items.Add(item);
                    break;
                }

            if (TreeView2.Items.Count > 0)
            {
                ButtonAllBack.IsEnabled = true;
                ButtonExecute.IsEnabled = true;
                TextBoxSaveAs.IsEnabled = true;
            }
            else
            {
                ButtonOneBack.IsEnabled = false;
                ButtonAllBack.IsEnabled = false;
                ButtonExecute.IsEnabled = false;
                TextBoxSaveAs.IsEnabled = false;
            }

            CheckItems();
        }

        private void ButtonOneBack_Click(object sender, RoutedEventArgs e)
        {
            foreach (var gdd in selectedItems2) TreeView2.Items.Remove(gdd.Key);

            if (TreeView2.Items.Count > 0)
            {
                ButtonOneBack.IsEnabled = true;
                ButtonAllBack.IsEnabled = true;
                ButtonExecute.IsEnabled = true;
                TextBoxSaveAs.IsEnabled = true;
            }
            else
            {
                ButtonOneBack.IsEnabled = false;
                ButtonAllBack.IsEnabled = false;
                ButtonExecute.IsEnabled = false;
                TextBoxSaveAs.IsEnabled = false;
            }

            CheckItems();
        }

        private void RadioButtonChecked3(object sender, RoutedEventArgs e)
        {
            RadioButton = 4;
        }

        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton = 5;
        }

        private void RadioButtonChecked1(object sender, RoutedEventArgs e)
        {
            RadioButton = 3;
        }

        private void RadioButtonChecked2(object sender, RoutedEventArgs e)
        {
            RadioButton = 1;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton = 2;
        }

        private void uitvoer()
        {
            var Bestandsnaam = "";

            var passedGer = 0;
            var failedGer = 0;
            DateTime totalBeginDateTime = DateTime.Now;

            using (new PleaseWait())
            {
                foreach (TreeViewItem node in TreeView2.Items)
                {
                    GeneralFunctionality.Functions.setTestrunID(General.LastTestRun);
                    Bestandsnaam = node.Header.ToString();
                    BeginDateTime = DateTime.Now;
                    var credits = GeneralFunctionality.Functions.GetCredentials(Bestandsnaam);
                    machinestatic = InloggerData.MachineCode;
                    var applicatieNaam = credits.Application;

                    var urlstring = credits.Url;

                    var chromePath = GeneralFunctionality.Functions.GetCurrentDir(0);
                    switch (RadioButton)
                    {
                        case 1:
                            driver = new ChromeDriver(chromePath) { Url = urlstring };
                            General.LogMessageDatabase("Chrome gekozen als 'driver'", 0, string.Empty, 0,
                                string.Empty,
                                machinestatic);
                            break;
                        case 2:
                            driver = new FirefoxDriver();
                            driver.Url = urlstring;
                            break;
                        case 3:
                            var options = new InternetExplorerOptions();
                            options.RequireWindowFocus = true;
                            options.EnableNativeEvents = false;
                            options.InitialBrowserUrl = urlstring;

                            // options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
                            options.IgnoreZoomLevel = true;
                            options.EnablePersistentHover = true;
                            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                            driver = new InternetExplorerDriver(chromePath, options);
                            break;
                        case 4:
                            // driver = new PhantomJSDriver();
                            // driver.Navigate().GoToUrl(credits.Url);
                            break;
                        case 5:
                            try
                            {
                                driver = new EdgeDriver(chromePath);
                                driver.Navigate().GoToUrl(urlstring);
                            }
                            catch (Exception ex)
                            {
                                General.LogMessageDatabase(
                                    ex.Message + "\r\n" + ex.StackTrace,
                                    4,
                                    string.Empty,
                                    0,
                                    string.Empty,
                                    machinestatic);
                            }

                            break;
                    }

                    driver.Manage().Window.Maximize();
                    var bestandsnaam_argument = Bestandsnaam;

                    GeneralFunctionality.Functions.Teststap(
                        driver,
                        machinestatic,
                        RadioButton.ToString(),
                        "",
                        bestandsnaam_argument);

                    driver.Quit();

                    var lastTestRun = Convert.ToString(Convert.ToInt32(General.LastTestRun) - 1);

                    var EinDateTime = DateTime.Now;
                    var verstreken = (EinDateTime - BeginDateTime).ToString();
                    var passed1 = "0";
                    var failed1 = "0";

                    var query = "Select If(result = 3, 'OK', 'NOK') as Result, ";
                    query += "IFNULL(Count(*), 0) as Count FROM testresultsselenium WHERE testrun = " +
                             lastTestRun +
                             " GROUP BY result";

                    var dt = GenericDataRead.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        var teller = 0;
                        var sum1 = 0;

                        passed1 = dt.Rows[0][1].ToString();
                        if (dt.Rows.Count > 1) failed1 = dt.Rows[1][1].ToString();


                        // MessageBox.Show(credits.Url);
                        DataStorage.TestCases.AddTestResults(
                            applicatieNaam,
                            lastTestRun,
                            passed1.Replace(",", string.Empty),
                            failed1.Replace(",", string.Empty),
                            BeginDateTime,
                            EinDateTime,
                            verstreken,
                            RadioButton.ToString(),
                            "",
                            machinestatic,
                            credits.Url,
                            bestandsnaam_argument);
                        passedGer += Convert.ToInt32(passed1);
                        failedGer += Convert.ToInt32(failed1);
                    }
                }
            }

            DateTime totalEndDateTime = DateTime.Now;
            Melding(passedGer, failedGer, totalBeginDateTime, totalEndDateTime);
            MessageBox.Show("All the tests are DONE!", "Test Execution", MessageBoxButton.OK,
                MessageBoxImage.Information);
            GeneralFunctionality.Functions.TestUitgevoerd(true);
            Close();
        }

        private void ButtonExecute1_Click(object sender, RoutedEventArgs e)
        {
            uitvoer();
        }

        private void Melding(Int32 passed, Int32 failed, DateTime beDateTime, DateTime enDateTime)
        {
            var query = string.Empty;
            var script_id = "";
            if (ComboBoxLoadScripts.Text != String.Empty)
            {
                query = "SELECT * FROM testscripts WHERE ";
                query += "name ='" + ComboBoxLoadScripts.Text + "';";
                var dt = GenericDataRead.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    script_id = dt.Rows[0][0].ToString();
                }
            }

            if (ComboBoxLoadScripts.Text != string.Empty)
            {
                query = "INSERT INTO testscriptstotal ";
                query += "(script_id, script_name, passed, failed, begin_time, ";
                query += "end_time, duration) ";
                query += "VALUES (";
                query += script_id + ", '" + ComboBoxLoadScripts.Text + "', ";
                query += passed + ", " + failed + ", '" + beDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                query += "', '" + enDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                query += "', '" + Convert.ToString(enDateTime - beDateTime) + "');";
            }
            else
            {
                query = "INSERT INTO testscriptstotal ";
                query += "(passed, failed, begin_time, ";
                query += "end_time, duration) ";
                query += "VALUES (";
                query += passed + ", " + failed + ", '" + beDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                query += "', '" + enDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                query += "', '" + Convert.ToString(enDateTime - beDateTime) + "');";
            }

            GenericDataRead.INUPDEL(query);

            LabelDone.Content = String.Format("Begin Time: {0} - End Time: {1} --- Duration: {2:T}", beDateTime, enDateTime, enDateTime-beDateTime);
            LabelDone1.Content = String.Format("Test Steps Passed: {0} - Test Steps Failed: {1} --- Total Test Steps: {2}", passed, failed, passed + failed);  
        }

        private void ButtonCancelExecute_Click(object sender, RoutedEventArgs e)
        {
            GridBrowser.Visibility = Visibility.Hidden;
            StackPanelSave.Visibility = Visibility.Visible;
            StackPanelLoad.Visibility = Visibility.Visible;
            selectie.Visibility = Visibility.Visible;
        }

        private void ButtonExecute_Click(object sender, RoutedEventArgs e)
        {
            selectie.Visibility = Visibility.Hidden;
            GridBrowser.Visibility = Visibility.Visible;
            StackPanelSave.Visibility = Visibility.Hidden;
            StackPanelLoad.Visibility = Visibility.Hidden;
        }

        private void ComboBoxLoadScripts_DropDownClosed(object sender, EventArgs e)
        {
            TreeView2.Items.Clear();
            if (ComboBoxLoadScripts.SelectedIndex != -1){
                TestScriptsDetails = ScriptsDataFactory.GetScriptsDetails(ComboBoxLoadScripts.SelectedValue.ToString());
                if (TestScriptsDetails.Count > 0)
                {
                    foreach (var testScriptsDetail in TestScriptsDetails)
                    {
                        var item = new TreeViewItem();
                        item.Header = testScriptsDetail.bestandsnaam;

                        item.ItemsSource = new[]
                            {testScriptsDetail.bestandsnaam, testScriptsDetail.application, testScriptsDetail.url, testScriptsDetail.page};

                        TreeView2.Items.Add(item);
                        var dirs = Directory.GetFiles(GeneralFunctionality.Functions.GetCurrentDir(1), "*.xml");
                        var gevonden = 0;
                        foreach (var dir1 in dirs)
                        {

                            var bestandsnaam = GeneralFunctionality.Functions.SplitBestand(dir1);
                            if (bestandsnaam == testScriptsDetail.bestandsnaam)
                            {
                                gevonden = 1;
                            }
                        }
                        if (gevonden == 0)
                        {
                            CheckSettingsDir(
                                testScriptsDetail.bestandsnaam,
                                testScriptsDetail.application,
                                testScriptsDetail.url,
                                testScriptsDetail.page);
                            GetBestanden();
                        }
                    }

                    ButtonAllBack.IsEnabled = true;
                    ButtonOneBack.IsEnabled = true;
                    ButtonExecute.IsEnabled = true;

                    //ComboBoxLoadScripts.SelectedIndex = -1;
                }
            }
        }

        private void CheckSettingsDir(string bestandsnaamstr, string applicationstr, string urlstr, string pagestr)
        {
            var settingsXML = new XmlWriterSettings();
            settingsXML.Indent = true;
            settingsXML.OmitXmlDeclaration = true;
            settingsXML.IndentChars = "\t";

            using (XmlWriter writer =
                XmlWriter.Create(Functions.GetCurrentDir(1) + bestandsnaamstr + ".xml", settingsXML))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("settings");
                writer.WriteStartElement("start");
                writer.WriteElementString("url",urlstr);
                writer.WriteElementString("application", applicationstr);
                writer.WriteElementString("page", pagestr);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void TextBoxSaveAs_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxSaveAs.Text.Length > 0)
                ButtonSaveAs.IsEnabled = true;
            else
                ButtonSaveAs.IsEnabled = false;
        }

        private void ButtonSaveAs_Click(object sender, RoutedEventArgs e)
        {
            var id = "0";
            // Controleer of de naam reeds bestaat
            var query = "SELECT * FROM testscripts WHERE name='" + TextBoxSaveAs.Text + "';";
            var dt = GenericDataRead.GetData(query);
            if (dt.Rows.Count == 0)
            {   
                // Voeg toe aan testscripts
                query = "INSERT INTO testscripts (name) VALUES ('" + TextBoxSaveAs.Text + "'); ";
                General.ExecuteQueryCommand(query);

                // Haal laatste id op van testscripts
                query = "SELECT id FROM testscripts ORDER BY id DESC LIMIT 1;";
                var dt1 = GenericDataRead.GetData(query);
                id = "0";
                if (dt1.Rows.Count > 0) id = dt1.Rows[0][0].ToString();
            }
            else
            {
                id = dt.Rows[0][0].ToString();
                query = "DELETE FROM testscript_detail WHERE testscriptid = " + id;
                GenericDataRead.INUPDEL(query);
            }
            
            foreach (TreeViewItem node in TreeView2.Items)
            {
                var item = new TreeViewItem();
                item.Header = node.Header;
                item.ItemsSource = node.ItemsSource;

                // Voeg toe aan testscriptsdetails
                query = "INSERT INTO testscript_detail (testscriptid, bestandsnaam, url, application, page) VALUES ( ";
                query += id + ", ";
                query += "'" + node.Items[0] + "', ";
                query += "'" + node.Items[1] + "', ";
                query += "'" + node.Items[2] + "', ";
                query += "'" + node.Items[3] + "'";
                query += ");";
                GenericDataRead.INUPDEL(query);
            }

            TextBoxSaveAs.Text = string.Empty;
            ButtonSaveAs.IsEnabled = false;
            GetScripts();
        }
    }
}