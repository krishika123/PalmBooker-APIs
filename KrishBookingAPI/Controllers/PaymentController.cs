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

    public class PaymentController
    {
        private readonly KRISHBOOKINGDBContext _dbContext;
        private readonly IMapper _mapper;

        public PaymentController(KRISHBOOKINGDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetPayments")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.Bookings.ToListAsync();
                if (response != null)
                {
                    var bookings = _mapper.Map<List<BookingDetailsDto>>(response);
                    return Ok(bookings);
                }
                return NoContent();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
