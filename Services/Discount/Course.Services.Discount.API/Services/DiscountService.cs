using Course.Share.Dtos;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services.Discount.API.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var deleteDiscount = await _dbConnection.ExecuteAsync("DELETE FROM discount WHERE Id = @id", new { Id = id });

            return deleteDiscount > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found",404);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount")).ToList();
            return Response<List<Models.Discount>>.Success(discounts, 200);
        }
            
        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = await _dbConnection.QueryAsync("SELECT * FROM discount WHERE Code = @Code AND UserId = @UserId",new {Code =  code,UserId = userId});

            return discount != null ? Response<Models.Discount>.Success(discount.SingleOrDefault(), 200) : Response<Models.Discount>.Fail("Discount not found",404);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where id = @id", new { Id = id })).SingleOrDefault();

            if (discount == null) return Response<Models.Discount>.Fail("Discount not found",404);

            return Response<Models.Discount>.Success(discount, 200);

        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var saveStatus = await _dbConnection.ExecuteAsync("INSERT INTO discount(UserId,Rate,Code) VALUES(@UserId,@Rate,@Code)",discount);

            if (saveStatus > 0) return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error occured while save operation", 500);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            if(discount.Id == 0 || discount.Id < 0)
            {
                return Response<NoContent>.Fail("Discount not found", 404);
            } 

            var status = await _dbConnection.ExecuteAsync("UPDATE discount SET UserId = @UserId, Code = @Code, Rate = @Rate WHERE Id =@Id",
                                                          new { Id = discount.Id, UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate });

            if (status > 0) return Response<NoContent>.Success(204);

            return Response<NoContent>.Fail("An error occured while update operation", 500);
        }
    }
}
