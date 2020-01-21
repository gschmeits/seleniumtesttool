﻿// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-13-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="VersionClass.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace WPFTestResults
{
    using System;
    using System.Deployment.Application;
    using System.Reflection;
    using System.Windows.Forms;

    using DataStorage;

    using GeneralFunctionality;

    /// <summary>
    /// Class VersionClass.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for VersionClass
    public static class VersionClass
    {
        /// <summary>
        /// Gets or sets the bestand.
        /// </summary>
        /// <value>The bestand.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Bestand
        public static string Bestand { get; set; }

        /// <summary>
        /// Gets or sets the bestandsnaam.
        /// </summary>
        /// <value>The bestandsnaam.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Bestandsnaam
        public static string Bestandsnaam { get; set; }

        /// <summary>
        /// Gets the running version.
        /// </summary>
        /// <returns>Version.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetRunningVersion
        public static Version GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// Opens the bestand.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for OpenBestand
        public static void OpenBestand()
        {
            Bestand = string.Empty;
            Bestandsnaam = string.Empty;

            var openFileDialog = new OpenFileDialog
                                     {
                                         InitialDirectory = Functions.GetCurrentDir(1),
                                         Filter = Properties.Resources
                                             .UpdateDataBulk_OpenBestand_XML_files___xml____xml_All_files_________,
                                         FilterIndex = 2,
                                         RestoreDirectory = true
                                     };

            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            try
            {
                Bestand = openFileDialog.FileName;
                Bestandsnaam = Functions.SplitBestand(Bestand);
            }
            catch (Exception ex)
            {
                General.LogMessageDatabase(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source, 4);
            }
        }
    }
}
