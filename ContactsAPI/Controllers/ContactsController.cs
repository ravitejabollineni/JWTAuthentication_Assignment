using ContactsLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactsRepo _contactsRepo;
        public ContactsController(IContactsRepo contactsRepo)
        {
            _contactsRepo = contactsRepo;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contacts = await _contactsRepo.GetContacts();
                if (contacts == null)
                    return NotFound();
                return Ok(contacts);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{city}")]
       [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get(string city)
        {
            try
            {
                var contacts = await _contactsRepo.GetContactsByCity(city);
                if (contacts == null)
                    return NotFound();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {               
               var id = await _contactsRepo.AddContact(contact);
                if (id > 0)
                  return Created($"~api/contacts/{contact.ContactNo}", contact);
                 return BadRequest();
                
                
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _contactsRepo.UpdateContact(contact);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
        [HttpDelete("{contactid}")]
        public async Task<IActionResult> Delete(int contactid)
        {
                int result = await _contactsRepo.DeleteContact(contactid);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            
        }
    }
}
