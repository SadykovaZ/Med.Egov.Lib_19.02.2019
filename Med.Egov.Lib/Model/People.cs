using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public abstract class People
    {
        public int Id { get; set; }
        public People()
        { }
        public People(string name, string surname, string middleName="")
        {
            this.Name = name;
            this.Surname = surname;
            this.MiddleName = middleName;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime Dob { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - Dob.Year;
            }
        }

        public virtual void PrintSecNumber()
        {
            Random rnd = new Random();
            Console.WriteLine(rnd.Next());
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("{0} {1} {2}", Surname,Name[0],MiddleName[0]);
        }

        public abstract double GetDiscount();
    }
}
