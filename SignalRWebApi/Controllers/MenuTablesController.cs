using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly SignalRContext _context;

        public MenuTablesController(IMenuTableService menuTableService, SignalRContext context)
        {
            _menuTableService = menuTableService;
            _context = context;
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
    }
}
