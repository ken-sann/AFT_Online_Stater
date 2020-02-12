<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        {/*
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    Arguments = "ipconfig/flushdns",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.WaitForExit();
            process.Close();*/
            //创建启动对象 
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                //设置运行文件 
                FileName = "inject.exe",
                //设置启动动作,确保以管理员身份运行 
                Verb = "runas",
                Arguments = $"-d -k divahook.dll diva.exe"
            };
            //如果不是管理员，则启动UAC 
            Process.Start(startInfo); 
            Close();
        }
    }
}
=======
﻿using System;
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
                Arguments = $"-d -k divahook.dll diva.exe"
            };
            //如果不是管理员，则启动UAC

            Process[] pro = Process.GetProcesses();//获取已开启的所有进程

            //遍历所有查找到的进程

            for (int i = 0; i < pro.Length; i++)
            {

                //判断此进程是否是要查找的进程
                if (pro[i].ProcessName.ToString().ToLower() == "diva")
                {
                    pro[i].Kill();//结束进程
                }
            }
            Process.Start(startInfo);//启动diva.exe 
            Close();
        }
    }
}
>>>>>>> 23f92b2769af8b38f1b16b0c352cec72aebacc8e
