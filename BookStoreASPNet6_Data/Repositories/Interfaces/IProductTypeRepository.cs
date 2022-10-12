using BookStoreASPNet6_Data.Entities;
using BookStoreASPNet6_Data.Model.Requests;
using BookStoreASPNet6_Data.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreASPNet6_Data.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        public Task<IEnumerable<ProductType>> GetAllTypes();
        public Task<GetProType> GetTypeById(int id);
        public Task<ErrorResponse> CreateType(CreateTypes createTypes);
        public Task<ErrorResponse> UpdateType(int id, CreateTypes createTypes);
        public Task<bool> DeleteType(int id);
    }
}
