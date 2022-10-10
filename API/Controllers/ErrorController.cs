using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/Error")]
    public IActionResult Error()
    {
        return Problem();
    }
}