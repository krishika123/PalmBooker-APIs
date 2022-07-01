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
    [Route("api/[controller]")]
    [ApiController]

    public class ContactController : ControllerBase
    {
        private readonly KRISHBOOKINGDBContext _dbContext;
        private readonly IMapper _mapper;

        public ContactController(KRISHBOOKINGDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetContacts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.Contacts.ToListAsync();
                return Ok(response);

            }
            catch
            {
                return NoContent();
            }
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> Post(CreateContactDto item)
        {
            try
            {
                //auto mapper
                Contact mapContact = _mapper.Map<Contact>(item);

                var response = await _dbContext.Contacts.AddAsync(mapContact);
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

