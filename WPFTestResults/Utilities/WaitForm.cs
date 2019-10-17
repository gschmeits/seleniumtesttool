// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-16-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="WaitForm.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BikeBillWPF2016
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using WPFTestResults.Properties;

    public partial class WaitForm : Form
    {
        public int YPOS;

        public WaitForm(int intPosY)
        {
            this.InitializeComponent();
            this.YPOS = intPosY;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void test_Load(object sender, EventArgs e)
        {
            this.lblTekst.Text = Resources.WaitForm_test_Load_One_moment_please___;
            this.Location = new Point(this.Location.X, this.Location.Y - this.YPOS);
        }
    }
}