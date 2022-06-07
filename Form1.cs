using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int buttonInt = 0;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );
        public static Form1 form1Instance;
        private Form activeForm;
        private Button currentButton;
        public Panel panel123;

        public void Kekw()
        {
            while (true)
            {
                Console.WriteLine("Hello");
                Thread.Sleep(1000);
                flowLayoutPanel2.BringToFront();

            }
        }

        public Form1()
        {
            InitializeComponent();
            panel123 = panelDesktopPanel;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;

                }
            }
        }
        private void DisableButton()
        {

        }
        public void OpenForm1()
        {
            
            this.panelDesktopPanel.Size = new Size(0, 0);
            panelDesktopPanel.SendToBack();
            panelDesktopPanel.SendToBack();
            flowLayoutPanel2.BringToFront();
            button1.BringToFront();
            //Kekw();
        }
        public void OpenChildForm2(Form childFrom)
        {

            panelDesktopPanel.BringToFront();

            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childFrom;
            childFrom.BringToFront();
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;

            this.panelDesktopPanel.Controls.Add(childFrom);
            this.panelDesktopPanel.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
            button1.BringToFront();
        }
        public void OpenChildForm(Form childFrom)
        {
            
            panelDesktopPanel.BringToFront();
     
            if (activeForm != null)
            {
                activeForm.Close();
            }
            
            activeForm = childFrom;
            childFrom.BringToFront();
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
    
            this.panelDesktopPanel.Controls.Add(childFrom);
            this.panelDesktopPanel.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
            button1.BringToFront();
        }
        public void CloseChildForm(Form childForm)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonInt == 0)
            {
                
                OpenChildForm(new Form2());
                button1.Text = "Close";
                buttonInt = 1;
            }
            else if (buttonInt == 1)
            {
                buttonInt = 0;
                OpenChildForm(new Form1());
                button1.Text = "Open";
            }
            
        }
    }
}
