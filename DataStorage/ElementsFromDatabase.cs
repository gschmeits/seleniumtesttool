﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 04-26-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="ElementsFromDatabase.cs" company="SCHMEITS SOFTWARE">
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
    using System.Windows;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// Class ElementsFromDatabase.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for ElementsFromDatabase
    public static class ElementsFromDatabase
    {
        /// <summary>
        /// Updates all checkboxes.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="wel">The wel.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for UpdateAllCheckboxes
        public static void UpdateAllCheckboxes(string url, Boolean wel, string element)
        {
            var selecteren = 0;
            if (wel == true)
            {
                selecteren = 1;
            }
            var query = "UPDATE selenium_elements ";
            query += "SET " + element + " = " + selecteren;
            query += " WHERE url = '" + url + "';";
            General.ExecuteQueryCommand(query);
        }

        public static void UpdateAllCheckbox8(string id, Boolean wel, string element)
        {
            var selecteren = 0;
            if (wel == true)
            {
                selecteren = 1;
            }
            var query = "UPDATE selenium_elements ";
            query += "SET " + element + " = " + selecteren;
            query += " WHERE idselenium_elements = '" + id + "';";
            General.ExecuteQueryCommand(query);
        }

        public static void UpdateCheckBox8(string id, Boolean wel)
        {
            var selecteren = 0;
            if (wel == true)
            {
                selecteren = 1;
            }
            var query = "UPDATE selenium_elements ";
            query += "SET checktext = '" + selecteren + "' WHERE idselenium_elements = " + id + ";";
            General.ExecuteQueryCommand(query);

        }

        public static void UpdateCheckBox(string id, Boolean wel)
        {
            var selecteren = 0;
            if (wel == true)
            {
                selecteren = 1;
            }
            var query = "UPDATE selenium_elements ";
            query += "SET selenium_check = '" + selecteren + "' WHERE idselenium_elements = " + id + ";";
            General.ExecuteQueryCommand(query);

        }

        public static void UpdateCheckBoxText(string id, string tekst)
        {
            var query = "UPDATE selenium_elements ";
            query += "SET text = '" + tekst + "' WHERE idselenium_elements = " + id + ";";
            General.ExecuteQueryCommand(query);
        }


        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>List&lt;NewElements.AllElements&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetDataTable
        public static List<NewElements.AllElements> GetDataTable(string url)
        {
            var elementresults = new List<NewElements.AllElements>();

            var query = "SELECT idselenium_elements, gebruikte_link, tagname, text, href, id, name, class, xpath, selenium_check, checktext FROM selenium_elements ";
            query += "WHERE url = '" + url + "' ORDER BY gebruikte_link, idselenium_elements;";

            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(query, objConn);
            var objDataset = new DataSet();
            var boo1 = "0";
            var boo2 = false;
            var boochecktext1 = "0";
            var boochecktext2 = true;
            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls123");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                {
                    boo1 = objDataset.Tables[0].Rows[i]["selenium_check"].ToString();
                    boochecktext1 = objDataset.Tables[0].Rows[i]["checktext"].ToString();
                    if (boo1 == "1") boo2 = true;
                    if (boo1 == "0") boo2 = false;
                    if (boochecktext1 == "0") boochecktext2 = false;
                    if (boochecktext1 == "1") boochecktext2 = true;
                    elementresults.Add(
                        new NewElements.AllElements
                            {
                                elementLink = objDataset.Tables[0].Rows[i]["gebruikte_link"].ToString(),
                                elementTagname = objDataset.Tables[0].Rows[i]["tagname"].ToString(),
                                elementText = objDataset.Tables[0].Rows[i]["text"].ToString(),
                                elementHref = objDataset.Tables[0].Rows[i]["href"].ToString(),
                                elementId = objDataset.Tables[0].Rows[i]["id"].ToString(),
                                elementName = objDataset.Tables[0].Rows[i]["name"].ToString(),
                                elementClass = objDataset.Tables[0].Rows[i]["class"].ToString(),
                                elementXpath = objDataset.Tables[0].Rows[i]["xpath"].ToString(),
                                elementCheck = boo2,
                                elementCheckText = boochecktext2,
                                idSelenium_element = Convert.ToInt32(objDataset.Tables[0].Rows[i]["idselenium_elements"].ToString())
                            });
                }

                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return elementresults;
        }

        /// <summary>
        /// Updates the x path.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for UpdateXPath
        public static void UpdateXPath(string url)
        {
            var query = "SELECT xpath, count(*) AS teller FROM autotest.selenium_elements ";
                query += "WHERE url = '"+ url + "' GROUP BY xpath; ";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(query, objConn);
            var objDataset = new DataSet();

            objConn.Open();
            objDataAdapter.Fill(objDataset, "call_calls123");
            for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt16(objDataset.Tables[0].Rows[i][1].ToString()) > 1)
                {
                    StapForStap(url, objDataset.Tables[0].Rows[i][0].ToString());
                }
            }
        }

        /// <summary>
        /// Staps for stap.
        /// </summary>
        /// <param name="url1">The url1.</param>
        /// <param name="waarde">The waarde.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for StapForStap
        public static void StapForStap(string url1, string waarde)
        {
            var query = "SELECT * FROM autotest.selenium_elements ";
            query += "WHERE url = '"+ url1 + "' AND xpath = '"+ waarde +"'; ";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(query, objConn);
            var objDataset = new DataSet();
            var number = 1;
            objConn.Open();
            objDataAdapter.Fill(objDataset, "call_calls123");
            for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
            {
                var elementid = objDataset.Tables[0].Rows[i]["idselenium_elements"].ToString();
                var sql = "UPDATE selenium_elements SET xpath = '" + waarde + "[" + number + "]' WHERE url = '"
                          + url1 + "' AND idselenium_elements = '" + elementid + "'";
                number++;
                General.ExecuteQueryCommand(sql);
            }
        }


        /// <summary>
        /// Deletes the data from database.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for DeleteDataFromDatabase
        public static void DeleteDataFromDatabase(string url)
        {
            var query = "DELETE FROM selenium_elements ";
            query += "WHERE url = '" + url + "' ";
            General.ExecuteQueryCommand(query);

        }

        /// <summary>
        /// Updates the x path1.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="xpath">The xpath.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for UpdateXPath1
        private static void UpdateXPath1(string url, string xpath)
        {
            var query = "SELECT idselenium_elements, xpath, text FROM selenium_elements ";

            query += "WHERE url = '" + url + "' AND xpath = '" + xpath + "' ";
            query += "ORDER BY xpath, idselenium_elements";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(query, objConn);
            var objDataset = new DataSet();
            var number = 1;
            var anumber = 1;

            objConn.Open();
            objDataAdapter.Fill(objDataset, "call_calls133");
            for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                if (objDataset.Tables[0].Rows.Count > 1)
                {
                    var xpath1 = objDataset.Tables[0].Rows[i]["xpath"].ToString();
                    var tekstGer = objDataset.Tables[0].Rows[i]["text"].ToString();
                    var xpath2 = string.Empty;
                    var xpath3 = string.Empty;
                    var xpath4 = string.Empty;
                    if (xpath1.Substring(xpath1.Length - 2, 2) == @"/a")
                    {
                        xpath2 = xpath1.Substring(0, xpath1.Length - 2);
                        xpath3 = @"/a";
                    }
                    else
                    {
                        xpath2 = xpath1;
                    }

                    xpath4 = xpath2 + "[" + number + "]" + xpath3;

                    if (xpath1.IndexOf("/li/", StringComparison.Ordinal) > 0)
                    {
                        xpath4 = xpath1.Substring(0, xpath1.IndexOf("/li") + 3) + "["+ number +"]" + xpath1.Substring(xpath1.IndexOf("/li") + 3, xpath1.Length - xpath1.IndexOf("/li") - 3);
                    }

                    if (xpath1.IndexOf("/h4/", StringComparison.Ordinal) > 0)
                    {
                        xpath4 = xpath1.Substring(0, xpath1.IndexOf("/h4/")) + "[" + number + "]" + xpath1.Substring(xpath1.IndexOf("/h4/"), xpath1.Length - xpath1.IndexOf("/h4/"));
                    }


                    var elementid = objDataset.Tables[0].Rows[i]["idselenium_elements"].ToString();
                    var sql = "UPDATE selenium_elements SET xpath = '" + xpath4 + "' WHERE url = '"
                              + url + "' AND idselenium_elements = '" + elementid + "'";
                    number++;
                    General.ExecuteQueryCommand(sql);
                }
        }
    }
}