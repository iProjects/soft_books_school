using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public class db_logger
    {
        public string TAG;
        public List<notificationdto> _lstnotificationdto = new List<notificationdto>();
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public db_logger(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {

            TAG = this.GetType().Name;

            _notificationmessageEventname = notificationmessageEventname;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized db_logger", TAG));
        }

        public void lo_to_db(Exception sourceException)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("==================================================================");
            sb.Append("ERROR OCCOURED AT :" + DateTime.Now.ToString());
            sb.Append("SOURCE:" + sourceException.Source);
            sb.Append("MESSAGE:" + sourceException.Message);
            sb.Append("Whole Exception:" + sourceException.ToString());
            sb.Append("==================================================================");
            sb.Append("");

            try
            {
                error_logger_dto _weight_record_dto = new error_logger_dto();
                _weight_record_dto.error_description = "44";
                _weight_record_dto.error_date = DateTime.Now.ToString();
                _weight_record_dto.error_source = "c-sharp";

                responsedto _mssql_responsedto = mssqlapisingleton.getInstance(_notificationmessageEventname).createweightindatabase(_weight_record_dto);

                if (_mssql_responsedto.isresponseresultsuccessful)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_mssql_responsedto.responsesuccessmessage, TAG));
                }
                else
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_mssql_responsedto.responseerrormessage, TAG));
                }
            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
            }

        }
    }
}
