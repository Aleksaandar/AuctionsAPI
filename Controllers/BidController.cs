﻿using AuctionsAPI.IRepository;
using AuctionsAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly ILogger<ItemController> _logger;
        private readonly IMapper _mapper;

        public BidController(IUnitofWork unitOfWork, ILogger<ItemController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getBids()
        {
            try
            {
                var bids = await _unitOfWork.Bids.GetAll();
                var result = _mapper.Map<IList<BidDTO>>(bids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getBids)}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getBid(int id)
        {
            try
            {
                var bid = await _unitOfWork.Bids.Get(q => q.Id == id, new List<string> { "Auction"});
                var result = _mapper.Map<BidDTO>(bid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(getBid)}");
                return StatusCode(500, "Internal server Error. Please try again later.");
            }
        }
    }
}
