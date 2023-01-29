using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class UserController:ApiErrorController
{
    private readonly UserServices _userServices;

    public UserController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost("Login")]
    public async Task<Response<string>> Login(LoginDto loginDto)
    {
        if (ModelState.IsValid)
        {
            return await _userServices.Login(loginDto);
        }

        return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
    }

    [HttpPost("Register")]
    public async Task<Response<string>> Regidter(RegisterDto registerDto)
    {
        if (ModelState.IsValid)
        {
            return await _userServices.Registre(registerDto);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }
}