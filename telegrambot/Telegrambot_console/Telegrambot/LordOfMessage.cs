using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Npgsql;
using System.Reflection.PortableExecutable;
using Newtonsoft.Json.Linq;
using Npgsql.Replication.PgOutput.Messages;
using System.Data;
using System.Text;

namespace Telegrambot
{
        public class LordOfMessage
    {
        public const string ConnString = "Host=192.168.1.100;Username=db_admin;Password=123456;Database=biblio_db";
        public const string FileStorageRoot = "C:\\Users\\xgolen\\Documents\\C#\\BlazorApps\\Biblioheap\\BlazorApps\\";
        public LordOfMessage(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            BotClient = botClient;
            Update = update;
            Client = client;
        }
        public ITelegramBotClient BotClient { get; }
        public Update Update { get; }
        public CancellationToken Client { get; }
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        //обработчик входящих сообщений
        public async void IncomeMessage(ITelegramBotClient botClient, Update update, CancellationToken client)//Logging +
        {
            try{
                    //проверка на ноль
                    if (Update.Message != null)
                    {
                    Logger.Info(@$"TextMessage: {Update.Message.From}");
                        try
                        {
                            await using var conn = new NpgsqlConnection(ConnString);
                            conn.Open();
                            NpgsqlCommand getUser = new NpgsqlCommand($"SELECT searchaction FROM users WHERE username = \'{Update.Message.From}\'", conn);
                            getUser.Prepare();
       
                            await using (NpgsqlDataReader dr = getUser.ExecuteReader())
                            {
                                if (dr.HasRows == true)
                                {
                                    while (dr.Read())
                                    {
                                        Logger.Info("Search by: " + dr.GetString(0));
                                    }
                                }
                                else
                                {
                                    Logger.Info($"Adding new user:{Update.Message.From}");
                                    conn.Close();
                                    try
                                    {
                                        conn.Open();
                                        NpgsqlCommand newUser = new NpgsqlCommand($"INSERT INTO users (username, searchaction) VALUES (\'{Update.Message.From}\', 'book_name')", conn);
                                        int recordAffected = newUser.ExecuteNonQuery();
                                        conn.Close();
                                        if (Convert.ToBoolean(recordAffected))
                                        {
                                            Logger.Warn($"New user {Update.Message.From} is add.");
                                    }
                                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Вы добавлены в базу данных.");
                                        return;
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Error($"New user {Update.Message.From} not added. {ex}");
                                        return;
                                    }                                
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        //Код обработки ошибок
                            Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                            return;
                        }
                        //если ене ноль, запускает проверку типа сообщения
                        await DocTypeChecker(BotClient, Update, Client);
                    }
                    else
                    {
                    //иначе сообщение и выход
                        Logger.Warn(@$"Входящее сообщение не имеет смысловой нагрузки");
                        return;
                    }
            }
            catch (Exception ex) 
            {
                //Код обработки ошибок
#nullable disable
                Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                return;
            }
        }
//распознает тип сообщения текст или документ и делает форк, если тип не указан, то сообщение и выход
        async Task DocTypeChecker(ITelegramBotClient botClient, Update update, CancellationToken client)//Logging +
        {
#nullable disable
            string response = @$"Входящее сообщение от {Update.Message.From} {DateTime.UtcNow} имеет тип {Update.Message.Type}";

            //подключиться к БД и проверить на состояние поиска

            if (Update.Message.Text != null)
            {
                await using var conn = new NpgsqlConnection(ConnString);
                if (Update.Message.Text == "{ Список книг }")
                {
                    conn.Open();
                    NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET searchaction = 'book_name' WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = addBook.ExecuteNonQuery();
                    conn.Close();
                    await ListOfBooks(BotClient, Update, Client);
                    Logger.Info($"DB Update request from {Update.Message.From}");
                    return;
                }
                if (Update.Message.Text == "{ Поиск по жанрам }")
                {
                    conn.Open();
                    NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET searchaction = 'genre' WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = addBook.ExecuteNonQuery();
                    conn.Close();
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Поиск по жанрам", replyMarkup: GetListButton());
                    Logger.Info($"DB Update request from {Update.Message.From}");
                    return;
                }
                if (Update.Message.Text == "{ Поиск по авторам }")
                {
                    conn.Open();
                    NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET searchaction = 'author' WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = addBook.ExecuteNonQuery();
                    conn.Close();
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Поиск по авторам", replyMarkup: GetListButton());
                    Logger.Info($"DB Update request from {Update.Message.From}");
                    return;
                }//{ Открыть/Скачать }
                if (Update.Message.Text == "{ Открыть/Скачать }")
                {
                    string selectBook = string.Empty;
                    string selectBookHref = string.Empty;
                    try
                    {
                        conn.Close();
                        conn.Open();
                        NpgsqlCommand getUser = new NpgsqlCommand($"SELECT * FROM users WHERE username = \'{Update.Message.From}\'", conn);
                        getUser.Prepare();

                        await using (NpgsqlDataReader dr = getUser.ExecuteReader())
                        {
                            if (dr.HasRows == true)
                            {
                                while (dr.Read())
                                {
                                    selectBook = dr.GetString(3);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Код обработки ошибок
                        Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                        return;
                    }
                    try
                    {
                        conn.Close();
                        conn.Open();
                        NpgsqlCommand getBook = new NpgsqlCommand($"SELECT * FROM books WHERE book_name = '{selectBook}'", conn);
                        getBook.Prepare();

                        await using (NpgsqlDataReader dr = getBook.ExecuteReader())
                        {
                            if (dr.HasRows == true)
                            {
                                while (dr.Read())
                                {
                                    selectBookHref = dr.GetString(2);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Код обработки ошибок
                        Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                        return;
                    }
                    conn.Close();
                    conn.Open();
                    NpgsqlCommand setDefaultActBook = new NpgsqlCommand($"UPDATE users SET action_book = 'нет' " +
                                                                    $"WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = setDefaultActBook.ExecuteNonQuery();
                    conn.Close();
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"<a href=\"{selectBookHref}\">{selectBook}</a>", ParseMode.Html, replyMarkup: GetListButton());
                    Logger.Info($"Send {selectBook} reference to {Update.Message.From}");
                    return;
                }//{ Жанр (Ред.) }
                if (Update.Message.Text == "{ Жанр (Ред.) }")
                {
                    conn.Open();
                    NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET action = 'ред_жанр' " +
                                                              $"WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = addBook.ExecuteNonQuery();
                    conn.Close();
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Жанр (Ред.)", replyMarkup: GetListButton());
                    Logger.Info($"DB Update request from {Update.Message.From}");
                    return;
                }//{ Автор (Ред.) }
                if (Update.Message.Text == "{ Автор (Ред.) }")
                {
                    conn.Open();
                    NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET action = 'ред_автора' " +
                                                              $"WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = addBook.ExecuteNonQuery();
                    conn.Close();
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Автор (Ред.)", replyMarkup: GetListButton());
                    Logger.Info($"DB Update request from {Update.Message.From}");
                    return;
                }//{ Описание (Ред.) }
                if (Update.Message.Text == "{ Описание (Ред.) }")
                {
                    conn.Open();
                    NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET action = 'ред_описание' " +
                                                              $"WHERE username = '{Update.Message.From}'", conn);
                    int recordAffected = addBook.ExecuteNonQuery();
                    conn.Close();
                    Logger.Info($"DB Update request from {Update.Message.From}");
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Описание (Ред.)", replyMarkup: GetListButton());
                    return;
                }
                else
                {
                    if (Update.Message.Text.EndsWith(".pdf"))
                    {
                        //устанавливаем экшн с этой книгой
                        try
                        {
                            conn.Open();
                            NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE users SET action_book = '{Update.Message.Text}' " +
                                                                      $"WHERE username = '{Update.Message.From}'", conn);
                            int recordAffected = addBook.ExecuteNonQuery();
                            conn.Close();
                            Logger.Info($"DB Update request from {Update.Message.From}");
                        }
                        catch (Exception ex)
                        {
                            //Код обработки ошибок
                            Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                            return;
                        }
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Это PDF книга", replyMarkup: GetEditButton());
                        return;
                    } 
                    else 
                    {
                        //берем из БД действие и объект
                        string action = string.Empty;
                        string action_book = string.Empty;
                        int recordAffected;
                        try
                        {
                            conn.Close();
                            conn.Open();
                            NpgsqlCommand getUser = new NpgsqlCommand($"SELECT * FROM users WHERE username = \'{Update.Message.From}\'", conn);
                            getUser.Prepare();

                            await using (NpgsqlDataReader dr = getUser.ExecuteReader())
                            {
                                if (dr.HasRows == true)
                                {
                                    while (dr.Read())
                                    {
                                        action = dr.GetString(4);
                                        action_book = dr.GetString(3);
                                    }//ред_жанр ред_автора ред_описание
                                    conn.Close();
                                    conn.Open();
                                    if (action == "ред_жанр")
                                    {
                                        NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE books SET genre = '{Update.Message.Text}' " +
                                                                                  $"WHERE book_name = '{action_book}'", conn);
                                        recordAffected = addBook.ExecuteNonQuery();
                                        conn.Close();
                                        conn.Open();
                                        NpgsqlCommand setDefaultActBook = new NpgsqlCommand($"UPDATE users SET action_book = 'нет' " +
                                                                                        $"WHERE username = '{Update.Message.From}'", conn);
                                        recordAffected = setDefaultActBook.ExecuteNonQuery();
                                        conn.Close();
                                        conn.Open();
                                        NpgsqlCommand setDefaultAction = new NpgsqlCommand($"UPDATE users SET action = 'нет' " +
                                                                                        $"WHERE username = '{Update.Message.From}'", conn);
                                        recordAffected = setDefaultAction.ExecuteNonQuery();
                                        conn.Close();
                                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Жанр изменен", replyMarkup: GetMenuButton());
                                        Logger.Info($"DB Update request from {Update.Message.From}");
                                        return;
                                    }
                                    if (action == "ред_автора")
                                    {
                                        NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE books SET author = '{Update.Message.Text}' " +
                                                                                  $"WHERE book_name = '{action_book}'", conn);
                                        recordAffected = addBook.ExecuteNonQuery();
                                        conn.Close();
                                        conn.Open();
                                        NpgsqlCommand setDefaultActBook = new NpgsqlCommand($"UPDATE users SET action_book = 'нет' " +
                                                                                        $"WHERE username = '{Update.Message.From}'", conn);
                                        recordAffected = setDefaultActBook.ExecuteNonQuery();
                                        conn.Close();
                                        conn.Open();
                                        NpgsqlCommand setDefaultAction = new NpgsqlCommand($"UPDATE users SET action = 'нет' " +
                                                                                        $"WHERE username = '{Update.Message.From}'", conn);
                                        recordAffected = setDefaultAction.ExecuteNonQuery();
                                        conn.Close();
                                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Автор изменен", replyMarkup: GetMenuButton());
                                        Logger.Info($"DB Update request from {Update.Message.From}");
                                        return;
                                    }
                                    if (action == "ред_описание")
                                    {
                                        NpgsqlCommand addBook = new NpgsqlCommand($"UPDATE books SET description = '{Update.Message.Text}' " +
                                                                                  $"WHERE book_name = '{action_book}'", conn);
                                        recordAffected = addBook.ExecuteNonQuery();
                                        conn.Close();
                                        conn.Open();
                                        NpgsqlCommand setDefaultActBook = new NpgsqlCommand($"UPDATE users SET action_book = 'нет' " +
                                                                                            $"WHERE username = '{Update.Message.From}'", conn);
                                        recordAffected = setDefaultActBook.ExecuteNonQuery();
                                        conn.Close();
                                        conn.Open();
                                        NpgsqlCommand setDefaultAction = new NpgsqlCommand($"UPDATE users SET action = 'нет' " +
                                                                                           $"WHERE username = '{Update.Message.From}'", conn);
                                        recordAffected = setDefaultAction.ExecuteNonQuery();
                                        conn.Close();
                                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Описание изменено", replyMarkup: GetMenuButton());
                                        Logger.Info($"DB Update request from {Update.Message.From}");
                                        return;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //Код обработки ошибок
                            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                            Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                            return;
                        }
                        //тут должно приходить название книги, сверяем хвост .pdf
                        await SearchMessage(BotClient, Update, Client);
                        return;
                    }
                }
            }
            if (Update.Message.Document != null)
            {
                Logger.Info($"{response}");
                await DocumentTypeMessage(BotClient, Update, Client);
                return;
            }
            else
            {
                Logger.Warn($"{response} Doctype not support.");
                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, response + " Данный тип не поддерживается.");
                return;
            }
        }
//срабатывает при типе сообщения "Текст"
        async Task SearchMessage(ITelegramBotClient botClient, Update update, CancellationToken client)//Logging +
        {
            await using var conn = new NpgsqlConnection(ConnString);
            conn.Open();
            //определяем тип поиска пользователя
            NpgsqlCommand getUser = new NpgsqlCommand($"SELECT searchaction FROM users WHERE username = \'{Update.Message.From}\'", conn);
            getUser.Prepare();
            await using (NpgsqlDataReader actReader = getUser.ExecuteReader())
            {
                while (actReader.Read())
                {
                    //ПОИСК ПО АВТОРУ
                    if (actReader.GetString(0) == "author")
                    {
                        Logger.Info($"{Update.Message.From} searching by author.");
                        conn.Close();
                        conn.Open();
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"Автор: \"{Update.Message.Text}\"", replyMarkup: GetMenuButton());
                        NpgsqlCommand searchRequest = new NpgsqlCommand($"SELECT * FROM books WHERE author LIKE \'%{Update.Message.Text}%\'", conn);
                        searchRequest.Prepare();
                        await using (NpgsqlDataReader searchReader = searchRequest.ExecuteReader())
                        {
                            Logger.Info($"DB Select request from {Update.Message.From}");
                            if (searchReader.HasRows == true)
                            {
                                StringBuilder bookList = new StringBuilder();
                                int i = 1;
                                while (searchReader.Read())
                                {
                                    bookList.Append($"{i}. `{searchReader.GetString(1).ToString()}`\n" +
                                                    $"Автор: {searchReader.GetString(3).ToString()}\n");
                                    i++;
                                }
                                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, bookList.ToString(), ParseMode.Markdown, replyMarkup: GetMenuButton());
                            }
                            else
                            {
                                conn.Close();
                                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"По запросу \"{Update.Message.Text}\" книги не найдены");
                                return;
                            }
                        }
                        return;
                    }
                    //ПОИСК ПО ЖАНРАМ
                    if (actReader.GetString(0) == "genre")
                    {
                        Logger.Info($"{Update.Message.From} searching by genre.");
                        conn.Close();
                        conn.Open();
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"Жанр: \"{Update.Message.Text}\"", replyMarkup: GetMenuButton());
                        NpgsqlCommand searchRequest = new NpgsqlCommand($"SELECT * FROM books WHERE genre LIKE \'%{Update.Message.Text}%\'", conn);
                        searchRequest.Prepare();
                        await using (NpgsqlDataReader searchReader = searchRequest.ExecuteReader())
                        {
                            Logger.Info($"DB Select request from {Update.Message.From}");
                            if (searchReader.HasRows == true)
                            {
                                StringBuilder bookList = new StringBuilder();
                                int i = 1;
                                while (searchReader.Read())
                                {
                                    bookList.Append($"{i}. `{searchReader.GetString(1).ToString()}`\n" +
                                                    $"Жанр: {searchReader.GetString(4).ToString()}\n");
                                    i++;
                                }
                                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, bookList.ToString(), ParseMode.Markdown, replyMarkup: GetMenuButton());
                            }
                            else
                            {
                                conn.Close();
                                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"По запросу \"{Update.Message.Text}\" книги не найдены");
                                return;
                            }
                        }
                        return;
                    }
                    //ПОИСК ПО НАЗАВАНИЮ
                    if (actReader.GetString(0) == "book_name")
                    {
                        Logger.Info($"{Update.Message.From} searching by book name.");
                        conn.Close();
                        conn.Open();                        
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"Название: \"{Update.Message.Text}\"", replyMarkup: GetMenuButton());
                        NpgsqlCommand searchRequest = new NpgsqlCommand($"SELECT * FROM books WHERE book_name LIKE \'%{Update.Message.Text}%\'", conn);
                        searchRequest.Prepare();
                        await using (NpgsqlDataReader searchReader = searchRequest.ExecuteReader())
                        {
                            Logger.Info($"DB Select request from {Update.Message.From}");
                            if (searchReader.HasRows == true)
                            {
                                StringBuilder bookList = new StringBuilder();
                                int i = 1;
                                while (searchReader.Read())
                                {
                                    bookList.Append($"{i}. `{searchReader.GetString(1).ToString()}`\n");
                                    i++;
                                }
                                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, bookList.ToString(), ParseMode.Markdown, replyMarkup: GetMenuButton());
                            }
                            else
                            {
                                conn.Close();
                                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"По запросу \"{Update.Message.Text}\" книги не найдены");
                                return;
                            }
                        }
                        return;
                    }
                }
            }
        }
