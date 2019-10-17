﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 07-21-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="GlobalVar.cs" company="SCHMEITS SOFTWARE">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The GlobalVariables namespace.
/// </summary>
/// <autogeneratedoc />
/// TODO Edit XML Comment Template for GlobalVariables
namespace GlobalVariables
{
    /// <summary>
    /// Class Globals_org.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for Globals_org
    public static class Globals_org
    {
        // parameterless constructor required for static class
        /// <summary>
        /// Initializes static members of the <see cref="Globals_org" /> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        static Globals_org()
        {
            ServerName = "autotest";
            UserName1 = "autotest";
            Password1 = "autotest";
            Database1 = "autotest";
            Provider = "MySql.Data.MySqlClient";
        } // default value

        /// <summary>
        /// Gets the database1.
        /// </summary>
        /// <value>The database1.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Database1
        public static string Database1 { get; private set; }

        /// <summary>
        /// Gets the password1.
        /// </summary>
        /// <value>The password1.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Password1
        public static string Password1 { get; private set; }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Provider
        public static string Provider { get; private set; }

        // public get, and private set for strict access control
        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ServerName
        public static string ServerName { get; private set; }

        /// <summary>
        /// Gets the user name1.
        /// </summary>
        /// <value>The user name1.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for UserName1
        public static string UserName1 { get; private set; }

        /// <summary>
        /// Sets the database1.
        /// </summary>
        /// <param name="newDatabase">The new database.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SetDatabase1
        public static void SetDatabase1(string newDatabase)
        {
            Database1 = newDatabase;
        }

        /// <summary>
        /// Sets the password1.
        /// </summary>
        /// <param name="newPassword">The new password.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SetPassword1
        public static void SetPassword1(string newPassword)
        {
            Password1 = newPassword;
        }

        /// <summary>
        /// Sets the provider.
        /// </summary>
        /// <param name="newProvider">The new provider.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SetProvider
        public static void SetProvider(string newProvider)
        {
            Provider = newProvider;
        }

        // GlobalInt can be changed only via this method
        /// <summary>
        /// Sets the name of the server.
        /// </summary>
        /// <param name="newServerName">New name of the server.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SetServerName
        public static void SetServerName(string newServerName)
        {
            ServerName = newServerName;
        }

        /// <summary>
        /// Sets the user name1.
        /// </summary>
        /// <param name="newUserName">New name of the user.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SetUserName1
        public static void SetUserName1(string newUserName)
        {
            UserName1 = newUserName;
        }
    }
}