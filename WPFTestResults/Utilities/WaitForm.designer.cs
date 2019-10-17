// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 03-16-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="WaitForm.designer.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The BikeBillWPF2016 namespace.
/// </summary>
namespace BikeBillWPF2016
{
    /// <summary>
    /// Class WaitForm.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class WaitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form" />.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTekst = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(71, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTekst
            // 
            this.lblTekst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTekst.ForeColor = System.Drawing.Color.Navy;
            this.lblTekst.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTekst.Location = new System.Drawing.Point(0, 71);
            this.lblTekst.Name = "lblTekst";
            this.lblTekst.Size = new System.Drawing.Size(207, 36);
            this.lblTekst.TabIndex = 1;
            this.lblTekst.Text = "Gegevens worden ";
            this.lblTekst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTekst.Click += new System.EventHandler(this.label1_Click);
            // 
            // WaitForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(207, 106);
            this.ControlBox = false;
            this.Controls.Add(this.lblTekst);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The picture box1
        /// </summary>
        private System.Windows.Forms.PictureBox pictureBox1;
        /// <summary>
        /// The label tekst
        /// </summary>
        private System.Windows.Forms.Label lblTekst;
    }
}