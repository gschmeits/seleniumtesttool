﻿// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-09-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="SettingsTextScript.xaml.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WPFTestResults
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Xml;

    using DataStorage;

    using GeneralFunctionality;

    using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

    /// <summary>
    /// Interaction logic for SettingsTextScript.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class SettingsTextScript : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTextScript" /> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public SettingsTextScript()
        {
            InitializeComponent();
            this.ButtonSaveTestSet.IsEnabled = false;
        }

        /// <summary>
        /// Handles the Click event of the ButtonGetTestSet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonGetTestSet_Click
        private void ButtonGetTestSet_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Functions.GetCurrentDir(1);
            openFileDialog.Filter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var bestand = openFileDialog.FileName;
                    var bestandsnaam = Functions.SplitBestand(bestand);
                    var credits = Functions.GetCredentials(bestandsnaam);
                    this.TextBoxTestSetName.Text = bestandsnaam;
                    this.TextBoxURL.Text = credits.Url;
                    this.TextBoxApplication.Text = credits.Application;
                    this.TextBoxPage.Text = credits.Page;
                    this.TextBoxTestSetName.IsEnabled = false;
                    this.TextBoxURL.Focusable = true;
                    this.TextBoxURL.Focus();

                    this.ButtonSaveTestSet.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    General.LogMessageDatabase(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source, 4);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonCreateTestSet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonCreateTestSet_Click
        private void ButtonCreateTestSet_Click(object sender, RoutedEventArgs e)
        {
            this.EmptyFields();
        }

        /// <summary>
        /// Handles the Click event of the ButtonSaveTestSet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonSaveTestSet_Click
        private void ButtonSaveTestSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var settingsXML = new XmlWriterSettings();
                settingsXML.Indent = true;
                settingsXML.OmitXmlDeclaration = true;
                settingsXML.IndentChars = "\t";

                using (XmlWriter writer =
                    XmlWriter.Create(Functions.GetCurrentDir(1) + this.TextBoxTestSetName.Text + ".xml", settingsXML))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("settings");
                    writer.WriteStartElement("start");
                    writer.WriteElementString("url", this.TextBoxURL.Text);
                    writer.WriteElementString("application", this.TextBoxApplication.Text);
                    writer.WriteElementString("page", this.TextBoxPage.Text);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                MessageBox.Show(
                    "TestSet settings are saved!!!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                EmptyFields();
            }
            catch (Exception exception)
            {
                General.LogMessageDatabase(exception.Message + "\r\n" + exception.Source + "\r\n" + exception.StackTrace, 4);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the TextBoxTestSetName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TextBoxTestSetName_KeyDown
        private void TextBoxTestSetName_KeyDown(object sender, KeyEventArgs e)
        {
            CheckTextBoxes();
        }
        /// <summary>
        /// Handles the KeyDown event of the TextBoxURL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TextBoxURL_KeyDown
        private void TextBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            CheckTextBoxes();
        }

        /// <summary>
        /// Handles the KeyDown event of the TextBoxApplication control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TextBoxApplication_KeyDown
        private void TextBoxApplication_KeyDown(object sender, KeyEventArgs e)
        {
            CheckTextBoxes();
        }

        /// <summary>
        /// Checks the text boxes.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CheckTextBoxes
        private void CheckTextBoxes()
        {
            if (this.TextBoxTestSetName.Text != string.Empty && this.TextBoxURL.Text != string.Empty
                                                             && this.TextBoxApplication.Text != string.Empty
                                                             && this.TextBoxPage.Text != string.Empty)
            {
                this.ButtonSaveTestSet.IsEnabled = true;
            }
            else
            {
                this.ButtonSaveTestSet.IsEnabled = false;
            }
        }

        /// <summary>
        /// Empties the fields.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for EmptyFields
        private void EmptyFields()
        {
            this.TextBoxTestSetName.Text = string.Empty;
            this.TextBoxURL.Text = string.Empty;
            this.TextBoxApplication.Text = string.Empty;
            this.TextBoxPage.Text = string.Empty;
            this.ButtonSaveTestSet.IsEnabled = false;
            this.TextBoxTestSetName.IsEnabled = true;
            this.TextBoxTestSetName.Focusable = true;
            this.TextBoxTestSetName.Focus();
            this.ButtonCreateTestSet.IsEnabled = false;
        }
    }
}