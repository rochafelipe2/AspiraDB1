using ProjetoWebRHDB1.Repository.DB.Abstracao;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.DB.Implementacao
{
    public class VagaRepository : IRepository
    {
        private List<EntidadeBase> Entidades { get; set; }

        public VagaRepository()
        {
            this.Entidades = HttpContext.Current.Session["VagasBD"] as List<EntidadeBase>;

            if (this.Entidades == null)
            {
                this.Entidades = new List<EntidadeBase>();
                CarregarPadrao();
            }
               
        }

        private void Refresh()
        {
            HttpContext.Current.Session["VagasBD"] = this.Entidades;
        }

        public bool Adicionar(Entity.EntidadeBase entidade)
        {
            bool flag = false;

            try
            {
                entidade.ID = BuscarID();
                this.Entidades.Add(entidade);
                HttpContext.Current.Session["VagasBD"] = this.Entidades;
                flag = true;
            }
            catch (Exception exp)
            {
                ((List<ExceptionEntity>)HttpContext.Current.Session["Exceptions"]).Add(new ExceptionEntity() { Mensagem = "Erro ao salvar tecnologia" });
            }

            return flag;
        }

        public bool Adicionar(List<Entity.EntidadeBase> entidades)
        {
            bool flag = false;

            foreach (var entidade in entidades)
            {
                flag = this.Adicionar(entidade);
            }

            return flag;
        }

        public List<Entity.EntidadeBase> ConsultarTodos()
        {
            

            return Entidades;
        }

        public Entity.EntidadeBase Consultar(Criteria.CriteriaBase criteria)
        {
            return Entidades.FirstOrDefault();
        }

        public Entity.EntidadeBase Consultar(long ID)
        {
            return Entidades.Where(x => x.ID == ID).FirstOrDefault();
        }

        public bool Atualizar(Entity.EntidadeBase entidade)
        {
            bool flag = false;
            try
            {
                var deleted = Entidades.Where(x => x.ID == entidade.ID).First();
                Entidades.Remove(deleted);

                Entidades.Add(entidade);
                Refresh();
                flag = true;
            }
            catch (Exception exp)
            {
                flag = false;
            }
            return flag;
        }

        public bool Remover(long ID)
        {
            bool flag = false;
            try
            {
                if (ID > 0)
                {
                    var entidade = this.Entidades.First(x => x.ID == ID);
                    this.Entidades.Remove(entidade);
                    flag = true;
                }
            }
            catch (Exception exp)
            {
                flag = false;
            }

            return flag;
        }

        public bool Remover(List<long> IDs)
        {
            bool flag = false;

            foreach (var entidade in IDs)
            {
                flag = this.Remover(entidade);
            }

            return flag;
        }

        private long BuscarID()
        {
            if (this.Entidades.Count == 0)
            {
                return 1;
            }
            else
            {
                return this.Entidades.Count + 1;
            }
        }

        private void CarregarPadrao()
        {
            if (Entidades.Count == 0)
            {
                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Analista de negócio",
                    Responsavel = "Fernanda Cunha",
                    Descricao = "Atuar na análise e levantamento de requisitos de negócio e criação de casos de teste."
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Desenvolvedor .NET Pleno",
                    Responsavel = "Fernanda Cunha",
                    Descricao = "Desenvolvedor com boa experiência em projetos Web na plataforma .NET"
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Desenvolvedor .NET Junior",
                    Responsavel = "Fernanda Cunha",
                    Descricao = "Desenvolvedor com experiência comprovada em projetos Web na plataforma .NET"
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "DBA Oracle",
                    Responsavel = "Silvio Lewandosvisk",
                    Descricao = "Analista DBA Oracle, criação de procedures, manutenção de usuários no banco e implantação de backups."
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Desenvolvedor Front-end Angular",
                    Responsavel = "Gisele Aparecida",
                    Descricao = "Desenvolvedor com boa experiência no framework angular com MVC .NET e API's."
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Desenvolvedor Full-stack Java",
                    Responsavel = "Tereza Sampaio",
                    Descricao = "Desenvolvedor para atuar em todas as atividades do projeto Java corporativo de grande porte."
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Engenheira de software .NET",
                    Responsavel = "Fernanda Cunha",
                    Descricao = "Vaga exclusiva para meninas super poderosas."
                });

                Entidades.Add(new VagaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Engenheira de software Python",
                    Responsavel = "Mariana Linhares",
                    Descricao = "Vaga exclusiva para meninas super poderosas."
                });
            }
        }
    }
}