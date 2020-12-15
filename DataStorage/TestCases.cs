﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 01-18-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="TestCases.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The DataStorage namespace.
/// </summary>
/// <autogeneratedoc />
/// TODO Edit XML Comment Template for DataStorage

using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace DataStorage
{
    /// <summary>
    ///     Class TestCases.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for TestCases
    public static class TestCases
    {
        /// <summary>
        ///     Adds the test case.
        /// </summary>
        /// <param name="testname">The testname.</param>
        /// <param name="testnr">The testnr.</param>
        /// <param name="testcase">The testcase.</param>
        /// <param name="testelementname">The testelementname.</param>
        /// <param name="testelement">The testelement.</param>
        /// <param name="testattribute">The testattribute.</param>
        /// <param name="testaction">The testaction.</param>
        /// <param name="testtext">The testtext.</param>
        /// <param name="testurl">The testurl.</param>
        /// <param name="testexecution">The testexecution.</param>
        /// <param name="testswitch">The testswitch.</param>
        /// <param name="testinverse">The testinverse.</param>
        /// <param name="testdescription">The testdescription.</param>
        /// <param name="testcomment">The testcomment.</param>
        /// <param name="testmachinecode">The testmachinecode.</param>
        /// <param name="testtag">The testtag.</param>
        /// <param name="testcheck">The testcheck.</param>
        /// <param name="test_password">The test password.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for AddTestCase
        public static void AddTestCase(
            string testname,
            string testnr,
            string testcase,
            string testelementname,
            string testelement,
            string testattribute,
            string testaction,
            string testtext,
            string testurl,
            string testexecution,
            string testswitch,
            string testinverse,
            string testdescription,
            string testcomment,
            string testmachinecode,
            string testtag,
            string testcheck,
            string test_password = "")
        {
            try
            {
                var commandText = "INSERT INTO testcases_selenium SET ";
                commandText += "testname = '" + testname + "', ";
                commandText += "testnr = " + testnr + ", ";
                commandText += "testcase ='" + testcase + "', ";
                commandText += "testlogicalobjectname = '" + MySqlHelper.EscapeString(testelementname) + "', ";
                commandText += "testelement = '" + MySqlHelper.EscapeString(testelement) + "', ";
                commandText += "testattribute = '" + MySqlHelper.EscapeString(testattribute) + "', ";
                commandText += "testaction = '" + MySqlHelper.EscapeString(testaction) + "', ";
                commandText += "testtag = '" + MySqlHelper.EscapeString(testtag) + "', ";
                commandText += "testtext = '" + MySqlHelper.EscapeString(testtext) + "', ";
                commandText += "testext_check = '" + MySqlHelper.EscapeString(testcheck) + "', ";
                commandText += "testurl = '" + MySqlHelper.EscapeString(testurl) + "', ";
                commandText += "testexecution = '" + MySqlHelper.EscapeString(testexecution) + "', ";
                commandText += "testinverse = '" + MySqlHelper.EscapeString(testinverse) + "', ";
                commandText += "test_comment = '" + MySqlHelper.EscapeString(testcomment) + "', ";
                commandText += "machinenumber = '" + testmachinecode + "', ";
                commandText += "test_password = '" + test_password + "', ";
                commandText += "testswitch = '" + MySqlHelper.EscapeString(testswitch) + "';";
                General.ExecuteQueryCommand(commandText);
                General.LogMessage(commandText, 1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
            }
        }

        /// <summary>
        ///     Edits the test case.
        /// </summary>
        /// <param name="testID">The test identifier.</param>
        /// <param name="testname">The testname.</param>
        /// <param name="testnr">The testnr.</param>
        /// <param name="testcase">The testcase.</param>
        /// <param name="testelementname">The testelementname.</param>
        /// <param name="testelement">The testelement.</param>
        /// <param name="testattribute">The testattribute.</param>
        /// <param name="testaction">The testaction.</param>
        /// <param name="testtext">The testtext.</param>
        /// <param name="testurl">The testurl.</param>
        /// <param name="testexecution">The testexecution.</param>
        /// <param name="testswitch">The testswitch.</param>
        /// <param name="testinverse">The testinverse.</param>
        /// <param name="testdescription">The testdescription.</param>
        /// <param name="testcomment">The testcomment.</param>
        /// <param name="testtag">The testtag.</param>
        /// <param name="testpassword">The testpassword.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for EditTestCase
        public static void EditTestCase(
            string testID,
            string testname,
            string testnr,
            string testcase,
            string testelementname,
            string testelement,
            string testattribute,
            string testaction,
            string testtext,
            string testurl,
            string testexecution,
            string testswitch,
            string testinverse,
            string testdescription,
            string testcomment,
            string testtag,
            string testpassword = "")
        {
            try
            {
                var commandText = "UPDATE testcases_selenium SET ";
                commandText += "testname = '" + MySqlHelper.EscapeString(testname) + "', ";
                commandText += "testnr = " + MySqlHelper.EscapeString(testnr) + ", ";
                commandText += "testcase ='" + MySqlHelper.EscapeString(testcase) + "', ";
                commandText += "testlogicalobjectname = '" + MySqlHelper.EscapeString(testelementname) + "', ";
                commandText += "testelement = '" + MySqlHelper.EscapeString(testelement) + "', ";
                commandText += "testattribute = '" + MySqlHelper.EscapeString(testattribute) + "', ";
                commandText += "testaction = '" + MySqlHelper.EscapeString(testaction) + "', ";
                commandText += "testtag = '" + MySqlHelper.EscapeString(testtag) + "', ";
                commandText += "testtext = '" + MySqlHelper.EscapeString(testtext) + "', ";
                commandText += "testurl = '" + MySqlHelper.EscapeString(testurl) + "', ";
                commandText += "testexecution = '" + MySqlHelper.EscapeString(testexecution) + "', ";
                commandText += "testinverse = '" + MySqlHelper.EscapeString(testinverse) + "', ";
                commandText += "testext_check = '" + MySqlHelper.EscapeString(testdescription) + "', ";
                commandText += "test_comment = '" + MySqlHelper.EscapeString(testcomment) + "', ";
                commandText += "test_password = '" + testpassword + "', ";
                commandText += "testswitch = '" + MySqlHelper.EscapeString(testswitch) + "' WHERE ";
                commandText += "id = " + testID;
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
            }
        }

        /// <summary>
        ///     Deletes the test case.
        /// </summary>
        /// <param name="testID">The test identifier.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for DeleteTestCase
        public static void DeleteTestCase(string testID)
        {
            try
            {
                var commandText = "DELETE FROM testcases_selenium WHERE ";
                commandText += "id = " + testID;
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
            }
        }


        /// <summary>
        ///     Adds the test case.
        /// </summary>
        /// <param name="testname">The testname.</param>
        /// <param name="testnr">The testnr.</param>
        /// <param name="testcase">The testcase.</param>
        /// <param name="testelementname">The testelementname.</param>
        /// <param name="testelement">The testelement.</param>
        /// <param name="testattribute">The testattribute.</param>
        /// <param name="testaction">The testaction.</param>
        /// <param name="testtext">The testtext.</param>
        /// <param name="testurl">The testurl.</param>
        /// <param name="testexecution">The testexecution.</param>
        /// <param name="testswitch">The testswitch.</param>
        /// <param name="testinverse">The testinverse.</param>
        /// <param name="testdescription">The testdescription.</param>
        /// <param name="testcomment">The testcomment.</param>
        /// <param name="testmachinecode">The testmachinecode.</param>
        /// <param name="testtag">The testtag.</param>
        /// <param name="testcheck">The testcheck.</param>
        /// <param name="test_password">The test password.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for AddTestCase
        public static void AddTestBlock(
            string testblock,
            string testnr,
            string testcase,
            string testelementname,
            string testelement,
            string testattribute,
            string testaction,
            string testtext,
            string testurl,
            string testexecution,
            string testswitch,
            string testinverse,
            string testdescription,
            string testcomment,
            string testmachinecode,
            string testtag,
            string testcheck,
            string projectid,
            string test_password = "")
        {
            try
            {
                var commandText = "INSERT INTO testblock SET ";
                commandText += "testblock = '" + testblock + "', ";
                commandText += "testnr = " + testnr + ", ";
                commandText += "testcase ='" + testcase + "', ";
                commandText += "testelement = '" + MySqlHelper.EscapeString(testelement) + "', ";
                commandText += "testlogicalobjectname = '" + MySqlHelper.EscapeString(testelementname) + "', ";
                commandText += "testattribute = '" + MySqlHelper.EscapeString(testattribute) + "', ";
                commandText += "testaction = '" + MySqlHelper.EscapeString(testaction) + "', ";
                commandText += "testtag = '" + MySqlHelper.EscapeString(testtag) + "', ";
                commandText += "testtext = '" + MySqlHelper.EscapeString(testtext) + "', ";
                commandText += "testext_check = '" + MySqlHelper.EscapeString(testcheck) + "', ";
                commandText += "testurl = '" + MySqlHelper.EscapeString(testurl) + "', ";
                commandText += "testexecution = '" + MySqlHelper.EscapeString(testexecution) + "', ";
                commandText += "testinverse = '" + MySqlHelper.EscapeString(testinverse) + "', ";
                commandText += "testdescription = '" + MySqlHelper.EscapeString(testcomment) + "', ";
                commandText += "test_password = '" + MySqlHelper.EscapeString(test_password) + "', ";
                commandText += "project_id = " + MySqlHelper.EscapeString(projectid) + ", ";
                commandText += "testswitch = '" + MySqlHelper.EscapeString(testswitch) + "';";
                General.ExecuteQueryCommand(commandText);
                General.LogMessage(commandText, 1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
            }
        }

        /// <summary>
        ///     Edits the test case.
        /// </summary>
        /// <param name="testID">The test identifier.</param>
        /// <param name="testname">The testname.</param>
        /// <param name="testnr">The testnr.</param>
        /// <param name="testcase">The testcase.</param>
        /// <param name="testelementname">The testelementname.</param>
        /// <param name="testelement">The testelement.</param>
        /// <param name="testattribute">The testattribute.</param>
        /// <param name="testaction">The testaction.</param>
        /// <param name="testtext">The testtext.</param>
        /// <param name="testurl">The testurl.</param>
        /// <param name="testexecution">The testexecution.</param>
        /// <param name="testswitch">The testswitch.</param>
        /// <param name="testinverse">The testinverse.</param>
        /// <param name="testdescription">The testdescription.</param>
        /// <param name="testcomment">The testcomment.</param>
        /// <param name="testtag">The testtag.</param>
        /// <param name="testpassword">The testpassword.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for EditTestCase
        public static void EditTestBlock(
            string testID,
            string testblock,
            string testnr,
            string testcase,
            string testelementname,
            string testelement,
            string testattribute,
            string testaction,
            string testtext,
            string testurl,
            string testexecution,
            string testswitch,
            string testinverse,
            string testdescription,
            string testcomment,
            string testmachinecode,
            string testtag,
            string testcheck,
            string projectid,
            string test_password = "")
        {
            try
            {
                var commandText = "UPDATE testblock SET ";
                commandText += "testblock = '" + testblock + "', ";
                commandText += "testnr = " + testnr + ", ";
                commandText += "testcase ='" + testcase + "', ";
                commandText += "testelement = '" + MySqlHelper.EscapeString(testelement) + "', ";
                commandText += "testlogicalobjectname = '" + MySqlHelper.EscapeString(testelementname) + "', ";
                commandText += "testattribute = '" + MySqlHelper.EscapeString(testattribute) + "', ";
                commandText += "testaction = '" + MySqlHelper.EscapeString(testaction) + "', ";
                commandText += "testtag = '" + MySqlHelper.EscapeString(testtag) + "', ";
                commandText += "testtext = '" + MySqlHelper.EscapeString(testtext) + "', ";
                commandText += "testext_check = '" + MySqlHelper.EscapeString(testcheck) + "', ";
                commandText += "testurl = '" + MySqlHelper.EscapeString(testurl) + "', ";
                commandText += "testexecution = '" + MySqlHelper.EscapeString(testexecution) + "', ";
                commandText += "testinverse = '" + MySqlHelper.EscapeString(testinverse) + "', ";
                commandText += "testdescription = '" + MySqlHelper.EscapeString(testcomment) + "', ";
                commandText += "test_password = '" + MySqlHelper.EscapeString(test_password) + "', ";
                commandText += "project_id = " + MySqlHelper.EscapeString(projectid) + ", ";
                commandText += "testswitch = '" + MySqlHelper.EscapeString(testswitch) + "' WHERE ";
                commandText += "id = " + testID + ";";
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
            }
        }

        /// <summary>
        ///     Deletes the test case.
        /// </summary>
        /// <param name="testID">The test identifier.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for DeleteTestCase
        public static void DeleteTestBlock(string testID)
        {
            try
            {
                var commandText = "DELETE FROM testblock WHERE ";
                commandText += "id = " + testID;
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
            }
        }


        /// <summary>
        ///     The insert test page source.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="title">The title.</param>
        /// <param name="pageSource">The page source.</param>
        public static void InsertTestPageSource(string url, string title, string pageSource)
        {
            var commandText = "INSERT INTO TestUrls SET ";
            commandText += "TestUrl ='" + MySqlHelper.EscapeString(url) + "', ";
            commandText += "TestTile = '" + MySqlHelper.EscapeString(title) + "', ";
            commandText += "TestUrlPageSource = '" + MySqlHelper.EscapeString(pageSource) + "';";
            General.ExecuteQueryCommand(commandText);
        }

        /// <summary>
        ///     Removes the test cases.
        /// </summary>
        /// <param name="testname">The testname.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for RemoveTestCases
        public static void RemoveTestCases(string testname)
        {
            try
            {
                var commandText = "DELETE FROM testcases_selenium ";
                commandText += "WHERE testname = '" + testname + "';";
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace, 4);
            }
        }

        /// <summary>
        ///     Changes the execution.
        /// </summary>
        /// <param name="begin">The begin.</param>
        /// <param name="eind">The eind.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ChangeExecution
        public static void ChangeExecution(string begin, string eind)
        {
            try
            {
                var commandText = "UPDATE testcases_selenium ";
                commandText += "SET testexecution = 'no' ";
                commandText += "WHERE testnr >= " + begin + " AND testnr <= " + eind;
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace, 4);
            }
        }

        /// <summary>
        ///     Adds the test results.
        /// </summary>
        /// <param name="testrun_application">The testrun application.</param>
        /// <param name="testrun">The testrun.</param>
        /// <param name="testpassed">The testpassed.</param>
        /// <param name="testfailed">The testfailed.</param>
        /// <param name="begin">The begin.</param>
        /// <param name="eind">The eind.</param>
        /// <param name="tijd">The tijd.</param>
        /// <param name="browserid">The browserid.</param>
        /// <param name="version1">The version1.</param>
        /// <param name="machinenumber">The machinenumber.</param>
        /// <param name="start_url">The start URL.</param>
        /// <param name="testscenario_name">Name of the testscenario.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for AddTestResults
        public static void AddTestResults(string testrun_application, string testrun, string testpassed,
            string testfailed, DateTime begin,
            DateTime eind, string tijd, string browserid, string version1, string machinenumber, string start_url,
            string testscenario_name, string projectid)
        {
            try
            {
                var commandText = "INSERT INTO testruns_selenium SET ";
                commandText += "testrun_application = '" + testrun_application + "', ";
                commandText += "testrun_run = " + testrun + ", ";
                commandText += "testrun_passed = " + testpassed + ", ";
                commandText += "testrun_failed = " + testfailed + ", ";
                commandText += "testrun_begintime = '" + begin.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                commandText += "testrun_endtime = '" + eind.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                commandText += "testrun_time = '" + tijd + "', ";
                commandText += "testrun_browserID = " + browserid + ", ";
                commandText += "testrun_machinenumber = '" + machinenumber + "', ";
                commandText += "testscenario_name = '" + testscenario_name + "', ";
                commandText += "start_url ='" + start_url + "', ";
                commandText += "project_id = " + projectid + ", ";
                commandText += "testrun_version = '" + version1 + "';";
                General.LogMessage(commandText, 1);
                General.ExecuteQueryCommand(commandText);
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace, 4);
            }
        }
    }
}