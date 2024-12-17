using System.Net;
using Dapper;
using Domain.Models;

namespace Infastructure.Services;

public class ApplicationsService:IGenericService<Applications>
{
    private readonly DataContaxt connection = new DataContaxt();
    
    public async Task<Response<bool>> Create(Applications data)
    {
        var sql = "insert into Applications(Resume,Status,CreatedAt,UpdatedAt,JobId,ApplicantId) values(@Resume,@Status,@CreatedAt,@UpdatedAt,@JobId,@ApplicantId)";
        var res = await connection.Connection().ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }

    public async Task<Response<List<Applications>>> GetAll()
    {
        var sql = "select * from Applications;";
        var res = (await connection.Connection().QueryAsync<Applications>(sql)).ToList();
        return new Response<List<Applications>>(res);
    }

    public async Task<Response<Applications>> GetById(int id)
    {
        var sql = "select * from Applications where ApplicationId = @ID;";
        var res = await connection.Connection().QueryFirstOrDefaultAsync<Applications>(sql);
        return new Response<Applications>(res);
    }

    public async Task<Response<bool>> Update(Applications data)
    {
        var sql = "update Applications set Resume=@Resume,Status=@Status,CreatedAt=@CreatedAt,UpdatedAt=@UpdatedAt,JobId=@JobId,ApplicantId=@ApplicantId where ApplicationId = @ApplicationId;";
        var res = await connection.Connection().ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = "delete from Applications where ApplicationId=@ID";
        var res = await connection.Connection().ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }
}