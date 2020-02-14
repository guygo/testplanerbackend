using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace JavaCompiler
{
    class ManageJavaFileSystem
    {
        public readonly JavaCode codeFile;

        public ManageJavaFileSystem(string _code,string classname, string path = @"E:\javadir")
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            codeFile = new JavaCode();
            codeFile.className = classname;
            codeFile.filepath = string.Format(@"{0}\{1}.java", path,codeFile.className);
            File.WriteAllText(codeFile.filepath, _code);
            Compile();
        }
        private void Compile()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files\Java\jdk1.8.0_231\bin\javac.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = codeFile.filepath;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            Console.WriteLine(p.StandardError.ReadToEnd());
            p.WaitForExit();
          
           
            
        }
        public void run()
        {
            var outputBuilder = new StringBuilder();
            ProcessStartInfo startInfo = new ProcessStartInfo();
           
            startInfo.FileName = @"C:\Program Files\Java\jdk1.8.0_231\bin\java.exe";
            startInfo.Arguments = Path.GetFileNameWithoutExtension(codeFile.filepath);
            Process p = new Process();
            p.StartInfo = startInfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(codeFile.filepath);
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            Console.WriteLine(p.StandardError.ReadToEnd());
            p.WaitForExit();
        }
    }
}
