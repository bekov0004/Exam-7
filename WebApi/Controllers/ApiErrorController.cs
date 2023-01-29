using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ApiErrorController:ControllerBase
{
    [NonAction]
    public List<string> GetModelErrors()
    {
        var errors = ModelState.Values.SelectMany(x => x.Errors.Select(x=>x.ErrorMessage)).ToList();
        return errors;
    }
}