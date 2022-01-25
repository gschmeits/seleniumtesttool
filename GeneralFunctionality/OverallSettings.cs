﻿// ***********************************************************************
// Assembly         : GeneralFunctionality
// Author           : G.H.M.H. Schmeits
// Created          : 03-08-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="OverallSettings.cs" company="SCHMEITS SOFTWARE">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataStorage;

namespace GeneralFunctionality
{
    /// <summary>
    /// Class OverallSettings.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for OverallSettings
    public static class OverallSettings
    {
        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for applicationName
        public static string applicationName { get; set; }
        /// <summary>
        /// Gets or sets the settings data dir.
        /// </summary>
        /// <value>The settings data dir.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SettingsDataDir
        public static string SettingsDataDir { get; set; }

        public static string SettingswdioDir { get; set; }

        public static string SettingCypressioDir { get; set; }

        /// <summary>
        /// Gets or sets the settings settings dir.
        /// </summary>
        /// <value>The settings settings dir.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SettingsSettingsDir
        public static string SettingsSettingsDir { get; set; }

        // View
        /// <summary>
        /// Gets or sets the color of the show border.
        /// </summary>
        /// <value>The color of the show border.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ShowBorderColor
        public static string ShowBorderColor { get; set; }

        /// <summary>
        /// Gets or sets the width of the show border.
        /// </summary>
        /// <value>The width of the show border.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ShowBorderWidth
        public static int ShowBorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the duration of the show.
        /// </summary>
        /// <value>The duration of the show.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ShowDuration
        public static int ShowDuration { get; set; }

        /// <summary>
        /// Gets or sets the show error display.
        /// </summary>
        /// <value>The show error display.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ShowErrorDisplay
        public static int ShowErrorDisplay { get; set; }

        /// <summary>
        /// Gets or sets the show extra checks.
        /// </summary>
        /// <value>The show extra checks.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ShowExtraChecks
        public static int ShowExtraChecks { get; set; }

        /// <summary>
        /// Gets or sets the machinestatic.
        /// </summary>
        /// <value>The machinestatic.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for machinestatic
        private static string machinestatic { get; set; }

        /// <summary>
        /// Initializes static members of the <see cref="OverallSettings" /> class.
        /// </summary>
        public static void ShowData()
        {
            machinestatic = InloggerData.MachineCode;

            var xelement = XElement.Load(Functions.GetCurrentDir(0) + "config.xml");

            try
            {
                var testsElements = xelement.Elements();
                foreach (var testElement in testsElements)
                {
                    ShowBorderColor = testElement.Element("bordercolor").Value;
                    ShowBorderWidth = Convert.ToInt16(testElement.Element("borderwidth").Value);
                    ShowDuration = Convert.ToInt16(testElement.Element("duration").Value);
                    ShowExtraChecks = Convert.ToInt16(testElement.Element("checks").Value);
                    ShowErrorDisplay = Convert.ToInt16(testElement.Element("errors").Value);
                }
            }
            catch (Exception ex)
            {
                General.LogMessage(ex.Message + "\r\n" + ex.StackTrace, 4, string.Empty, 0, string.Empty,
                    machinestatic);
            }
        }

        /// <summary>
        /// Shows the data settings.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ShowDataSettings
        public static void ShowDataSettings()
        {
            var ValueList = new List<string>();

            try
            {
                var xelement = XElement.Load("settings.xml");
                var elementVars = xelement.Elements();
                foreach (var elementVar in elementVars)
                    ValueList.Add(elementVar.Value);
                SettingsSettingsDir = ValueList[0];
                SettingsDataDir = ValueList[1];
                SettingswdioDir = ValueList[2];
                SettingCypressioDir = ValueList[3];
            }
            catch (Exception ex)
            {
                General.LogMessage(ex.Message + "\r\n" + ex.StackTrace, 4, string.Empty, 0, string.Empty,
                    machinestatic);
            }
        }
    }
}