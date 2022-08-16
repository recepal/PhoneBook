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
        public async Task<IActionResult> AddProduct(AddContactRequest request)
        {
            return Ok(await _contactService.AddContact(request));
        }
    }
}
