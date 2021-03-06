﻿// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-19-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="DeleteBulkData.xaml.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WPFTestResults
{
    using System;
    using System.Windows;
    using System.Windows.Forms;

    using DataStorage;

    using LicentieWPF.LicenseKey;

    using KeyEventArgs = System.Windows.Input.KeyEventArgs;
    using MessageBox = System.Windows.Forms.MessageBox;

    /// <summary>
    ///     Class DeleteBulkData.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for DeleteBulkData
    public partial class DeleteBulkData : Window
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteBulkData" /> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public DeleteBulkData()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Handles the Click event of the ButtonDatabaseConnectionCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonDatabaseConnectionCancel_Click
        private void ButtonDatabaseConnectionCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///     Buttons the delete click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonDeleteClick
        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            var deleteString = "DELETE FROM testcases_selenium WHERE testname = '" + this.LabelTestSET.Content
                                                                                   + "' AND " + this.TextBoxDeletion
                                                                                       .Text;

            General.LogMessageDatabase(
                "Query for deletion: '" + deleteString + "'.",
                3,
                string.Empty,
                0,
                string.Empty,
                InloggerData.MachineCode);

            var ok = false;
            try
            {
                General.ExecuteQueryCommand(deleteString);
                ok = true;
            }
            catch (Exception ex)
            {
                General.LogMessageDatabase(
                    ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source,
                    4,
                    string.Empty,
                    0,
                    string.Empty,
                    InloggerData.MachineCode);
                MessageBox.Show(
                    "Selected TestSteps are NOT deleted from the database!!!",
                    "Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (ok)
            {
                MessageBox.Show(
                    "Selected TestSteps are deleted from the database!!!",
                    "Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                General.LogMessageDatabase(
                    "Selected TestSteps are deleted from the database",
                    3,
                    string.Empty,
                    0,
                    string.Empty,
                    InloggerData.MachineCode);
                this.Close();
            }
            else
            {
                this.TextBoxDeletion.Text = string.Empty;
                this.ButtonDelete.IsEnabled = false;
            }
        }

        /// <summary>
        ///     Handles the Click event of the ButtonGetTestSet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ButtonGetTestSet_Click
        private void ButtonGetTestSet_Click(object sender, RoutedEventArgs e)
        {
            VersionClass.OpenBestand();
            var bestandsnaam = VersionClass.Bestandsnaam;
            this.LabelTestSET.Content = bestandsnaam;

            General.LogMessageDatabase(
                "Selected TestCase: '" + bestandsnaam + "'.",
                3,
                string.Empty,
                0,
                string.Empty,
                InloggerData.MachineCode);

            if (this.LabelTestSET.Content.ToString().Length > 0) this.TextBoxDeletion.IsEnabled = true;
        }

        /// <summary>
        ///     Handles the KeyDown event of the TextBoxDeletion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TextBoxDeletion_KeyDown
        private void TextBoxDeletion_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.TextBoxDeletion.Text.Length > 0) this.ButtonDelete.IsEnabled = true;
            else this.ButtonDelete.IsEnabled = false;
        }
    }
}