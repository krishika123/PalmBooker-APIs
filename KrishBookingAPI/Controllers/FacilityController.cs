using AutoMapper;
using KrishBookingAPI.Data;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KrishBookingAPI.Controllers
{
    [Authorize]
    [AllowAnonymous]
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

        [HttpGet("GetFacilityBy{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _dbContext.Facilities
                    .Where(c => c.Id == id)
                    .ToListAsync();
                return Ok(response);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [HttpPut("UpdateFacilityBy{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateFacilityDto facility)
        {
            //auto mapper
            Facility mapBooking = _mapper.Map<Facility>(facility);


            if (id != mapBooking.Id)
                return BadRequest();

            //_dbContext.Entry(mapBooking).Entity.AdditionalInfo = EntityState.Modified.;
            _dbContext.Entry(mapBooking).State = EntityState.Modified;

            try
            {

                var response = await _dbContext.SaveChangesAsync();
                return Ok();

            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FacilityExists(id))
                    return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("DeleteFacilityBy{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {

                var facilityDelete = await _dbContext.Facilities
                    .Include(c => c.Bookings)
                    .Where(c => c.Id == id)
                    .ToListAsync();

                if (facilityDelete != null)
                {
                    _dbContext.Facilities.RemoveRange(facilityDelete);

                    var response = await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();



            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool FacilityExists(Guid id)
        {
            return _dbContext.Facilities.Any(e => e.Id == id);
        }

    }
}
