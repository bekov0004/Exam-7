using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RoleServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RoleServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<RoleDto>>> GetRole()
    {
        var result =await _context.Roles.ToListAsync();
        return new Response<List<RoleDto>>(_mapper.Map<List<RoleDto>>(result));
    }

    public async Task<Response<RoleDto>> AddRole(RoleDto roleDto)
    {
        try
        {
            var mapped = _mapper.Map<Role>(roleDto);
           await _context.Roles.AddAsync(mapped);
           await _context.SaveChangesAsync();
            return new Response<RoleDto>(roleDto);

        }
        catch (Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<RoleDto>> UpdateRole(RoleDto roleDto)
    {
        try
        {
            var mapped = _mapper.Map<Role>(roleDto);
            _context.Roles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RoleDto>(roleDto);

        }
        catch (Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteRole(int id)
    {
        var existing = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (existing==null)
        {
            return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });
        }

        var delete =await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        _context.Roles.Remove(delete);
        await _context.SaveChangesAsync();
        return new Response<string>("Delete Successfully");

    }
}