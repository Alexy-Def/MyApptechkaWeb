using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service.Interface
{
    public interface ISmsService
    {
        int CreateCodeFromSms();
        void SendSMS(string tel, string text);
    }
}
