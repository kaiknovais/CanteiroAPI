using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CanteiroAPI.Models;

namespace CanteiroAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController: ControllerBase
{
    private readonly AppDbContext _context;

    public TarefaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tarefas = await _context.Tarefas
            .Include(t => t.Funcionario)
            .Include(t => t.Equipamento)
            .ToListAsync();
        return Ok(tarefas);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tarefa = await _context.Tarefas
            .Include(t => t.Funcionario)
            .Include(t => t.Equipamento)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = tarefa.Id}, tarefa);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest();
        _context.Entry(tarefa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return NotFound();
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}