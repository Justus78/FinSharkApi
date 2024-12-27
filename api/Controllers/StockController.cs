using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.DTOs.Stock;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;

        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _context = context;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {

            var stocks = await _stockRepo.GetAllAsync(query);

            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto StockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var stockModel = StockDto.ToStockFromCreateDTO(); // map from dto
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetbyId), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var stockModel = await _stockRepo.UpdateAsync(id, updateStockDto);
            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var stockModel = await _stockRepo.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    } // end controller
} // end namespace