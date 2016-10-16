using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponentManual();
            InitializeComponent();
        }
         
        public void InitializeComponentManual()
        {
            res = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imageList.ImageSize = new System.Drawing.Size(Global.icoSize, Global.icoSize);
            this.imageList.Images.Clear();
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_00_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_01_" + Global.icoSize.ToString())));
    
        }
    }
}