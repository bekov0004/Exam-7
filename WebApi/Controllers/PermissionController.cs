 using System.Net;
 using Domain.Dtos;
 using Domain.Entities;
 using Domain.Wrapper;
 using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class PermissionController:ApiErrorController
{
    private readonly PermissionServices _permissionServices;

    public PermissionController(PermissionServices permissionServices)
    {
        _permissionServices = permissionServices;
    }
    [HttpGet("GetPermission")]
    public async Task<Response<List<PermissionDto>>> GetPermission()
    {
        return await _permissionServices.GetPermission();
    }

    [HttpPost("AddPermission")]
    public async Task<Response<PermissionDto>> AddPermission(PermissionDto permissionDto)
    {
        if (ModelState.IsValid)
        {
            return await _permissionServices.AddPermission(permissionDto);
        }
        else
        {
            return new Response<PermissionDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpPut("UpdatePermission")]
    public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto permissionDto)
    {
        if (ModelState.IsValid)
        {
            return await _permissionServices.UpdatePermission(permissionDto);
        }
        else
        {
            return new Response<PermissionDto>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }

    [HttpDelete("DeletePermission")]
    public async Task<Response<string>> DeletePermission(int id)
    {
        if (ModelState.IsValid)
        {
            return await _permissionServices.DeletePermission(id);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }
}