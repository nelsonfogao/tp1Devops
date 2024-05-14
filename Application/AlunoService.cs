using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AlunoService
    {
        private AlunoRepository alunoRepository;

        public AlunoService(AlunoRepository alunoRepository)
        {
            this.alunoRepository = alunoRepository;
        }

        public Aluno CriarAluno(Aluno aluno)
        {
            this.alunoRepository.Save(aluno);

            return aluno;

        }

        public Aluno ObterAluno(Guid id)
        {
            var aluno = this.alunoRepository.GetAluno(id);
            return aluno;
        }
        public List<Aluno> ObterAlunos()
        {
            var alunos = this.alunoRepository.GetAlunos();
            return alunos;
        }
    }
}
