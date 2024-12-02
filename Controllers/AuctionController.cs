using AuctionsAPI.Data;
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

        [HttpGet("{id:int}", Name ="GetAuction")]
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

        [HttpPost]
        public async Task<IActionResult> CreateAuction([FromBody] CreateAuctionDTO auctionDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateAuction)}");
                return BadRequest(ModelState);
            }

            try
            {
                var auction = _mapper.Map<Auction>(auctionDTO);
                await _unitOfWork.Auctions.Insert(auction);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetAuction", new { id = auction.Id }, auction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateAuction)}");
                return StatusCode(500, "Internal server Error. Please try again later.");

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAuction)}");
                return BadRequest();
            }

            try
            {
                var auction = await _unitOfWork.Auctions.Get(q => q.Id == id);
                if (auction == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAuction)}");
                    return BadRequest("Submitted data is invalid");
                }
                await _unitOfWork.Auctions.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(DeleteAuction)}");
                return StatusCode(500, "Internal server error. Please try again later.");

            }
        }
    }


}
