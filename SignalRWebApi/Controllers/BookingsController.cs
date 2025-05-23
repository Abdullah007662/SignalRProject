﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ApiDTO.BookingDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet] // Bu metodun bir HTTP GET isteği ile çalıştırılacağını belirtir
        public IActionResult BookingList() // BookingList adında, HTTP cevabı döndüren bir aksiyon metodudur
        {
            var values = _mapper.Map<List<ResultBookingDTO>>(_bookingService.BGetListAll());
            // Veritabanındaki tüm Booking verileri alınır (_bookingService.BGetListAll()),
            // daha sonra bu veriler ResultBookingDTO listesine dönüştürülür (AutoMapper ile)

            return Ok(values);
            // HTTP 200 (Başarılı) durum kodu ile birlikte values verisi JSON olarak döndürülür
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDTO dTO)
        {
            _bookingService.BAdd(_mapper.Map<Booking>(dTO));
            return Ok("Rezervasyon Başarılı Bir Şekilde Oluşturuldu");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDTO dTO)
        {
            _bookingService.BUpdate(_mapper.Map<Booking>(dTO));
            return Ok("Rezervasyon Başarılı Bir Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var bookingDto = _bookingService.BGetById(id);
            _bookingService.BDelete(bookingDto);
            return Ok("Rezervasyon Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bookingService.BGetById(id);
            return Ok(value);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BBookingStatusApproved(id); ;
            return Ok("Rezeryasyon Güncellendi");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.BBookingStatusCancelled(id); ;
            return Ok("Rezeryasyon Güncellendi");
        }
    }

}

