using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class UIText
    {
        private string menuInfo = 
            $"┌                                                                                   ┐{Environment.NewLine}" +
            $"│                              ТЕЛЕФОННЫЙ СПРАВОЧНИК                                │{Environment.NewLine}" +
            $"│ 1 - Добавить. 2 - Прочитать всё. 3 - Сменить владельца номера. 4 - Удалить.       │{Environment.NewLine}" +
            $"└                                                                                   ┘{Environment.NewLine}";
        private string read =
            $"\tФайл существует. Вывести содержимое.        {Environment.NewLine}" +
            $"\tЕсли файла нет, создать.                    {Environment.NewLine}";
        private string add =
            $"\tПроверить наличие файла. Если нет - создать.{Environment.NewLine}" +
            $"\tПредложить ввести номер.                    {Environment.NewLine}" +
            $"\tПредложить ввести имя.                      {Environment.NewLine}" +
            $"\tЗаписать данные в конец файла.              {Environment.NewLine}";
        private string change =
            $"\tСменить имя владельца номера.               {Environment.NewLine}" +
            $"\tПредложить ввести номер.                    {Environment.NewLine}" +
            $"\tПарсировать номер.                          {Environment.NewLine}" +
            $"\tИскать сходство в файле.                    {Environment.NewLine}" +
            $"\tЕсли сходство найдено, то сменить имя.      {Environment.NewLine}";
        private string delete =
            $"\tПолностью удаляет запись.                   {Environment.NewLine}" +
            $"\tПредложить ввести номер.                    {Environment.NewLine}" +
            $"\tПредложить ввести имя.                      {Environment.NewLine}" +
            $"\tИскать сходство в файле.                    {Environment.NewLine}" +
            $"\tЕсли сходство найдено, то удалить запись.   {Environment.NewLine}";
        public string MenuInfo
        {
            get { return menuInfo; }
        }
        public string Read
        {
            get { return read; }
        }
        public string Add
        {
            get { return add; }
        }
        public string Change
        {
            get { return change; }
        }
        public string Delete
        {
            get { return delete; }
        }
    }
}
