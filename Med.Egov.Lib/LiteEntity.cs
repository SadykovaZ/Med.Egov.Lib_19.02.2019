using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Med.Egov.Lib.Model;
namespace Med.Egov.Lib
{
    public class LiteEntity
    {
        private LiteDatabase db = null;

        public LiteEntity()
        {
            db = new LiteDatabase("Med.db");
        }
        public void CreateRequest(Request r)
        {
            var requests = db.GetCollection<Request>("requests");
            requests.Insert(r);
            
        }

        public List<Request> GetRequests()
        {
            var requests = db.GetCollection<Request>("requests");
            return requests.FindAll().ToList();
        }


        public List<Request> GetRequests(int id)
        {
            var requests = db.GetCollection<Request>("requests");
            return requests.FindAll().Where(w=>w.Id==id).ToList();
        }

        public List<Request> GetRequestsByPatientId(int PatientId)
        {
            var requests = db.GetCollection<Request>("requests");
            return requests.FindAll().Where(w => w.PatientId == PatientId).ToList();
        }

        public List<Request> GetRequestsByMedOrgId(int MedOrgId)
        {
            var requests = db.GetCollection<Request>("requests");
            return requests.FindAll().Where(w => w.MedOrgId == MedOrgId).ToList();
        }

        public void UpdateRequest(Request r)
        {
            var requests = db.GetCollection<Request>("requests");
            requests.Update(r);
        }


    }
}
