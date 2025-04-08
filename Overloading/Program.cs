
/*
 

для классов Студент и Группа из предыдущего ДЗ реализовать следующие перегрузки:
для Студента:
1) критерий истинности: если средний балл по оценкам более и равен 7 баллам, то вернуть true, если ниже 7
то вернуть false
2) > и <: сравнение студентов по средним баллам (или по именам)
3) == и !=: сравнение студентов по средним баллам (или по именам)

для Группы:
1) критерий истинности: если количесво студентов в группе больше 0 человек, то вернуть true, если равно 0 (группа пустая) то вернуть false
2) > и <: сравнение групп по количеству студентов (или по названию)
3) == и !=: сравнение групп по количеству студентов (или по названию)
4) []: индексатор возвращает студента из группы по переданному целочисленному индексу

 */

using System.Text.RegularExpressions;

namespace Overloading
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Student student = new Student();
            // student.Name = "Ivan";
            // student.Surname = "Ivanov";
            // student.Patronymic = "Ivanovich";
            //// student.BirthDate = new DateOnly(2000, 1, 2);
            // student.Address = "Ukraine";
            //student.Group = "Group1";
            //student.CurrentTeacher = 1;
            string teacherName = "Карпов Игорь Владимирович";
            

            Group group = new Group("ПВ420");
            //Console.WriteLine(group);

            //group.Teacher = idTeacher;

            //Console.WriteLine(group);
            Student st = new Student ("Иванов", "Андрей", "Федорович", new DateOnly(2000, 7, 12), "Одесса");
            group.AddStudent(st);
            group.AddStudent(new Student("Соколов", "Василий", "Петрович", new DateOnly(2000, 11, 21), "Николаев"));
            group.AddStudent(new Student("Антонова", "Елизавета", "Григорьевна", new DateOnly(2000, 9, 18), "Херсон"));
            Console.WriteLine("Добавлены студенты, преподаватель неизвестен:");
            group.ShowStudents();
            group.Teacher = teacherName;
            Console.WriteLine("Добавлен преподаватель:");
            group.ShowStudents();

            group.ChangeNameGroup("ПВ421");
            Console.WriteLine("Изменено название группы:");
            group.ShowStudents();

            Console.WriteLine("\nпроверка студена на критерий истинности");

            if (st)
            {
                Console.WriteLine("Студент сдал все экзамены");
            }
            else
            {
                Console.WriteLine("Студент сдал не  все экзамены");
            }
            Console.WriteLine("\nпроверка группы на критерий истинности");
            if (group)
            {
                Console.WriteLine("В группе есть студенты");
            }
            else
            {
                Console.WriteLine("В группе нет студентов");
            }
            Console.WriteLine("\nСравнение студентов по среднему баллу:");
            Console.WriteLine($"group[0] == group[1]: {group[0] == group[1]}");

            group.setMark(0, 10, "C++", MarkType.Exam, teacherName);
            group.setMark(1, 8, "C++", MarkType.Exam, teacherName);

            Console.WriteLine("\nСравнение студентов по среднему баллу после проставления оценок:");
            Console.WriteLine($"group[0] == group[1]: {group[0] == group[1]}");
            Console.WriteLine($"group[0] != group[1]: {group[0] != group[1]}");
            Console.WriteLine($"group[0] < group[1]: {group[0] < group[1]}");
            Console.WriteLine($"group[0] > group[1]: {group[0] > group[1]}");
            Console.WriteLine("\nдоступ к студенту по перегруженному оператору []");
            Console.WriteLine(group[0] + "\n");
            Console.WriteLine(group[1]);            

        }
    }
}
