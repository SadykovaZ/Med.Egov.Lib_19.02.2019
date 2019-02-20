using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public class ServiceMedOrg
    {
        public static bool RemovePatientFromMedOrg(int MedOrgId, int PatientId)
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var pam = db.GetCollection<PatientAddedMed>("PatientAddedMed");
                int result = pam.Delete(f => f.MedOrgId == MedOrgId && f.PatientId == PatientId);

                if (result > 0)
                    return true;
                else
                    return false;

            }

        }

        public static bool AddPatientFromMedOrg(int MedOrgId, int PatientId)
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var pam = db.GetCollection<PatientAddedMed>("PatientAddedMed");
                PatientAddedMed p = new PatientAddedMed();
                p.MedOrgId = MedOrgId;
                p.PatientId = PatientId;
                pam.Insert(p);

                return true;


            }

        }

        public static List<MedOrg> GetMedOrg()
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var medOrg = db.GetCollection<MedOrg>("MedOrg");
                return medOrg.FindAll().ToList();
            }
        }

        public static void AddMedOrg(MedOrg mOrg)
        {
            using (LiteDatabase db = new LiteDatabase("Med.db"))
            {
                var medOrg = db.GetCollection<MedOrg>("MedOrg");
                medOrg.Insert(mOrg);
            }
        }
    }
}
