using ProjetoWebRHDB1.Repository.DB.Abstracao;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.DB.Implementacao
{
    public class CandidatoRepository : IRepository
    {

        private List<EntidadeBase> Entidades { get; set; }

        public CandidatoRepository()
        {
            this.Entidades = HttpContext.Current.Session["CandidatosBD"] as List<EntidadeBase>;

            if (this.Entidades == null)
            {
                this.Entidades = new List<EntidadeBase>();
                CarregaCandidatosPadrao();
            }  
        }

        private void Refresh()
        {
            HttpContext.Current.Session["CandidatosBD"] = this.Entidades;
        }

        public bool Adicionar(Entity.EntidadeBase entidade)
        {
            bool flag = false;

            try
            {
                entidade.ID = BuscarID();
                this.Entidades.Add(entidade);
                Refresh();
                flag = true;
            }
            catch (Exception exp)
            {
                flag = false;
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
            if(this.Entidades.Count == 0)
            {
                return 1;
            }
            else
            {
                return this.Entidades.Count + 1;
            }
        }

        private void CarregaCandidatosPadrao()
        {
            if (Entidades.Count == 0)
            {
                Entidades.Add(new CandidatoEntity()
                {
                    ID = BuscarID(),
                    Nome = "Cleber Santana",
                    Formacao = "Superior",
                    Idade = 30,
                    TempoExperiencia = 10,
                    URL_Git = "clebersantana"
                });
                Entidades.Add(new CandidatoEntity()
                {
                    ID = BuscarID(),
                    Nome = "Rodrigo Valh",
                    Formacao = "Superior",
                    Idade = 25,
                    TempoExperiencia = 4,
                    URL_Git = ""
                });
                Entidades.Add(new CandidatoEntity()
                {
                    ID = BuscarID(),
                    Nome = "Sandra Linda",
                    Formacao = "Pós",
                    Idade = 28,
                    TempoExperiencia = 9,
                    URL_Git = "sandralinda"
                });
                Entidades.Add(new CandidatoEntity()
                {
                    ID = BuscarID(),
                    Nome = "Carla Trontin",
                    Formacao = "Técnico",
                    Idade = 19,
                    TempoExperiencia = 1,
                    URL_Git = "carlatrontin"
                });
                Entidades.Add(new CandidatoEntity()
                {
                    ID = BuscarID(),
                    Nome = "Felipe Rocha",
                    Formacao = "Superior",
                    Idade = 27,
                    TempoExperiencia = 5,
                    URL_Git = "rochafelipe"
                });


            }
           
        }

    }
}