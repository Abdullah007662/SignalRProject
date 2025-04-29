using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.ApiDTO.MenüTable;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly SignalRContext _context;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, SignalRContext context, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.BMenuTableCount());
        }
        [HttpGet]
        public IActionResult GetAllMenuTables()
        {
            var tables = _context.MenuTables
                .Where(x => x.Status == false) // Belki sadece boş masaları çekmek istersin
                .Select(x => new
                {
                    x.MenuTableID,
                    x.Name
                })
                .ToList();

            return Ok(tables);
        }
        // Masa durumunu aktif hale getirme
        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            var table = _context.MenuTables.FirstOrDefault(t => t.MenuTableID == id);
            if (table == null)
            {
                return NotFound("Masa bulunamadı.");
            }

            // Masa durumunu true yap
            table.Status = true; // Masa durumunu aktif yap
            _context.SaveChanges(); // Değişiklikleri kaydet

            return Ok("Masa aktif hale getirildi.");
        }
        [HttpGet("MenuTableList")]
        public IActionResult MenuTableList()
        {
            var menütableDTOs = _mapper.Map<List<ResultMenüTableDTO>>(_menuTableService.BGetListAll());
            return Ok(menütableDTOs);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenüTableDTO createMenüTableDTO)
        {
            _menuTableService.BAdd(_mapper.Map<MenuTable>(createMenüTableDTO));
            return Ok("Masa bilgisi başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var menütable = _menuTableService.BGetById(id);
            _menuTableService.BDelete(menütable);
            return Ok("Masa bilgisi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenüTableDTO updateMenüTableDTO)
        {
            _menuTableService.BUpdate(_mapper.Map<MenuTable>(updateMenüTableDTO));
            return Ok("Masa bilgisi başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult MenuTableGetById(int id)
        {
            var value = _menuTableService.BGetById(id);
            return Ok(value);
        }
    }
}
