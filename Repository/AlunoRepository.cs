using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AlunoRepository
    {
        private static List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public AlunoRepository()
        {
        }


        public void Save(Aluno aluno)
        {
            aluno.Id = Guid.NewGuid();
            Alunos.Add(aluno);
        }

        public Aluno GetAluno(Guid id)
        {
            return Alunos.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Aluno> GetAlunos()
        {
            return Alunos;
        }

        public void Update(Aluno aluno)
        {
            Alunos.Remove(aluno);
            Alunos.Add(aluno);
        }

        public void Remove(Aluno aluno)
        {
            Alunos.Remove(aluno);
        }


    }
}