//срабатывает при типе сообщения "Документ"
        async Task DocumentTypeMessage(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await AddBook(BotClient, Update, Client);
            return;
        }
//обращается к БД и выдает список книг
        async Task ListOfBooks(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await using var conn = new NpgsqlConnection(ConnString);
            await conn.OpenAsync();
            try
            {
                StringBuilder bookList = new StringBuilder();
                await using (var getBooks = new NpgsqlCommand("SELECT book_name FROM books", conn))
                await using (var readData = await getBooks.ExecuteReaderAsync())
                {
                    int i = 1;
                    while (await readData.ReadAsync())
                    {
                        bookList.Append($"{ i }. `{ readData.GetString(0).ToString() }`\n");
                        i++;
                    }
                    await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, bookList.ToString(), ParseMode.Markdown, replyMarkup: GetMenuButton());
                }
                Logger.Info($"DB Update request from {Update.Message.From}");
                return;
            }
            catch (Exception ex)
            {
                Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, ex.ToString());
                return;
            }
        }
//загрузить книгу
        async Task AddBook(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await using var conn = new NpgsqlConnection(ConnString);
            Stopwatch stopwatch = new Stopwatch();
            string response = $@"Идет проверка книги {Update.Message.Document.FileName}. Ожидайте...";
            await botClient.SendTextMessageAsync(Update.Message.Chat.Id, response);
            var fileInfo = await botClient.GetFileAsync(update.Message.Document.FileId);
            var filePath = fileInfo.FilePath;            
            string destinationFilePath = $@"{FileStorageRoot}Files\pdf\{Update.Message.Document.FileName}";
            string fileName = Update.Message.Document.FileName.ToString();
            string fileHref = @$"https://94.181.94.29:7194/Files/pdf/{Path.GetFileName(Update.Message.Document.FileName).ToString()}";
            string user = Update.Message.From.ToString();
            conn.Close();
            try
            {
                conn.Open();
                NpgsqlCommand getBook = new NpgsqlCommand($"SELECT * FROM books WHERE book_name = \'{ fileName }\'", conn);
                getBook.Prepare();
                Logger.Info($"DB Select request from {Update.Message.From}");
                await using (NpgsqlDataReader dr = getBook.ExecuteReader())
                {
                    if (dr.HasRows == true)
                    {
                        conn.Close();
                        Console.WriteLine("Книга уже существует.");
                    }
                    else
                    {
                        conn.Close();
                        stopwatch.Start();
                        conn.Open();
                        NpgsqlCommand addBook = new NpgsqlCommand($"INSERT INTO books (book_name, href, author, genre, upload_user, description) " +
                                                                  $"VALUES (\'{fileName}\',\'{fileHref}\', 'нет', 'нет', \'{user}\', 'нет')", conn);
                        int recordAffected = addBook.ExecuteNonQuery();
                        Logger.Info($"DB Insert request from {Update.Message.From}");
                        conn.Close();
                        if (Convert.ToBoolean(recordAffected))
                        {
                            Logger.Info($"Add a new book to DB by {Update.Message.From}");
                        }
                        await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                        await botClient.DownloadFileAsync(filePath, fileStream);
                        fileStream.Close();
                        stopwatch.Stop();
                        Logger.Info($"Add a new book to FS by {Update.Message.From}");
                        await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, $"Книга добавлена за {(float)stopwatch.ElapsedMilliseconds / 100} сек.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"{Update.Message.From} DataBase Error. {ex}");
                return;
            }
        }
        //---------НАБОРЫ КНОПОК-----------//

        //Кнопки главного меню
        public IReplyMarkup GetMenuButton()
        {
            var keybuttons = new List<List<KeyboardButton>>
            {
                    new List<KeyboardButton>
                    {
                        new KeyboardButton("{ Список книг }")
                    },
                    new List<KeyboardButton>
                    {
                        new KeyboardButton("{ Поиск по жанрам }"),
                        new KeyboardButton("{ Поиск по авторам }"),
                    }
            };

            return new ReplyKeyboardMarkup(keybuttons);
        }
        public IReplyMarkup GetListButton()
        {
            var keybuttons = new List<KeyboardButton>
            {
              new KeyboardButton("{ Список книг }")
            };
            return new ReplyKeyboardMarkup(keybuttons);
        }
        public IReplyMarkup GetEditButton()
        {
            var keybuttons = new List<List<KeyboardButton>>
            {
                    new List<KeyboardButton>
                    {
                        new KeyboardButton("{ Открыть/Скачать }"),
                        new KeyboardButton("{ Список книг }")
                    },
                    new List<KeyboardButton>
                    {
                        new KeyboardButton("{ Автор (Ред.) }"),
                        new KeyboardButton("{ Жанр (Ред.) }"),
                        new KeyboardButton("{ Описание (Ред.) }")
                    }
            };
            return new ReplyKeyboardMarkup(keybuttons);
        }
    }
}
