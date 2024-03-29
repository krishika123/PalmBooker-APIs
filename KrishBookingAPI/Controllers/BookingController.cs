﻿using AutoMapper;
using KrishBookingAPI.Data;
using KrishBookingAPI.Entities;
using KrishBookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KrishBookingAPI.Controllers
{
    [Authorize]    
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly KRISHBOOKINGDBContext _dbContext;
        private readonly IMapper _mapper;

        public BookingController(KRISHBOOKINGDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("GetBookings")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.Bookings
                    .Where(c => c.StatusAoD != "DEL")
                    .Include(c => c.User).ThenInclude(c=>c.AspNetUserClaims)
                    .Include(c => c.Facility)
                    .ToListAsync();
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

        [AllowAnonymous]
        [HttpGet("GetDeletedBookings")]
        public async Task<IActionResult> GetDeleted()
        {
            try
            {
                var response = await _dbContext.Bookings
                    .Where(c => c.StatusAoD == "DEL")
                    .Include(c => c.User)
                    .Include(c => c.Facility)
                    .ToListAsync();
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

        [AllowAnonymous]
        [HttpGet("GetBookingBy{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _dbContext.Bookings
                    .Where(c => c.Id == id && c.StatusAoD != "DEL")
                    .Include(c => c.User)
                    .Include(c => c.Facility)
                    .ToListAsync();
                if(response != null)
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

        [AllowAnonymous]
        [HttpGet("GetBookingsByEmail{email}")]
        public async Task<IActionResult> GetBookingsByEmail(string email)
        {
            try
            {                

                var response = await _dbContext.Bookings                    
                    .Include(c => c.User).ThenInclude(c => c.AspNetUserClaims)
                    .Include(c => c.Facility)
                    .Where(c => c.User.AspNetUserClaims.FirstOrDefault(c => c.ClaimType == "email").ClaimValue == email && c.StatusAoD != "DEL")
                    .ToListAsync();
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

        [Authorize]
        [HttpGet("GetUserBookings")]
        public async Task<IActionResult> GetUserBookings()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
                var response = await _dbContext.Bookings                    
                    .Include(c => c.User).ThenInclude(c => c.AspNetUserClaims)
                    .Include(c => c.Facility)
                    .Where(c => c.UserId == userId && c.StatusAoD != "DEL")
                    .ToListAsync();
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

        //[Authorize]
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> Post(CreateBookingDto item)
        {
            try
            {

                Booking mapBooking = _mapper.Map<Booking>(item);

                //var userid = HttpContext.User.Claims.Where(c=>c.Type=="sub").FirstOrDefault().Value;
                mapBooking.UserId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
                //mapBooking.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var response2 = await _dbContext.Bookings.AddAsync(mapBooking);
                var response3 = await _dbContext.SaveChangesAsync();
                if (response3 > 0)
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

        [AllowAnonymous]
        [HttpPut("UpdateBookingBy{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateBookingDto booking)
        {
            //auto mapper
            Booking mapBooking = _mapper.Map<Booking>(booking);

            if (id != mapBooking.Id)
                return BadRequest();

            //_dbContext.Entry(mapBooking).Entity.AdditionalInfo = EntityState.Modified.;
            _dbContext.Entry(mapBooking).State = EntityState.Modified;

            try
            {
                var response = await _dbContext.SaveChangesAsync();
                if (response > 0)
                {
                    return Ok();
                }
                throw new Exception("Booking cannot be modified now. Try Again later.");

            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FacilityExists(id))
                    return NotFound();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpDelete("DeleteBookingBy{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {

                var bookingDelete = await _dbContext.Bookings
                    .Include(c => c.Payments)
                    .Where(c => c.Id == id)
                    .ToListAsync();


                if (bookingDelete != null)
                {

                    //Hard Delete
                    //_dbContext.Bookings.RemoveRange(bookingDelete);


                    //Soft Delete
                    foreach (var item in bookingDelete)
                    {
                        item.StatusAoD = "DEL";
                    }
                    _dbContext.Bookings.UpdateRange(bookingDelete);
                    //

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
            return _dbContext.Bookings.Any(e => e.FacilityId == id);
        }
        //private bool UserFilter(BookingDetailsDto user)
        //{
        //    return _dbContext.Bookings.Any(e => e.UserId == id);
        //}
        private bool BookingExists(Guid id)
        {
            return _dbContext.Bookings.Any(e => e.Id == id);
        }
    }
}
