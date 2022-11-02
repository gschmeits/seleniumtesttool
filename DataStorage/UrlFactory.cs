﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 03-26-2019
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="UrlFactory.cs" company="SCHMEITS SOFTWARE">
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
    using System;
    using System.Collections.Generic;
    using System.Data;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Class UrlFactory.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for UrlFactory
    public static class UrlFactory
    {
        /// <summary>
        /// Gets the ur ls.
        /// </summary>
        /// <returns>List&lt;UrlOverview&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetURLs
        public static List<UrlOverview> GetURLs(int keuze = 0)
        {
            var tabel = "selenium_elements";
            if (keuze == 0)
            {
                tabel = " elements_short";
            }
            var sqlConn = "SELECT url FROM " + tabel + " GROUP BY url ORDER BY url;";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var testurl = new List<UrlOverview>();

            try
            {
                using (var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn))
                {
                    var objDataset = new DataSet();
                    objConn.Open();
                    objDataAdapter.Fill(objDataset, "call_calls14");

                    testurl.Clear();
                    for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                        testurl.Add(
                            new UrlOverview
                            {
                                urlstring = objDataset.Tables[0].Rows[i][0].ToString()
                            });

                    objConn.Close();
                }
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return testurl;
        }


        /// <summary>
        /// Class UrlOverview.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for UrlOverview
        public class UrlOverview
        {
            /// <summary>
            /// Gets or sets the urlstring.
            /// </summary>
            /// <value>The urlstring.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for urlstring
            public string urlstring { get; set; }
        }
    }
}