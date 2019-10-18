﻿// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-19-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="UpdateCopyDataBulk.xaml.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WPFTestResults
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;

    using DataStorage;

    using GeneralFunctionality;

    using MySql.Data.MySqlClient;

    using MessageBox = System.Windows.MessageBox;

    /// <summary>
    /// TODO The update copy data bulk.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class UpdateCopyDataBulk : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCopyDataBulk"/> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public UpdateCopyDataBulk()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Buttons the copy click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonCopyClick
        private void ButtonCopyClick(object sender, RoutedEventArgs e)
        {
            if (this.LabelTestSource.Content.ToString().Trim().ToLower()
                == this.LabelTestDestination.Content.ToString().Trim().ToLower())
            {
                MessageBox.Show(
                    "Source file and Destination can not be the same TestCase!!!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                this.LabelTestSource.Content = string.Empty;
                this.LabelTestDestination.Content = string.Empty;
            }
            else
            {
                // Get last testnr from destination testcase
                move_window();
                var dataTable = General.GetLaatsteTestCase(this.TextBoxDestination.Text);

                var testNr = 1;
                if (dataTable.Rows.Count > 0)
                {
                    testNr = Convert.ToInt32(dataTable.Rows[0]["testnr"].ToString()) + 40;
                }

                var que = string.Empty;
                que += "SELECT ";
                que += "testnr, ";
                que += "`testcase`, ";
                que += "`testlogicalobjectname`, ";
                que += "`testelement`, ";
                que += "`testattribute`, ";
                que += "`testaction`, ";
                que += "`testtext`, ";
                que += "`testurl`, ";
                que += "`testswitch`, ";
                que += "`testdescription`, ";
                que += "`testexecution`, ";
                que += "`testext_check`, ";
                que += "`test_password`, ";
                que += " `test_comment` ";
                que += "FROM testcases_selenium ";
                que += "WHERE testname = '" + this.LabelTestSource.Content + "' ";
                que += "ORDER BY testnr;";
                var dataTableSource = General.ExecuteQueryCommandReturnTable(que);

                var ok = false;
                try
                {
                    using (new PleaseWait())
                    {
                        for (var i = 0; i < dataTableSource.Rows.Count; i++)
                        {
                            que = string.Empty;
                            que += "INSERT INTO `autotest`.`testcases_selenium` ";
                            que += "(`testname`, ";
                            que += "`testnr`, ";
                            que += "`testcase`, ";
                            que += "`testlogicalobjectname`, ";
                            que += "`testelement`, ";
                            que += "`testattribute`, ";
                            que += "`testaction`, ";
                            que += "`testtext`, ";
                            que += "`testurl`, ";
                            que += "`testswitch`, ";
                            que += "`testdescription`, ";
                            que += "`testexecution`, ";
                            que += "test_comment, ";
                            que += "test_password, ";
                            que += "`testext_check`) ";
                            que += "VALUES (";
                            que += "'" + this.LabelTestDestination.Content + "', '";
                            que += Convert.ToInt32(MySqlHelper.EscapeString(dataTableSource.Rows[i]["testnr"].ToString())) + testNr + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testcase"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testlogicalobjectname"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testelement"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testattribute"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testaction"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testtext"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testurl"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testswitch"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testdescription"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testexecution"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["test_comment"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["test_password"].ToString()) + "', ";
                            que += "'" + MySqlHelper.EscapeString(dataTableSource.Rows[i]["testext_check"].ToString()) + "');";

                            General.LogMessageDatabase(que, 1);
                            General.ExecuteQueryCommand(que);
                        }
                    }

                    ok = true;
                }
                catch (Exception ex)
                {
                    General.LogMessageDatabase(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source, 4);
                    MessageBox.Show(
                        "Selected TestSteps are NOT copied to the selected TestCase!!!",
                        "Message",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

                if (ok)
                {
                    MessageBox.Show(
                        "Selected TestSteps are copied to the selected TestCase!!!",
                        "Message",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    this.LabelTestSource.Content = string.Empty;
                    this.LabelTestDestination.Content = string.Empty;
                    this.TextBoxDestination.Text = string.Empty;
                    this.TextBoxSource.Text = string.Empty;
                    this.ButtonCopy.IsEnabled = false;
                }
            }
        }

        private void move_window()
        {
            this.Top += 250;
        }

        /// <summary>
        /// Buttons the database connection cancel click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonDatabaseConnectionCancelClick
        private void ButtonDatabaseConnectionCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Buttons the get test set click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonGetTestSetClick
        private void ButtonGetTestSetClick(object sender, RoutedEventArgs e)
        {
            VersionClass.OpenBestand();
            var bestandsnaam = VersionClass.Bestandsnaam;
            this.LabelTestSource.Content = bestandsnaam;
            this.TextBoxSource.Text = bestandsnaam;
        }

        /// <summary>
        /// Buttons the set test set click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonSetTestSetClick
        private void ButtonSetTestSetClick(object sender, RoutedEventArgs e)
        {
            VersionClass.OpenBestand();
            var bestandsnaam = VersionClass.Bestandsnaam;
            this.LabelTestDestination.Content = bestandsnaam;
            this.TextBoxDestination.Text = bestandsnaam;
        }

        /// <summary>
        /// Checks the inhoud source destination.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CheckInhoudSourceDestination
        private void CheckInhoudSourceDestination()
        {
            if (this.TextBoxSource.Text.Length > 0 && this.TextBoxDestination.Text.Length > 0)
                this.ButtonCopy.IsEnabled = true;
            else this.ButtonCopy.IsEnabled = false;
        }

        /// <summary>
        /// Texts the box destination text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TextBoxDestinationTextChanged
        private void TextBoxDestinationTextChanged(object sender, TextChangedEventArgs e)
        {
            this.CheckInhoudSourceDestination();
        }

        /// <summary>
        /// Texts the box source text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TextBoxSourceTextChanged
        private void TextBoxSourceTextChanged(object sender, TextChangedEventArgs e)
        {
            this.CheckInhoudSourceDestination();
        }
    }
}