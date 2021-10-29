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
        private Logger _logger;
        private int _interval;
        private int _serverResponse;
        private string _url;
        private string _adminEmail;
        public Pingger(int interval, int serverResponseTime, string url, string adminEmail)
        {
            _interval = interval;
            _serverResponse = serverResponseTime;
            _url = url;
            _adminEmail = adminEmail;
            cancelTokenSource = new CancellationTokenSource();
            _logger = NLog.LogManager.GetLogger("myRules");
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
            while (!token.IsCancellationRequested)
            {
                PingReply reply = ping.Send(_url, _serverResponse * 1000);
                if (PingStatus(reply))
                {
                    Thread.Sleep(_interval * 1000);
                }
                else
                {
                    break;
                }
            }
        }
        private async Task SendMessage(string email, string subject, string message)
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync(email, subject, message);
        }
        private bool PingStatus(PingReply reply)
        {
            if (reply != null)
            {
                if (reply.Status == IPStatus.Success)
                {
                    if (reply.RoundtripTime <= _serverResponse)
                    {
                        _logger.Info("Site {0} status - Active, RoundTripTime - {1}", _url, reply.RoundtripTime);
                        return true;
                    }
                    else
                    {
                        SendMessage(_adminEmail, "Site status", "Site " + _url + " Resopse time > " + _serverResponse).GetAwaiter();
                        return false;
                    }
                }
                else
                {
                    SendMessage(_adminEmail, "Site status", "Site " + _url + " is not available!").GetAwaiter();
                    return false;
                }
            }
            return false;
        }
    }
}
