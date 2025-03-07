using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdactController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _apiContext;
        public ProdactController(IValidator<Product> prodact, ApiContext apiContext)
        {
            _validator = prodact;
            _apiContext = apiContext;
        }
        [HttpGet]
        public IActionResult ProdactList()
        {
            var values = _apiContext.products.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreatProduct(Product product)
        {
            var validationResul = _validator.Validate(product);
            if(!validationResul.IsValid)
            {
                return BadRequest(validationResul.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.products.Add(product);
                _apiContext.SaveChanges();
                return Ok("Ürün Ekleme işlemi başarılı");
            }
        }
        [HttpDelete]
        public IActionResult DeleteProdact(int id)
        {
            var value = _apiContext.products.Find(id);
            _apiContext.products.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Silme İşlemi Başarılı"); 
        }
        [HttpGet("GetProdact")]
        public IActionResult GetProdact(int id)
        {
            var value = _apiContext.products.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProdact(Product product)
        {
            var validationResul = _validator.Validate(product);
            if (!validationResul.IsValid)
            {
                return BadRequest(validationResul.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.products.Update(product);
                _apiContext.SaveChanges();
                return Ok("Ürün güncelleme işlemi başarılı");
            }
        }
    }
}
