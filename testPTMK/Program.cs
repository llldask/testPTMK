using System.Diagnostics;

namespace testPTMK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(args[0]);

            if (input == 1)
            {
                DBManager.CreateNewTableEmployee();
            }
            else if (input == 2)
            {
                string gender = args[args.Length - 1];
                string date = args[args.Length - 2];
                string name= String.Empty;
                for (int i= 1; i>= args.Length - 3; i++)
                {
                    name = args[i];
                    if (i!= args.Length - 3)
                        name += " ";
                }
                DBManager.AddNewEmployee(new Employee(name, DateTime.Parse(date), gender));
            }
            else if (input == 3)
            {
                var employees= DBManager.Select1();
                foreach (var item in employees)
                {
                    Console.WriteLine(item);
                }
            }
            else if (input == 4)
            {
                DBManager.AddArrayEmployees(GenerateArrayEmployee.GetEmployees());
            }

            else if (input == 5)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var employees = DBManager.Select2();
                stopwatch.Stop();
                foreach (var item in employees)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
