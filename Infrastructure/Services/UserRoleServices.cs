using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserRoleServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRoleServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<UserRoleDto>>> GetUserRole()
    {
        var result =await _context.UserRoles.ToListAsync();
        return new Response<List<UserRoleDto>>(_mapper.Map<List<UserRoleDto>>(result));
    }

    public async Task<Response<UserRoleDto>> AddUserRole(UserRoleDto userRoleDto)
    {
        try
        {
            var mapped = _mapper.Map<UserRole>(userRoleDto);
           await _context.UserRoles.AddAsync(mapped);
           await _context.SaveChangesAsync();
            return new Response<UserRoleDto>(userRoleDto);

        }
        catch (Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<UserRoleDto>> UpdateUserRole(UserRoleDto userRoleDto)
    {
        
        try
        {
            var poisk = _context.UserRoles.FirstOrDefaultAsync(x => x.Id == userRoleDto.Id);
            var mapped = _mapper.Map<UserRole>(userRoleDto);
            _context.UserRoles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<UserRoleDto>(userRoleDto);

        }
        catch (Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteUserRole(int id)
    {
        var existing = await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
        if (existing==null)
        {
            return new Response<string>(HttpStatusCode.NotFound, new List<string>() { "Not Found" });
        }

        var delete =await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
        _context.UserRoles.Remove(delete);
        await _context.SaveChangesAsync();
        return new Response<string>("Delete Successfully");

    }

}