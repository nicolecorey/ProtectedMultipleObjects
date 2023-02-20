// using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace Inheritance
{

    class Students
    {
        protected int _Id;
        protected string _Name;
        protected int _gradYear;

        public Students()
        {
            _Id = 0;
            _Name = string.Empty;
            _gradYear = 0;
        }
        public Students(int id, string name, int gradYear)
        {
            _Id = id;
            _Name = name;
            _gradYear = gradYear;
        }
        
        public virtual void addChange()
        {
            Console.Write("ID:");
            _Id=int.Parse(Console.ReadLine());
            Console.Write("Name:");
            _Name=Console.ReadLine();
            Console.Write("Graduation Year:");
            _gradYear=int.Parse(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine("Student Information:");
            Console.WriteLine($"ID: {_Id}");
            Console.WriteLine($"Name: {_Name}");
            Console.WriteLine($"Graduation Year: {_gradYear}");
        }
    }
    class Teachers : Students
    {
        protected string _Subject;
        protected string _Location;

        public Teachers()
            : base()
        {
            _Subject = string.Empty;
            _Location = string.Empty;
        }
        public Teachers(int id, string name, int gradYear, string subject, string location)
        {
            _Id= id;
            _Name= name;    
            _gradYear= gradYear;
            _Subject = subject;
            _Location = location;
        }
        public override void addChange()
        {
            Console.WriteLine("Teacher Information");
            Console.Write($"ID:");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("Name:");
            _Name = Console.ReadLine();
            Console.Write("Graduation Year:");
            _gradYear = int.Parse(Console.ReadLine());
            Console.WriteLine($"Subject Taught:");
            _Subject = Console.ReadLine();
            Console.WriteLine($"Location:");
            _Location = Console.ReadLine();
            Console.WriteLine();
        }
        public override void print()
        {
            Console.WriteLine();
            Console.WriteLine("      Teachers    ");
            Console.WriteLine("------------------");
            Console.WriteLine($" ID: {_Id}   Name: {_Name}");
            Console.WriteLine($" Graduation Year: {_gradYear}");
            Console.WriteLine($"Subject Taught: {_Subject}");
            Console.WriteLine($" Location: {_Location}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many students do you want to enter?");
            int maxStudents;
            while (!int.TryParse(Console.ReadLine(), out maxStudents))
                Console.WriteLine("Please enter a whole number");

            Students[] students = new Students[maxStudents];

            Console.WriteLine("How many Teachers do you want to enter?");
            int maxTeachers;
            while (!int.TryParse(Console.ReadLine(), out maxTeachers))
                Console.WriteLine("Please enter a whole number");

            Teachers[] teachers = new Teachers[maxTeachers];

            int choice, rec, type;
            int studentCounter = 0, teacherCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Teacher or 2 for Student");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Teacher or 2 for Student");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (teacherCounter <= maxTeachers)
                                {
                                    teachers[teacherCounter] = new Teachers();
                                    teachers[teacherCounter].addChange();
                                    teacherCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of Teachers has been reached.");

                            }
                            else
                            {
                                if (studentCounter <= maxStudents)
                                {
                                    students[studentCounter] = new Students();
                                    students[studentCounter].addChange();
                                    studentCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of students has been reached.");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the ID number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the ID number you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > teacherCounter - 1 || rec < 0)
                                {
                                    Console.Write("Your number must be in range, please try again.");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the ID number you want to change: ");
                                    rec--;
                                }
                                teachers[rec].addChange();
                            }
                            else
                            {
                                while (rec > studentCounter - 1 || rec < 0)
                                {
                                    Console.Write("Your number must be in range, please try again.");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the ID number you want to change: ");
                                    rec--;
                                }
                                students[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < teacherCounter; i++)
                                    teachers[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < studentCounter; i++)
                                    students[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("Sorry, that is not an option. Please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }
        private static int Menu()
        {
            Console.WriteLine("Please choose a selection.");
            Console.WriteLine("1:Add  2:Change  3:Display  4:End Session");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1:Add  2:Change  3:Display  4:End Session");
            return selection;
        }
    }
}
