using System.Diagnostics;

const string triangleTypeCheckAppName = "C:\\Users\\user\\source\\repos\\TIOPO\\lab1\\TriangleCheck\\TriangleCheck\\bin\\Debug\\net6.0\\TriangleCheck.exe";
const string outputResultFileName = "result.txt";


Console.WriteLine("Enter the file path");
string? pathToInpFile = Console.ReadLine();
if (!File.Exists(pathToInpFile))
{
    Console.WriteLine("Error open file.");
    return;
}
using StreamReader sr = new(pathToInpFile);
using StreamWriter sw = new(outputResultFileName);

string? inputArgs = "";
while ((inputArgs = sr.ReadLine()) != null)
{
    try
    {
        string[] testArgs = inputArgs.Split(' ');
        if (testArgs.Length != 4) throw new ArgumentException();        
        var startInfo = new ProcessStartInfo
        {
            FileName = triangleTypeCheckAppName,
            Arguments = $"{testArgs[0]} {testArgs[1]} {testArgs[2]}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        using Process? proc = Process.Start(startInfo);
        if (proc != null)
        {
            while (!proc.StandardOutput.EndOfStream)
            {
                string? result = proc.StandardOutput.ReadLine();

                string outputRes = (testArgs[3] == result) ? "success" : "error";

                sw.WriteLine(outputRes);
            }
        }
    }
    catch (Exception)
    {
        sw.WriteLine("error");
    }
}
/*
struct TestCase
{
    public string a;
    public string b;
    public string c;
    public string result;
}
*/
//C:\Users\user\source\repos\TIOPO\lab1\TriangleCheck\tests\TestSuccesCase.txt
//C:\Users\user\source\repos\TIOPO\lab1\TriangleCheck\tests\TestErrorCase.txt