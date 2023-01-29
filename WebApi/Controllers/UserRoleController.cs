using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class UserRoleController:ApiErrorController
{
    private UserRoleServices _userRoleServices;

    public UserRoleController(UserRoleServices userRoleServices)
    {
        _userRoleServices = userRoleServices;
    }

    [HttpGet("GetUserRole")]
    public async Task<Response<List<UserRoleDto>>> GetUserRole()
    {
        return await _userRoleServices.GetUserRole();
    }

    [HttpPost("AddUserRole")]
    public async Task<Response<UserRoleDto>> AddUserRole(UserRoleDto userRoleDto)
    {
        if (ModelState.IsValid)
        {
            return await _userRoleServices.AddUserRole(userRoleDto);
        }
        else
        {
            return new Response<UserRoleDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpPut("UpdateUserRole")]
    public async Task<Response<UserRoleDto>> UpdateUserRole(UserRoleDto userRoleDto)
    {
        if (ModelState.IsValid)
        {
            return await _userRoleServices.UpdateUserRole(userRoleDto);
        }
        else
        {
            return new Response<UserRoleDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpDelete("DeleteUserRole")]
    public async Task<Response<string>> DeleteRole(int id)
    {
        if (ModelState.IsValid)
        {
            return await _userRoleServices.DeleteUserRole(id);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }
}


















