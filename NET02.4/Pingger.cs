using NLog;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace NET02._4
{
    class Pingger
    {
        public CancellationTokenSource cancelTokenSource;
        Logger loger;
        int _interval;
        int _serverResponse;
        string _url;
        string _adminEmail;
        public Pingger(int interval, int serverResponseTime, string url, string adminEmail)
        {
            _interval = interval;
            _serverResponse = serverResponseTime;
            _url = url;
            _adminEmail = adminEmail;
            cancelTokenSource = new CancellationTokenSource();
            loger = NLog.LogManager.GetLogger("myRules");
        }
        public void StartPing()
        {
            CancellationToken token = cancelTokenSource.Token;
            Task task = new Task(() => Ping(token));
            task.Start();
        }
        private void Ping(CancellationToken token)
        {
            Ping ping = new Ping();
            PingReply reply;
            for (;;)
            {
                if (token.IsCancellationRequested)
                    return;
                try
                {
                    reply = ping.Send(_url, _serverResponse * 1000);
                    if (reply != null)
                    {
                        if (reply.Status == IPStatus.Success)
                        {
                            if (reply.RoundtripTime <= _serverResponse)
                            {
                                loger.Info("Site {0} status - Active, RoundTripTime - {1}", _url, reply.RoundtripTime);
                            }
                            else
                            {
                                SendMessage(_adminEmail, "Site status", "Site " + _url + " Resopse time > " + _serverResponse).GetAwaiter();
                                return;
                            }
                        }
                        else
                        {
                            SendMessage(_adminEmail, "Site status", "Site " + _url + " is not available!").GetAwaiter();
                            return;
                        }
                    }
                    Thread.Sleep(_interval * 1000);
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
        private async Task SendMessage(string email, string subject, string message)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, subject, message);
        }
    }
}
