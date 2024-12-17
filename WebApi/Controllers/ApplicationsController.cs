using Domain.Models;
using Infastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController(IGenericService<Applications> applicationsService):ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Applications data)
    {
        return await applicationsService.Create(data);
    }

    [HttpGet]
    public async Task<Response<List<Applications>>> GetAll()
    {
        return await applicationsService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Applications>> GetById(int id)
    {
        return await applicationsService.GetById(id);
    }

    [HttpPut]
    public async Task<Response<bool>> Update(Applications data)
    {
        return await applicationsService.Update(data);
    }

    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await applicationsService.Delete(id);
    }
}