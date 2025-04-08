

/*
 почитать статью https://metanit.com/sharp/tutorial/3.4.php прочитать 10 главу Рихтера про свойства 
для классов Студент и Группа под каждое поле реализовать соответствующие свойства. 
поля и уже написанные геттеры/сеттеры для них - удалять не надо! 
добавить в сеттеры проброску исключений, если были переданы неверные параметры на стороне клиента перехватить исключения трай-кетчем. 
 */


namespace gettersSettersTryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string teacherName = "Карпов Игорь Владимирович";



            try
            {
                Group group = new Group("ПВ420") { Course = 1 };


                Student st = new Student("Иванов", "Андрей", "Федорович", new DateOnly(2000, 7, 12), "Одесса");
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
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }                
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nпрограмма завершилась:)");
            }

        }
    }
}
