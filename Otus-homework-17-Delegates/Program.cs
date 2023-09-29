using Otus_homework_17_Delegates;

Console.WriteLine("Введите путь к директории:");
string? path = Console.ReadLine();
void DisplayMessage(string message) => Console.WriteLine(message);
void FileFoundMessage(object sender, FileArgsEventArgs fileArgs) => Console.WriteLine($"Найден файл: {fileArgs.FileName}");

CancellationTokenSource cancelTokenSource = new();
CancellationToken token = cancelTokenSource.Token;

FileSearcher fileSearcher = new();
fileSearcher.FileFound += FileFoundMessage!;
fileSearcher.Notify += DisplayMessage;
fileSearcher.SearchFiles(path, token);
Thread.Sleep(150);
cancelTokenSource.Cancel();
Console.ReadKey();
