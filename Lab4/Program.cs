using System;
using System.IO;
using System.Runtime.InteropServices;
using McMaster.Extensions.CommandLineUtils;


[Command(Name = "Lab4", Description = "Консольное приложение для запуска лабораторных работ"),
     Subcommand(typeof(VersionCommand)),
     Subcommand(typeof(RunCommand)),
     Subcommand(typeof(SetPathCommand))]
class Program
{
    static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    private void OnExecute(CommandLineApplication app)
    {
        Console.WriteLine("Укажите команду: version, run <lab1|lab2|lab3>, set-path -p <путь>");
        app.ShowHelp();
    }

    private void OnUnknownCommand(CommandLineApplication app)
    {
        Console.WriteLine("Unknown command. Use one of the following:");
        Console.WriteLine(" - version: Displays app version and author");
        Console.WriteLine(" - run: Run a specific lab");
        Console.WriteLine(" - set-path: Set input/output path");
    }
}

[Command(Name = "version", Description = "Показать информацию о программе")]
class VersionCommand
{
    private void OnExecute()
    {
        Console.WriteLine("Lab4 консольное приложение");
        Console.WriteLine("Автор: Влад Штефан");
        Console.WriteLine("Версия: 1.0.0");
    }
}

[Command(Name = "run", Description = "Запустить выбранную лабораторную работу")]
class RunCommand
{
    [Argument(0, Description = "Лабораторная работа для запуска (lab1, lab2, lab3)")]
    public string LabName { get; set; } = string.Empty;

    [Option("-I|--input", Description = "Путь к входному файлу")]
    public string? InputFilePath { get; set; }

    [Option("-o|--output", Description = "Путь к выходному файлу")]
    public string? OutputFilePath { get; set; }

    private void OnExecute()
    {
        if (string.IsNullOrEmpty(LabName))
        {
            Console.WriteLine("Укажите лабораторную работу для запуска: lab1, lab2 или lab3");
            return;
        }

        string inputPath = !string.IsNullOrEmpty(InputFilePath) ? InputFilePath : GetInputPath();
        string outputPath = !string.IsNullOrEmpty(OutputFilePath) ? OutputFilePath : GetOutputPath();

        try
        {
            string input = File.ReadAllText(inputPath);
            string result = LabName.ToLower() switch
            {
                "lab1" => LabRunner.RunLab1(input),
                "lab2" => LabRunner.RunLab2(input),
                "lab3" => LabRunner.RunLab3(input),
                _ => throw new ArgumentException("Указана неверная лабораторная работа.")
            };

            File.WriteAllText(outputPath, result);
            Console.WriteLine(result);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл ввода не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка выполнения: {ex.Message}");
        }
    }

    private string GetInputPath()
    {
        return Environment.GetEnvironmentVariable("LAB_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Lab4", "Input.txt");
    }

    private string GetOutputPath()
    {
        return Environment.GetEnvironmentVariable("LAB_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Lab4", "Output.txt");
    }
}

[Command(Name = "set-path", Description = "Установить путь для файлов ввода и вывода")]
class SetPathCommand
{
    [Option("-p|--path", "Путь к папке для файлов ввода и вывода", CommandOptionType.SingleValue)]
    public string? Path { get; set; }

    private void OnExecute()
    {
        if (string.IsNullOrEmpty(Path))
        {
            Console.WriteLine("Укажите путь с помощью параметра -p.");
            return;
        }

        Environment.SetEnvironmentVariable("LAB_PATH", Path);
        Console.WriteLine($"Путь установлен: {Path}");
    }
}
