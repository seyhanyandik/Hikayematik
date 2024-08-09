using Hikayematikwebapi.Data;
using Hikayematikwebapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hikayematikwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SiirsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SiirsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Siir>>> GetSiirs()
        {
            return await _context.siir.ToListAsync();
            //Tüm verileri çekmek için kullandığımız method
        }
        [HttpGet("id")]
        public async Task<ActionResult<Siir>> GetSiir(int id)
        {
            return await _context.siir.FindAsync(id);
        }
        [HttpDelete("id)")]
        public async Task<ActionResult<Siir>> DeleteSiir(int id)
        {
            var result = _context.siir.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        [HttpPut("id)")]
        public async Task<ActionResult<Siir>> UpdateSiir(Siir siir,int id)
        {
            var result = _context.siir.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                result.Baslik = siir.Baslik;
                result.Icerik = siir.Icerik;
                result.Sair = siir.Sair;
                result.yayim_tarihi = siir.yayim_tarihi;
                await _context.SaveChangesAsync();
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult> PostSiir(Siir gelen)
        {
            _context.siir.Add(gelen);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}