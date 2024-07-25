using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPTMK
{
    public class Employee
    {

        public Employee(int id, string name, DateTime date, string gender) { 
            Id = id; Name = name; DateOfBirth = date;
            Gender= (GenderType)Enum.Parse(typeof(GenderType), gender);
        }

        public Employee( string name, DateTime date, string gender)
        {
            Name = name; DateOfBirth = date;
            Gender = (GenderType)Enum.Parse(typeof(GenderType), gender);
        }

        public Employee(string name, DateTime date, GenderType gender)
        {
            Name = name; DateOfBirth = date; Gender = gender;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (today.Month < DateOfBirth.Month || (today.Month == DateOfBirth.Month && today.Day < DateOfBirth.Day))
            {
                age--;
            }
            return age;
        }

        public override string ToString()
        {
            return Name+" "+DateOfBirth.ToString("yyyy-MM-dd") + " "+Gender.ToString()+" "+GetAge();
        }

    }
    
}
