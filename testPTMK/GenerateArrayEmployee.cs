namespace testPTMK
{
    public class GenerateArrayEmployee
    {
        static Dictionary<GenderType, string[]> names = new Dictionary<GenderType, string[]>()
            {
            { GenderType.Male,["Carl", "Earl", "Harry", "Joshua", "Lester", "Martin", "Neil"]  },
            { GenderType.Female,["Alice", "Emily", "Olivia", "Sophia", "Ava", "Isabella", "Mia"]  }
            };

        static string[] lastnames = ["Abbott", "Baker", "Carter", "Davis", "Edwards", "Fisher", "Garcia",
                                  "Harris", "Ingram", "Jackson", "King", "Lewis", "Miller", "Nelson",
                                  "Owens", "Parker", "Quinn", "Robinson", "Smith", "Thomas", "Underwood",
                                  "Vance", "Walker", "Xavier", "Young", "Zimmerman"];


        public static Employee[] GetEmployees()
        {
            DateTime startDate = new DateTime(1950, 1, 1);
            DateTime endDate = DateTime.Now.AddYears(-18);
            DateGenerator dateGenerator = new DateGenerator(startDate, endDate);


            Random rnd = new Random();
             var employees = new Employee[1000100];
             int lastNameLenght = (employees.Length - 100) / lastnames.Length;
            int countGender = lastNameLenght / 2;
            int currentLastName = 0;
            GenderType currentGender = GenderType.Male;

            for (int i = 0; i < employees.Length-100;)
            {
                var currentNames = names[currentGender];
                var name = lastnames[currentLastName] + " " + currentNames[rnd.Next(currentNames.Length)];
                employees[i] = new Employee(name, dateGenerator.GetRandomDate(), currentGender);
                i++;
                if (i % lastNameLenght == 0 && currentLastName < lastnames.Length - 1)
                    currentLastName++;
                else if (i % lastNameLenght == 0)
                    currentLastName = 0;

                if (i % countGender == 0 && currentGender == GenderType.Male)
                    currentGender = GenderType.Female;
                else if (i % countGender == 0 && currentGender == GenderType.Female)
                    currentGender = GenderType.Male;

            }

            currentLastName = 5;

            for (int i = employees.Length - 100; i < employees.Length;i++)
            {
                var currentNames = names[currentGender];
                var name = lastnames[currentLastName] + " " + currentNames[rnd.Next(currentNames.Length)];
                employees[i] = new Employee(name, dateGenerator.GetRandomDate(), GenderType.Male);

            }

            return employees;
        }
    }
}
