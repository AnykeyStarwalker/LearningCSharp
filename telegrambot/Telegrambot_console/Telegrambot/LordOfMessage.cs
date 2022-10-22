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

namespace Telegrambot
{
    public class LordOfMessage
    {
        //тексты кнопок
        private const string TEXT_1 = "B_PUSH_1";
        private const string TEXT_2 = "B_PUSH_2";
        private const string TEXT_3 = "B_PUSH_3";
        private const string TEXT_4 = "B_PUSH_4";
        public LordOfMessage(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            BotClient = botClient;
            Update = update;
            Client = client;
        }

        public ITelegramBotClient BotClient { get; }
        public Update Update { get; }
        public CancellationToken Client { get; }

        public async void IncomeMessage(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            //запись в консоль
            #nullable disable
            Console.WriteLine(@$"Входящее сообщение от {Update.Message.From} {DateTime.Now}");
            //проверка на ноль
            if(Update.Message != null)
            {
                await DocTypeChecker(BotClient, Update, Client);
            }
            else
            {
                #nullable disable
                Console.WriteLine(@$"Входящее сообщение от {Update.Message.From} не имеет смысловой нагрузки");
                return;
            }
        }
        async Task DocTypeChecker(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            string response = @$"Входящее сообщение от {Update.Message.From} {DateTime.UtcNow} имеет тип {Update.Message.Type}";

            if(Update.Message.Text != null)
            {
                Console.WriteLine(response);
                if(Update.Message.Text == "Подключиться к БД")
                {
                    await TryToConnectPG(BotClient, Update, Client);
                    return;
                }
                if (Update.Message.Text == "Список книг")
                {
                    await ListOfBooks(BotClient, Update, Client);
                    return;
                }
                if (Update.Message.Text == "Добавить книгу")
                {
                    await AddBook(BotClient, Update, Client);
                    return;
                }
                if (Update.Message.Text == "Поиск...")
                {
                    await BooksSearch(BotClient, Update, Client);
                    return;
                }
                else
                {
                    await TextTypeMessage(BotClient, Update, Client);
                    return;
                }
            }
            if (Update.Message.Document != null)
            {
                Console.WriteLine(response);
                //await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, response);
                await DocumentTypeMessage(BotClient, Update, Client);
                return;
            }
            else
            {
                Console.WriteLine(response + " Данный тип не поддерживается.");
                await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, response + " Данный тип не поддерживается.");
                return;
            }
        }
        async Task TextTypeMessage(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Меню", replyMarkup: GetButton());
            //пробуем подключиться к БД
            //при успешном подключении выводим сообщение
            return;
        }

        public IReplyMarkup GetButton()
        {
            var keybuttons = new List<List<KeyboardButton>>
            {
                    new List<KeyboardButton>
                    {
                        new KeyboardButton("Подключиться к БД"),
                        new KeyboardButton("Список книг"),
                    },
                    new List<KeyboardButton>
                    {
                        new KeyboardButton("Добавить книгу"),
                        new KeyboardButton("Поиск...")
                    }
            }; 
        
            return new ReplyKeyboardMarkup(keybuttons);
        }

        async Task DocumentTypeMessage(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Ожидание работы с документом");
            return;
        }
        async Task TryToConnectPG(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Проверка подключения к БД...");
            return;
        }
        async Task ListOfBooks(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Список доступных книг");
            return;
        }
        async Task BooksSearch(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Поиск по названию, авторам, жанрам");
            return;
        }
        async Task AddBook(ITelegramBotClient botClient, Update update, CancellationToken client)
        {
            await BotClient.SendTextMessageAsync(Update.Message.Chat.Id, "Загрузка своей книги");
            return;
        }
    }
}
