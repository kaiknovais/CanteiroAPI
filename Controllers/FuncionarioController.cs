using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CanteiroAPI.Models;

namespace CanteiroAPI.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var funcionarios = await _context.Funcionarios.ToListAsync();
        return Ok(funcionarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario == null) return NotFound();
        return Ok(funcionario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Funcionario funcionario)
    {
        if (id != funcionario.Id) return BadRequest();
        _context.Entry(funcionario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario == null) return NotFound();
        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}