using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars.API.Data;
using Cars.API.Data.Entities;
using Cars.Shared.DTO;
using Repositories;

namespace Cars.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IService<CarDto, CarDetailsDto> _carService;
        private readonly CarContext _context;
        private readonly IMapper _mapper;

        public CarsController(CarContext context, IService<CarDto, CarDetailsDto> carService)
        {
            _carService = carService;
            _context = context;
        }

        // GET: api/Cars
        [HttpGet("GetCars")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            
            var cars = await _carService.Get();
            return Ok(cars);
        }
        // GET: api/CarsDetails
        [HttpGet("GetCarsDetails")]
        public async Task<ActionResult<IEnumerable<CarDetailsDto>>> GetCarsDetails()
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }

            var cars = await _carService.GetDetails();
            return Ok(cars);
        }
        // GET: api/Cities/GetCityDetails/5
        [HttpGet("GetCarDetails/{id}")]
        public async Task<ActionResult<CarDetailsDto>> GetCarDetails(int id)
        {
            var car = await _carService.GetDetails(id); 
            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // GET: api/Cars/5
        [HttpGet("GetCar/{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            var car = await _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CarDto>> PutCar(int id, CarDto car)
        {

            if (id != car.Id)
            {
                return BadRequest();
            }

            CarDto? result = null;

            try
            {
                result = await _carService.Put(car);

                if (result is null)
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_carService.IsExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return result;
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(CarDto car)
        {
            if (car.Id > 0)
            {
                car.Id = 0;
            }

            var result = await _carService.Put(car);

            return CreatedAtAction("GetCar", new { id = result.Id }, result);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarDto>> DeleteCar(int id)
        {
            var result = await _carService.Delete(id);

            if (result is null)
            {
                return NotFound();
            }

            return result;
        }

      
    }
}
