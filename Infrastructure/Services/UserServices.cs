using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<string>> Registre(RegisterDto registerDto)
    {
        var existing = await _context.Users.FirstOrDefaultAsync(x =>
            x.Email == registerDto.Email || x.MobileNumber == registerDto.MobileNumber);
        if (existing != null)
        {
            return new Response<string>(HttpStatusCode.BadRequest,
                new List<string>() { "This email or phone already exists" });
        }

        var mapped = _mapper.Map<User>(registerDto);
        await _context.Users.AddAsync(mapped);
        await _context.SaveChangesAsync();
        return new Response<string>("You are successfully registered");

    }

    public async Task<Response<string>> Login(LoginDto loginDto)
    {
        var existing = await _context.Users.FirstOrDefaultAsync(x =>
            (x.Email == loginDto.Username || x.MobileNumber == loginDto.Username) && x.PassWord == loginDto.PassWord);
        if (existing==null)
        {
            return new Response<string>(HttpStatusCode.BadRequest,
                new List<string>() { "Username or password is incorrect" });
        }
        
        return new Response<string>("You are welcome");
        
        
    }
}