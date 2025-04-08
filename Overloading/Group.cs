using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 
для Группы:
1) критерий истинности: если количесво студентов в группе больше 0 человек, то вернуть true, если равно 0 (группа пустая) то вернуть false
2) > и <: сравнение групп по количеству студентов (или по названию)
3) == и !=: сравнение групп по количеству студентов (или по названию)
4) []: индексатор возвращает студента из группы по переданному целочисленному индексу

 */
namespace Overloading
{
    class Group
    {
        private string teacher = "";
        public string Name { get; private set; }
        public string Specialization { get; private set; }
        public int Course { get; private set; }

        public string Teacher
        {
            get => teacher;
            set
            {
                teacher = value;
            }
        }
        public List<Student> Students { get; set; }
        public Group() : this("") { }
        public Group(string name, string teacher = "")
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
            Students.Add(new Student(surname, name, patronymic, birthDate, address));
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
            Students.Remove(st);
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
        public void setMark(int id, int mark, string subject, MarkType t, string teacher)
        {
            if (id < 0 || id >= Students.Count)
                throw new IndexOutOfRangeException("неверный индекс");
            if (this.teacher != teacher)
            {
                throw new Exception("несанкционированный учитель.");
            }
            Students[id].SetMark(mark, subject, t, teacher);
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
