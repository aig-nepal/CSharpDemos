using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMSDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "ACbe27ed0dd8c5951f4308939c849bde12";
            string authToken = "f48a3a6f09153b4daf81f7f5113bac72";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            body: "Hi there!",
            from: new Twilio.Types.PhoneNumber("+13178861072"),
            to: new Twilio.Types.PhoneNumber("+9779804020737")
        );

            Console.WriteLine(message.Sid);
        }
    }
}
