using Microsoft.AspNetCore.Mvc;
using net_ita_2_checkpoint.Services.Interfaces;

namespace net_ita_2_checkpoint.Services
{
    public class LoggingService : ILoggingService
    {

        private int exCount = 0;

        public IActionResult Log(string message)
        {
            exCount++;
            System.Diagnostics.Debug.WriteLine($"{exCount}:{message}");

            return new ObjectResult(new { ErrorMessage = $"Error {exCount}: {message}" }) { StatusCode = 400 };
        }

    }
}
