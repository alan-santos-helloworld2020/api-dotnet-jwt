using Microsoft.AspNetCore.Mvc;
using back.Repository;
using back.Models;
using back.HashConfiguration;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly DatabaseContext db;

        public FornecedorController(DatabaseContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> findAll()
        {
            var fornecedores = db.fornecedores.ToList();
            return Ok(fornecedores);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> findById(int id)
        {
            var fornecedor = await db.fornecedores.FindAsync(id);
            if (fornecedor is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(fornecedor);
            }

        }

        [HttpPost]
        public async Task<IActionResult> salvar(Fornecedor fornecedor)
        {
            await db.AddAsync(fornecedor);
            int i = await db.SaveChangesAsync();
            return Ok(i);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, Fornecedor fornecedor)
        {
            HashConfig hash = new HashConfig();
            var old = await db.fornecedores.FindAsync(id);
            if (old is null)
            {
                return NotFound();
            }
            else
            {
                old.Nome = fornecedor.Nome;
                old.RazaoSocial = fornecedor.RazaoSocial;
                old.Email = fornecedor.Email;
                old.Telefone = fornecedor.Telefone;
                old.Cep = fornecedor.Cep;
                old.Cpf = fornecedor.Cpf;
                old.Cnpj = fornecedor.Cnpj;
                old.Observacao = fornecedor.Observacao;
                int i = await db.SaveChangesAsync();
                return Ok(i);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletar(int id)
        {
            var fornecedor = await db.fornecedores.FindAsync(id);
            if (fornecedor is null)
            {
                return NotFound();
            }
            else
            {
                db.fornecedores.Remove(fornecedor);
                int i = await db.SaveChangesAsync();
                return Ok(i);
            }
        }


    }

}