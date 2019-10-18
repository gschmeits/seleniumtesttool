﻿// ***********************************************************************
// Assembly         : SeleniumTestTool
// Author           : G.H.M.H. Schmeits
// Created          : 07-21-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 08-19-2018
// ***********************************************************************
// <copyright file="Login.xaml.cs" company="SCHMEITS SOFTWARE">
//     Copyright © G.H.M.H. Schmeits  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace WPFTestResults
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using BlogsPrajeesh.BlogSpot.WPFControls;

    using DataStorage;

    using GeneralFunctionality;

    using LicentieWPF;
    using LicentieWPF.LicenseKey;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    //using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Support.UI;

    using Application = System.Windows.Application;
    using KeyEventArgs = System.Windows.Input.KeyEventArgs;
    using MessageBox = System.Windows.MessageBox;

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class Login : Window
    {
        /// <summary>
        /// The int teller
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for intTeller
        public int intTeller;


        private static string machinestatic { get; set; }
        /// <summary>
        /// The string gebruiker
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for strGebruiker
        public string strGebruiker = string.Empty;

        /// <summary>
        /// The string loginnaam
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for strLoginnaam
        public string strLoginnaam = string.Empty;

        /// <summary>
        /// Gets or sets the bestandsnaam argument.
        /// </summary>
        /// <value>The bestandsnaam argument.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for bestandsnaam_argument
        private static string bestandsnaam_argument { get; set; }

        /// <summary>
        /// The driver
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for driver
        private static IWebDriver driver;
        /// <summary>
        /// Gets or sets the browser number.
        /// </summary>
        /// <value>The browser number.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for browser_number
        private static int browser_number { get; set; }
        /// <summary>
        /// Gets or sets the begin datum.
        /// </summary>
        /// <value>The begin datum.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for beginDatum
        public DateTime beginDatum { get; set; }
        /// <summary>
        /// Gets or sets the eind datum.
        /// </summary>
        /// <value>The eind datum.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for eindDatum
        public DateTime eindDatum { get; set; }

        /// <summary>
        /// Gets or sets the machine string.
        /// </summary>
        /// <value>The machine string.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for machineString
        private string machineString { get; set; }

        /// <summary>
        /// Gets or sets the begin date time.
        /// </summary>
        /// <value>The begin date time.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for BeginDateTime
        private DateTime BeginDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ein date time.
        /// </summary>
        /// <value>The ein date time.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for EinDateTime
        private DateTime EinDateTime { get; set; }

        /// <summary>
        /// The gevonden medewerker
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for gevondenMedewerker
        private LoginViewModel gevondenMedewerker = new LoginViewModel();

        /// <summary>
        /// Gets or sets the results count.
        /// </summary>
        /// <value>The results count.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ResultsCount
        private static List<TestResultsFactory.ResultsCount> ResultsCount { get; set; }

        /// <summary>
        /// Gets or sets the test results.
        /// </summary>
        /// <value>The test results.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestResults
        private static List<TestResultsFactory.TestResults> TestResults { get; set; }
        /// <summary>
        /// Gets or sets the testresults fact.
        /// </summary>
        /// <value>The testresults fact.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestresultsFact
        private static List<TestResultsFactory.TestResultsSelect> TestresultsFact { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Login" /> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public Login()
        {
            this.InitializeComponent();
            Functions.InitializeDatabaseConnection(true);
            var returnwaarde = Functions.InitalizeSerialKey();

            if (returnwaarde != 2)
            {
                LicenceKey lk = new LicenceKey();
                lk.Show();
                this.Close();
            }
            else
            {
                CheckKey();
                var argumenten = Environment.GetCommandLineArgs();

                if (argumenten.Length > 2)
                {
                    Argumenten4();
                }
                else
                {
                    OverallSettings.ShowData();
                    this.txtGebruikersnaam.Text = this.strLoginnaam;
                }
            }
        }

        /// <summary>
        /// Checks the file argument.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CheckFileArgument
        private bool CheckFileArgument()
        {
            var return_value = false;
            var argumenten = Environment.GetCommandLineArgs();
            var filePath = Functions.GetCurrentDir(1);
            string[] fileArray = Directory.GetFiles(filePath);

            foreach (var filename in fileArray)
            {
                if (filename.ToUpper() == filePath.ToUpper() + argumenten[2].ToUpper() + ".XML")
                {
                    return_value = true;
                    bestandsnaam_argument = argumenten[2];
                    break;
                }
            }

            return return_value;
        }

        /// <summary>
        /// Checks the browser argument.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CheckBrowserArgument
        private bool CheckBrowserArgument()
        {
            var argumenten = Environment.GetCommandLineArgs();
            var browsers = DataStorage.TestResults.GetTestResultsBrowsers();
            var return_value = false;
            foreach (var browser in browsers)
            {
                if (browser.browser_name.ToUpper() == argumenten[1].ToUpper())
                {
                    return_value = true;
                    browser_number = Convert.ToInt16(browser.id.ToString());
                    break;
                }
            }

            return return_value;
        }
        /// <summary>
        /// Checks the login.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CheckLogin
        private bool CheckLogin()
        {
            var return_value = true;
            return return_value;
        }


        /// <summary>
        /// Argumenten4s this instance.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Argumenten4
        private void Argumenten4()
        {
            var argumenten = Environment.GetCommandLineArgs();

            if (argumenten.Length > 2)
            {
                if (this.CheckBrowserArgument() == false)
                {
                    MessageBox.Show("Browser not found!!! Please fill in a correct browser.", "Error", MessageBoxButton.OK);
                }
                if (this.CheckFileArgument() == false)
                {
                    MessageBox.Show("File not found!!! Please fill in the correct filename, without the .xml extension.", "Error", MessageBoxButton.OK);
                }

                if (CheckLogin() == false)
                {
                    MessageBox.Show("Username and/or password not correct!!! Please use the correct username and password.", "Error", MessageBoxButton.OK);
                }

                if (this.CheckBrowserArgument() == false || this.CheckFileArgument() == false || this.CheckLogin() == false)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    Functions.GetCurrentDir(0);
                    Functions.setTestrunID(General.LastTestRun);
                    Functions.setClassName(this.GetType().Name);
                    var credits = Functions.GetCredentials(bestandsnaam_argument);
                    Functions.setApplicationName(credits.Application);

                    Functions.CheckScreenshotDir("TestReports");
                    Functions.CheckScreenshotDir();
                    this.CommandUitvoer();
                    Application.Current.Shutdown();
                }
            }
        }

        /// <summary>
        /// Commands the uitvoer.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CommandUitvoer
        private void CommandUitvoer()
        {
            var credits = Functions.GetCredentials(bestandsnaam_argument);
            OverallSettings.ShowData();
            var applicatieNaam = credits.Application;
            try
            {
                var chromePath = Functions.GetCurrentDir(0);
                this.BeginDateTime = DateTime.Now;
                InloggerData.MachineCode = Convert.ToString(LicentieMachineCode.getMachineCode());
                machinestatic = InloggerData.MachineCode;

                switch (browser_number)
                {
                    case 1:
                        driver = new ChromeDriver(chromePath) { Url = credits.Url };
                        break;
                    case 2:
                        driver = new FirefoxDriver();
                        driver.Url = credits.Url;
                        break;
                    case 3:
                        var options = new InternetExplorerOptions();
                        options.RequireWindowFocus = true;
                        options.EnableNativeEvents = false;
                        options.InitialBrowserUrl = credits.Url;
                        //options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
                        options.IgnoreZoomLevel = true;
                        options.EnablePersistentHover = true;
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        driver = new InternetExplorerDriver(chromePath, options);
                        break;
                    case 4:
                        //driver = new PhantomJSDriver();
                        //driver.Navigate().GoToUrl(credits.Url);
                        break;
                    case 5:
                        try
                        {
                            driver = new EdgeDriver(chromePath);
                            driver.Navigate().GoToUrl(credits.Url);
                        }
                        catch (Exception ex)
                        {
                            General.LogMessageDatabase(ex.Message + "\r\n" + ex.StackTrace, 4, string.Empty, 0, string.Empty, InloggerData.MachineCode);
                        }

                        break;
                }

                driver.Manage().Window.Maximize();
                Functions.Teststap(driver, machinestatic, browser_number.ToString(),"", bestandsnaam_argument);
            }
            catch (Exception ex)
            {
                General.LogMessageDatabase(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source, 4, string.Empty, 0, string.Empty, InloggerData.MachineCode);
            }
            finally
            {
                try
                {
                    driver.Quit();
                    var testresultsCount = TestResultsFactory.GetTestResultSelects();
                    var indexT = testresultsCount.Count;
                    
                    var ttt = testresultsCount[indexT-1].ToString().Split(' ');
                    this.EinDateTime = DateTime.Now;
                    var TextBlockDateTime = (this.EinDateTime - this.BeginDateTime).ToString();
                    var Version = string.Empty;
                    TestResults = TestResultsFactory.GeTestResults(indexT.ToString(), indexT.ToString());
                    ResultsCount = TestResultsFactory.GetCount(indexT.ToString(), indexT.ToString());

                    var Passed = string.Empty;
                    var Failed = string.Empty;
                    var Total = string.Empty;
                    var teller = 0;
                    var sum1 = 0;
                    foreach (var testresult in ResultsCount)
                    {
                        var aantal = Convert.ToInt32(testresult.value1.ToString());

                        if (teller == 0)
                        {
                            Passed = string.Format("{0:N0}", aantal);
                            sum1 += aantal;
                        }

                        if (teller == 1)
                        {
                            Failed = string.Format("{0:N0}", aantal);
                            sum1 += aantal;
                        }

                        teller++;
                        Total = string.Format("{0:N0}", sum1);
                    }

                    var gegevens =
                        DataStorage.TestResults.GetResultTestRun(ttt[0]);
                    if (gegevens.Count > 0)
                    {
                        Passed = string.Format("{0:N0}", Convert.ToInt32(gegevens[0].testrun_passed));
                        Failed = string.Format("{0:N0}", Convert.ToInt32(gegevens[0].testrun_failed));
                        Total = string.Format(
                            "{0:N0}",
                            Convert.ToInt32(gegevens[0].testrun_passed) + Convert.ToInt32(gegevens[0].testrun_failed));
                        TextBlockDateTime = string.Format("{0:T}", gegevens[0].testrun_time);
                    }

                    if (ResultsCount.Count == 1) Failed = string.Format("{0:N0}", 0);

                    DataStorage.TestCases.AddTestResults(
                        applicatieNaam,
                        indexT.ToString(),
                        Passed.Replace(",", string.Empty),
                        Failed.Replace(",", string.Empty),
                        this.BeginDateTime,
                        this.EinDateTime,
                        TextBlockDateTime,
                        browser_number.ToString(),
                        string.Empty,
                        InloggerData.MachineCode,
                        credits.Url,
                        bestandsnaam_argument

);

                    Functions.CreateHTML(indexT.ToString());
                }
                catch (Exception ex)
                {
                    General.LogMessageDatabase(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source, 4, string.Empty, 0, string.Empty, InloggerData.MachineCode);
                    MessageBox.Show(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source);
                }
            }
        }

        /// <summary>
        /// Checks the key.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CheckKey
        private void CheckKey()
        {
            var keyString = string.Empty;

            keyString = General._serialKeyXML.Key1;
            keyString += General._serialKeyXML.Key2;
            keyString += General._serialKeyXML.Key3;
            keyString += General._serialKeyXML.Key4;
            keyString += General._serialKeyXML.Key5;
            keyString += General._serialKeyXML.Key6;

            string machineNumber = Convert.ToString(LicentieMachineCode.getMachineCode());

            var IDString = "FullVersion";
            var result = this.ValidateSerialKey(keyString + IDString);

            var datumTijd = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            if (machineString != machineNumber && result != -1)
            {
                WPFMessageBox.Show(
                    "Error message",
                    "You have the wrong machine number configured",
                    "You have the wrong machine number!!!\r\nYour machine number is: '" + machineNumber + "'.\r\nYour configured machine number is: '" + machineString + "'.\r\n\r\nPlease change to settings to the correct machine number: '" + machineNumber + "'.",
                    WPFMessageBoxButtons.OK, WPFMessageBoxImage.Error);
                this.Close();
            }

            if (datumTijd < beginDatum && result != -1)
            {
                WPFMessageBox.Show(
                    "Error message",
                    "date too early!!!",
                    WPFMessageBoxButtons.OK, WPFMessageBoxImage.Error);
                this.Close();
            }

            if (datumTijd > eindDatum && result != -1)
            {
                WPFMessageBox.Show(
                    "Error message",
                    "Expired date!!!\r\nCurrent date: " + datumTijd + ", End date: " + eindDatum ,
                    WPFMessageBoxButtons.OK, WPFMessageBoxImage.Error);
                this.Close();
            }

            if (result != 0)
            {
                var frmLicentieControle = new LicentieControle();
                frmLicentieControle.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Validates the serial key.
        /// </summary>
        /// <param name="Serial">The serial.</param>
        /// <returns>System.Int32.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ValidateSerialKey
        public int ValidateSerialKey(string Serial)
        {
            var str = string.Empty;
            var str2 = string.Empty;
            var HashTransformation = true;
            try
            {
                // reading from table "Serials" and from field "SerialKey".
                if (HashTransformation)
                    str = "SELECT * FROM serials WHERE SerialKey ='" + this.SHA512String(Serial) + "'";
                else
                    str = "SELECT * FROM Serials WHERE SerialKey ='" + Serial + "'";
                var dt = GenericDataRead.GetData(str);
                if (dt.Rows.Count > 0)
                {
                    str2 = dt.Rows[0][1].ToString();
                    this.beginDatum = Convert.ToDateTime(dt.Rows[0][3].ToString());
                    this.eindDatum = Convert.ToDateTime(dt.Rows[0][4].ToString());
                    this.machineString = dt.Rows[0][5].ToString();
                }

                if (string.IsNullOrEmpty(str2))
                    return -1; // serial key not found
                return 0; // serial key found!
            }
            catch (Exception ex)
            {
                return -2; //file error
            }
        }

        /// <summary>
        /// Bijwerkens the ingelogd.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for BijwerkenIngelogd
        private bool BijwerkenIngelogd()
        {
            var bW = false;

            var gevonden = LoginUsers.GetSelectedUser(this.txtGebruikersnaam.Text.ToUpper());
            if (gevonden[0].Ingelogd.ToString() == "False")
            {
                LoginUsers.SetIngelogd(this.txtGebruikersnaam.Text, true, false);
                bW = true;
            }
            else
            {
                var sTekst = "Gebruiker is reeds ingelogd!!!\r\nLogin met andere gebruiker.\r\n";
                sTekst += "Wilt u alsnog opnieuw inloggen?";
                var sCaption = "Reeds ingelogd";
                WPFMessageBoxResult result;
                result = WPFMessageBoxResult.No;
                result = WPFMessageBox.Show(
                    sCaption,
                    sTekst,
                    "Houdt er rekening mee dat het verstandig is om maar op 1 plek tegelijkertijd ingelogd te zijn!!!",
                    WPFMessageBoxButtons.YesNo,
                    WPFMessageBoxImage.Question);
                if (result == WPFMessageBoxResult.Yes)
                {
                    LoginUsers.SetIngelogd(this.txtGebruikersnaam.Text, true, false);
                    bW = true;
                }
                else
                {
                    this.txtGebruikersnaam.Text = string.Empty;
                    this.txtWachtwoord.Password = string.Empty;
                    this.txtGebruikersnaam.Focus();
                    LoginUsers.SetIngelogd(this.txtGebruikersnaam.Text, true, false);

                    bW = false;
                }
            }

            return bW;
        }

        /// <summary>
        /// Handles the Click event of the btnAanmelden control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for btnAanmelden_Click
        private void btnAanmelden_Click(object sender, RoutedEventArgs e)
        {
            this.btnAanmelden.Resources["DynamicBG"] = new SolidColorBrush(Colors.LightSteelBlue);
            this.SubAanmelden();
        }

        /// <summary>
        /// Handles the Click event of the btnWachtwoord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for btnWachtwoord_Click
        private void btnWachtwoord_Click(object sender, RoutedEventArgs e)
        {
            var wachtWachtwoordWijzigen = new WachtwoordWijzigen();
            wachtWachtwoordWijzigen.Show();
            this.Close();
        }

        /// <summary>
        /// Shes the a512 string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SHA512String
        private string SHA512String(string input)
        {
            var data = Encoding.ASCII.GetBytes(input);
            var shaM = new SHA512Managed();
            var result = shaM.ComputeHash(data);
            var output = string.Empty;

            foreach (var b in result)
                output += b.ToString("x2");
            return output;
        }

        /// <summary>
        /// Handles the Click event of the Sluiten control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Sluiten_Click
        private void Sluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Subs the aanmelden.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SubAanmelden
        private void SubAanmelden()
        {
            General.LogMessageDatabase("Subaanmelden gestart", 1, string.Empty, 0, string.Empty, InloggerData.MachineCode);
            var caption = "SeleniumTestTool";
            var message = string.Empty;

            if (this.strGebruiker != this.txtGebruikersnaam.Text) this.intTeller = 0;

            if (this.intTeller == 2)
            {
                message =
                    "You tried 3 times to login.\r\nYou didn't use the correct username and/of password.\r\nYou account is blokked!!!";
                WPFMessageBoxResult result;

                result = WPFMessageBox.Show(
                    caption,
                    message,
                    "There are 2 options:\r1. The username is wrong\r2. The password is wrong.",
                    WPFMessageBoxButtons.OK,
                    WPFMessageBoxImage.Alert);
                return;
            }

            var resultZoek = this.ZoekMedewerker(this.txtGebruikersnaam.Text, this.txtWachtwoord.Password);

            if(resultZoek == 0)
            {
                General.LogMessageDatabase("Na inloggen is gebruiker niet gevonden", 1, string.Empty, 0, string.Empty, InloggerData.MachineCode);
                message = "Gebruiker en/of wachtwoord zijn niet gevonden of niet correct!!!\r\nNogmaals proberen?";
                WPFMessageBoxResult result;
                result = WPFMessageBoxResult.Yes;
                result = WPFMessageBox.Show(caption, message, WPFMessageBoxButtons.YesNo, WPFMessageBoxImage.Alert);
                if (result == WPFMessageBoxResult.Yes)
                {
                    this.btnAanmelden.Resources["DynamicBG"] = new SolidColorBrush(Colors.LightSteelBlue);
                    this.txtWachtwoord.Password = string.Empty;
                    this.intTeller++;
                    this.txtGebruikersnaam.Focus();
                    return;
                }

                if (result == WPFMessageBoxResult.No)
                {
                    LoginUsers.SetIngelogd(this.txtGebruikersnaam.Text, false, false);
                    this.Close();
                }
            }

            if (resultZoek == 1)
            {
                var gevonden = LoginUsers.GetSelectedUser(this.txtGebruikersnaam.Text.ToUpper());

                if (gevonden.Count > 0)
                {
                    InloggerData.MedewerkersCode = gevonden[0].MedewerkerCode;
                    InloggerData.MedewerkersNaam = gevonden[0].MedewerkerNaam;
                    InloggerData.Wachtwoord = gevonden[0].Wachtwoord;
                    InloggerData.Ingelogd = gevonden[0].Ingelogd;
                    InloggerData.Rol = gevonden[0].Rol;
                    InloggerData.Actief = gevonden[0].Actief;
                    InloggerData.Geblokkeerd = gevonden[0].Geblokkeerd;
                    InloggerData.MachineCode = Convert.ToString(LicentieMachineCode.getMachineCode());

                    if (this.BijwerkenIngelogd())
                    {
                        var frmMainWindow = new MainWindow();
                        frmMainWindow.Show();
                    }

                    this.Close();
                }

                if (gevonden.Count == 0)
                {
                    WPFMessageBox.Show("Login", "Access Denied", WPFMessageBoxButtons.OK, WPFMessageBoxImage.Alert);
                    General.LogMessageDatabase("login access denied", 4, string.Empty, 0, string.Empty, InloggerData.MachineCode);
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the txtWachtwoord control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for txtWachtwoord_KeyDown
        private void txtWachtwoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.btnAanmelden.Resources["DynamicBG"] = new SolidColorBrush(Colors.LightSteelBlue);
                this.SubAanmelden();
            }
        }

        /// <summary>
        /// Handles the Activated event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Window_Activated
        private void Window_Activated(object sender, EventArgs e)
        {
            if (this.txtGebruikersnaam.Text.Length == 0)
            {
                this.txtGebruikersnaam.Focusable = true;
                this.txtGebruikersnaam.Focus();
            }

            if (this.txtGebruikersnaam.Text.Length != 0)
            {
                this.txtWachtwoord.Focusable = true;
                this.txtWachtwoord.Focus();
            }
        }

        /// <summary>
        /// Zoeks the medewerker.
        /// </summary>
        /// <param name="parMedewerkersCode">The par medewerkers code.</param>
        /// <param name="parMedewerkersPassword">The par medewerkers password.</param>
        /// <returns>System.Int32.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ZoekMedewerker
        private int ZoekMedewerker(string parMedewerkersCode, string parMedewerkersPassword)
        {
            var result = 1;
            var gevonden = LoginUsers.GetAantalGebruikers(parMedewerkersCode, parMedewerkersPassword);
            if (gevonden == 0)
            {
                result = 4;
                General.LogMessageDatabase("Gezochte medewerker = '" + parMedewerkersCode + "' is NIET gevonden.", result, string.Empty, 0, string.Empty, InloggerData.MachineCode);
            }
            else
            {
                General.LogMessageDatabase("Gezochte medewerker = '" + parMedewerkersCode + "' is gevonden.", result, string.Empty, 0, string.Empty, InloggerData.MachineCode);
            }

            return gevonden;
        }
    }
}