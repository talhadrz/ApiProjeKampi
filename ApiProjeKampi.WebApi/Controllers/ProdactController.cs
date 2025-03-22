using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdactController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ProdactController(IValidator<Product> prodact, ApiContext apiContext, IMapper mapper)
        {
            _validator = prodact;
            _context = apiContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProdactList()
        {
            var values = _context.products.ToList();
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
                _context.products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün Ekleme işlemi başarılı"); 
            }
        }
        [HttpDelete]
        public IActionResult DeleteProdact(int id)
        {
            var value = _context.products.Find(id);
            _context.products.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı"); 
        }
        [HttpGet("GetProdact")]
        public IActionResult GetProdact(int id)
        {
            var value = _context.products.Find(id);
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
                _context.products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün güncelleme işlemi başarılı");
            }
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.products.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpGet("ProductWithCategory")]
        public IActionResult ProductWithCategory()
        {
            var value = _context.products.Include(x => x.category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(value));
        }
    }
}
