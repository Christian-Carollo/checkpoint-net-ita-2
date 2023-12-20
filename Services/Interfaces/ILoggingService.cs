using Microsoft.AspNetCore.Mvc;

namespace net_ita_2_checkpoint.Services.Interfaces
{
    public interface ILoggingService
    {
        IActionResult Log(string message);
    }
}
