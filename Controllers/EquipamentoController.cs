using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CanteiroAPI.Models;

namespace CanteiroAPI.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EquipamentoController : ControllerBase
{
    private readonly AppDbContext _context;

    public EquipamentoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    
    public async Task<IActionResult> GetAll()
    {
        var equipamentos = await _context.Equipamentos.ToListAsync();
        return Ok(equipamentos);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var equipamento = await _context.Equipamentos.FindAsync(id);
        if (equipamento == null) return NotFound();
        return Ok(equipamento);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Equipamento equipamento)
    {
        _context.Equipamentos.Add(equipamento);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = equipamento.Id}, equipamento);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Equipamento equipamento)
    {
        if (id != equipamento.Id) return BadRequest();
        _context.Entry(equipamento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var equipamento = await _context.Equipamentos.FindAsync(id);
        if (equipamento == null) return NotFound();
        _context.Equipamentos.Remove(equipamento);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}