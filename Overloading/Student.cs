using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 

для классов Студент и Группа из предыдущего ДЗ реализовать следующие перегрузки:
для Студента:
1) критерий истинности: если средний балл по оценкам более и равен 7 баллам, то вернуть true, если ниже 7
то вернуть false
2) > и <: сравнение студентов по средним баллам (или по именам)
3) == и !=: сравнение студентов по средним баллам (или по именам)

 */
namespace Overloading
{
    class Student
    {
        private static int countStudents = 0;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Address { get; set; }


        List<Mark>? passMarks = new List<Mark>();  // зачеты
        List<Mark>? termMarks = new List<Mark>();  // курсовые
        List<Mark>? examMarks = new List<Mark>();
        public Array PassMarks { get; private set; }
        public Array TermMarks { get; private set; }
        public Array ExamMarks { get; private set; }

        public Student() : this("", "", "") { }
        public Student(string surname, string name, string patronymic) : this(surname, name, patronymic, new DateOnly(0, 0, 0), "") { }

        public Student(string surname, string name, string patronymic, DateOnly birthDate) : this(surname, name, patronymic, birthDate, "") { }
       
        public Student(string surname, string name, string patronymic, DateOnly birthDate, string address)
        {
            countStudents++;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Address = address;
        }
        public override string? ToString()
        {
            return $"Ф.:\t{Surname}\nИ.:\t{Name}\nО.:\t{Patronymic}\nДата.р.:{BirthDate}\nАдрес:\t{Address}";
        }

        public void SetMark(int mark, string subject, MarkType t, string teacher)
        {
            
            switch (t)
            {
                case MarkType.Pass:
                    passMarks.Add(new Mark(mark, subject, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), teacher));
                    break;
                case MarkType.Term:
                    termMarks.Add(new Mark(mark, subject, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),  teacher));
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

        public static bool operator >(Student s1, Student s2)
        {
            return s1.AverageMark(MarkType.Exam) > s2.AverageMark(MarkType.Exam);
        }
        public static bool operator <(Student s1, Student s2)
        {
            return s1.AverageMark(MarkType.Exam) < s2.AverageMark(MarkType.Exam);
        }
        public static bool operator ==(Student s1, Student s2)
        {
            return s1.AverageMark(MarkType.Exam) == s2.AverageMark(MarkType.Exam);
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public static bool operator true(Student s)
        {
            return s.AverageMark(MarkType.Exam) >= 7 ;
        }
        public static bool operator false(Student s)
        {
            return s.AverageMark(MarkType.Exam) < 7;
        }
    }
}
