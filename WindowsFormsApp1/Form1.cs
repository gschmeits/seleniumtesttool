namespace WindowsFormsApp1
{
    using System.Windows.Forms;

    using SeleniumTest;

    public partial class Form1 : Form
    {
        private SeleniumTests tests = new SeleniumTests();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.tests.Initialize();
            this.tests.T001_TestMethod1();
            this.tests.T002_TestMethod1();
            this.tests.T003_TestMethod1();
            this.tests.T004_TestMethod1();
            this.tests.StopExecution();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}