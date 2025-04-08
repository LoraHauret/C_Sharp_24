using System;
namespace gettersSettersTryCatch
{
    class Group
    {
       
        private string gTeacher = "";
        public string Teacher
        {
            get => gTeacher;
            set
            {
                gTeacher = value;
            }
        }

        private string gName;
        public string Name
        {
            get => gName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Имя группы не может быть пустым");
                }
                gName = value;
            }
        }

        private string gSpecialization;
        public string Specialization
        {
            get => gSpecialization;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Специальность не может быть пустой");
                }
                gSpecialization = value;
            }
        }
        private int gCourse;
        public int Course
        {
            get => gCourse;
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("Курс должен быть в диапазоне от 1 до 5");
                }
                gCourse = value;
            }
        }
        private List<Student> gStudents;
        public List<Student> Students
        {
            get => gStudents;
        }
        public Group() : this("") { }
        public Group(string name, string teacher = "")
        {
            gStudents = new List<Student>();
            Name = name;
            Teacher = teacher;

        }
        public void AddStudent(Student student)
        {
            gStudents.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            gStudents.Remove(student);
        }

        public override string ToString()
        {
            return $"Группа: {Name}\nПреподаватель: {Teacher}\nКурс: {Course}";
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public void ShowStudents()
        {
            Console.WriteLine(this);
            for (int i = 0; i < gStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}.\n{gStudents[i].ToString()}\n");
            }
        }

        public void AddStudent(string surname, string name, string patronymic, DateOnly birthDate, string address)
        {
            gStudents.Add(new Student(surname, name, patronymic, birthDate, address));
        }
        public void RemoveBadStudents(double criteria)
        {
            for (int i = 0; i < gStudents.Count; i++)
            {
                if (gStudents[i].AverageMark(MarkType.Exam) < criteria)
                {
                    gStudents.RemoveAt(i);
                    i--;
                }
            }
        }
        public void ChangeNameGroup(string name)
        {
            Name = name;
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
            group.AddStudent(st);
            gStudents.Remove(st);
        }
        public Student? FindStudent(int id)
        {
            if (id < 0 || id >= gStudents.Count)
                return null;

            return gStudents[id];
        }

        public bool hasStudent(Student st)
        {
            return gStudents.Contains(st);
        }
        public void setMark(int id, int mark, string subject, MarkType t, string teacher)
        {
            if (id < 0 || id >=gStudents.Count)
                throw new IndexOutOfRangeException("неверный индекс");
            if (this.gTeacher != teacher)
            {
                throw new Exception("несанкционированный учитель.");
            }
            gStudents[id].SetMark(mark, subject, t, teacher);
        }
        public static bool operator true(Group g)
        {
            return g.Students.Count > 0;
        }
        public static bool operator false(Group g)
        {
            return g.Students.Count == 0;
        }
        public static bool operator >(Group g1, Group g2)
        {
            return g1.Students.Count > g2.Students.Count;
        }
        public static bool operator <(Group g1, Group g2)
        {
            return g1.Students.Count < g2.Students.Count;
        }
        public static bool operator ==(Group g1, Group g2)
        {
            return g1.Students.Count == g2.Students.Count;
        }
        public static bool operator !=(Group g1, Group g2)
        {
            return g1.Students.Count != g2.Students.Count;
        }
        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("неверный индекс");
                return Students[index];
            }
            set
            {
                if (index < 0 || index >= Students.Count)
                    throw new IndexOutOfRangeException("неверный индекс");
                Students[index] = value;
            }
        }
    }
}
