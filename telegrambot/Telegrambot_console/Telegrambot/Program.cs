using System.Diagnostics;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


//950 165-51-81
internal class Program
{
    public static string filestorage = "C:\\Users\\xgolen\\Documents\\C#\\BlazorApps\\Biblioheap\\BlazorApps\\Files\\";
    private static void Main(string[] args)
    {
        using var cts = new CancellationTokenSource();

        var client = new TelegramBotClient("5789379747:AAGtUho2m0hklh0f05Ri1KJrES9HMxif_NE");

        client.StartReceiving(Update, Error);

        Console.ReadLine();
    }



    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken client)
    {

        var message = update.Message;
#nullable disable
        if(message.Text != null)
        {
            if (message.Text.ToLower().Contains("ку"))
            {
                string response = "куууу";
                await botClient.SendTextMessageAsync(message.Chat.Id, response);
                return;
            }
            if (message.Text.ToLower().Contains("книги"))
            {

                string response =   $"1. Книга 1\n" +
                                    $"2. Книга 2\n" +
                                    $"2. Книга 3\n";

                await botClient.SendTextMessageAsync(message.Chat.Id, response, ParseMode.Html);
                return;
            }
            
        }
        if (message.Document != null)
        {
            if(message.Document.MimeType == "application/pdf")
            {
                Stopwatch stopwatch = new Stopwatch();

                //добавить проверку на существование имени
                string response = $@"Будет загружена PDF книга с названием {message.Document.FileName}. Ожидайте...";
                await botClient.SendTextMessageAsync(message.Chat.Id, response);

                var fieldId = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(fieldId);
                var filePath = fileInfo.FilePath;

                string destinationFilePath = $@"{filestorage}\pdf\{message.Document.FileName}";

                stopwatch.Start();

                await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                await botClient.DownloadFileAsync(filePath, fileStream);
                fileStream.Close();

                stopwatch.Stop();

                response = $@"Добавление книги заняло {(float)stopwatch.ElapsedMilliseconds / 100} сек.";
                await botClient.SendTextMessageAsync(message.Chat.Id, response);
                return;
            }
            if (message.Document.MimeType == "image/jpeg")
            {
                Stopwatch stopwatch = new Stopwatch();

                //добавить проверку на существование имени
                string response = $@"Будет загружено изображение с названием {message.Document.FileName}. Ожидайте...";
                await botClient.SendTextMessageAsync(message.Chat.Id, response);

                var fieldId = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(fieldId);
                var filePath = fileInfo.FilePath;

                string destinationFilePath = $@"{filestorage}\img\{message.Document.FileName}";

                stopwatch.Start();

                await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                await botClient.DownloadFileAsync(filePath, fileStream);
                fileStream.Close();

                stopwatch.Stop();

                response = $@"Добавление изображения заняло {(float)stopwatch.ElapsedMilliseconds / 100} сек.";
                await botClient.SendTextMessageAsync(message.Chat.Id, response);
                return;
            }
            else
            {
                string response = $@"Формат загружамого: {message.Document.MimeType}. Пока не поддерживается. Увы :(";
                await botClient.SendTextMessageAsync(message.Chat.Id, response);
            }
        }
        if (message.Photo != null)
        {
            Stopwatch stopwatch = new Stopwatch();

            //добавить проверку на существование имени
            string response = $@"Будет загружена фоточка с названием {message.Document.FileName}. Ожидайте...";
            await botClient.SendTextMessageAsync(message.Chat.Id, response);

            var fieldId = update.Message.Document.FileId;
            var fileInfo = await botClient.GetFileAsync(fieldId);
            var filePath = fileInfo.FilePath;

            string destinationFilePath = $@"{filestorage}\img\{message.Document.FileName}";

            stopwatch.Start();

            await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
            await botClient.DownloadFileAsync(filePath, fileStream);
            fileStream.Close();

            stopwatch.Stop();

            response = $@"Добавление фотки заняло {(float)stopwatch.ElapsedMilliseconds / 100} сек.";
            await botClient.SendTextMessageAsync(message.Chat.Id, response);
            return;
        }
    }
    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }

}