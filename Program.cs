using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Binateq.CommandLine;


namespace ShowQRcodeApp
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main(string[] args)
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var parser = Parser.Simple<CommandLineOptions>()
                               .Named(x => x.DisplayIndex,  "-d", "--display")
                               .Named(x => x.FormMaximize,  "-x", "--maximize")
                               .Named(x => x.FormPosition,  "-p", "--position")
                               .Named(x => x.Topmost,       "-o", "--ontop")
                               .Named(x => x.Mode,          "-m", "--mode")
                               .Named(x => x.Timeout,       "-t", "--timeout")
                               .Named(x => x.Quit,          "-q", "--quit")
                               .Nonamed(x => x.Path);

            try
            {
                var cmlOptions = parser.Parse(args);

                Run(cmlOptions);
            }
            catch (Exception exception)
            {
                string t_Message = "Использование: ShowQRcodeApp.exe <путь-к-файлу> [параметры]" + Environment.NewLine +
                                   Environment.NewLine +
                                   "путь-к-файлу        Путь к изображению или html-файлу в зависимости от режима. Файлы изображения откроются в режиме html." + Environment.NewLine +
                                   Environment.NewLine +
                                   "Параметры:" + Environment.NewLine +
                                   "-m | --mode         Режим работы <img|html> (по умолчанию img)" + Environment.NewLine +
                                   "-d | --display      Индекс дисплея в системе (0)" + Environment.NewLine +
                                   "-o | --ontop        Отображение поверх остальных окон (false) " + Environment.NewLine +
                                   "-t | --timeout      Таймаут закрытия окна в секундах (0 = отключено)" + Environment.NewLine +
                                   "-x | --maximize     Разворачивать окно на весь экран (false)" + Environment.NewLine +
                                   "-p | --position     Позиция окна <top,left[,height,width]>, игнорируется при --maximize" + Environment.NewLine +
                                   "-q | --quit         Закрыть все запущенные копии приложения" + Environment.NewLine +
                                   Environment.NewLine +
                                   "Пример:" + Environment.NewLine +
                                   "ShowQRcodeApp \"d:\\page.html\" -m:html -t:300 -o -p:100,1200,300,300" + Environment.NewLine +
                                   "ShowQRcodeApp \"f:\\image.jpg\" --ontop --display=1 --timeout=300" + Environment.NewLine +
                                   "ShowQRcodeApp --quit";

                MessageBox.Show($"Ошибка:{Environment.NewLine}{exception.Message}{Environment.NewLine}{Environment.NewLine}{t_Message}", $"{Application.ProductName} {Application.ProductVersion}"); ;
            }
        }


        class CommandLineOptions
        {
            public IReadOnlyList<string> Path { get; set; }
            public string Mode { get; set; }
            public int DisplayIndex { get; set; }
            public IEnumerable<int> FormPosition { get; set; }
            public bool FormMaximize { get; set; }
            public int Timeout { get; set; }
            public bool Topmost { get; set; }
            public bool Quit { get; set; }

            public CommandLineOptions()
            {
                DisplayIndex = 0;
                Timeout = 0;
                Topmost = false;
                FormMaximize = false;
                Mode = "img";
            }

        }

        private static void Run(CommandLineOptions options)
        {
            var frm = new frmMain();

            if (options.Quit)
            {
                CloseInstatces();
                return;
            }

            if (options.Path.Count == 0)
                throw new Exception("Не задан путь к файлу");

            WinformExtension.SetPosition(frm, options.DisplayIndex, options.FormMaximize, options.FormPosition);
            WinformExtension.SetTopmost(frm, options.Topmost);

            frm.Mode = options.Mode;
            frm.FilePath = options.Path[0];
            frm.Timeout = options.Timeout;

            Application.Run(frm);
        }

        private static void CloseInstatces()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Equals(Process.GetCurrentProcess().ProcessName) && proc.Id != Process.GetCurrentProcess().Id)
                {
                    proc.Kill();
                }
            }
        }
    }
}
