using ProjetoWebRHDB1.Repository.Criteria;
using ProjetoWebRHDB1.Repository.DB.Abstracao;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.DB.Implementacao
{
    public class EntrevistaTecnologiaPesoRepository : IRepository
    {
         private List<EntidadeBase> Entidades { get; set; }

         public EntrevistaTecnologiaPesoRepository()
        {
            this.Entidades = HttpContext.Current.Session["EntrevistaTecnologiaPesoBD"] as List<EntidadeBase>;

            if (this.Entidades == null)
            {
                this.Entidades = new List<EntidadeBase>();
                CarregarPadrao();
            }
               
        }

         private void Refresh()
         {
             HttpContext.Current.Session["EntrevistaTecnologiaPesoBD"] = this.Entidades;
         }

        public bool Adicionar(Entity.EntidadeBase entidade)
        {
            bool flag = false;

            try
            {
                entidade.ID = BuscarID();
                this.Entidades.Add(entidade);
                HttpContext.Current.Session["EntrevistaTecnologiaPesoBD"] = this.Entidades;
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
            var list = Entidades.Cast<EntrevistaTecnologiaPesoEntity>();
            long IDEntrevista = ((EntrevistaTecnologiaPesoCriteria)criteria).IDEntrevista;
            if (IDEntrevista > 0)
            {
                list = list.Where(x => x.IDEntrevista == IDEntrevista).ToList();
            }

            return list.First();
        }

        public List<Entity.EntrevistaTecnologiaPesoEntity> ConsultarEntrevistas(Criteria.CriteriaBase criteria)
        {
            var list = Entidades.Cast<EntrevistaTecnologiaPesoEntity>();
            long IDEntrevista = ((EntrevistaTecnologiaPesoCriteria)criteria).IDEntrevista;
            if (IDEntrevista > 0)
            {
                list = list.Where(x => x.IDEntrevista == IDEntrevista).ToList();
            }

            return list.ToList();
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
                var updated = Entidades.Where(x => x.ID == entidade.ID).FirstOrDefault();

                if (updated != null)
                {
                    updated = entidade;

                }
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
  
        }

    }
}