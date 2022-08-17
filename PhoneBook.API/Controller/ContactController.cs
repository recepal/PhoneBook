using Microsoft.AspNetCore.Mvc;
using PhoneBook.API.Requests;
using PhoneBook.API.Services;

namespace PhoneBook.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> ServiceTest()
        {
            return Ok(true);
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact(AddContactRequest request)
        {
            return Ok(await _contactService.AddContact(request));
        }

        [HttpDelete("DeleteContact")]
        public async Task<IActionResult> DeleteContact(Guid contactId)
        {
            return Ok(await _contactService.DeleteContact(contactId));
        }

        [HttpPost("AddContactDetail")]
        public async Task<IActionResult> AddContactDetail(AddContactDetailRequest request)
        {
            return Ok(await _contactService.AddContactDetail(request));
        }

        [HttpDelete("DeleteContactDetail")]
        public async Task<IActionResult> DeleteContactDetail(Guid contactDetailId)
        {
            return Ok(await _contactService.DeleteContactDetail(contactDetailId));
        }

        [HttpGet("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _contactService.GetContacts());
        }

        [HttpGet("GetContactWithDetails")]
        public async Task<IActionResult> GetContactWithDetails(Guid contactId)
        {
            return Ok(await _contactService.GetContactWithDetails(contactId));
        }
    }
}
