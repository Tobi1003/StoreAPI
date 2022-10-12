using BookStoreASPNet6_Data.Model.Requests;
using BookStoreASPNet6_Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreASPNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController( IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _productTypeRepository.GetAllTypes();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            else
            {
                var result = await _productTypeRepository.GetTypeById(id);
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateType(CreateTypes model)
        {
            var result = await _productTypeRepository.CreateType(model);
            if(result.ErrorsMsg.Equals("sucess"))
            {
                return Ok(result); 
            }
            return BadRequest(result.ErrorsMsg);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateType(int id, CreateTypes model)
        {
            var result = await _productTypeRepository.UpdateType(id, model);
            if (result.ErrorsMsg.Equals("sucess"))
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorsMsg);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteType(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var result = await _productTypeRepository.DeleteType(id);
            return Ok(result);
        }
    }
}
