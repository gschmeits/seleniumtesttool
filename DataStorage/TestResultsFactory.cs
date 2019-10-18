﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 01-04-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="TestResultsFactory.cs" company="SCHMEITS">
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
    /// Class TestResultsFactory.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for TestResultsFactory
    public class TestResultsFactory
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="testrunFrom">The testrun from.</param>
        /// <param name="testrunTill">The testrun till.</param>
        /// <returns>List&lt;ResultsCount&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetCount
        public static List<ResultsCount> GetCount(string testrunFrom, string testrunTill)
        {

            var testresults = new List<ResultsCount>();
            var sqlConn = "SELECT count(*) as Result  FROM autotest.testresultsselenium where testrun >= '"
                          + testrunFrom;
            sqlConn += "' and testrun <= '" + testrunTill + "' GROUP BY result";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls124");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    testresults.Add(
                        new ResultsCount { value1 = Convert.ToInt64(objDataset.Tables[0].Rows[i][0].ToString()) });
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return testresults;
        }

        /// <summary>
        /// Ges the test results.
        /// </summary>
        /// <param name="testrunFrom">The testrun from.</param>
        /// <param name="testrunTill">The testrun till.</param>
        /// <returns>List&lt;TestResults&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GeTestResults
        public static List<TestResults> GeTestResults(string testrunFrom, string testrunTill)
        {
            var testresults = new List<TestResults>();
            var sqlConn =
                "SELECT testrun, datetime_created, application, testnr, element, attribute, If(result = 3, 'OK', 'NOK') as Result, testname, browserID, comment, elementname, testpage ";
            sqlConn += "FROM testresultsselenium where testrun <= " + testrunTill + " and testrun >= " + testrunFrom;
            sqlConn += " ORDER BY testrun, testnr";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls123");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    testresults.Add(
                        new TestResults
                            {
                                testrun = Convert.ToInt64(objDataset.Tables[0].Rows[i][0].ToString()),
                                date = objDataset.Tables[0].Rows[i][1].ToString(),
                                application = objDataset.Tables[0].Rows[i][2].ToString(),
                                testnr = objDataset.Tables[0].Rows[i][3].ToString(),
                                element = objDataset.Tables[0].Rows[i][4].ToString(),
                                attribute = objDataset.Tables[0].Rows[i][5].ToString(),
                                result = objDataset.Tables[0].Rows[i][6].ToString(),
                                testname = objDataset.Tables[0].Rows[i][7].ToString(),
                                browserID = objDataset.Tables[0].Rows[i][8].ToString(),
                                comment = objDataset.Tables[0].Rows[i][9].ToString(),
                                elementname = objDataset.Tables[0].Rows[i][10].ToString(),
                                page = objDataset.Tables[0].Rows[i][11].ToString()
                        });
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return testresults;
        }

        /// <summary>
        /// Gets the test cases.
        /// </summary>
        /// <param name="testname">The testname.</param>
        /// <returns>List&lt;TestCases&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetTestCases
        public static List<TestCases> GetTestCases(string testname)
        {
            var testcases = new List<TestCases>();
            var sqlConn = "SELECT id, testname, testnr, testcase, testlogicalobjectname, testelement, testattribute, testaction, testtext, testurl, testswitch, testexecution, testext_check, testinverse,testtag, test_comment, testpage ";
            sqlConn += "FROM testcases_selenium WHERE testname = '" + testname + "' ";
            sqlConn += "ORDER BY testname, testnr";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();
            var rownumber = 1;
            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls123");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                {
                    testcases.Add(
                        new TestCases
                        {
                            rownr = rownumber,
                            id = objDataset.Tables[0].Rows[i]["id"].ToString(),
                            testname = objDataset.Tables[0].Rows[i]["testname"].ToString(),
                            testnr = Convert.ToInt32(objDataset.Tables[0].Rows[i]["testnr"].ToString()),
                            testcase = objDataset.Tables[0].Rows[i]["testcase"].ToString(),
                            testelementname = objDataset.Tables[0].Rows[i]["testlogicalobjectname"].ToString(),
                            testelement = objDataset.Tables[0].Rows[i]["testelement"].ToString(),
                            testattribute = objDataset.Tables[0].Rows[i]["testattribute"].ToString(),
                            testaction = objDataset.Tables[0].Rows[i]["testaction"].ToString(),
                            testtext = objDataset.Tables[0].Rows[i]["testtext"].ToString(),
                            testurl = objDataset.Tables[0].Rows[i]["testurl"].ToString(),
                            testswitch = objDataset.Tables[0].Rows[i]["testswitch"].ToString(),
                            testexecution = objDataset.Tables[0].Rows[i]["testexecution"].ToString(),
                            testinverse = objDataset.Tables[0].Rows[i]["testinverse"].ToString(),
                            testcomment = objDataset.Tables[0].Rows[i]["test_comment"].ToString(),
                            testext_check = objDataset.Tables[0].Rows[i]["testext_check"].ToString(),
                            testpage = objDataset.Tables[0].Rows[i]["testpage"].ToString(),
                            testtag = objDataset.Tables[0].Rows[i]["testtag"].ToString(),
                        });
                    rownumber++;
                }

                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return testcases;
        }

        /// <summary>
        /// Gets the test cases count.
        /// </summary>
        /// <param name="testname">The testname.</param>
        /// <returns>Int64.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetTestCasesCount
        public static Int64 GetTestCasesCount(string testname)
        {
            var sqlConn = "SELECT id, testname, testnr, testcase, testlogicalobjectname, testelement, testattribute, testaction, testtext, testurl, testswitch, testext_check, testpage ";
            sqlConn += "FROM testcases_selenium WHERE testname = '" + testname + "' ";
            sqlConn += "ORDER BY testname, testnr";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();
            var teststepscount = 0;

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls123");
                teststepscount = objDataset.Tables[0].Rows.Count;
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }
            
            return teststepscount;
        }

        /// <summary>
        /// Gets the scenarios.
        /// </summary>
        /// <returns>List&lt;Scenario&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetScenarios
        public static List<Scenario> GetScenarios()
        {
            var scenarios = new List<Scenario>();
            var sqlConn =
                "SELECT id, bestandsnaam, scenarios, description FROM call_calls WHERE scenarios IS NOT NULL AND scenarios <> '';";

            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls12");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    scenarios.Add(
                        new Scenario
                            {
                                id = objDataset.Tables[0].Rows[i][0].ToString(),
                                scenarionaam = objDataset.Tables[0].Rows[i][2].ToString().Replace("\\", "\\\\"),
                                description = objDataset.Tables[0].Rows[i][3].ToString().Replace("\\", "\\\\")
                            });
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return scenarios;
        }

        /// <summary>
        /// Gets the selected scenarios.
        /// </summary>
        /// <returns>List&lt;SelectedScenario&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetSelectedScenarios
        public static List<SelectedScenario> GetSelectedScenarios()
        {
            var selectedScenarios = new List<SelectedScenario>();
            var query =
                "SELECT st.selected_scenarios, sc.bestandsnaam, sc.data FROM selectedtests as st, scenario_steps as sc WHERE st.selected_scenarios = sc.call_calls_id;";

            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var tekst = string.Empty;
            var objDataAdapter = new MySqlDataAdapter(query, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls13");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                {
                    tekst = objDataset.Tables[0].Rows[i][2].ToString().Replace("\\", "\\\\");
                    selectedScenarios.Add(
                        new SelectedScenario
                            {
                                selectedScenario =
                                    Convert.ToInt32(objDataset.Tables[0].Rows[i][0].ToString()),
                                bestandsnaam =
                                    objDataset.Tables[0].Rows[i][1].ToString().Replace("\\", "\\\\"),
                                data = objDataset.Tables[0].Rows[i][2].ToString().Replace("\\", "\\\\")
                            });
                }

                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return selectedScenarios;
        }

        /// <summary>
        /// Gets the selected scenarios call.
        /// </summary>
        /// <returns>List&lt;SelectedScenarioCall&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetSelectedScenariosCall
        public static List<SelectedScenarioCall> GetSelectedScenariosCall()
        {
            var selectedScenariosCall = new List<SelectedScenarioCall>();
            var query =
                "SELECT st.selected_scenarios, cc.bestandsnaam, cc.data, cc.settingsxml FROM selectedtests as st, call_calls as cc WHERE st.selected_scenarios = cc.id";

            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var tekst = string.Empty;
            var objDataAdapter = new MySqlDataAdapter(query, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls12");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                {
                    tekst = objDataset.Tables[0].Rows[i][2].ToString().Replace("\\", "\\\\");
                    selectedScenariosCall.Add(
                        new SelectedScenarioCall
                            {
                                selectedScenario =
                                    Convert.ToInt32(objDataset.Tables[0].Rows[i][0].ToString()),
                                bestandsnaam = objDataset.Tables[0].Rows[i][1].ToString(),
                                data =
                                    objDataset.Tables[0].Rows[i][2].ToString().Replace("\\", "\\\\"),
                                setting = objDataset.Tables[0].Rows[i][3].ToString()
                                    .Replace("\\", "\\\\")
                            });
                }

                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return selectedScenariosCall;
        }

        /// <summary>
        /// Gets the test results.
        /// </summary>
        /// <param name="testrun2">The testrun2.</param>
        /// <returns>List&lt;TestResultPie&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetTestResults
        public static List<TestResultPie> GetTestResults(string testrun2)
        {
            var sqlConn =
                "Select If(result = 3, 'OK', 'NOK') as Result, IFNULL(Count(*), 0) as Count, module, function, datetime_created FROM testresults WHERE testrun =  "
                + testrun2 + " GROUP BY result";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var testresults = new List<TestResultPie>();
             
            try
            {
                using (var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn))
                {
                    var objDataset = new DataSet();
                    objConn.Open();
                    objDataAdapter.Fill(objDataset, "call_calls14");

                    testresults.Clear();
                    for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                        testresults.Add(
                            new TestResultPie
                                {
                                    result = objDataset.Tables[0].Rows[i][0].ToString(),
                                    count1 = Convert.ToInt64(objDataset.Tables[0].Rows[i][1].ToString()),
                                    module = objDataset.Tables[0].Rows[i][2].ToString(),
                                    function = objDataset.Tables[0].Rows[i][3].ToString()
                                });

                    objConn.Close();
                }
            }
            catch (Exception e)
            {
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return testresults;
        }

        /// <summary>
        /// Gets the test result selects.
        /// </summary>
        /// <returns>List&lt;TestResultsSelect&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetTestResultSelects
        public static List<TestResultsSelect> GetTestResultSelects()
        {
            var testresults = new List<TestResultsSelect>();
            try
            {
                var sqlConn =
                    "SELECT testrun, DATE_FORMAT(datetime_created, '%Y-%m %d %T') as Date FROM testresultsselenium GROUP BY testrun ORDER BY testID DESC";
                var objConn = new MySqlConnection(General.MySqlConnectionString());
                using (var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn))
                {
                    var objDataset = new DataSet();
                    objConn.Open();
                    objDataAdapter.Fill(objDataset, "call_calls189");
                    for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                        testresults.Add(
                            new TestResultsSelect
                                {
                                    testrun = Convert.ToInt64(
                                        objDataset.Tables[0].Rows[i][0].ToString()),
                                    date = objDataset.Tables[0].Rows[i][1].ToString()
                                });
                    objConn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.Message);
                General.LogMessageDatabase(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);

            }
            return testresults;
        }

        /// <summary>
        /// Class ResultsCount.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ResultsCount
        public class ResultsCount
        {
            /// <summary>
            /// Gets or sets the value1.
            /// </summary>
            /// <value>The value1.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for value1
            public long value1 { get; set; }
        }

        /// <summary>
        /// Class Scenario.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Scenario
        public class Scenario
        {
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for description
            public string description { get; set; }

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for id
            public string id { get; set; }

            /// <summary>
            /// Gets or sets the scenarionaam.
            /// </summary>
            /// <value>The scenarionaam.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for scenarionaam
            public string scenarionaam { get; set; }
        }

        /// <summary>
        /// Class SelectedScenario.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SelectedScenario
        public class SelectedScenario
        {
            /// <summary>
            /// Gets or sets the bestandsnaam.
            /// </summary>
            /// <value>The bestandsnaam.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for bestandsnaam
            public string bestandsnaam { get; set; }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for data
            public string data { get; set; }

            /// <summary>
            /// Gets or sets the selected scenario.
            /// </summary>
            /// <value>The selected scenario.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for selectedScenario
            public int selectedScenario { get; set; }
        }

        /// <summary>
        /// Class SelectedScenarioCall.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SelectedScenarioCall
        public class SelectedScenarioCall
        {
            /// <summary>
            /// Gets or sets the bestandsnaam.
            /// </summary>
            /// <value>The bestandsnaam.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for bestandsnaam
            public string bestandsnaam { get; set; }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for data
            public string data { get; set; }

            /// <summary>
            /// Gets or sets the selected scenario.
            /// </summary>
            /// <value>The selected scenario.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for selectedScenario
            public int selectedScenario { get; set; }

            /// <summary>
            /// Gets or sets the setting.
            /// </summary>
            /// <value>The setting.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for setting
            public string setting { get; set; }
        }

        /// <summary>
        /// Class TestResultPie.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestResultPie
        public class TestResultPie
        {
            /// <summary>
            /// Gets or sets the count1.
            /// </summary>
            /// <value>The count1.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for count1
            public long count1 { get; set; }

            /// <summary>
            /// Gets or sets the function.
            /// </summary>
            /// <value>The function.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for function
            public string function { get; set; }

            /// <summary>
            /// Gets or sets the module.
            /// </summary>
            /// <value>The module.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for module
            public string module { get; set; }

            /// <summary>
            /// Gets or sets the result.
            /// </summary>
            /// <value>The result.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for result
            public string result { get; set; }
        }

        /// <summary>
        /// Class TestResults.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestResults
        public class TestResults
        {
            /// <summary>
            /// Gets or sets the application.
            /// </summary>
            /// <value>The application.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for application
            public string application { get; set; }

            /// <summary>
            /// Gets or sets the attribute.
            /// </summary>
            /// <value>The attribute.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for attribute
            public string attribute { get; set; }

            /// <summary>
            /// Gets or sets the date.
            /// </summary>
            /// <value>The date.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for date
            public string date { get; set; }

            /// <summary>
            /// Gets or sets the element.
            /// </summary>
            /// <value>The element.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for element
            public string element { get; set; }

            /// <summary>
            /// Gets or sets the result.
            /// </summary>
            /// <value>The result.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for result
            public string result { get; set; }

            /// <summary>
            /// Gets or sets the testrun.
            /// </summary>
            /// <value>The testrun.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testrun
            public long testrun { get; set; }

            /// <summary>
            /// Gets or sets the testname.
            /// </summary>
            /// <value>The testname.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testname
            public String testname { get; set; }
            /// <summary>
            /// Gets or sets the testnr.
            /// </summary>
            /// <value>The testnr.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testnr
            public string testnr { get; set; }

            /// <summary>
            /// Gets or sets the browser identifier.
            /// </summary>
            /// <value>The browser identifier.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for browserID
            public string browserID { get; set; }

            /// <summary>
            /// Gets or sets the comment.
            /// </summary>
            /// <value>The comment.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for comment
            public string comment { get; set; }
            /// <summary>
            /// Gets or sets the elementname.
            /// </summary>
            /// <value>The elementname.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for elementname
            public string elementname { get; set; }
            /// <summary>
            /// Gets or sets the page.
            /// </summary>
            /// <value>The page.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for page
            public string page { get; set; }
        }

        /// <summary>
        /// Class TestResultsSelect.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestResultsSelect
        public class TestResultsSelect
        {
            /// <summary>
            /// Gets or sets the date.
            /// </summary>
            /// <value>The date.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for date
            public string date { get; set; }

            /// <summary>
            /// Gets or sets the testrun.
            /// </summary>
            /// <value>The testrun.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testrun
            public long testrun { get; set; }
        }

        /// <summary>
        /// Class TestCases.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for TestCases
        public class TestCases
        {
            /// <summary>
            /// Gets or sets the rownr.
            /// </summary>
            /// <value>The rownr.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for rownr
            public int rownr { get; set; }
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for id
            public string id { get; set; }
            /// <summary>
            /// Gets or sets the testname.
            /// </summary>
            /// <value>The testname.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testname
            public string testname { get; set; }
            /// <summary>
            /// Gets or sets the testnr.
            /// </summary>
            /// <value>The testnr.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testnr
            public int testnr { get; set; }
            /// <summary>
            /// Gets or sets the testcase.
            /// </summary>
            /// <value>The testcase.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testcase
            public string testcase { get; set; }
            /// <summary>
            /// Gets or sets the testelementname.
            /// </summary>
            /// <value>The testelementname.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testelementname
            public string testelementname { get; set; }
            /// <summary>
            /// Gets or sets the testelement.
            /// </summary>
            /// <value>The testelement.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testelement
            public string testelement { get; set; }
            /// <summary>
            /// Gets or sets the testattribute.
            /// </summary>
            /// <value>The testattribute.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testattribute
            public string testattribute { get; set; }
            /// <summary>
            /// Gets or sets the testaction.
            /// </summary>
            /// <value>The testaction.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testaction
            public string testaction { get; set; }
            /// <summary>
            /// Gets or sets the testtext.
            /// </summary>
            /// <value>The testtext.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testtext
            public string testtext { get; set; }
            /// <summary>
            /// Gets or sets the testurl.
            /// </summary>
            /// <value>The testurl.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testurl
            public string testurl { get; set; }
            /// <summary>
            /// Gets or sets the testswitch.
            /// </summary>
            /// <value>The testswitch.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testswitch
            public string testswitch { get; set; }
            /// <summary>
            /// Gets or sets the testext check.
            /// </summary>
            /// <value>The testext check.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testext_check
            public string testext_check { get; set; }
            /// <summary>
            /// Gets or sets the testexecution.
            /// </summary>
            /// <value>The testexecution.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testexecution
            public string testexecution { get; set; }
            /// <summary>
            /// Gets or sets the testinverse.
            /// </summary>
            /// <value>The testinverse.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testinverse
            public string testinverse { get; set; }
            /// <summary>
            /// Gets or sets the testcomment.
            /// </summary>
            /// <value>The testcomment.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testcomment
            public string testcomment { get; set; }

            /// <summary>
            /// Gets or sets the testpage.
            /// </summary>
            /// <value>The testpage.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testpage
            public string testpage { get; set; }
            /// <summary>
            /// Gets or sets the testtag.
            /// </summary>
            /// <value>The testtag.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testtag
            public string testtag { get; set; }
        }
    }
}