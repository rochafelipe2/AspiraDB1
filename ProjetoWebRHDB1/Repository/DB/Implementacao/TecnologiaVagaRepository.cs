using ProjetoWebRHDB1.Repository.DB.Abstracao;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.DB.Implementacao
{
    public class TecnologiaVagaRepository : IRepository
    {
        private List<EntidadeBase> Entidades { get; set; }

        public TecnologiaVagaRepository()
        {
            this.Entidades = HttpContext.Current.Session["TecnologiasVagaBD"] as List<EntidadeBase>;

            if (this.Entidades == null)
                this.Entidades = new List<EntidadeBase>();
        }


        private void Refresh()
        {
            HttpContext.Current.Session["TecnologiasVagaBD"] = this.Entidades;
        }


        public bool Adicionar(Entity.EntidadeBase entidade)
        {
            bool flag = false;

            try
            {
                this.Entidades.Add(entidade);
                Refresh();
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
    }
}