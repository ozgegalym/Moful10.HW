using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Создать иерархию классов. Каждый класс должен содержать свойства, а также виртуальную функцию
// Print() и переопределенную функцию ToString(). Основная программа должна создавать массив
// объектов Person или их наследников, после чего выводить их на экран. У каждого объекта Teacher должен
// быть список объектов класса Students, которыми он руководит. У каждого объекта класса
// Student - объект класса Teacher.

namespace ConsoleApplication1
{
    public class Person : System.Object
    {
        protected int возраст;
        protected string имя, фамилия;

        public Person()
        {
            возраст = 0;
            имя = default;
            фамилия = default;
        }

        public Person(int _возраст, string _имя, string _фамилия)
        {
            возраст = _возраст;
            имя = _имя;
            фамилия = _фамилия;
        }

        public Person(Person _Person)
        {
            возраст = _Person.возраст;
            имя = _Person.имя;
            фамилия = _Person.фамилия;
        }

        public virtual void Print()
        {
            Console.WriteLine("Имя и фамилия человека: {0} {1}, возраст: {2}", имя, фамилия, возраст);
        }

        public virtual void Scan()
        {
            Console.WriteLine("\t\t Введите возраст (число): ");
            возраст = int.Parse(Console.ReadLine());
            Console.WriteLine("\t\t Введите имя и фамилию (строка): ");
            имя = Console.ReadLine();
            фамилия = Console.ReadLine();
        }

        public override bool Equals(object obj)
        {
            Person temp = (Person)obj;
            if (temp.возраст == возраст && temp.имя == имя && temp.фамилия == фамилия)
            {
                return true;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return возраст.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[Имя = {0}", имя);
            sb.AppendFormat(" Фамилия = {1}", фамилия);
            sb.AppendFormat(" Возраст = {2}]", возраст);
            return sb.ToString();
        }
    }

    public class Student : Person
    {
        private bool место_в_университете;
        private double средняя_оценка;
        private string группа;
        private string преподаватель;

        public Student() : base()
        {
            место_в_университете = default;
            средняя_оценка = default;
            группа = default;
            преподаватель = default;
        }

        public Student(string _преподаватель, bool _место_в_университете, double _средняя_оценка, string _группа, int _возраст, string _имя, string _фамилия)
        : base(_возраст, _имя, _фамилия)
        {
            место_в_университете = _место_в_университете;
            средняя_оценка = _средняя_оценка;
            группа = _группа;
            преподаватель = _преподаватель;
        }

        public string Преподаватель
        {
            get
            {
                return преподаватель;
            }
            set
            {
                преподаватель = value;
            }
        }
        public override void Print()
        {
            Console.WriteLine("[Студент: Имя = {0}, Фамилия = {1}," +
                " Возраст = {2}, Место в университете: {3}, Средняя оценка: {4}," +
                " Группа: {5}]", имя, фамилия, возраст, место_в_университете, средняя_оценка, группа);
        }

        public override void Scan()
        {
            base.Scan();
            Console.WriteLine("\t\t Введите место в университете (булево): ");
            место_в_университете = bool.Parse(Console.ReadLine());
            Console.WriteLine("\t\t Введите среднюю оценку (число): ");
            средняя_оценка = double.Parse(Console.ReadLine());
            Console.WriteLine("\t\t Введите группу (строка): ");
            группа = Console.ReadLine();
            Console.WriteLine("\t\t Введите фамилию преподавателя (строка): ");
            преподаватель = Console.ReadLine();
        }

        public void SetGroup()
        {
            группа = Console.ReadLine();
        }

        public void SetAverage()
        {
            средняя_оценка = double.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" [Место в университете: {0}", место_в_университете);
            sb.AppendFormat(" Средняя оценка: {1}", средняя_оценка);
            sb.AppendFormat(" Группа: {2}]", группа);
            return base.ToString() + sb.ToString();
        }
    }

    public class Teacher : Person
    {
        private List<Student> список_студентов;
        private string должность;
        private int стаж;

        public Teacher() : base()
        {
            должность = default;
            стаж = 0;
            список_студентов = new List<Student>();
        }

        public Teacher(string _должность, int _стаж, int _возраст, string _имя, string _фамилия)
            : base(_возраст, _имя, _фамилия)
        {
            должность = _должность;
            стаж = _стаж;
            список_студентов = new List<Student>();
        }
        public string Фамилия
        {
            get
            {
                return фамилия;
            }
            set
            {
                фамилия = value;
            }
        }
        public override void Print()
        {
            Console.WriteLine("[Преподаватель: Имя = {0}, Фамилия = {1}," +
                " Возраст = {2}, Должность: {3}, Стаж: {4}]", имя, фамилия, возраст, должность, стаж);
            Console.WriteLine();
            Console.WriteLine("У меня есть эти студенты: ");
            foreach (var student in список_студентов)
            {
                student.Print();
                Console.WriteLine();
            }
        }

        public override void Scan()
        {
            base.Scan();
            Console.WriteLine("\t\t Введите должность (строка): ");
            должность = Console.ReadLine();
            Console.WriteLine("\t\t Введите стаж (число): ");
            стаж = int.Parse(Console.ReadLine());
        }

        public void SetPosition()
        {
            должность = Console.ReadLine();
        }

        public void SetSeniority()
        {
            стаж = int.Parse(Console.ReadLine());
        }

        public void AddStudent(Student student)
        {
            список_студентов.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            return список_студентов.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" [Должность: {0}", должность);
            sb.AppendFormat(" Стаж: {1}]", стаж);
            return base.ToString() + sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)

        {
            List<Student> студенты = new List<Student>();
            List<Teacher> преподаватели = new List<Teacher>();
            string usr_inp;

            do
            {
                Console.WriteLine("\t\t\t 1. Добавить нового студента \n\t\t\t 2. Добавить нового преподавателя \n\t\t\t 3. Обновить отношения Преподаватель-Студент \n\t\t\t 4. Вывести Преподавателей с каждым студентом \n\t\t\t 5. Выйти");
                try
                {
                    usr_inp = Console.ReadLine();
                    switch (int.Parse(usr_inp))
                    {
                        case 1:
                            {
                                Student temp = new Student();
                                temp.Scan();
                                студенты.Add(temp);
                                Console.WriteLine("\t\t\t Студент успешно добавлен!");
                            }
                            break;
                        case 2:
                            {
                                Teacher temp = new Teacher();
                                temp.Scan();
                                преподаватели.Add(temp);
                                Console.WriteLine("\t\t\t Преподаватель успешно добавлен!");
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i <= студенты.Count - 1; i++)
                                {
                                    for (int j = 0; j <= преподаватели.Count - 1; j++)
                                    {
                                        if (преподаватели[j].Фамилия == студенты[i].Преподаватель)
                                        {
                                            преподаватели[j].AddStudent(студенты[i]);
                                        }
                                    }
                                }
                                Console.WriteLine("\t\t\t Отношения успешно обновлены!");
                            }
                            break;
                        case 4:
                            {
                                foreach (var преподаватель1 in преподаватели)
                                {
                                    преподаватель1.Print();
                                }
                            }
                            break;
                        case 5:
                            return;
                        default:
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                }

            }
            while (true);
        }
    }
}
