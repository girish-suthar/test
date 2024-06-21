using AutoMapper;
using DemoOnionArchitecture.Application.Abstract;
using DemoOnionArchitecture.Application.DTOs;
using DemoOnionArchitecture.DataAccess.Context;
using DemoOnionArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace ExampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ApplicationdbContext _context;
        private readonly IMapper _mapper;
        
        private readonly IVillaService _villaService;
        public VillaController(ApplicationdbContext applicationDb, IMapper mapper,IVillaService villaService)
        {
            _context = applicationDb;
            _mapper = mapper;
            
            _villaService = villaService;
        }
        [HttpGet]
        [Authorize]
        public List<VillaDTO> Villa()
        {
            return _context.Villas.ToList().Select(a => new VillaDTO
            {
                VillaId = a.VillaId,
                IsOccupied = a.IsOccupied,
                VillaAddress = a.VillaAddress,
                VillaName = a.VillaName,
            }).ToList();
        }
        [HttpGet("{id:int}")]
        [Authorize(Roles ="admin")]
        public IActionResult Villa(int id)
        {
            Villa villa = _context.Villas.FirstOrDefault(a => a.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<VillaDTO>(villa));
        }

        [HttpPost]
        public IActionResult Villa(VillaDTO model)
        {
            Villa villa = _mapper.Map<Villa>(model);
           
            _context.Villas.Update(villa);
            _context.SaveChanges();
            return Ok(villa);
        }
        [HttpPut("{id:int}")]
        public IActionResult Villa(int id, VillaDTO model)
        {
            Villa villa = _context.Villas.FirstOrDefault(a => a.VillaId == id);
            if (villa == null)
            {
                villa = new Villa()
                {
                    IsOccupied = model.IsOccupied,
                    VillaAddress = model.VillaAddress,
                    VillaName = model.VillaName,
                };
                _context.Add(villa);
            }
            else
            {

                villa.IsOccupied = model.IsOccupied;
                villa.VillaAddress = model.VillaAddress;
                villa.VillaName = model.VillaName;
                _context.Update(villa);
            }
            _context.SaveChanges();

            return Ok(villa);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteVilla(int id)
        {
            Villa villa = _context.Villas.FirstOrDefault(a => a.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }
            _context.Remove(villa);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PatchVilla(int id, JsonPatchDocument<Villa> PatchDTO)
        {
            if (id == 0 || PatchDTO == null)
            {
                return BadRequest();
            }
            Villa villa = _context.Villas.FirstOrDefault(villa => villa.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }
            PatchDTO.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Update(villa);
            _context.SaveChanges();
            return Ok(villa);
        }
        [HttpGet("tryOnion")]
        public IActionResult getlist()
        {
            var list = _context.Villas.ToList();
            return Ok(list);
        }
    }
}
