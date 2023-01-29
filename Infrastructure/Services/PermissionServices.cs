using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PermissionServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PermissionServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<PermissionDto>>> GetPermission()
    {
        var result =await _context.Roles.ToListAsync();
        return new Response<List<PermissionDto>>(_mapper.Map<List<PermissionDto>>(result));
    }

    public async Task<Response<PermissionDto>> AddPermission(PermissionDto permissionDto)
    {
        try
        {
            var mapped = _mapper.Map<Permission>(permissionDto);
            await _context.Permissions.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<PermissionDto>(permissionDto);

        }
        catch (Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto permissionDto)
    {
        try
        {
            var mapped = _mapper.Map<Permission>(permissionDto);
            _context.Permissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<PermissionDto>(permissionDto);

        }
        catch (Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeletePermission(int id)
    {
        var existing = await _context.Permissions.FirstOrDefaultAsync(x => x.Id == id);
        if (existing==null)
        {
            return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });
        }

        var delete =await _context.Permissions.FirstOrDefaultAsync(x => x.Id == id);
        _context.Permissions.Remove(delete);
        await _context.SaveChangesAsync();
        return new Response<string>("Delete Successfully");

    }
}