using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class RoleController:ApiErrorController
{
    private readonly RoleServices _roleServices;

    public RoleController(RoleServices roleServices)
    {
        _roleServices = roleServices;
    }
    
    [HttpGet("GetRole")]
    public async Task<Response<List<RoleDto>>> GetRole()
    {
        return await _roleServices.GetRole();
    }

    [HttpPost("AddRole")]
    public async Task<Response<RoleDto>> AddRole(RoleDto roleDto)
    {
        if (ModelState.IsValid)
        {
            return await _roleServices.AddRole(roleDto);
        }
        else
        {
            return new Response<RoleDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpPut("UpdateRole")]
    public async Task<Response<RoleDto>> UpdateRole(RoleDto roleDto)
    {
        if (ModelState.IsValid)
        {
            return await _roleServices.UpdateRole(roleDto);
        }
        else
        {
            return new Response<RoleDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpDelete("DeleteRole")]
    public async Task<Response<string>> DeleteRole(int id)
    {
        if (ModelState.IsValid)
        {
            return await _roleServices.DeleteRole(id);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }
}