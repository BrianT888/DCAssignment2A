using DCAssignment2A.Data;
using DCAssignment2A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAssignment2A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly DBManager _context;

        public UserProfilesController(DBManager context)
        {
            _context = context;
        }

        // GET: api/UserProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return userProfile;
        }

        // PUT: api/UserProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile(int id, UserProfile userProfile)
        {
            if (id != userProfile.UserProfileId)
            {
                return BadRequest();
            }

            _context.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserProfiles
        // wait we don't have exception handling for duplicate names or duplicate user profiles with matching data oops?
        [HttpPost]
        public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
        {
            //set the user profile to have the default profile picture
            userProfile.profilePicture = ProfilePicReader.GetDefaultPFP();

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserProfile", new { id = userProfile.UserProfileId }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserProfileExists(int id)
        {
            return _context.UserProfiles.Any(e => e.UserProfileId == id);
        }

        // GET: Username = api/UserProfiles/Name/{name}
        [HttpGet("Name/{name}")]
        public async Task<ActionResult<UserProfile>> GetUserProfileByUsername(string name)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.name == name);

            if (userProfile == null)
            {
                return NotFound($"No User found for {name}");
            }

            return userProfile;
        }

        // GET: Email = api/UserProfiles/Email/{email}
        [HttpGet("Email/{email}")]
        public async Task<ActionResult<UserProfile>> GetUserProfileByEmail(string email)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.email == email);

            if (userProfile == null)
            {
                return NotFound($"No User found for {email}");
            }

            return userProfile;
        }

        //get the profile picture for a user
        [HttpGet("ProfilePic/{id}")]
        public async Task<IActionResult> GetUserPFP(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);

            if (userProfile == null)
            {
                return NotFound($"No User found for {id}");
            }

            return File(userProfile.profilePicture, "image/jpeg");
        }

        // Update Name
        [HttpPut]
        [Route("UpdateName/{username}/{newName}")]
        public async Task<IActionResult> UpdateName(string username, string newName)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.name == username);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            userProfile.name = newName;
            await _context.SaveChangesAsync();

            return Ok($"Successfully updated name to {newName}");
        }

        // Update Email
        [HttpPut]
        [Route("UpdateEmail/{username}/{newEmail}")]
        public async Task<IActionResult> UpdateEmail(string username, string newEmail)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.name == username);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            userProfile.email = newEmail;
            await _context.SaveChangesAsync();

            return Ok($"Successfully updated email to {newEmail}");
        }

        // Update Address
        [HttpPut]
        [Route("UpdateAddress/{username}/{newAddress}")]
        public async Task<IActionResult> UpdateAddress(string username, string newAddress)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.name == username);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            userProfile.address = newAddress;
            await _context.SaveChangesAsync();

            return Ok($"Successfully updated address to {newAddress}");
        }

        // Update Phone Number
        [HttpPut]
        [Route("UpdatePhoneNumber/{username}/{newPhoneNumber}")]
        public async Task<IActionResult> UpdatePhoneNumber(string username, string newPhoneNumber)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.name == username);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            userProfile.phoneNumber = newPhoneNumber;
            await _context.SaveChangesAsync();

            return Ok($"Successfully updated phone number to {newPhoneNumber}");
        }

        // Update Password
        [HttpPut]
        [Route("UpdatePassword/{username}/{newPassword}")]
        public async Task<IActionResult> UpdatePassword(string username, string newPassword)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.name == username);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            userProfile.password = newPassword;
            await _context.SaveChangesAsync();

            return Ok($"Successfully updated password");
        }
    }
}
