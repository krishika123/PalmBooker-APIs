using AutoMapper;
using KrishBookingAPI.Data;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KrishBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly KRISHBOOKINGDBContext _dbContext;
        private readonly IMapper _mapper;

        public FacilityController(KRISHBOOKINGDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetFacilities")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.Facilities.ToListAsync();
                return Ok(response);
                
                
            }
            catch 
            {
                return NoContent();
            }
        }

        [HttpPost("CreateFacility")]
        public async Task<IActionResult> Post(CreateFacilityDto item)
        {
            try
            {
                //auto mapper
                Facility mapBooking = _mapper.Map<Facility>(item);

                var response = await _dbContext.Facilities.AddAsync(mapBooking);
                var response2 = await _dbContext.SaveChangesAsync();
                if (response2 > 0)
                {
                    return Ok(item);
                }
                return BadRequest();

            }
            catch (Exception e)
            {

                throw e;
            }
        }


    }
}
