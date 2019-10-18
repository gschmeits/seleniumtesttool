﻿// ***********************************************************************
// Assembly         : LicentieWPF
// Author           : G.H.M.H. Schmeits
// Created          : 03-07-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 04-17-2018
// ***********************************************************************
// <copyright file="LicentieAdmin.xaml.cs" company="SCHMEITS SOFTWARE">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace LicentieWPF.LicenseKey
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for LicentieAdmin.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class LicentieAdmin : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicentieAdmin" /> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public LicentieAdmin()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnLiConOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for btnLiConOK_Click
        private void btnLiConOK_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(2);
        }
    }
}