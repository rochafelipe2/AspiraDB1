using ProjetoWebRHDB1.Repository.DB.Abstracao;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.DB.Implementacao
{
    public class TecnologiaRepository : IRepository
    {
        private List<EntidadeBase> Entidades { get; set; }

        public TecnologiaRepository()
        {
            this.Entidades = HttpContext.Current.Session["TecnologiasBD"] as List<EntidadeBase>;

            if (this.Entidades == null)
            {
                this.Entidades = new List<EntidadeBase>();
                CarregarPadrao();
            }
                
        }

        private void Refresh()
        {
            HttpContext.Current.Session["TecnologiasBD"] = this.Entidades;
        }

        public bool Adicionar(Entity.EntidadeBase entidade)
        {
            bool flag = false;

            try
            {
                entidade.ID = BuscarID();
                this.Entidades.Add(entidade);
                HttpContext.Current.Session["TecnologiasBD"] = this.Entidades;
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
                    Refresh();
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
                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "SQL"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "N-SQL"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Java"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "C#"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "C++"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Github"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "MVC"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Ruby"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Phyton"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Javascript"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "HTML5"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "CSS3"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "JQuery"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "TypeScript"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Node.js"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Angular"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Mobile Android"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "Mobile IOS"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "PL-SQL"
                });

                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "ETL"
                });
                Entidades.Add(new TecnologiaEntity()
                {
                    ID = BuscarID(),
                    Nome = "BI"
                });
            }
        }
    }
}