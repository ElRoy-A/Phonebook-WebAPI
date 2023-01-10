using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Data;
using PhonebookAPI.Models;

namespace PhonebookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonebookController : Controller
    {
        private readonly PhonebookAPIDbContext dbContext;

        // Constructor
        public PhonebookController(PhonebookAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /**************
         * CRUD METHODS
         **************/

        // Read (GET) methods
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            // check if id exists
            Contact? contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

        // Create (POST) method
        [HttpPost]
        public async Task<IActionResult> AddContact(ContactRequest addContact)
        {
            Contact contact = new()
            {
                FirstName = addContact.FirstName,
                LastName = addContact.LastName,
                PhoneNumber = addContact.PhoneNumber,
                Email = addContact.Email,
                Address = addContact.Address
            };

            await dbContext.Contacts.AddAsync(contact);

            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        // Update (PUT) method
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, ContactRequest updateContact)
        {
            // check if id exists
            Contact? contact = dbContext.Contacts.Find(id);

            if (contact != null)
            {
                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.PhoneNumber = updateContact.PhoneNumber;
                contact.Email = updateContact.Email;
                contact.Address = updateContact.Address;

                await dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

        // Delete (DELETE) method
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            // check if id exists
            Contact? contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                dbContext.Remove(contact);

                await dbContext.SaveChangesAsync();

                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
