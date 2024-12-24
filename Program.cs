using System;
using System.Diagnostics;

class Program
{
    private const string src1 = @"C:\Users\Admin\Desktop\2 курс\4.docx";
    private const string src2 = @"C:\Users\Admin\Desktop\2 курс\9.docx";

    private const string dest1 = @"C:\Users\Admin\Desktop\2 курс\copy4.docx";
    private const string dest2 = @"C:\Users\Admin\Desktop\2 курс\copy9.docx";

    static async Task Main(string[] args)
    {
        try
        {
            // Запускаем копирование файлов 
            await Task.WhenAll(CopyFileAsync(src1, dest1), CopyFileAsync(src2, dest2));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    private static async Task CopyFileAsync(string source, string destination)
    {
        // Проверяем исходный файл
        if (File.Exists(source))
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                // Копируем файл
                FileInfo fileInfo = new FileInfo(source);
                await Task.Run(() => fileInfo.CopyTo(destination, true));
                stopwatch.Stop();

                Console.WriteLine($"Файл '{Path.GetFileName(source)}' успешно скопирован в '{destination}'");
                Console.WriteLine($"Время выполнения копирования: {stopwatch.Elapsed}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при копировании файла '{Path.GetFileName(source)}': {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"Файл '{Path.GetFileName(source)}' не найден.");
        }
    }
}
