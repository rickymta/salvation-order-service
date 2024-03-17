using Microsoft.AspNetCore.Mvc;
using Salvation.Services.OrderService.Models.Response;

namespace Salvation.Services.OrderService.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected ResponseObject ErrorMessage(string message, int code = -1)
    {
        return new ResponseObject { Message = message, Code = code };
    }

    protected ResponseObject ErrorMessage(object data, string message, int code = -1)
    {
        return new ResponseObject { Message = message, Code = code, Data = data };
    }

    protected ResponseObject SuccessData()
    {
        return new ResponseObject { Code = 0 };
    }

    protected ResponseObject SuccessData(object data)
    {
        return new ResponseObject { Code = 0, Data = data };
    }

    protected ResponseObject SuccessData(object data, string message)
    {
        return new ResponseObject { Code = 0, Data = data, Message = message };
    }

    protected ResponseObject SuccessMessage(string message)
    {
        return new ResponseObject { Code = 0, Message = message };
    }
}
