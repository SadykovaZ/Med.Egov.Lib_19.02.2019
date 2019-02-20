using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class ServiceUser
    {
        public static bool updateUserMedOrg(int MedOrgId, int UserId)
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var patients = db.GetCollection<Patient>("User");
                var patient = patients.FindById(UserId);
                patient.MedOrgID = MedOrgId; 
                patients.Update(patient);
                return true;
            }
        }
        public static List<Patient> GetPatient()
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var patient = db.GetCollection<Patient>("Patient");
                return patient.FindAll().ToList();
            }
        }

        public static void AddPatent(Patient patient)
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var patients = db.GetCollection<Patient>("Patient");
                patients.Insert(patient);
            }
        }
    }
}
