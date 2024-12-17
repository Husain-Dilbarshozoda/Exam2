using System.Net;
using Dapper;
using Domain.Models;

namespace Infastructure.Services;

public class UsersService:IGenericService<Users>
{
    
    private readonly DataContaxt connection = new DataContaxt();
    
    public async Task<Response<bool>> Create(Users data)
    {
        var sql = "insert into Users(FullName,Email,Phone,Role,CreatedAt) values(@FullName,@Email,@Phone,@Role,@CreatedAt);";
        int res = await connection.Connection().ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }

        return new Response<bool>(res!=0);
    }

    public async Task<Response<List<Users>>> GetAll()
    {
        var sql = "select * from users;";
        var res = (await connection.Connection().QueryAsync<Users>(sql)).ToList();
        return new Response<List<Users>>(res);
    }

    public async Task<Response<Users>> GetById(int id)
    {
        var sql = "select * from users where UserId = @ID";
        var res = await connection.Connection().QueryFirstOrDefaultAsync<Users>(sql, new { ID = id });
        return new Response<Users>(res);
    }

    public async Task<Response<bool>> Update(Users data)
    {
        var sql =
            "update users set FullName=@FullName,Email=@Email,Phone=@Phone,Role=@Role,CreatedAt=@CreatedAt where UserId=@UserId;";
        var res = await connection.Connection().ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "server error");
        }

        return new Response<bool>(res != 0);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = "delete from users where userid = @ID";
        int res = await connection.Connection().ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "server error");
        }

        return new Response<bool>(res != 0);
    }
}