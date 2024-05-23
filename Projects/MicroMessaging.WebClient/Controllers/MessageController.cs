using MicroMessaging.WebClient.Configuration;
using MicroMessaging.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroMessaging.WebClient.Controllers
{
    public class MessageController : Controller
    {
        private readonly IConfiguration _configuration;
      
        public MessageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString(ServerConfiguration.ConnectionStringName).Trim('/');
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Sender()
        {
            return View(new ServerSettingsViewModel { ConnectionString = ConnectionString});
        }

        public IActionResult Receiver()
        {
            return View(new ServerSettingsViewModel { ConnectionString = ConnectionString });
        }

        public IActionResult ViewLastMessages()
        {
            return View(new ServerSettingsViewModel { ConnectionString = ConnectionString });
        }
    }
}
