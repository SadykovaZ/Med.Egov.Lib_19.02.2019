using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
namespace Med.Egov.Lib.Model
{
    class ServiceRequest
    {
        private LiteEntity db = new LiteEntity();
        private Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool CreateRequest(Request r)
        {
            try
            {
                db.CreateRequest(r);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return false;
            }
        }

        public List<Request> GetUserRequest(int id)
        {
            return db.GetRequestsByPatientId(id);
        }

        public List<Request> GetMedOrgRequest(int id)
        {
            return db.GetRequestsByMedOrgId(id);
        }

        public void changeRequestStatus(Request r)
        {
            switch (r.requestStatus)
            {

                case RequestStatus.approve:
                    {
                        //1.получить организацию patient
                        if (r.Patient.MedOrg != null)
                        {
                            int MedOrgId = r.Patient.MedOrg.Id;
                            int PatientId = r.PatientId;
                            //2.удалить с организации User данного User
                            ServiceMedOrg.RemovePatientFromMedOrg(MedOrgId,PatientId);
                        }

                        //3.проставить User новую организацию
                        ServiceUser.updateUserMedOrg(r.MedOrgId, r.PatientId);
                        //4.добавить в новую организацию User
                        ServiceMedOrg.AddPatientFromMedOrg(r.MedOrgId, r.PatientId);
                    }
                    break;
                case RequestStatus.reject:
                    db.UpdateRequest(r);
                    break;

            }
        }

    }
}
