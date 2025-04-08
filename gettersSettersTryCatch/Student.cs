using System;
namespace gettersSettersTryCatch
{
    class Student
    {
        private static int countStudents;
        public static int CountStudents
        {
            get { return countStudents; }
        }
        private string sName;
        public string Name
        {
            get => sName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Имя не может быть пустым");
                }
                sName = value;
            }
        }

        private string sSurname;
        public string Surname
        {
            get { return sSurname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Фамилия не может быть пустой");
                }
                sSurname = value;
            }
        }

        private string sPatronymic;
        public string Patronymic
        {
            get => sPatronymic;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Отчество не может быть пустым");
                }
                sPatronymic = value;
            }
        }

        private DateOnly sBirthDate;
        public DateOnly BirthDate
        {
            get { return sBirthDate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Дата рождения не может быть пустой");
                }
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentOutOfRangeException("Дата рождения не может быть в будущем");
                }
                sBirthDate = value;
            }
        }

        private string sAddress;
        public string Address
        {
            get => sAddress; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Адрес не может быть пустым");
                }
                sAddress = value;
            }
        }
        //private int? sGroup;
        //public int? Group
        //{
        //    get => sGroup;
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentOutOfRangeException("Группа не может быть отрицательной");
        //        }
        //        sGroup = value;
        //    }
        //}


        List<Mark>? passMarks = new List<Mark>();  // зачеты
        List<Mark>? termMarks = new List<Mark>();  // курсовые
        List<Mark>? examMarks = new List<Mark>();
        public Array PassMarks
        {
            get
            {
                return passMarks.ToArray();
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Список оценок не может быть пустым");
                }
                passMarks = new List<Mark>();
                foreach (var item in value)
                {
                    passMarks.Add((Mark)item);
                }
            }
        }
        public Array TermMarks
        {
            get
            {
                return termMarks.ToArray();
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Список оценок не может быть пустым");
                }
                termMarks = new List<Mark>();
                foreach (var item in value)
                {
                    termMarks.Add((Mark)item);
                }
            }
        }
        public Array ExamMarks
        {
            get
            {
                return examMarks.ToArray();
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Список оценок не может быть пустым");
                }
                examMarks = new List<Mark>();
                foreach (var item in value)
                {
                    examMarks.Add((Mark)item);
                }
            }
        }
        
        static Student()
        {
            countStudents = 0;
        }
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
            return s.AverageMark(MarkType.Exam) >= 7;
        }
        public static bool operator false(Student s)
        {
            return s.AverageMark(MarkType.Exam) < 7;
        }
        public void ClearMarks()
        {
            passMarks.Clear();
            termMarks.Clear();
            examMarks.Clear();
        }
        public void ClearMarks(MarkType t)
        {
            switch (t)
            {
                case MarkType.Pass:
                    passMarks.Clear();
                    break;
                case MarkType.Term:
                    termMarks.Clear();
                    break;
                case MarkType.Exam:
                    examMarks.Clear();
                    break;
                default:
                    Console.WriteLine("Что-то пошло не так.");
                    break;
            }
        }
    }

}