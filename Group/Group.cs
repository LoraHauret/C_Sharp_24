using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    internal class Group
    {
        private int teacher = -1;
        public string Name { get; private set; }
        public string Specialization { get; private set; }
        public int Course { get; private set; }

        public int Teacher
        {
            get => teacher;
            set
            {
                teacher = value;
                for (int i = 0; i < Students.Count; i++)
                {
                    Students[i].CurrentTeacher = value;
                }
            }
        }
        public List<Student> Students { get; set; }
        public Group() : this("") { }
        public Group(string name, int teacher = -1)
        {
            Students = new List<Student>();
            Name = name;
            Teacher = teacher;

        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public override string ToString()
        {
            return $"Группа: {Name}\nПреподаватель: {Teacher}";
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public void ShowStudents()
        {
            Console.WriteLine(this);
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine($"{i + 1}.\n{Students[i].ToString()}\n");
            }
        }

        public void AddStudent(string surname, string name, string patronymic, DateOnly birthDate, string address)
        {
            Students.Add(new Student(surname, name, patronymic, birthDate, address, this.Name));
        }
        public void RemoveBadStudents(double criteria)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageMark(MarkType.Exam) < criteria)
                {
                    Students.RemoveAt(i);
                    i--;
                }
            }
        }
        public void RemoveWorstStudent()
        {
            if (Students.Count == 0)
                return;
            int theWorstInd = 0;
            for (int i = 0; i < Students.Count -1; i++)
            {
                if (Students[i].GetAverageMark() < Students[theWorstInd].AverageMark(MarkType.Exam))
                    theWorstInd = i;
            }
            Students.RemoveAt(theWorstInd);
        }
        public void ChangeNameGroup(string name)
        {
            Name = name;
            for(int i = 0; i < Students.Count; i++)
            {
                Students[i].Group = name;
            }
        }
        public void ChangeSpecialization(string specialization)
        {
            Specialization = specialization;
        }

        public void ChangeCourse(int course)
        {
            Course = course;
        }

        public void TransferStudent(Student st, Group group)
        {
            st.Group = group.Name;
            st.CurrentTeacher = -1;
            group.AddStudent(st);
            Students.Remove(st);
        }
        
        public int? FindStudent(Student st)
        {
            return Students.FindIndex(x => x == st);
        }
        public Student? FindStudent(int id)
        {
            if (id < 0 || id >= Students.Count)
                return null;

            return Students[id];
        }

        public bool hasStudent(Student st)
        {
            return Students.Contains(st);
        }
        public bool hasStudent(int id)
        {
            return id >= 0 && id < Students.Count;
        }
        public void ChangeStudentInfo(int id)
        {
            --id;
            if (id < 0 || id >= Students.Count)
                return;
            Console.WriteLine(Students[id]);
            Console.WriteLine();
            Console.WriteLine("Изменить:\n1. Имя\n2. Фамилию\n3. Отчество\n4. Дату рождения\n5. Адрес\n6. Выход");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите новое имя:");
                        Students[id].Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите новую фамилию:");
                        Students[id].Surname = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Введите новое отчество:");
                        Students[id].Patronymic = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Введите новую дату рождения:");
                        Students[id].BirthDate = DateOnly.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Введите новый адрес:");
                        Students[id].Address = Console.ReadLine();
                        break;
                    default:
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
/*
 2. Реализовать класс Group, который работает с List студентов. 
Обязательные поля: 
ссылка на List студентов,+
название группы, +
специализация группы,+
номер курса. +
Обязательные методы: конструктор по умолчанию создаёт пустую группу. +
Реализовать следующие методы: 
показ всех студентов группы (сначала группы, затем порядковые номера, фамилии в алфавитном порядке и имена студентов), +
добавление студента в группу, +
редактирование данных о студенте и группе, 
перевод студента из одной группы в другую, +
отчисление всех студентов со средним баллом ниже 7, + (унифицировано. Можно указать параметр-критерий в методе)
отчисление одного самого неуспевающего студента. +
Вынести код класса в отдельный файл Group.cs+
 */