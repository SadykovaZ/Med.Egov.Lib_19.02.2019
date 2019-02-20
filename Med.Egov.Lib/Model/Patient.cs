using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class Patient:People
    {
        public Patient() : base()
        {

        }

        public Patient(string name, string surname, string middleName = ""): base(name, surname,middleName)
        {
            this.Name = name;
            this.Surname = surname;
            this.MiddleName = middleName;
        }

        private string IIN;
        public string Iin {
            get
            {
                return IIN;
            }
            set
            {
                if (value.Length != 12)
                {
                    throw new ArgumentException("Введите корректный ИИН");
                }
                IIN = value;
            }
        }
        public MedOrg MedOrg { get; set; } = null;
        public int MedOrgID { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Прикреплен к {0}", MedOrg.Name);
        }

        public override double GetDiscount()
        {
            return 0.2;
        }
    }
}
