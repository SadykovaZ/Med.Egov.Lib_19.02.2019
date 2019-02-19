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

    }
}
