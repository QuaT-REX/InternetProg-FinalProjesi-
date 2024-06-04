using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AracKiralamaPortali.Dtos;
using AracKiralamaPortali.Models;
using Microsoft.AspNetCore.Authorization;

namespace AracKiralamaPortali.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public CarsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarsDto> GetList()
        {
            var cars = _context.Cars.ToList();
            var carsDtos = _mapper.Map<List<CarsDto>>(cars);
            return carsDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public CarsDto Get(int id)
        {
            var cars = _context.Cars.Where(s => s.Id == id).SingleOrDefault();
            var carsDto = _mapper.Map<CarsDto>(cars);
            return carsDto;
        }

        [HttpPost]
        public ResultDto Post(CarsDto dto)
        {
            if (_context.Cars.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Araba Modeli Kayıtlıdır!";
                return result;
            }
            var cars = _mapper.Map<Cars>(dto);
            cars.Updated = DateTime.Now;
            cars.Created = DateTime.Now;
            _context.Cars.Add(cars);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Araba Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(CarsDto dto)
        {
            var cars = _context.Cars.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (cars == null)
            {
                result.Status = false;
                result.Message = "Araba Bulunamadı!";
                return result;
            }
            cars.Name = dto.Name;
            cars.IsActive = dto.IsActive;
            cars.Price = dto.Price;
            cars.Updated = DateTime.Now;
            cars.CategoryId = dto.CategoryId;
            _context.Cars.Update(cars);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Araba Bilgileri Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var cars = _context.Cars.Where(s => s.Id == id).SingleOrDefault();
            if (cars == null)
            {
                result.Status = false;
                result.Message = "Araba Bulunamadı!";
                return result;
            }
            _context.Cars.Remove(cars);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Araba Silindi";
            return result;
        }
    }
}
