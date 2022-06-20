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
    public class BookingController : ControllerBase
    {
        private readonly KRISHBOOKINGDBContext _dbContext;
        public BookingController(KRISHBOOKINGDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]       
        public  async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.Bookings.ToListAsync();
                return Ok(response);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookingDto item)
        {
            try
            {

                var response = await _dbContext.Bookings.AddAsync(new Booking());
                if (response.Entity != null)
                {
                    return Ok(response);
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
