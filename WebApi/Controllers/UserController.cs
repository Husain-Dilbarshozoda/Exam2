using Domain.Models;
using Infastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IGenericService<Users> userService):ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Users data)
    {
        return await userService.Create(data);
    }

    [HttpGet]
    public async Task<Response<List<Users>>> GetAll()
    {
        return await userService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Users>> GetById(int id)
    {
        return await userService.GetById(id);
    }

    [HttpPut]
    public async Task<Response<bool>> Update(Users data)
    {
        return await userService.Update(data);
    }

    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await userService.Delete(id);
    }
}