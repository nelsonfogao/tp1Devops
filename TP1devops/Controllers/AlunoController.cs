using Application;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TP1devops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private AlunoService service;

        public AlunoController(AlunoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Criar(AlunoRequest request)
        {
            if (ModelState.IsValid == false) return BadRequest();
            var aluno = new Aluno()
            {
                Id = new Guid(),
                Nome = request.Nome,
                Idade = request.Idade
            };


            var alunoCriado = this.service.CriarAluno(aluno);
            AlunoResponse response = AlunoParaResponse(alunoCriado);

            return Created($"/aluno/{response.Id}", response);

        }

        [HttpGet("{id}")]
        public IActionResult ObterAluno(Guid id)
        {
            var aluno = this.service.ObterAluno(id);

            if (aluno == null)
                return NotFound();

            var response = AlunoParaResponse(aluno);

            return Ok(response);

        }

        [HttpGet()]
        public IActionResult ObterAlunos()
        {
            var alunos = this.service.ObterAlunos();

            if (alunos == null)
                return NotFound();

            var response = alunos;

            return Ok(response);

        }

        private AlunoResponse AlunoParaResponse(Aluno alunoCriado)
        {
            var response = new AlunoResponse()
            {
                Id = alunoCriado.Id,
                Nome = alunoCriado.Nome,
                Idade = alunoCriado.Idade
            };

            return response;
        }

    }
}

