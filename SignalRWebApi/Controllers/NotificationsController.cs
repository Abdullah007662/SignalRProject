using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.NotificationDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.BGetListAll();
            return Ok(values);
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var value = _notificationService.BNotificationCountByStatusFalse();
            return Ok(value);
        }
        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            var values = _notificationService.BGetAllNotificationsByFalse();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateNotifications(CreateNotificationDTO dTO)
        {
            _notificationService.BAdd(_mapper.Map<Notification>(dTO));
            return Ok("Mesaj Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO dTO)
        {
            _notificationService.BUpdate(_mapper.Map<Notification>(dTO));
            return Ok("Mesaj Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var notificationEntity = _notificationService.BGetById(id);
            if (notificationEntity == null)
            {
                return NotFound();
            }

            _notificationService.BDelete(notificationEntity);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _notificationService.BGetById(id);
            return Ok(value);
        }
    }
}
