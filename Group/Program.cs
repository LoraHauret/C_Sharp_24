namespace Group
{
    internal class Program
    {
        static void Main(string[] args)
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
            int idTeacher = teacherName.GetHashCode();

            Group group = new Group("ПВ420");
            //Console.WriteLine(group);

            //group.Teacher = idTeacher;

            //Console.WriteLine(group);
            group.AddStudent(new Student("Иванов", "Андрей", "Федорович", new DateOnly(2000, 7, 12), "Одесса", group.Name));
            group.AddStudent(new Student("Соколов", "Василий", "Петрович", new DateOnly(2000, 11, 21), "Николаев", group.Name));
            group.AddStudent(new Student("Антонова", "Елизавета", "Григорьевна", new DateOnly(2000, 9, 18), "Херсон", group.Name));
            Console.WriteLine("Добавлены студенты, преподаватель неизвестен:");
            group.ShowStudents();
            group.Teacher = idTeacher;
            Console.WriteLine("Добавлен преподаватель:");
            group.ShowStudents();

            group.ChangeNameGroup("ПВ421");
            Console.WriteLine("Изменено название группы:");
            group.ShowStudents();
            Student st = new Student("Антонова", "Елизавета", "Григорьевна", new DateOnly(2000, 9, 18), "Херсон", group.Name);
            st.CurrentTeacher = idTeacher;
            st.SetMark(11, idTeacher, teacherName, MarkType.Pass);
            Console.WriteLine(group.hasStudent(st));

            Group group1 = new Group("ПВ422");
            group.TransferStudent(st, group1);
            Console.WriteLine("Переведен студент:");
            group.ShowStudents();
            group1.ShowStudents();
            group1.ChangeStudentInfo(1);
            group1.ShowStudents();
        }
    }
}
