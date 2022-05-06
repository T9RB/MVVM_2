﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp2
{
    public class VM_MW : VM_Super
    {
        public VM_MW()
        {
            Service.frame.Navigate(new Uri("Page/Page1.xaml", UriKind.Relative));
        }

        private RelayCommand profile;
        private RelayCommand userlist;
        private RelayCommand avaibletask;
        private RelayCommand takslist;
        private RelayCommand historytasks;
        private RelayCommand changestatustask;
        private RelayCommand db;

        public RelayCommand Profile => profile ??
                                             (profile = new RelayCommand((x) =>
                                             {
                                                 if (Service.user.Login == null)
                                                 {
                                                     MessageBox.Show("Вы не авторизовались!");
                                                     return;
                                                 }
                                                 if (Service.user.Login != null)
                                                 {
                                                     Service.frame.Navigate(new Page2());
                                                 }
                                             }));

        public RelayCommand UserList => userlist ??
                                        (userlist = new RelayCommand((x) =>
                                        {
                                            if (Service.user.Login == null)
                                            {
                                                MessageBox.Show("Вы не авторизовались!");
                                                return;
                                            }
                                            if (Service.user.Login != null)
                                            {
                                                Service.frame.Navigate(new Page3());
                                            }
                                        }));

        public RelayCommand AvaibleTask => avaibletask ??
                                           (avaibletask = new RelayCommand((x) =>
                                           {
                                               if (Service.user.Login == null)
                                               {
                                                   MessageBox.Show("Вы не авторизовались!");
                                                   return;
                                               }
                                               if (Service.user.Login != null)
                                               {
                                                   Service.frame.Navigate(new Page4());
                                               }
                                           }));
        public RelayCommand TaskList => takslist ??
                                           (takslist = new RelayCommand((x) =>
                                           {
                                               if (Service.user.Login == null)
                                               {
                                                   MessageBox.Show("Вы не авторизовались!");
                                                   return;
                                               }
                                               if (Service.user.Login != null)
                                               {
                                                   Service.frame.Navigate(new Page5());
                                               }
                                           }));

        public RelayCommand HistoryTask => historytasks ??
                                           (historytasks = new RelayCommand((x) =>
                                           {
                                               if (Service.user.Login == null)
                                               {
                                                   MessageBox.Show("Вы не авторизовались!");
                                                   return;
                                               }
                                               if (Service.user.Login != null)
                                               {
                                                   Service.frame.Navigate(new Page6());
                                               }
                                           }));
        public RelayCommand ChangeStatusTask => changestatustask ??
                                           (changestatustask = new RelayCommand((x) =>
                                           {
                                               if (Service.user.Login == null)
                                               {
                                                   MessageBox.Show("Вы не авторизовались!");
                                                   return;
                                               }
                                               if (Service.user.Login != null)
                                               {
                                                   Service.frame.Navigate(new Page7());
                                               }
                                           }));


        public RelayCommand DB => db ??
            (db = new RelayCommand((x) =>
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
            Service.db.Users.Add(user_1);
            Service.db.SaveChanges();
            User user_2 = new()
            {
                FName = "Рыбалкин",
                SName = "Никита",
                LName = "Артемович",
                Login = "ryb123",
                Password = "22d22",
                NumberPhone = "89132003232"
            };
            Service.db.Users.Add(user_2);
            Service.db.SaveChanges();
            User user_3 = new()
            {
                FName = "Петров",
                SName = "Петр",
                LName = "Петрович",
                Login = "petr123",
                Password = "ye312",
                NumberPhone = "86567765645"
            };
            Service.db.Users.Add(user_3);
            Service.db.SaveChanges();
            User user_4 = new()
            {
                FName = "Сидоров",
                SName = "Александр",
                LName = "Антонович",
                Login = "sidar123",
                Password = "arr312",
                NumberPhone = "84566767645"
            };
            Service.db.Users.Add(user_4);
            Service.db.SaveChanges();
            User user_5 = new()
            {
                FName = "Лашков",
                SName = "Сергей",
                LName = "Семенович",
                Login = "ser123434",
                Password = "ser556",
                NumberPhone = "88887373456"
            };
            Service.db.Users.Add(user_5);
            Service.db.SaveChanges();
            Status status1 = new()
            {
                NameStatus = "Не готов",
            };
            Service.db.Statuses.Add(status1);
            Service.db.SaveChanges();
            Status status2 = new()
            {
                NameStatus = "Выполняется",
            };
            Service.db.Statuses.Add(status2);
            Service.db.SaveChanges();
            Status status3 = new()
            {
                NameStatus = "Готов",
            };
            Service.db.Statuses.Add(status3);
            Service.db.SaveChanges();

            Task task1 = new()
            {
                NameTask = "Решите уравнение",
                DescriptionTask = "Нужно решить квадратное уравнение",
                DatePub = new DateTime(2020, 01, 10),
                CreatorId = 2,
                AcceptorId = 1,
                Statusid = 2
            };
            Service.db.Tasks.Add(task1);
            Service.db.SaveChanges();

            Task task2 = new()
            {
                NameTask = "Решите задачку",
                DescriptionTask = "Найдите сумму чисел",
                DatePub = new DateTime(2021, 10, 20),
                CreatorId = 1,
                AcceptorId = 2,
                Statusid = 2
            };
            Service.db.Tasks.Add(task2);
            Service.db.SaveChanges();
            Task task3 = new()
            {
                NameTask = "Решите задачу на c++",
                DescriptionTask = "Нужно выполнить 10 задач по по строкам",
                DatePub = new DateTime(2021, 03, 12),
                CreatorId = 2,
                AcceptorId = 3,
                Statusid = 3
            };
            Service.db.Tasks.Add(task3);
            Service.db.SaveChanges();
            Task task4 = new()
            {
                NameTask = "Решите уравнение",
                DescriptionTask = "Нужно решить кубическое уравнение",
                DatePub = new DateTime(2022, 06, 19),
                CreatorId = 3,
                AcceptorId = 2,
                Statusid = 3
            };
            Service.db.Tasks.Add(task4);
            Service.db.SaveChanges();
            Task task5 = new()
            {
                NameTask = "Решите неравенство",
                DescriptionTask = "Нужно решить неравенство",
                DatePub = new DateTime(2022, 11, 10),
                CreatorId = 4,
                AcceptorId = 5,
                Statusid = 2
            };
            Service.db.Tasks.Add(task5);
            Service.db.SaveChanges();
                MessageBox.Show("База данных заполнена!");
            }));
    }
}