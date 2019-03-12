using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace regForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var runKey = hklm.OpenSubKey(@"SOFTWARE\Meleshko", true))
            {
                string[] p5 = (string[])runKey.GetValue("P5", new string[] { "CCCC", "DDD565DDD" });
                string message = "";
                foreach (string str in p5)
                {
                    message += str + "\n";
                }
                MessageBox.Show(message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var runKey = hklm.OpenSubKey(@"SOFTWARE\Meleshko", true))
            {
                runKey.SetValue("P6", new string[] { "Я - активний студент", "кафедри КІ!" }, RegistryValueKind.MultiString);
                MessageBox.Show("parameter has been successfully writed to the registry");
            }

        }
    }
}
