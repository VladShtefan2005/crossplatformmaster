using System.Diagnostics;
using System.Runtime.InteropServices;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        private string RunCommand(string command)
        {
            string outputExecute;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                outputExecute = ExecuteCommand("cmd.exe", $"/c {command}");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                outputExecute = ExecuteCommand("/bin/bash", $"-c \"{command}\"");
            }
            else
            {
                outputExecute = "Unsupported operating system";
            }
            return outputExecute;
        }

        private string ExecuteCommand(string shell, string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = shell,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..")
            };
            string output, error;
            using (var process = Process.Start(processInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    return $"Error: {error}";
                }
            }
            return output;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RunLab(int labNumber)
        {
            string output = RunCommand($"dotnet build Build.proj -p:Solution=Lab{labNumber} -t:Run");
            return Content(output); // Display the result on the page
        }

        [HttpGet]
        public IActionResult BuildLab(int labNumber)
        {
            string output = RunCommand($"dotnet build Build.proj -p:Solution=Lab{labNumber} -t:Build");
            return Content(output); // Display the result on the page
        }

        [HttpGet]
        public IActionResult TestLab(int labNumber)
        {
            string output = RunCommand($"dotnet build Build.proj -p:Solution=Lab{labNumber} -t:Test");
            return Content(output); // Display the result on the page
        }
    }
}

