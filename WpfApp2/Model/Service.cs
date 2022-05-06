using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2
{
    public class Service
    {
        public static Frame frame;
        public static localdbContext db = new();
        public static User user = new();

        public static void DataUpd()
        {
            User user_1 = new()
            {
                FName = "Вдовкин",
                SName = "Арсений",
                LName = "Антонович",
                Login = "vdow123",
                Password = "12345",
                NumberPhone = "88005553535"
            };
            db.Users.Add(user_1);
            db.SaveChanges();
            User user_2 = new()
            {
                FName = "Рыбалкин",
                SName = "Никита",
                LName = "Артемович",
                Login = "ryb123",
                Password = "22d22",
                NumberPhone = "89132003232"
            };
            db.Users.Add(user_2);
            db.SaveChanges();
            User user_3 = new()
            {
                FName = "Петров",
                SName = "Петр",
                LName = "Петрович",
                Login = "petr123",
                Password = "ye312",
                NumberPhone = "86567765645"
            };
            db.Users.Add(user_3);
            db.SaveChanges();
            User user_4 = new()
            {
                FName = "Сидоров",
                SName = "Александр",
                LName = "Антонович",
                Login = "sidar123",
                Password = "arr312",
                NumberPhone = "84566767645"
            };
            db.Users.Add(user_4);
            db.SaveChanges();
            User user_5 = new()
            {
                FName = "Лашков",
                SName = "Сергей",
                LName = "Семенович",
                Login = "ser123434",
                Password = "ser556",
                NumberPhone = "88887373456"
            };
            db.Users.Add(user_5);
            db.SaveChanges();
            Status status1 = new()
            {
                NameStatus = "Не готов",
            };
            db.Statuses.Add(status1);
            db.SaveChanges();
            Status status2 = new()
            {
                NameStatus = "Выполняется",
            };
            db.Statuses.Add(status2);
            db.SaveChanges();
            Status status3 = new()
            {
                NameStatus = "Готов",
            };
            db.Statuses.Add(status3);
            db.SaveChanges();

            Task task1 = new()
            {
                NameTask = "Решите уравнение",
                DescriptionTask = "Нужно решить квадратное уравнение",
                DatePub = new DateTime(2020, 01, 10),
                CreatorId = 2,
                AcceptorId = 1,
                Statusid = 2
            };
            db.Tasks.Add(task1);
            db.SaveChanges();

            Task task2 = new()
            {
                NameTask = "Решите задачку",
                DescriptionTask = "Найдите сумму чисел",
                DatePub = new DateTime(2021, 10, 20),
                CreatorId = 1,
                AcceptorId = 2,
                Statusid = 2
            };
            db.Tasks.Add(task2);
            db.SaveChanges();
            Task task3 = new()
            {
                NameTask = "Решите задачу на c++",
                DescriptionTask = "Нужно выполнить 10 задач по по строкам",
                DatePub = new DateTime(2021, 03, 12),
                CreatorId = 2,
                AcceptorId = 3,
                Statusid = 3
            };
            db.Tasks.Add(task3);
            db.SaveChanges();
            Task task4 = new()
            {
                NameTask = "Решите уравнение",
                DescriptionTask = "Нужно решить кубическое уравнение",
                DatePub = new DateTime(2022, 06, 19),
                CreatorId = 3,
                AcceptorId = 2,
                Statusid = 3
            };
            db.Tasks.Add(task4);
            db.SaveChanges();
            Task task5 = new()
            {
                NameTask = "Решите неравенство",
                DescriptionTask = "Нужно решить неравенство",
                DatePub = new DateTime(2022, 11, 10),
                CreatorId = 4,
                AcceptorId = 5,
                Statusid = 2
            };
            db.Tasks.Add(task5);
            db.SaveChanges();
        }
    }
}
