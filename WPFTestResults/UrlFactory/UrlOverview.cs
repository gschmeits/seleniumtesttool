// ***********************************************************************
// Assembly         : SeleniumTestTool
// Author           : G.H.M.H. Schmeits
// Created          : 04-21-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="ElementsGetSet.xaml.cs" company="SCHMEITS SOFTWARE">
//     Copyright © G.H.M.H. Schmeits  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using DataStorage;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace UrlFactory
{
    internal class UrlOverview
    {
        public string urlstring { get; set; }

        public static List<UrlOverview> GetUrLs(int keuze = 0)
        {
            var tabel = "elements_short";
            if (keuze == 1)
            {
                tabel = "selenium_elements";
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
    }
}