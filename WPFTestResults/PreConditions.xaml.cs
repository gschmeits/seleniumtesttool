using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using DataStorage;
using GeneralFunctionality;

namespace WPFTestResults
{
    /// <summary>
    ///     Interaction logic for PreConditions.xaml
    /// </summary>
    public partial class PreConditions : Window
    {
        public PreConditions()
        {
            InitializeComponent();
            var testcasenamen = OverallSettings.applicationName.Split('.');
            testCase = testcasenamen[0];
            LabelTestCaseName.Content = testCase;
            Preconditionses = PreconditionsFactory.GetPreconditions(testCase);

            DataGridPre.ItemsSource = null;
            DataGridPre.ItemsSource = Preconditionses;
        }

        private static List<PreconditionsFactory.Preconditions> Preconditionses { get; set; }
        private static string testCase { get; set; }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            PreconditionsFactory.PreconditionsAddUpdate(DataGridPre, testCase);
            Preconditionses = PreconditionsFactory.GetPreconditions(testCase);
            DataGridPre.ItemsSource = null;
            DataGridPre.ItemsSource = Preconditionses;
            MessageBox.Show("Preconditions are updated!", "Preconditions", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}