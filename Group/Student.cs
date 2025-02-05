using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    internal class Student
    {

        private static int countStudents = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Address { get; set; }
        public string? Group { get; set; }
        public int? CurrentTeacher { get; set; }


        List<Mark>? passMarks = new List<Mark>();  // зачеты
        List<Mark>? termMarks = new List<Mark>();  // курсовые
        List<Mark>? examMarks = new List<Mark>();
        public Array PassMarks { get; private set; }
        public Array TermMarks { get; private set; }
        public Array ExamMarks { get; private set; }

        public Student() : this("", "", "") { }
        public Student(string surname, string name, string patronymic) : this(surname, name, patronymic, new DateOnly(0, 0, 0), "", "", -1) { }

        public Student(string surname, string name, string patronymic, DateOnly birthDate) : this(surname, name, patronymic, birthDate, "", "", -1) { }
        public Student(string surname, string name, string patronymic, DateOnly birthDate, string address) : this(surname, name, patronymic, birthDate, address, "", -1) { }
        public Student(string surname, string name, string patronymic, DateOnly birthDate, string address, string group) : this(surname, name, patronymic, birthDate, address, group, -1) { }
        public Student(string surname, string name, string patronymic, DateOnly birthDate, string address, string group, int currentTeacher)
        {
            countStudents++;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Address = address;
            Group = group;
            CurrentTeacher = currentTeacher;
        }
        public override string? ToString()
        {
            return $"Ф.:\t{Surname}\nИ.:\t{Name}\nО.:\t{Patronymic}\nДата.р.:{BirthDate}\nАдрес:\t{Address}\nГруппа: {Group}\nПреподаватель: {CurrentTeacher}";
        }

        public void SetMark(int mark, int teacher, string subject, MarkType t)
        {
            if (teacher != CurrentTeacher)
            {
                Console.WriteLine("Вы не можете оценивать этого студента.\nОценка не выставлена.");
                return;
            }
            switch (t)
            {
                case MarkType.Pass:
                    passMarks.Add(new Mark(mark, subject, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), teacher));
                    break;
                case MarkType.Term:
                    termMarks.Add(new Mark(mark, subject, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), teacher));
                    break;
                case MarkType.Exam:
                    examMarks.Add(new Mark(mark, subject, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), teacher));
                    break;
                _:
                    Console.WriteLine("Что-то пошло не так.");
                    break;
            }
        }

        private double AverageMark(List<Mark>? marks)
        {
            if (marks != null)
            {
                if (marks.Count != 0)
                {
                    int sum = 0;
                    foreach (var mark in marks)
                    {
                        sum += mark.Value;
                    }
                    return sum / marks.Count;
                }
            }
            return 0;
        }
        public double AverageMark(MarkType t)
        {
            switch (t)
            {
                case MarkType.Pass:
                    return AverageMark(passMarks);
                case MarkType.Term:
                    return AverageMark(termMarks);
                case MarkType.Exam:
                    return AverageMark(examMarks);
                default:
                    return 0;
            }
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1.GetHashCode() == s2.GetHashCode();
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1.GetHashCode() == s2.GetHashCode());
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is Student)
            {
                return GetHashCode() == obj.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + Patronymic.GetHashCode() + BirthDate.GetHashCode();
        }
        public static void ShowCount()
        {
            Console.WriteLine($"Количество студентов: {countStudents}");
        }
        public double GetAverageMark()
        {
            double sum = 0;
            int count = 0;
            if (passMarks != null)
            {
                foreach (var mark in passMarks)
                {
                    sum += mark.Value;
                    count++;
                }
            }
            if (termMarks != null)
            {
                foreach (var mark in termMarks)
                {
                    sum += mark.Value;
                    count++;
                }
            }
            if (examMarks != null)
            {
                foreach (var mark in examMarks)
                {
                    sum += mark.Value;
                    count++;
                }
            }
            return sum / count;
        }
    }
}
