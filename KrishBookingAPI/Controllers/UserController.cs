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

    public class UserController : ControllerBase
    {
        private readonly KRISHBOOKINGDBContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(KRISHBOOKINGDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _dbContext.AspNetUsers
                    .Include(c => c.Bookings)
                    .Include(c => c.AspNetUserClaims)
                    //.Include(c => c.Contacts)
                    .ToListAsync();
                if (response != null)
                {
                    var users = _mapper.Map<List<UserDetailsDto>>(response);
                    return Ok(users);
                }
                return NoContent();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet("GetUserBy{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _dbContext.AspNetUsers
                                        .Include(c => c.AspNetUserClaims)

                    .Where(c => c.Id == id.ToString())
                    .ToListAsync();
                return Ok(response);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //[HttpPost("CreateUser")]
        //public async Task<IActionResult> Post(CreateUserDto item)
        //{
        //    try
        //    {
        //        //auto mapper
        //       User mapUser = _mapper.Map<User>(item);

        //        var response = await _dbContext.Users.AddAsync(mapUser);
        //        var response2 = await _dbContext.SaveChangesAsync();
        //        if (response2 > 0)
        //        {
        //            return Ok(item);
        //        }
        //        return BadRequest();

        //    }
        //    catch (Exception e)
        //    {

        //       throw e;
        //   }
        //}

        //[HttpDelete("DeleteUserBy{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{

        //    try
        //    {

        //        var userDelete = await _dbContext.Users
        //            .Where(c => c.Id == id)
        //            .ToListAsync();


        //        if (userDelete != null)
        //        {

        //            //Hard Delete
        //            _dbContext.Users.RemoveRange(userDelete);


        //            ////Soft Delete
        //            //foreach (var item in userDelete)
        //            //{
        //            //    item.StatusAoD = "DEL";
        //            //}
        //            //_dbContext.Bookings.UpdateRange(userDelete);
        //            ////

        //            var response = await _dbContext.SaveChangesAsync();
        //            return Ok();
        //        }
        //        return NotFound();



        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}


        //[HttpPut("UpdateUserBy{id}")]
        //public async Task<IActionResult> Update(Guid id, UpdateUserDto user)
        //{
        //    //auto mapper
        //    User mapUser = _mapper.Map<User>(user);


        //    if (id != mapUser.Id)
        //        return BadRequest();

        //    //_dbContext.Entry(mapBooking).Entity.AdditionalInfo = EntityState.Modified.;
        //    _dbContext.Entry(mapUser).State = EntityState.Modified;

        //    try
        //    {

        //        var response = await _dbContext.SaveChangesAsync();
        //        return Ok();

        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {

        //        if (!UserExists(id))
        //            return NotFound();
        //    }
        //    return NoContent();
        //}


        private bool UserExists(Guid id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }

    }
}
