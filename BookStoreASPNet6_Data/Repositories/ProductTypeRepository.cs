using BookStoreASPNet6_Data.Context;
using BookStoreASPNet6_Data.Entities;
using BookStoreASPNet6_Data.Model.Requests;
using BookStoreASPNet6_Data.Model.Responses;
using BookStoreASPNet6_Data.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreASPNet6_Data.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly DapperContext _context;

        public ProductTypeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            var query = "Select TypeId, TypeName from ProductType";
            using (var conn = _context.CreateConnection())
            {
                conn.Open();
                var result = await conn.QueryAsync<ProductType>(query);
                conn.Close();
                if (!result.Any())
                {
                    return null;
                }
                return result;
            }
        }

        public async Task<GetProType> GetTypeById(int id)
        {
            var query = "Select TypeName From ProductType Where TypeId = @TypeId";
            using (var conn = _context.CreateConnection())
            {
                conn.Open();
                var result = await conn.QueryAsync<GetProType>(query, new { @TypeID = id });
                conn.Close();
                if (!result.Any())
                {
                    return null;
                }
                return result.FirstOrDefault();
            }

        }

        public async Task<ErrorResponse> CreateType(CreateTypes createTypes)
        {
            var query = "Insert into ProductType(TypeName) values (@TypeName)";
            var param = new DynamicParameters();
            param.Add("TypeName", createTypes.TypeName, DbType.String);
            using (var conn = _context.CreateConnection())
            {
                conn.Open();
                var result = await conn.ExecuteAsync(query, param);
                conn.Close();
                if (result == 0)
                {
                    return new ErrorResponse("fail");
                }
                return new ErrorResponse("sucess");
            }
        }

        public async Task<ErrorResponse> UpdateType(int id, CreateTypes model)
        {
            var query = "Update ProductType Set TypeName = @TypeName Where TypeId = @TypeId";
            var param = new DynamicParameters();
            param.Add("TypeName", model.TypeName, DbType.String);
            param.Add("TypeId", id);
            using (var conn = _context.CreateConnection())
            {
                conn.Open();
                var result = await conn.ExecuteAsync(query, param);
                conn.Close();
                if (result == 0)
                {
                    return new ErrorResponse("fail");
                }
                return new ErrorResponse("sucess");
            }
        }
        public async Task<bool> DeleteType(int id)
        {
            var query = "Delete from ProductType where TypeId = @TypeId";
            using (var conn = _context.CreateConnection())
            {
                conn.Open();
                var result = await conn.QueryAsync(query, new { @TypeId = id });
                conn.Close();
                if (result.Any())
                {
                    return false;
                }
                return true;
            }
        }
    }
}
