using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.API.Controller;
using PhoneBook.API.Dtos;
using PhoneBook.API.Services;
using Xunit;

namespace PhoneBook.Test
{
    public class ContactControllerTest
    {
        private readonly Mock<IContactService> _mockContactService;
        private readonly ContactController _contactController;

        public ContactControllerTest()
        {
            _mockContactService = new Mock<IContactService>();
            _contactController = new ContactController(_mockContactService.Object);
        }

        [Fact]
        public async Task GetContacts_Should_Return_Success()
        {
            _mockContactService.Setup(x => x.GetContacts())
                              .ReturnsAsync(new List<ContactDto>() { });

            var result = await _contactController.GetContacts();

            Assert.Equal(200, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public async Task GetContactDetails_Should_Return_Success()
        {
            _mockContactService.Setup(x => x.GetContactDetailsForReport())
                              .ReturnsAsync(new List<ContactDetailDto>() { });

            var result = await _contactController.GetContactDetailsForReport();

            Assert.Equal(200, ((ObjectResult)result).StatusCode);
        }
    }
}