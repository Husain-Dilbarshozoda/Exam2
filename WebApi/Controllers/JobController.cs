using Domain.Models;
using Infastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IGenericService<Jobs> jobService):ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Jobs data)
    {
        return await jobService.Create(data);
    }

    [HttpGet]
    public async Task<Response<List<Jobs>>> GetAll()
    {
        return await jobService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Jobs>> GetById(int id)
    {
        return await jobService.GetById(id);
    }

    [HttpPut]
    public async Task<Response<bool>> Update(Jobs data)
    {
        return await jobService.Update(data);
    }

    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await jobService.Delete(id);
    }
}