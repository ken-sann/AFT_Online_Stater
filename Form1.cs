using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace AFT_Online_Stater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static void CreateShortcut(string directory, string shortcutName, string targetPath,
            string description = null, string iconLocation = null)
        {
            string shortcutPath = Path.Combine(directory, string.Format("{0}.lnk", shortcutName));
            if (!System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);//创建快捷方式对象
                shortcut.TargetPath = targetPath;//指定目标路径
                shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);//设置起始位置
                shortcut.WindowStyle = 1;//设置运行方式，默认为常规窗口
                shortcut.Description = description;//设置备注
                shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;//设置图标路径
                shortcut.Save();//保存快捷方式
            }
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
            try
            {
                CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "AFT联机启动器", Process.GetCurrentProcess().MainModule.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("创建桌面图标失败");
                throw;
            }
            Process.Start(startInfo);//启动diva.exe 
            Close();
        }
    }
}
