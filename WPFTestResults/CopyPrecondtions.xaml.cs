using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataStorage;
using MySql.Data.MySqlClient;

namespace WPFTestResults
{
    /// <summary>
    ///     Interaction logic for CopyPrecondtions.xaml
    /// </summary>
    public partial class CopyPrecondtions : Window
    {
        public CopyPrecondtions()
        {
            InitializeComponent();
            DataGridPre.Visibility = Visibility.Hidden;
            StackPanelFromUpto.Visibility = Visibility.Hidden;
            ButtonCopy.IsEnabled = false;
        }

        private static List<PreconditionsFactory.Preconditions> Preconditionses { get; set; }
        private static string testCase { get; set; }

        private void ButtonGetTestSetClick(object sender, RoutedEventArgs e)
        {
            DataGridPre.Visibility = Visibility.Hidden;
            StackPanelFromUpto.Visibility = Visibility.Hidden;
            ButtonCopy.IsEnabled = false;
            VersionClass.OpenBestand();
            var bestandsnaam = VersionClass.Bestandsnaam;
            LabelTestSource.Content = bestandsnaam;
            TextBoxSource.Text = bestandsnaam;
            testCase = bestandsnaam;
            //LabelTestCaseName.Content = testCase;
            Preconditionses = PreconditionsFactory.GetPreconditions(testCase);

            if (Preconditionses.Count > 0)
            {
                DataGridPre.ItemsSource = null;
                DataGridPre.ItemsSource = Preconditionses;
                DataGridPre.Visibility = Visibility.Visible;
                ButtonCopy.IsEnabled = true;
            }
            else
            {
                MessageBox.Show(
                    "There are no Preconditions for the selected TestCase!!!\r\nPlease choose another TestCase.",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LabelTestSource.Content = string.Empty;
            }
        }

        private void ButtonSetTestSetClick(object sender, RoutedEventArgs e)
        {
            VersionClass.OpenBestand();
            var bestandsnaam = VersionClass.Bestandsnaam;
            LabelTestDestination.Content = bestandsnaam;
            TextBoxDestination.Text = bestandsnaam;
            StackPanelFromUpto.Visibility = Visibility.Visible;
            ButtonCopy.IsEnabled = true;
        }

        private void ButtonCopyClick(object sender, RoutedEventArgs e)
        {
            if (LabelTestSource.Content.ToString().Trim().ToLower()
                == LabelTestDestination.Content.ToString().Trim().ToLower())
            {
                MessageBox.Show(
                    "Source file and Destination can not be the same TestCase!!!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LabelTestSource.Content = string.Empty;
                LabelTestDestination.Content = string.Empty;
                StackPanelFromUpto.Visibility = Visibility.Hidden;
            }

            else if (txtFrom.Text != string.Empty && txtUpto.Text != string.Empty &&
                     Convert.ToInt64(txtFrom.Text) > Convert.ToInt64(txtUpto.Text))
            {
                MessageBox.Show(
                    "The from number can not be higher as the up to number.!!!",
                    "Message",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                txtFrom.Text = string.Empty;
                txtUpto.Text = string.Empty;
            }
            else
            {
                var que = string.Empty;
                que += "SELECT number, ";
                que += "testcase_name, ";
                que += "pre_condition ";
                que += "FROM selenium_preconditions ";
                que += "WHERE testcase_name = '" + TextBoxSource.Text + "' ";

                if (txtFrom.Text != string.Empty) que += " AND number >= " + txtFrom.Text;

                if (txtUpto.Text != string.Empty) que += " AND number <=" + txtUpto.Text;

                que += " ORDER BY number;";
                var dataTableSource = General.ExecuteQueryCommandReturnTable(que);
                var ok = false;
                if (dataTableSource.Rows.Count > 0)
                {
                    try
                    {
                        using (new PleaseWait())
                        {
                            for (var i = 0; i < dataTableSource.Rows.Count; i++)
                            {
                                que = string.Empty;
                                que += "INSERT INTO selenium_preconditions ";
                                que += "(number, ";
                                que += "testcase_name, ";
                                que += "pre_condition) ";
                                que += "VALUES (";
                                que += Convert.ToInt32(
                                           MySqlHelper.EscapeString(dataTableSource.Rows[i]["number"].ToString())) +
                                       ", ";
                                que += "'" + TextBoxDestination.Text + "', '";
                                que += MySqlHelper.EscapeString(dataTableSource.Rows[i]["pre_condition"].ToString()) +
                                       "');";

                                General.LogMessage( que, 1);
                                General.ExecuteQueryCommand(que);
                            }
                        }

                        ok = true;
                    }
                    catch (Exception ex)
                    {
                        General.LogMessage(ex.Message + "\r\n\r\n" + ex.StackTrace + "\r\n\r\n" + ex.Source, 4);

                        MessageBox.Show(
                            "Selected Preconditions are NOT copied to the selected TestCase!!!",
                            "Message",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }


                    if (ok)
                    {
                        MessageBox.Show(
                            "Selected Preconditions are copied to the selected TestCase!!!",
                            "Message",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                        Close();
                    }
                    else
                    {
                        LabelTestSource.Content = string.Empty;
                        LabelTestDestination.Content = string.Empty;
                        TextBoxDestination.Text = string.Empty;
                        TextBoxSource.Text = string.Empty;
                        ButtonCopy.IsEnabled = false;
                    }
                }
            }
        }

        private void ButtonDatabaseConnectionCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxtFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TxtUpto_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBoxDestinationTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBoxSourceTextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}