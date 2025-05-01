using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace External.Authentication.Twilio
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        const string SERVICEID = "VAbc532eb7b10920d2b5249d10d3b1398b";
        public AuthMessageSender(IOptions<SMSoptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public SMSoptions Options { get; }  // set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = Options.SMSAccountIdentification;
            // Your Auth Token from twilio.com/console
            var authToken = Options.SMSAccountPassword;

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
              to: new PhoneNumber(number),
              from: new PhoneNumber(Options.SMSAccountFrom),
              body: message);
        }

        public Task GetSMSCodeAsync(string mobile)
        {
            var accountSid = Options.SMSAccountIdentification;
            // Your Auth Token from twilio.com/console
            var authToken = Options.SMSAccountPassword;
            TwilioClient.Init(accountSid, authToken);
            //Step 2 -- Send Verification token
            try
            {
                var verification = VerificationResource.Create(
                                                  to: "+91" + mobile,
                                                  channel: "sms",
                                                  pathServiceSid: SERVICEID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(1);
            //Console.WriteLine(verification.Status);
        }
        public Task<string> VerifySMSCodeAsync(string mobile, string code)
        {
            var accountSid = Options.SMSAccountIdentification;
            // Your Auth Token from twilio.com/console
            var authToken = Options.SMSAccountPassword;
            TwilioClient.Init(accountSid, authToken);
            //Step 3 --  Verification of token
            var verificationCheck = VerificationCheckResource.Create(
             to: "+91" + mobile,
            code: code,
            pathServiceSid: SERVICEID);
            return Task.FromResult(verificationCheck.Status);
        }
    }
}
