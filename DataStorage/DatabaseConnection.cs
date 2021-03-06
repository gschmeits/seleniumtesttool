﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 01-04-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="DatabaseConnection.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The DataStorage namespace.
/// </summary>
/// <autogeneratedoc />
/// TODO Edit XML Comment Template for DataStorage
namespace DataStorage
{
    /// <summary>
    /// Class DatabaseConnection.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for DatabaseConnection
    public class DatabaseConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnection" /> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="database">The database.</param>
        /// <param name="port">The port.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public DatabaseConnection(string host, string database, string port, string user, string password)
        {
            this.Host = host;
            this.Database = database;
            this.Port = port;
            this.User = user;
            this.Password = password;
            this.Charset = "utf8;";
        }
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Host
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>The database.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Database
        public string Database { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Port
        public string Port { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for User
        public string User { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Password
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the charset.
        /// </summary>
        /// <value>The charset.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Charset
        public string Charset { get; set; }
    }
}