using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class RolePermissionController:ApiErrorController
{
    private RolePermissionServices _rolePermissionServices;

    public RolePermissionController(RolePermissionServices rolePermissionServices)
    {
        _rolePermissionServices = rolePermissionServices;
    }

    [HttpGet("GetRolePermission")]
    public async Task<Response<List<RolePermissionDto>>> GetRolePermission()
    {
        return await _rolePermissionServices.GetRolePermission();
    }

    [HttpPost("AddRolePermission")]
    public async Task<Response<RolePermissionDto>> AddRolePermission(RolePermissionDto rolePermissionDto)
    {
        if (ModelState.IsValid)
        {
            return await _rolePermissionServices.AddRolePermission(rolePermissionDto);
        }
        else
        {
            return new Response<RolePermissionDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpPut("UpdateRolePermission")]
    public async Task<Response<RolePermissionDto>> UpdateRolePermission(RolePermissionDto rolePermissionDto)
    {
        if (ModelState.IsValid)
        {
            return await _rolePermissionServices.UpdateRolePermission(rolePermissionDto);
        }
        else
        {
            return new Response<RolePermissionDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpDelete("DeleteRolePermission")]
    public async Task<Response<string>> DeleteRolePermission(int id)
    {
        if (ModelState.IsValid)
        {
            return await _rolePermissionServices.DeleteRolePermission(id);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }
}