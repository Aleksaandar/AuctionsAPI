using AuctionsAPI.IRepository;
using AuctionsAPI.Models;
using AuctionsAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly ILogger<AuctionController> _logger;
        private readonly IMapper _mapper;

        public AuctionController(IUnitofWork unitOfWork, ILogger<AuctionController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> getAuctions()
        {
            try
            {
                var auctions = await _unitOfWork.Auctions.GetAll();
                var result = _mapper.Map<IList<AuctionDTO>>(auctions);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getAuctions)}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getAuction(int id)
        {
            try
            {
                var auction = await _unitOfWork.Auctions.Get(q => q.Id == id,new List<string> { "Item"});
                var result = _mapper.Map<AuctionDTO>(auction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getAuction)}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }
    }


}
