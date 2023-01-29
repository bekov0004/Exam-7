using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RolePermissionServices
{  
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RolePermissionServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<RolePermissionDto>>> GetRolePermission()
    {
        var result =await _context.RolePermissions.ToListAsync();
        return new Response<List<RolePermissionDto>>(_mapper.Map<List<RolePermissionDto>>(result));
    }

    public async Task<Response<RolePermissionDto>> AddRolePermission(RolePermissionDto rolePermissionDto)
    {
        try
        {
            var mapped = _mapper.Map<RolePermission>(rolePermissionDto);
           await _context.RolePermissions.AddAsync(mapped);
           await _context.SaveChangesAsync();
            return new Response<RolePermissionDto>(rolePermissionDto);

        }
        catch (Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<RolePermissionDto>> UpdateRolePermission(RolePermissionDto rolePermissionDto)
    {
        try
        {
            var mapped = _mapper.Map<RolePermission>(rolePermissionDto);
            _context.RolePermissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RolePermissionDto>(rolePermissionDto);

        }
        catch (Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteRolePermission(int id)
    {
        var existing = await _context.RolePermissions.FirstOrDefaultAsync(x => x.Id == id);
        if (existing==null)
        {
            return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });
        }

        var delete =await _context.RolePermissions.FirstOrDefaultAsync(x => x.Id == id);
        _context.RolePermissions.Remove(delete);
        await _context.SaveChangesAsync();
        return new Response<string>("Delete Successfully");

    }
}