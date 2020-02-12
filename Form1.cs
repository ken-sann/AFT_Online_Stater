using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFT_Online_Stater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //创建启动对象 
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //设置运行文件 
            startInfo.FileName = "inject.exe";
            //设置启动动作,确保以管理员身份运行 
            startInfo.Verb = "runas";
            startInfo.Arguments = $"-d -k divahook.dll diva.exe";
            //如果不是管理员，则启动UAC 
            System.Diagnostics.Process.Start(startInfo);
            Close();
        }
    }
}
