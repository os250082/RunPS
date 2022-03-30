using System;
using System.Diagnostics;

namespace PSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunPS(@".\test.ps1", "");
        }

        private static void RunPS(string scriptName, string scriptParameters)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"powershell.exe";

            startInfo.Arguments = scriptName +
                                  " " + scriptParameters;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var errors = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(errors))
                throw (new Exception(errors));
        }
    }
}
