using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineRP
{
    public partial class Form1 : Form
    {
        private static string path;
        private bool is_donwloading = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsOnlineRPInstalled())
            {
                DialogResult dr = MessageBox.Show("You already installed Online RP! Open folder?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes) 
                {
                    Process.Start(path);
                }
            } else
            {

            }
        }

        private static bool IsOnlineRPInstalled() 
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\OnlineRP-CitizenPlay")) 
            {
                if (rk != null)
                {
                    Object obj = rk.GetValue("OnlineRP_Path");
                    if (obj != null)
                    {
                        path  = obj.ToString(); //path OnlineRP for Citizen Play
                        return true;
                    }
                }
            }
                return false;
        }
    }
}
