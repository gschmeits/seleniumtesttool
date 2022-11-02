namespace DataStorage
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ScriptsDataFactory
    {
        public static List<Scripts1> GetScripts()
        {
            var results = new List<Scripts1>();
            var sqlConn = "SELECT * FROM testscripts";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls124");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    results.Add(
                        new Scripts1()
                        {
                            id = objDataset.Tables[0].Rows[i][0].ToString(),
                            name = objDataset.Tables[0].Rows[i][1].ToString()
                        });
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return results;
        }

        public static List<ScriptDetails> GetScriptsDetails(string id)
        {
            var results = new List<ScriptDetails>();

            var sqlConn = "SELECT a.id, a.name, b.bestandsnaam, b.id, b.testscriptid, b.url, b.application, b.page ";
            sqlConn += "FROM testscripts as a RIGHT JOIN testscript_detail as b ";
            sqlConn += "ON a.id = b.testscriptid ";
            sqlConn += "WHERE a.id = " + id + ";";

            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls124");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    results.Add(
                        new ScriptDetails()
                        {
                            id = objDataset.Tables[0].Rows[i][0].ToString(),
                            testscriptid = objDataset.Tables[0].Rows[i][4].ToString(),
                            url = objDataset.Tables[0].Rows[i][5].ToString(),
                            application = objDataset.Tables[0].Rows[i][6].ToString(),
                            page = objDataset.Tables[0].Rows[i][7].ToString(),
                            name = objDataset.Tables[0].Rows[i][1].ToString(),
                            bestandsnaam = objDataset.Tables[0].Rows[i][2].ToString()
                        });
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return results;
        }
    }
}