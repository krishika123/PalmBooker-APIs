﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public BookingController(KRISHBOOKINGDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]       
        public  async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.Bookings
                    .Include(c=>c.User)
                    .Include(c=>c.Facility)
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
        [HttpGet("{id}")]       
        public  async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _dbContext.Bookings.Where(c=>c.Id==id).ToListAsync();
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
                //auto mapper
                Booking mapBooking = _mapper.Map<Booking>(item);

                var response = await _dbContext.Bookings.AddAsync(mapBooking);
                var response2 = await _dbContext.SaveChangesAsync();
                if (response2 >  0)
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


        [HttpPut("{id}")]
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
                return Ok();

            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FacilityExists(id))
                    return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            try
            {
             
                var bookingDelete = await _dbContext.Bookings.FindAsync(id);

                if (bookingDelete == null)
                    return NotFound();

                _dbContext.Bookings.Remove(bookingDelete);

                var response = await _dbContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception)
            {
                

                if (!BookingExists(id))
                 return NotFound();
            }
            return NoContent();
        }


        private bool FacilityExists(Guid id)
        {
            return _dbContext.Bookings.Any(e => e.FacilityId == id); 
        }
        private bool BookingExists(Guid id)
        {
            return _dbContext.Bookings.Any(e => e.Id == id);
        }
    }
}

