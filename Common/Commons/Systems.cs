using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;


namespace Common.Commons
{
    public class Systems
    {
        #region 操作系统常用信息获取
        /// <summary>
        /// 获取当前路径
        /// </summary>
        /// <returns></returns>
        public static string GetAppPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\";
            return path.Replace(@"\\", @"\");
        }

        /// <summary>
        /// 获取当前程序名称
        /// </summary>
        /// <returns></returns>
        public static string GetAppName()
        {
            return System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        }

        public static string GetTempPath()
        {
            string path = System.Environment.GetEnvironmentVariable("TEMP");
            return path.Replace(@"\\", @"\") + @"\";
        }

        /// <summary>
        /// 获取本地计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            return System.Environment.MachineName;
        }
        #endregion

        #region 操作系统常用操作
        /// <summary>
        /// 运行外部程序
        /// </summary>
        /// <param name="programFile"></param>
        /// <param name="isWait">是否等待程序运行完毕后再返回</param>
        /// <param name="isWait">是否在后台隐藏执行</param>
        public static bool RunProgram(string programFile, string arguments, bool isWait, bool isHide)
        {
            if (File.Exists(programFile))
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = programFile;
                psi.Arguments = arguments;
                if (isHide)
                    psi.WindowStyle = ProcessWindowStyle.Hidden;

                System.Diagnostics.Process ps = Process.Start(psi);
                if (isWait)
                    ps.WaitForExit();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RunProgram(string programFile)
        {
            return RunProgram(programFile, string.Empty, false, false);
        }

        public static bool RunProgram(string programFile, bool isWait)
        {
            return RunProgram(programFile, string.Empty, isWait, false);
        }

        public static bool RunProgram(string programFile, string arguments)
        {
            return RunProgram(programFile, arguments, false, false);
        }

        /// <summary>
        /// 注册DLL动态库
        /// </summary>
        /// <param name="dllFilePath"></param>
        public static void RegDll(string dllFilePath)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Regsvr32.exe";
            p.StartInfo.Arguments = "/s \"" + dllFilePath + "\"";
            p.StartInfo.ErrorDialog = true;
            p.Start();
        }
        #endregion

        #region 让程序以单一实例运行
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        /// <summary>
        /// 在 main() 中调用：if (!Common.RunSingleInstance()) return;
        /// </summary>
        /// <returns></returns>
        public static bool RunSingleInstance()
        {
            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length > 1)
            {
                Process p = Process.GetCurrentProcess();
                int n = 0;
                if (processes[0].Id == p.Id)
                {
                    n = 1;
                }
                IntPtr hWnd = processes[n].MainWindowHandle;
                if (IsIconic(hWnd))
                {
                    ShowWindowAsync(hWnd, SW_RESTORE);
                }
                SetForegroundWindow(hWnd);
                return false;
            }
            return true;
        }
        #endregion

        public static bool IsExitProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 1)
                return true;
            else
                return false;
        }
        public static void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName == processName || item.ProcessName == processName.Split('.')[0])
                {
                    item.Kill();
                }
            }
        }
    }
}
