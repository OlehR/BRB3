namespace BRB.Forms
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.SystemColors.Info;
            this.btClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClose.Location = new System.Drawing.Point(0, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(238, 295);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btClose);
            this.Menu = this.mainMenu1;
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Button btClose;
    }
}