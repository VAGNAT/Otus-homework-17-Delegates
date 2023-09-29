namespace Otus_homework_17_Delegates
{
    public class FileSearcher
    {
        public event Action<string>? Notify;
        public event EventHandler<FileArgsEventArgs>? FileFound;

        public async Task SearchFiles(string path, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(path))
                {
                    Notify?.Invoke("Директория не существует!");
                    return;
                }

                string[] paths = Directory.GetFiles(path);
                if (paths.Any())
                {
                    IEnumerable<FileArgsEventArgs> files = paths.Select(s => new FileArgsEventArgs() { FileName = s });
                    foreach (var item in files)
                    {
                        if (!cancellationToken.IsCancellationRequested)
                        {
                            FileFound?.Invoke(this, item);
                            Thread.Sleep(100);
                        }
                        else
                        {
                            Notify?.Invoke($"Максимальный элемент: {files.GetMax(CompareMaxFileArgsEventArgs)?.ToString()}");
                            Notify?.Invoke($"Операция прервана!");
                            return;
                        }
                    }
                    Notify?.Invoke($"Максимальный элемент: {files.GetMax(CompareMaxFileArgsEventArgs)?.ToString()}");
                }
                else
                {
                    Notify?.Invoke($"В текущей директории нет файлов!");
                }
            }, cancellationToken);
        }

        private float CompareMaxFileArgsEventArgs(FileArgsEventArgs args) => args.FileName!.Length;
    }
}
