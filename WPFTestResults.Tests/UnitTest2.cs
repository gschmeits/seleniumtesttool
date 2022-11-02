using NUnit.Framework;

namespace WPFTestResults.Tests
{
    [TestFixture]

    public class TestClass_0003_TestCase_Form
    {

        [Test]
        [Category("TestCase_Form_Buttons")]
        public void GetCurrentConfuguredDirs_0()
        {
            // TODO: Add your test code here
            Assert.AreEqual(GeneralFunctionality.Functions.GetCurrentDir(0), @"D:\SeleniumTestTool\Settings\");
        }

        [Test]
        [Category("TestCase_Form_Buttons")]
        public void GetCurrentConfuguredDirs_1()
        {
            // TODO: Add your test code here
            Assert.AreEqual(GeneralFunctionality.Functions.GetCurrentDir(1), @"D:\SeleniumTestTool\Data\");
        }

        [Test]
        [Category("TestCase_Form_Buttons")]
        public void GetCurrentConfuguredDirs_2()
        {
            // TODO: Add your test code here
            Assert.AreEqual(GeneralFunctionality.Functions.GetCurrentDir(2), @"D:\Projects\webdriver.io\test\specs");
        }
    }
}
