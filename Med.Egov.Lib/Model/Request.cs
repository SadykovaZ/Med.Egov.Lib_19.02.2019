using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.Egov.Lib.Model
{
    public enum RequestStatus { create,approve,reject}
    public class Request
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ProcessDate { get; set; }

        public int PatientId { get; set; }
        public Patient Patient = null;
        public int MedOrgId { get; set; }

        public MedOrg MedOrg { get; set; }

        public RequestStatus requestStatus { get; set; }


        public Request()
        {
            Patient = new Patient();
            MedOrg = new MedOrg();
        }

    }
}
