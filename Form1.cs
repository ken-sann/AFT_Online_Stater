using System;
using System.Diagnostics;
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
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                //设置运行文件 
                FileName = "inject.exe",
                //设置启动动作,确保以管理员身份运行 
                Verb = "runas",
                Arguments = "-d -k divahook.dll diva.exe"
            };
            //如果不是管理员，则启动UAC

            Process[] pro = Process.GetProcesses();//获取已开启的所有进程

            //遍历所有查找到的进程
            foreach (var divaProcess in pro)
            {
                if (divaProcess.ProcessName.ToLower() == "diva")
                {
                    divaProcess.Kill();//结束进程
                }
            }

            Process.Start(startInfo);//启动diva.exe 
            Close();
        }
    }
}
