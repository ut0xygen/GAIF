using System.Diagnostics;
using System.IO;
using GAIF;


string PATH_PLUGINS = Path.GetFullPath("./plugins");
string[] files = Directory.GetFiles(PATH_PLUGINS);
string[] libs = Array.FindAll<string>(files, );


// See https://aka.ms/new-console-template for more information
//全てのプロセスを列挙する
foreach (Process p in Process.GetProcesses()) {
  if (p.MainWindowTitle.Length != 0) {
    Console.WriteLine($"{p.Id.ToString().PadRight(7)}[{p.ProcessName}] {p.MainWindowTitle}");
  }
}