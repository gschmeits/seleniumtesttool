﻿// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-19-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 04-30-2018
// ***********************************************************************
// <copyright file="UpdateDataBulk.xaml.cs" company="SCHMEITS">
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

    using GeneralFunctionality;

    /// <summary>
    /// Class UpdateDataBulk.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for UpdateDataBulk
    public partial class UpdateDataBulk : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateDataBulk"/> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public UpdateDataBulk()
        {
            this.InitializeComponent();
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
            this.LabelTestSET.Content = VersionClass.Bestandsnaam;
            if (this.LabelTestSET.Content.ToString().Length > 0) this.TextBoxDeletion.IsEnabled = true;
        }
    }
}