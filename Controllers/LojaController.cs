using back.HashConfiguration;
using back.Models;
using back.Repository;
using Microsoft.AspNetCore.Mvc;
namespace back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LojaController : ControllerBase
{

    private readonly DatabaseContext db;
    public LojaController(DatabaseContext _db)
    {
        db = _db;
    }

    [HttpGet]
    public async Task<IActionResult> findAll()
    {
        var lojas = db.lojas.ToList();
        return Ok(lojas);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> findById(int id)
    {
        var loja = await db.lojas.FindAsync(id);
        if (loja is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(loja);
        }

    }

    [HttpPost]
    public async Task<IActionResult> salvar(Loja loja)
    {
        await db.AddAsync(loja);
        int i = await db.SaveChangesAsync();
        return Ok(i);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> update(int id,Loja loja)
    {
        HashConfig hash = new HashConfig();
        var old = await db.lojas.FindAsync(id);
        if (old is null)
        {
            return NotFound();
        }
        else
        {
            old.Nome = loja.Nome;
            old.Email = loja.Email;
            old.Telefone = loja.Telefone;
            old.Cep = loja.Cep;
            int i = await db.SaveChangesAsync();
            return Ok(i);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deletar(int id)
    {
        var lojaDel = await db.lojas.FindAsync(id);
        if (lojaDel is null)
        {
            return NotFound();
        }
        else
        {
            db.lojas.Remove(lojaDel);
            int i = await db.SaveChangesAsync();
            return Ok(i);
        }
    }
}