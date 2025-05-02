using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.MessageDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var messageDTos = _mapper.Map<List<ResultMessageDTO>>(_messageService.BGetListAll());
            return Ok(messageDTos);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            _messageService.BAdd(_mapper.Map<Message>(_messageService));
            return Ok("Mesaj bilgisi başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _messageService.BGetById(id);
            _messageService.BDelete(message);
            return Ok("Mesaj bilgisi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            _messageService.BUpdate(_mapper.Map<Message>(updateMessageDTO));
            return Ok("Mesaj bilgisi başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _messageService.BGetById(id);
            return Ok(value);
        }
    }
}
