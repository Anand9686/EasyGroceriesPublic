using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External.Authentication.Twilio
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
        Task GetSMSCodeAsync(string mobile);
        Task<string> VerifySMSCodeAsync(string mobile,string code);
    }
}
