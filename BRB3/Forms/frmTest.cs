using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace BRB.Forms
{
    public partial class frmTest : Form
    {
        int hid = FindWindow("HHTaskBar", ""); // назва TaskBar

        public frmTest()
        {
         
            InitializeComponent();

            //забераємо TaskBar
            ShowWindow(hid, 0);  // SW_HIDE = 0, SW_SHOW = 5, SW_MAXIMIZE = 3, SW_NORMAL = 1
            EnableWindow(hid, false);

            this.Menu = null;
            this.ControlBox = false;
            this.Text = string.Empty;
            this.FormBorderStyle = FormBorderStyle.None; //заголовок
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.TopMost = true;
           
        }

            private void btClose_Click(object sender, EventArgs e)
            {
                ShowWindow(hid, 5);
                EnableWindow(hid, true);

                this.Close();
            }


        //Отображает тем или иным способом окно (в том числе и скрывает его).
        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(int hwnd, int nCmdShow);

        //Делает окно доступным либо недоступным (убрать с экрана либо показать).
        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        public static extern bool EnableWindow(int hwnd, bool enabled);

        //Находит нужное окно по наименованию.
        [DllImport("coredll.dll")]
        public static extern int FindWindow(string className, string windowName);

    }
}