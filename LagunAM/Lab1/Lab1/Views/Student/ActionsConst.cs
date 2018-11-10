using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Views.Student
{
    public class ActionsConst
    {
        public static readonly Dictionary<string, string> ActiveActions = new Dictionary<string, string>
        { 
            { "Добавить студента", "NewStudent"},
            { "Просмотреть инфо студента", "InfoStudent" },
            { "Обновить инфо о студенте", "UpdateInfoStudent" },
            { "Удалить студента", "DeleteStudent" },
            { "Скачать список студентов(Excel->Данные->Получение внешних данных->Из текста. Кодировка - Unicode, разделитель - ; )", "DownloadList" }
        };

        public static readonly Dictionary<string, string> StudentFields = new Dictionary<string, string>
        {
            { "Введите Фамилию:", "LastName"},
            { "Введите Имя:", "FirstName" },
            { "Введите факультет:", "Faculty" },
            { "Введите специальность:", "Speciality" },
            { "Введите курс:", "Course" },
            { "Введите средний балл:", "GradePointAverage" },
        };

        public static readonly Dictionary<string, string> StudentPsevdonims = new Dictionary<string, string>
        {
            { "Дата поступления", "ReceiptDate"},
            { "Фамилия:", "LastName"},
            { "Имя:", "FirstName" },
            { "Факультет:", "Faculty" },
            { "Специальность:", "Speciality" },
            { "Курс:", "Course" },
            { "Средний балл:", "GradePointAverage" },
        };




    }
}