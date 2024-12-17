using System.Net;
using Dapper;
using Domain.Models;

namespace Infastructure.Services;

public class JobSerice:IGenericService<Jobs>
{
    private readonly DataContaxt connection = new DataContaxt();

    public async Task<Response<bool>> Create(Jobs data)
    {
        var sql = "insert into Jobs(Title,Description,Salary,Country,City,Status,CreatedAt,UpdatedAt,EmployerId) values(@Title,@Description,@Salary,@Country,@City,@Status,@CreatedAt,@UpdatedAt,@EmployerId);";
        int res = await connection.Connection().ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }

    public async Task<Response<List<Jobs>>> GetAll()
    {
        var sql = "select * from jobs;";
        var res = (await connection.Connection().QueryAsync<Jobs>(sql)).ToList();
        return new Response<List<Jobs>>(res);
    }

    public async Task<Response<Jobs>> GetById(int id)
    {
        var sql = "select * from jobs where JobId = @ID;";
        var res = await connection.Connection().QueryFirstOrDefaultAsync<Jobs>(sql, new { ID = id });
        return new Response<Jobs>(res);
    }

    public async Task<Response<bool>> Update(Jobs data)
    {
        var sql = "update jobs set Title=@Title,Description=@Description,Salary=@Salary,Country=@Country,City=@City,Status=@Status,CreatedAt=@CreatedAt,UpdatedAt=@UpdatedAt,EmployerId=@EmployerId where JobId=@JobId;";
        var res = await connection.Connection().ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = "delete from jobs where jobid=@ID;";
        var res = await connection.Connection().ExecuteAsync(sql,new{ID=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }
}