using System;
using System.Linq;

namespace Pdb_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(" 1-добавить \n 2-удалить \n 3-обновить \n 4-показать \n 5-выход");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                {
                    AddObject();
                }
                else if (num == 2)
                {
                    RemoveObject();
                }
                else if (num == 3)
                {
                    UpdateObject();
                }
                else if (num == 4)
                {
                    ShowObject();
                }
                else if (num == 5)
                {
                    break;
                }
            }
        }
        public static void AddObject()
        {
            ApplicationContext db = new ApplicationContext();
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            int age = Convert.ToInt32(Console.ReadLine());
            User u = new User { Name = name, Age = age };
            db.Users.Add(u);
            db.SaveChanges();
            Console.WriteLine("Добавление произошло успешно");
        }
        public static void RemoveObject()
        {
            ApplicationContext db = new ApplicationContext();
            Console.WriteLine("Введите номер элемента для удаления");
            int num = Convert.ToInt32(Console.ReadLine());
            User u = db.Users.ToList().ElementAt(num);
            db.Users.Remove(u);
            db.SaveChanges();
            Console.WriteLine("Объект удален");
        }
        public static void ShowObject()
        {
            ApplicationContext db = new ApplicationContext();
            var users = db.Users.ToList();
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
            Console.ReadLine();
        }
        public static void UpdateObject()
        {
            ApplicationContext db = new ApplicationContext();
            Console.WriteLine("Введите номер элемента для обновления");
            int num = Convert.ToInt32(Console.ReadLine());
            User u = db.Users.ToList().ElementAt(num);
            Console.WriteLine("Введите новое имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите новый возраст");
            int age = Convert.ToInt32(Console.ReadLine());
            u.Name = name;
            u.Age = age;
            db.Users.Update(u);
            db.SaveChanges();
            Console.WriteLine("Изменения применены");
        }
    }
}
