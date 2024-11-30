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
                var result=_mapper.Map<IList<ItemDTO>>(items);      
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getItems)}");
                return StatusCode(500,"Internal server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getItem(int id)
        {
            try
            {
                var item = await _unitOfWork.Items.Get(q=>q.Id==id);
                var result = _mapper.Map<ItemDTO>(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getItem )}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }
    }
}
