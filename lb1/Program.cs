using System;
namespace lb1
{
    enum Menu
    {
        Exit,
        AddStudent,
        SetMarks,
        GetMarks,
        CompareStudents,
        ShowInfo
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Menu choise;
            var students = new Student[10];
            int nStudents = 2;
            students[0] = new Student("Шолохов Семен Володимирович", "123456789", 4);
            students[1] = new Student("Кузнецов Петро Михайлович", "987654321", 3);
            while (exit != true)
            {
                int i = 0;
                Console.WriteLine("Choose menu index: ");
                foreach (var item in Enum.GetNames(typeof(Menu)))
                {
                    Console.WriteLine($"{i++}. {item}");
                }
                Console.Write("> ");
                choise = (Menu)int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case Menu.AddStudent:
                        {
                            try
                            {
                                Console.WriteLine("Enter name of the student: ");
                                string name = Console.ReadLine();
                                Console.WriteLine($"Enter number of the student {name} recordbook: ");
                                string id = Console.ReadLine();
                                Console.WriteLine($"Enter students {name} course: ");
                                int course = int.Parse(Console.ReadLine());
                                var stud = new Student(name, id, course);
                                students[nStudents++] = stud;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An error occurred: {e.Message}");
                            }
                            break;
                        }
                    case Menu.SetMarks:
                        {
                            try
                            {
                                i = 0;
                                Console.WriteLine("Choose the student: ");
                                foreach (var student in students)
                                {
                                    if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                                }
                                var choosenStudent = students[int.Parse(Console.ReadLine())];
                                Console.WriteLine("Choose the subject: ");
                                i = 0;
                                foreach (string subject in Enum.GetNames(typeof(Subjects)))
                                {
                                    Console.WriteLine($"{i++}. {subject}");
                                }
                                var choosenSubject = (Subjects)int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter mark: ");
                                choosenStudent.SetMark(choosenSubject, int.Parse(Console.ReadLine()));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"An error occured: {e.Message}");
                            }
                            break;
                        }
                    case Menu.GetMarks:
                        {
                            i = 0;
                            Console.WriteLine("Choose the student: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                            }
                            var choosenStudent = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine("Choose the subject: ");
                            i = 0;
                            foreach (string subject in Enum.GetNames(typeof(Subjects)))
                            {
                                Console.WriteLine($"{i++}. {subject}");
                            }
                            var choosenSubject = (Subjects)int.Parse(Console.ReadLine());
                            Console.WriteLine($"Mark: {choosenStudent.GetMark(choosenSubject)}");
                            break;
                        }
                    case Menu.CompareStudents:
                        {
                            i = 0;
                            Console.WriteLine("Choose two students by entering their indexes: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) 
                                    Console.WriteLine($"{i++}. {student.Name}");
                            }
                            var chosenStudent1 = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine($"First student: {chosenStudent1.ToString()}");
                            var chosenStudent2 = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine($"Second student: {chosenStudent2.ToString()}");
                            Console.WriteLine("Reesult of the comparing: ");
                            i = 0;
                            foreach (string subject in Enum.GetNames(typeof(Subjects)))
                            {
                                Console.WriteLine($"{i}. {subject}");
                                Console.WriteLine($"First: {chosenStudent1.GetMark((Subjects)Enum.Parse(typeof(Subjects), subject))}");
                                Console.WriteLine($"Second: {chosenStudent2.GetMark((Subjects)Enum.Parse(typeof(Subjects), subject))}");
                                Console.WriteLine($"Difference: {chosenStudent1.CompareTo(chosenStudent2)[i++]}");
                            }
                            break;
                        }
                    case Menu.ShowInfo:
                        {
                            i = 0;
                            Console.WriteLine("Choose student: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                            }
                            Console.WriteLine(students[int.Parse(Console.ReadLine())].ToString());
                            break;
                        }
                    case Menu.Exit:
                        {
                            exit = true;
                            break;
                        }
                }
            }
        }
    }
    
}

