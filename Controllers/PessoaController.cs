using Microsoft.EntityFrameworkCore;
using api_Sqlite.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api_Sqlite.Models;

namespace api_Sqlite.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly DataContext db;

        public PessoaController(DataContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var pessoas = await db.Pessoa.ToListAsync();
            return Ok( pessoas );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Listar(int id)
        {
            var pessoa = await db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            return Ok( pessoa );
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] Pessoa pessoa)
        {
            db.Pessoa.Add(pessoa);
            await db.SaveChangesAsync();
            return Created("Criado com sucesso", pessoa );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Alterar(int id, [FromBody]Pessoa pessoa)
        {
            var pessoaDb = await db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            pessoaDb.Nome = pessoa.Nome;
            pessoaDb.Idade = pessoa.Idade;
            await db.SaveChangesAsync();
            return Ok( pessoaDb );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var pessoaDb = await db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            db.Pessoa.Remove(pessoaDb);
            await db.SaveChangesAsync();
            return Ok( pessoaDb );
        }
    }
}