using AuctionsAPI.Data;
using AuctionsAPI.IRepository;
using AuctionsAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IUnitofWork _unitOfWork;
        private readonly ILogger<ItemController> _logger;
        private readonly IMapper _mapper;

        public ItemController(IUnitofWork unitOfWork, ILogger<ItemController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getItems()
        {
            try
            {
                var items = await _unitOfWork.Items.GetAll();
                var result = _mapper.Map<IList<ItemDTO>>(items);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getItems)}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}", Name ="GetItem")]
        public async Task<IActionResult> getItem(int id)
        {
            try
            {
                var item = await _unitOfWork.Items.Get(q => q.Id == id);
                var result = _mapper.Map<ItemDTO>(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getItem)}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateItem)}");
                return BadRequest(ModelState);
            }

            try
            {
                var item = _mapper.Map<Item>(itemDTO);
                await _unitOfWork.Items.Insert(item);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetItem", new { id = item.Id },item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateItem)}");
                return StatusCode(500, "Internal server Error. Please try again later.");

            }
        }
    }
}
