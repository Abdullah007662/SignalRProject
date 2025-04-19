using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ContactDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDTO>>(_contactService.BGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO dTO)
        {
            _contactService.BAdd(_mapper.Map<Contact>(dTO));
            return Ok("Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO dTO)
        {
            _contactService.BUpdate(_mapper.Map<Contact>(dTO));
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.BGetById(id);
            _contactService.BDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var value = _contactService.BGetById(id);
            return Ok(value);
        }

    }
}
