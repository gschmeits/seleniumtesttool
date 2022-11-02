﻿// ***********************************************************************
// Assembly         : DataStorage
// Author           : G.H.M.H. Schmeits
// Created          : 03-15-2019
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 05-24-2019
// ***********************************************************************
// <copyright file="PreconditionsFactory.cs" company="SCHMEITS SOFTWARE">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

/// <summary>
/// The DataStorage namespace.
/// </summary>
/// <autogeneratedoc />
/// TODO Edit XML Comment Template for DataStorage
namespace DataStorage
{
    /// <summary>
    /// Class PreconditionsFactory.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for PreconditionsFactory
    public static class PreconditionsFactory
    {
        /// <summary>
        /// Gets or sets the datagrid1.
        /// </summary>
        /// <value>The datagrid1.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for datagrid1
        private static DataGrid datagrid1 { get; set; }

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>DataGridCell.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetCell
        public static DataGridCell GetCell(int row, int column)
        {
            var rowContainer = GetRow(row);

            if (rowContainer != null)
            {
                var presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                if (presenter != null)
                {
                    var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    if (cell == null)
                    {
                        datagrid1.ScrollIntoView(rowContainer, datagrid1.Columns[column]);
                        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    }

                    return cell;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the data grid rows.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <returns>IEnumerable&lt;DataGridRow&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetDataGridRows
        public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource;

            // if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <param name="testcase">The testcase.</param>
        /// <returns>List&lt;Preconditions&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetPreconditions
        public static List<Preconditions> GetPreconditions(string testcase)
        {
            var testresults = new List<Preconditions>();
            var sqlConn =
                "SELECT id, number, testcase_name, pre_condition FROM autotest.selenium_preconditions WHERE testcase_name = '";
            sqlConn += testcase + "' ORDER BY number;";
            var objConn = new MySqlConnection(General.MySqlConnectionString());
            var objDataAdapter = new MySqlDataAdapter(sqlConn, objConn);
            var objDataset = new DataSet();

            try
            {
                objConn.Open();
                objDataAdapter.Fill(objDataset, "call_calls123");
                for (var i = 0; i < objDataset.Tables[0].Rows.Count; i++)
                    if (objDataset.Tables[0].Rows[i][2].ToString() != string.Empty)
                        testresults.Add(
                            new Preconditions
                            {
                                id = objDataset.Tables[0].Rows[i][0].ToString(),
                                number = objDataset.Tables[0].Rows[i][1].ToString(),
                                testcase = objDataset.Tables[0].Rows[i][2].ToString(),
                                description = objDataset.Tables[0].Rows[i][3].ToString()
                            });
                objConn.Close();
            }
            catch (Exception e)
            {
                General.LogMessage(e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source, 4);
            }

            return testresults;
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>DataGridRow.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetRow
        public static DataGridRow GetRow(int index)
        {
            var row = (DataGridRow)datagrid1.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                datagrid1.UpdateLayout();
                datagrid1.ScrollIntoView(datagrid1.Items[index]);
                row = (DataGridRow)datagrid1.ItemContainerGenerator.ContainerFromIndex(index);
            }

            return row;
        }

        /// <summary>
        /// Gets the visual child.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">The parent.</param>
        /// <returns>T.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetVisualChild`1
        public static T GetVisualChild<T>(Visual parent)
            where T : Visual
        {
            var child = default(T);
            var numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < numVisuals; i++)
            {
                var v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null) child = GetVisualChild<T>(v);
                if (child != null) break;
            }

            return child;
        }

        /// <summary>
        /// Preconditionses the add update.
        /// </summary>
        /// <param name="dataGrid">The data grid.</param>
        /// <param name="testCase">The test case.</param>
        /// <param name="delete">The delete.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for PreconditionsAddUpdate
        public static void PreconditionsAddUpdate(DataGrid dataGrid, string testCase, Boolean delete = false)
        {
            datagrid1 = dataGrid;
            TextBlock elementID = new TextBlock();
            TextBlock elementDescription = new TextBlock();
            TextBlock elementNumber = new TextBlock();

            for (var i = 0; i < dataGrid.Items.Count; i++)
            {
                var query = string.Empty;
                elementID.Text = string.Empty;
                elementDescription.Text = string.Empty;
                elementNumber.Text = string.Empty;

                if (GetCell(i, 0) != null)
                {
                    elementID = GetCell(i, 0).Content as TextBlock;
                }

                elementNumber = GetCell(i, 1).Content as TextBlock;
                elementDescription = GetCell(i, 2).Content as TextBlock;
                if (elementDescription.Text != string.Empty)
                {
                    if (elementID.Text != string.Empty)
                    {
                        // Update rij in database
                        query = "UPDATE selenium_preconditions SET pre_condition = '";
                        query += elementDescription.Text + "' WHERE id = " + elementID.Text + ";";
                    }
                    else
                    {
                        // Insert rij in database
                        query = "INSERT INTO selenium_preconditions (testcase_name, number, pre_condition) VALUES('";
                        query += testCase + "', '" + elementNumber.Text + "', '" + elementDescription.Text + "');";
                    }

                    GenericDataRead.INUPDEL(query);
                }
                else
                {
                    if (elementID.Text != string.Empty)
                    {
                        // Verwijder rij in database
                        query = "DELETE FROM selenium_preconditions ";
                        query += " WHERE id = " + elementID.Text + ";";
                        GenericDataRead.INUPDEL(query);
                    }
                }

            }
        }

        /// <summary>
        /// Class Preconditions.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Preconditions
        public class Preconditions
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
            /// Gets or sets the number.
            /// </summary>
            /// <value>The number.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for number
            public string number { get; set; }
            /// <summary>
            /// Gets or sets the testcase.
            /// </summary>
            /// <value>The testcase.</value>
            /// <autogeneratedoc />
            /// TODO Edit XML Comment Template for testcase
            public string testcase { get; set; }
        }
    }
}