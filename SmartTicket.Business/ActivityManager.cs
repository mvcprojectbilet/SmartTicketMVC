using SmartTicket.Business.Result;
using SmartTicket.Entities;
using SmartTicket.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Business
{
    public class ActivityManager:ManagerBase<Activity>
    {
        public BusinessLayerResult<Activity> getuserid(int id)
        {
            //BusinessLayerResult tipinde dönücek bütün metodlar error kontroller adderror metodu ile eklenecek resulta 
            //istenen nesne Result propertisinde atanacak
            BusinessLayerResult<Activity> res = new BusinessLayerResult<Activity>();
            res.Result = Find(x=>x.Id==id);
            if (res.Result==null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı yok");

            }
            if (true)
            {
                res.AddError(ErrorMessageCode.UserAlreadyDefined, "Kullanıcı zaten tanımlı");

            }
            return res;


        }

    
    }
}
