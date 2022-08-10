using Microsoft.AspNetCore.Mvc;
using back.Repository;
using back.Models;

namespace back.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private DatabaseContext db;
        public ClienteController(DatabaseContext _Clientedb)
        {
            db = _Clientedb;
        }

        [HttpGet]
        public async Task<IActionResult> finddAll()
        {
            var clientes = db.clientes.ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> pesquisar(int id)
        {
            var dados = await db.clientes.FindAsync(id);
            if (dados is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(dados);
            }
        }

        [HttpPost]
        public async Task<IActionResult> salvar(Cliente cliente)
        {
            await db.AddAsync(cliente);
            int i = await db.SaveChangesAsync();
            return Ok(i);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> editar(int id, Cliente cliente)
        {
            var old = await db.clientes.FindAsync(id);
            if (old is null)
            {
                return NotFound();
            }
            else
            {
                old.Nome = cliente.Nome;
                old.Telefone = cliente.Telefone;
                old.Email = cliente.Email;
                old.Cep = cliente.Cep;
                int i = await db.SaveChangesAsync();
                return Ok(i);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletar(int id)
        {
            var dados = await db.clientes.FindAsync(id);
            if (dados is null)
            {
                return NotFound();
            }
            else
            {
                db.clientes.Remove(dados);
                int i = await db.SaveChangesAsync();
                return Ok(i);
            }
        }
    }
}