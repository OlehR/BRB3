namespace BRB.Forms
{
    partial class frmWaresScan
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
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miSeparator = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.mplDocNum = new System.Windows.Forms.Label();
            this.mplDocNumCapt = new System.Windows.Forms.Label();
            this.mpchBoxAutoScan = new System.Windows.Forms.CheckBox();
            this.mplBorderTop = new System.Windows.Forms.Label();
            this.mplBorderDown = new System.Windows.Forms.Label();
            this.mplBorderLeft = new System.Windows.Forms.Label();
            this.mplBorderRight = new System.Windows.Forms.Label();
            this.mplAddWaresTxt = new System.Windows.Forms.Label();
            this.mplArticle = new System.Windows.Forms.Label();
            this.mplArticleCapt = new System.Windows.Forms.Label();
            this.mplCodeCapt = new System.Windows.Forms.Label();
            this.mplCode = new System.Windows.Forms.Label();
            this.mplName = new System.Windows.Forms.Label();
            this.mplNameCapt = new System.Windows.Forms.Label();
            this.mplNameCaptB = new System.Windows.Forms.Label();
            this.mplTemplCapt = new System.Windows.Forms.Label();
            this.mplQtyTempl = new System.Windows.Forms.Label();
            this.mplAUTempl = new System.Windows.Forms.Label();
            this.mplNowCapt = new System.Windows.Forms.Label();
            this.mplQtyNow = new System.Windows.Forms.Label();
            this.mplDateReal = new System.Windows.Forms.Label();
            this.mptbAddQtyCapt = new System.Windows.Forms.Label();
            this.mptbAddPriceCapt = new System.Windows.Forms.Label();
            this.mptbAddQty = new System.Windows.Forms.TextBox();
            this.mptbAddPrice = new System.Windows.Forms.TextBox();
            this.mpbtnAdd = new System.Windows.Forms.Button();
            this.mpbtnCancel = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mplCoef = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            // 
            // miMovements
            // 
            this.miMovements.MenuItems.Add(this.miExit);
            this.miMovements.Text = "Додатково";
            // 
            // miExit
            // 
            this.miExit.Text = "Вихід";
            this.miExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // miSeparator
            // 
            this.miSeparator.Text = "";
            // 
            // labelLeft
            // 
            this.labelLeft.BackColor = System.Drawing.SystemColors.Window;
            this.labelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLeft.Location = new System.Drawing.Point(0, 0);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(1, 295);
            // 
            // labelRigth
            // 
            this.labelRigth.BackColor = System.Drawing.SystemColors.Window;
            this.labelRigth.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelRigth.Location = new System.Drawing.Point(237, 0);
            this.labelRigth.Name = "labelRigth";
            this.labelRigth.Size = new System.Drawing.Size(1, 295);
            // 
            // labelTop
            // 
            this.labelTop.BackColor = System.Drawing.SystemColors.Window;
            this.labelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTop.Location = new System.Drawing.Point(1, 0);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(236, 1);
            // 
            // labelDown
            // 
            this.labelDown.BackColor = System.Drawing.SystemColors.Window;
            this.labelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDown.Location = new System.Drawing.Point(1, 294);
            this.labelDown.Name = "labelDown";
            this.labelDown.Size = new System.Drawing.Size(236, 1);
            // 
            // mplDocNum
            // 
            this.mplDocNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplDocNum.BackColor = System.Drawing.Color.Gainsboro;
            this.mplDocNum.Location = new System.Drawing.Point(88, 2);
            this.mplDocNum.Name = "mplDocNum";
            this.mplDocNum.Size = new System.Drawing.Size(66, 20);
            // 
            // mplDocNumCapt
            // 
            this.mplDocNumCapt.Location = new System.Drawing.Point(0, 2);
            this.mplDocNumCapt.Name = "mplDocNumCapt";
            this.mplDocNumCapt.Size = new System.Drawing.Size(86, 20);
            this.mplDocNumCapt.Text = "№ накладної:";
            this.mplDocNumCapt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mpchBoxAutoScan
            // 
            this.mpchBoxAutoScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mpchBoxAutoScan.Checked = true;
            this.mpchBoxAutoScan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mpchBoxAutoScan.Enabled = false;
            this.mpchBoxAutoScan.Location = new System.Drawing.Point(156, 2);
            this.mpchBoxAutoScan.Name = "mpchBoxAutoScan";
            this.mpchBoxAutoScan.Size = new System.Drawing.Size(82, 20);
            this.mpchBoxAutoScan.TabIndex = 0;
            this.mpchBoxAutoScan.Text = "АвтоЗбер";
            // 
            // mplBorderTop
            // 
            this.mplBorderTop.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderTop.Location = new System.Drawing.Point(1, 32);
            this.mplBorderTop.Name = "mplBorderTop";
            this.mplBorderTop.Size = new System.Drawing.Size(235, 1);
            // 
            // mplBorderDown
            // 
            this.mplBorderDown.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderDown.Location = new System.Drawing.Point(1, 263);
            this.mplBorderDown.Name = "mplBorderDown";
            this.mplBorderDown.Size = new System.Drawing.Size(235, 1);
            // 
            // mplBorderLeft
            // 
            this.mplBorderLeft.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderLeft.Location = new System.Drawing.Point(1, 32);
            this.mplBorderLeft.Name = "mplBorderLeft";
            this.mplBorderLeft.Size = new System.Drawing.Size(1, 231);
            // 
            // mplBorderRight
            // 
            this.mplBorderRight.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderRight.Location = new System.Drawing.Point(235, 32);
            this.mplBorderRight.Name = "mplBorderRight";
            this.mplBorderRight.Size = new System.Drawing.Size(1, 231);
            // 
            // mplAddWaresTxt
            // 
            this.mplAddWaresTxt.Location = new System.Drawing.Point(5, 23);
            this.mplAddWaresTxt.Name = "mplAddWaresTxt";
            this.mplAddWaresTxt.Size = new System.Drawing.Size(126, 18);
            this.mplAddWaresTxt.Text = "Додавання товару:";
            this.mplAddWaresTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mplArticle
            // 
            this.mplArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplArticle.BackColor = System.Drawing.Color.Gainsboro;
            this.mplArticle.Location = new System.Drawing.Point(89, 43);
            this.mplArticle.Name = "mplArticle";
            this.mplArticle.Size = new System.Drawing.Size(145, 20);
            // 
            // mplArticleCapt
            // 
            this.mplArticleCapt.Location = new System.Drawing.Point(19, 43);
            this.mplArticleCapt.Name = "mplArticleCapt";
            this.mplArticleCapt.Size = new System.Drawing.Size(63, 20);
            this.mplArticleCapt.Text = "Артикул:";
            this.mplArticleCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplCodeCapt
            // 
            this.mplCodeCapt.Location = new System.Drawing.Point(4, 66);
            this.mplCodeCapt.Name = "mplCodeCapt";
            this.mplCodeCapt.Size = new System.Drawing.Size(79, 20);
            this.mplCodeCapt.Text = "Штрих-код:";
            this.mplCodeCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplCode
            // 
            this.mplCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplCode.BackColor = System.Drawing.Color.Gainsboro;
            this.mplCode.Location = new System.Drawing.Point(89, 66);
            this.mplCode.Name = "mplCode";
            this.mplCode.Size = new System.Drawing.Size(145, 20);
            // 
            // mplName
            // 
            this.mplName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplName.BackColor = System.Drawing.Color.Gainsboro;
            this.mplName.Location = new System.Drawing.Point(4, 89);
            this.mplName.Name = "mplName";
            this.mplName.Size = new System.Drawing.Size(230, 53);
            // 
            // mplNameCapt
            // 
            this.mplNameCapt.Location = new System.Drawing.Point(4, 89);
            this.mplNameCapt.Name = "mplNameCapt";
            this.mplNameCapt.Size = new System.Drawing.Size(79, 20);
            this.mplNameCapt.Text = "Назва:";
            this.mplNameCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplNameCaptB
            // 
            this.mplNameCaptB.Location = new System.Drawing.Point(4, 89);
            this.mplNameCaptB.Name = "mplNameCaptB";
            this.mplNameCaptB.Size = new System.Drawing.Size(85, 20);
            // 
            // mplTemplCapt
            // 
            this.mplTemplCapt.Location = new System.Drawing.Point(3, 145);
            this.mplTemplCapt.Name = "mplTemplCapt";
            this.mplTemplCapt.Size = new System.Drawing.Size(68, 20);
            this.mplTemplCapt.Text = "Очікуємо:";
            this.mplTemplCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplQtyTempl
            // 
            this.mplQtyTempl.BackColor = System.Drawing.Color.Gainsboro;
            this.mplQtyTempl.Location = new System.Drawing.Point(73, 145);
            this.mplQtyTempl.Name = "mplQtyTempl";
            this.mplQtyTempl.Size = new System.Drawing.Size(56, 20);
            // 
            // mplAUTempl
            // 
            this.mplAUTempl.BackColor = System.Drawing.Color.Gainsboro;
            this.mplAUTempl.Location = new System.Drawing.Point(133, 145);
            this.mplAUTempl.Name = "mplAUTempl";
            this.mplAUTempl.Size = new System.Drawing.Size(100, 20);
            // 
            // mplNowCapt
            // 
            this.mplNowCapt.Location = new System.Drawing.Point(4, 168);
            this.mplNowCapt.Name = "mplNowCapt";
            this.mplNowCapt.Size = new System.Drawing.Size(68, 20);
            this.mplNowCapt.Text = "Текуче:";
            this.mplNowCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplQtyNow
            // 
            this.mplQtyNow.BackColor = System.Drawing.Color.Gainsboro;
            this.mplQtyNow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.mplQtyNow.Location = new System.Drawing.Point(73, 168);
            this.mplQtyNow.Name = "mplQtyNow";
            this.mplQtyNow.Size = new System.Drawing.Size(56, 20);
            // 
            // mplDateReal
            // 
            this.mplDateReal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplDateReal.BackColor = System.Drawing.Color.Gainsboro;
            this.mplDateReal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.mplDateReal.Location = new System.Drawing.Point(133, 168);
            this.mplDateReal.Name = "mplDateReal";
            this.mplDateReal.Size = new System.Drawing.Size(100, 20);
            // 
            // mptbAddQtyCapt
            // 
            this.mptbAddQtyCapt.Location = new System.Drawing.Point(2, 193);
            this.mptbAddQtyCapt.Name = "mptbAddQtyCapt";
            this.mptbAddQtyCapt.Size = new System.Drawing.Size(50, 20);
            this.mptbAddQtyCapt.Text = "Додати:";
            this.mptbAddQtyCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mptbAddPriceCapt
            // 
            this.mptbAddPriceCapt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mptbAddPriceCapt.Location = new System.Drawing.Point(139, 193);
            this.mptbAddPriceCapt.Name = "mptbAddPriceCapt";
            this.mptbAddPriceCapt.Size = new System.Drawing.Size(35, 20);
            this.mptbAddPriceCapt.Text = "Ціна:";
            this.mptbAddPriceCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mptbAddQty
            // 
            this.mptbAddQty.Location = new System.Drawing.Point(52, 191);
            this.mptbAddQty.Name = "mptbAddQty";
            this.mptbAddQty.Size = new System.Drawing.Size(55, 23);
            this.mptbAddQty.TabIndex = 1;
            // 
            // mptbAddPrice
            // 
            this.mptbAddPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mptbAddPrice.Location = new System.Drawing.Point(175, 191);
            this.mptbAddPrice.Name = "mptbAddPrice";
            this.mptbAddPrice.Size = new System.Drawing.Size(58, 23);
            this.mptbAddPrice.TabIndex = 2;
            // 
            // mpbtnAdd
            // 
            this.mpbtnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mpbtnAdd.Location = new System.Drawing.Point(3, 216);
            this.mpbtnAdd.Name = "mpbtnAdd";
            this.mpbtnAdd.Size = new System.Drawing.Size(141, 20);
            this.mpbtnAdd.TabIndex = 4;
            this.mpbtnAdd.Text = "Додати товар";
            this.mpbtnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mpbtnCancel
            // 
            this.mpbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mpbtnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.mpbtnCancel.Location = new System.Drawing.Point(146, 216);
            this.mpbtnCancel.Name = "mpbtnCancel";
            this.mpbtnCancel.Size = new System.Drawing.Size(86, 20);
            this.mpbtnCancel.TabIndex = 5;
            this.mpbtnCancel.Text = "Відміна";
            this.mpbtnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mplCoef);
            this.mainPanel.Controls.Add(this.mplDocNumCapt);
            this.mainPanel.Controls.Add(this.mplDocNum);
            this.mainPanel.Controls.Add(this.mpchBoxAutoScan);
            this.mainPanel.Controls.Add(this.mplBorderLeft);
            this.mainPanel.Controls.Add(this.mplBorderRight);
            this.mainPanel.Controls.Add(this.mplAddWaresTxt);
            this.mainPanel.Controls.Add(this.mplArticleCapt);
            this.mainPanel.Controls.Add(this.mplArticle);
            this.mainPanel.Controls.Add(this.mplCodeCapt);
            this.mainPanel.Controls.Add(this.mplCode);
            this.mainPanel.Controls.Add(this.mplNameCapt);
            this.mainPanel.Controls.Add(this.mplNameCaptB);
            this.mainPanel.Controls.Add(this.mplName);
            this.mainPanel.Controls.Add(this.mplTemplCapt);
            this.mainPanel.Controls.Add(this.mplQtyTempl);
            this.mainPanel.Controls.Add(this.mplAUTempl);
            this.mainPanel.Controls.Add(this.mplNowCapt);
            this.mainPanel.Controls.Add(this.mplQtyNow);
            this.mainPanel.Controls.Add(this.mplDateReal);
            this.mainPanel.Controls.Add(this.mptbAddQtyCapt);
            this.mainPanel.Controls.Add(this.mptbAddQty);
            this.mainPanel.Controls.Add(this.mptbAddPrice);
            this.mainPanel.Controls.Add(this.mptbAddPriceCapt);
            this.mainPanel.Controls.Add(this.mpbtnAdd);
            this.mainPanel.Controls.Add(this.mpbtnCancel);
            this.mainPanel.Controls.Add(this.mplBorderTop);
            this.mainPanel.Controls.Add(this.mplBorderDown);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            // 
            // mplCoef
            // 
            this.mplCoef.BackColor = System.Drawing.Color.LimeGreen;
            this.mplCoef.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.mplCoef.Location = new System.Drawing.Point(108, 193);
            this.mplCoef.Name = "mplCoef";
            this.mplCoef.Size = new System.Drawing.Size(32, 18);
            this.mplCoef.Text = "x1000";
            // 
            // frmWaresScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRigth);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmWaresScan";
            this.Load += new System.EventHandler(this.frmWaresScan_Load);
            this.Closed += new System.EventHandler(this.frmWaresScan_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmWaresScan_Closing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WaresScan_KeyUp);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRigth;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelDown;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem miMovements;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.MenuItem miSeparator;
        private System.Windows.Forms.Label mplDocNum;
        private System.Windows.Forms.Label mplDocNumCapt;
        private System.Windows.Forms.CheckBox mpchBoxAutoScan;
        private System.Windows.Forms.Label mplBorderTop;
        private System.Windows.Forms.Label mplBorderDown;
        private System.Windows.Forms.Label mplBorderLeft;
        private System.Windows.Forms.Label mplBorderRight;
        private System.Windows.Forms.Label mplAddWaresTxt;
        private System.Windows.Forms.Label mplArticleCapt;
        private System.Windows.Forms.Label mplArticle;
        private System.Windows.Forms.Label mplCode;
        private System.Windows.Forms.Label mplCodeCapt;
        private System.Windows.Forms.Label mplName;
        private System.Windows.Forms.Label mplNameCapt;
        private System.Windows.Forms.Label mplNameCaptB;
        private System.Windows.Forms.Label mplTemplCapt;
        private System.Windows.Forms.Label mplQtyTempl;
        private System.Windows.Forms.Label mplAUTempl;
        private System.Windows.Forms.Label mplNowCapt;
        private System.Windows.Forms.Label mplQtyNow;
        private System.Windows.Forms.Label mplDateReal;
        private System.Windows.Forms.Label mptbAddQtyCapt;
        private System.Windows.Forms.Label mptbAddPriceCapt;
        private System.Windows.Forms.TextBox mptbAddQty;
        private System.Windows.Forms.TextBox mptbAddPrice;
        private System.Windows.Forms.Button mpbtnAdd;
        private System.Windows.Forms.Button mpbtnCancel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label mplCoef;
    }
}