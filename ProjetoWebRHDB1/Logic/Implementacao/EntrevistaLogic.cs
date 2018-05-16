using ProjetoWebRHDB1.Models.Entrevista;
using ProjetoWebRHDB1.Repository.Criteria;
using ProjetoWebRHDB1.Repository.DB.Implementacao;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Logic.Abstracao
{
    public class EntrevistaLogic : IEntrevistaLogic
    {
        private CandidatoRepository CandidatoRepository;
        private CandidatoVagaRepository CandidatoVagaRepository;
        private TecnologiaCandidatoRepository TecnologiaCandidatoRepository;
        private EntrevistaTecnologiaPesoRepository EntrevistaTecnologiaPesoRepository;
        private VagaRepository VagaRepository;

        public EntrevistaLogic()
        {
            this.CandidatoVagaRepository = new CandidatoVagaRepository();
            this.TecnologiaCandidatoRepository = new TecnologiaCandidatoRepository();
            this.EntrevistaTecnologiaPesoRepository = new EntrevistaTecnologiaPesoRepository();
            this.CandidatoRepository = new CandidatoRepository();
            this.VagaRepository = new VagaRepository();
        }

        public bool Adicionar(Repository.Entity.EntidadeBase entidade)
        {

            return CandidatoVagaRepository.Adicionar(entidade);
        }

        public bool Adicionar(List<Repository.Entity.EntidadeBase> entidades)
        {
            return CandidatoVagaRepository.Adicionar(entidades);
        }

        public List<Repository.Entity.EntidadeBase> ConsultarTodos()
        {
            return CandidatoVagaRepository.ConsultarTodos();
        }

        public Repository.Entity.EntidadeBase Consultar(Repository.Criteria.CriteriaBase criteria)
        {
            throw new NotImplementedException();
        }

        public Repository.Entity.EntidadeBase Consultar(long ID)
        {
            return this.CandidatoVagaRepository.Consultar(ID);
        }

        public bool Atualizar(Repository.Entity.EntidadeBase entidade)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Remover(List<long> IDs)
        {
            throw new NotImplementedException();
        }

        public bool AdicionarCandidatoTec(TecnologiaCandidatoEntity entity)
        {
            return this.TecnologiaCandidatoRepository.Adicionar(entity);
        }

        public List<Repository.Entity.TecnologiaCandidatoEntity> ConsultarPorCandidato(long ID)
        {
            return this.TecnologiaCandidatoRepository.ConsultarPorCandidato(ID);

        }

        public bool SalvarEntrevista(EntrevistaTecnologiaPesoEntity e)
        {

            if (e.ID > 0)
            {
                var updated = EntrevistaTecnologiaPesoRepository.Consultar(e.ID);

                ((EntrevistaTecnologiaPesoEntity)updated).Peso = e.Peso;

                return this.EntrevistaTecnologiaPesoRepository.Atualizar(updated);
            }
            else
            {
                return EntrevistaTecnologiaPesoRepository.Adicionar(e);
            }


        }

        public List<EntidadeBase> ConsultarEntrevista()
        {
            return this.EntrevistaTecnologiaPesoRepository.ConsultarTodos();
        }
        public List<EntrevistaTecnologiaPesoEntity> ConsultarEntrevista(long IDEtrevista)
        {
            return this.EntrevistaTecnologiaPesoRepository.ConsultarEntrevistas(new EntrevistaTecnologiaPesoCriteria()
            {
                IDEntrevista = IDEtrevista
            });
        }

        public List<CandidatoRankViewModel> ConsultarRankCandidatos()
        {
            List<CandidatoRankViewModel> retorno = new List<CandidatoRankViewModel>();

            var entrevistas = this.ConsultarEntrevista().Cast<EntrevistaTecnologiaPesoEntity>().ToList();

            var entrevistasAgrupadas = entrevistas.GroupBy(x => x.IDEntrevista, (key, group) => new { EntrevistaID = key, Itens = group.ToList() });

            foreach (var item in entrevistasAgrupadas)
            {
                var entrevistaCandidatoVaga = this.CandidatoVagaRepository.Consultar(item.EntrevistaID);

                retorno.Add(new CandidatoRankViewModel()
                {
                    Vaga = this.VagaRepository.Consultar(((CandidatoVagaEntitycs)entrevistaCandidatoVaga).IDVaga).Nome,
                    Candidado = this.CandidatoRepository.Consultar(((CandidatoVagaEntitycs)entrevistaCandidatoVaga).IDCandidato).Nome,
                    Posicao = entrevistas.Where(x => x.IDEntrevista == item.EntrevistaID).Sum(s => s.Peso)
                });
            }
           

            return retorno.OrderByDescending(x => x.Posicao).ToList();
        }
    }
}