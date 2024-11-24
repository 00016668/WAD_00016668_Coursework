using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.CODEBASE._00016668.Data;
using WAD.CODEBASE._00016668.Models;
using WAD.CODEBASE._00016668.Repositories;

namespace WAD.CODEBASE._00016668.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IRepository<Contacts> _contactsRepository;


        public ContactsController(IRepository<Contacts> contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }




        // GET: api/Contacts --  getting all items
        [HttpGet]
        public async Task<IEnumerable<Contacts>> GetAll() => await _contactsRepository.GetAllAsync();
        


        
        // getting it by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(Contacts), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultContact = await _contactsRepository.GetByIdAsync(id);
            return resultContact == null ? NotFound() : Ok(resultContact);
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Contacts contact)
        {
            await _contactsRepository.AddAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = contact.ContactId }, contact);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Contacts contact)
        {
            if (id != contact.ContactId) return BadRequest();
            await _contactsRepository.UpdateAsync(contact);
            return NoContent();
        }




        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
