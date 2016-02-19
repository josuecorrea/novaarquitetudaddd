using Arquitetura.Dominio.Aggregates.MunicipioAgg;
using System.Linq;
using Arquitetura.Aplicacao.Base;
using Arquitetura.Aplicacao.Services.Interface;
using Arquitetura.Dominio.Aggregates.MunicipioAgg;
using Arquitetura.Dominio.Repositories.Interfaces;
using Arquitetura.DTO;
using Arquitetura.Infraestrutura.Adapter;
using Arquitetura.Infraestrutura.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Arquitetura.Infraestrutura.Util;
using Arquitetura.Infraestrutura.Validator;

namespace Arquitetura.Aplicacao.Services
{
    public class MunicipioAppService : IMunicipioAppService
    {
        #region Membros

        readonly IMunicipioRepository _municipioRepository;

        #endregion

        #region Construtor

        public MunicipioAppService(IMunicipioRepository municipioRepository)
        {
            if (municipioRepository == null)
                throw new ArgumentNullException("municipioRepository");

            _municipioRepository = municipioRepository;
        }

        #endregion

        #region Membros de IMunicipioAppService

        public MunicipioDTO FindMunicipio(int municipioId)
        {
            try
            {
                if (municipioId <= 0)
                    throw new ArgumentException("Valor inválido.", "municipioId");

                var municipio = _municipioRepository.Get(municipioId);
                if (municipio == null)
                    throw new Exception("Município não encontrado. Id: " + municipioId);

                var adapter = TypeAdapterFactory.CreateAdapter();
                return adapter.Adapt<Municipio, MunicipioDTO>(municipio);
            }
            catch (ApplicationValidationErrorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().LogError(ex);
                throw new Exception("O servidor não respondeu.");
            }
        }

        public List<MunicipioDTO> FindMunicipios<KProperty>(string texto, Expression<Func<Municipio, KProperty>> orderByExpression, bool ascending = true)
        {
            try
            {
                var spec = MunicipioSpecifications.ConsultaTexto(texto);
                var municipios = _municipioRepository.AllMatching<KProperty>(spec, orderByExpression, ascending).ToList();

                var adapter = TypeAdapterFactory.CreateAdapter();
                return adapter.Adapt<List<Municipio>, List<MunicipioDTO>>(municipios);
            }
            catch (ApplicationValidationErrorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().LogError(ex);
                throw new Exception("O servidor não respondeu.");
            }
        }

        public List<MunicipioDTO> FindMunicipios<KProperty>(string texto, Expression<Func<Municipio, KProperty>> orderByExpression, bool ascending, int pageIndex, int pageCount)
        {
            try
            {
                if (pageIndex <= 0 || pageCount <= 0)
                    throw new Exception("Argumentos da paginação inválidos.");

                var spec = MunicipioSpecifications.ConsultaTexto(texto);
                var municipios = _municipioRepository.GetPaged<KProperty>(pageIndex, pageCount, spec, orderByExpression, ascending).ToList();

                var adapter = TypeAdapterFactory.CreateAdapter();
                return adapter.Adapt<List<Municipio>, List<MunicipioDTO>>(municipios);
            }
            catch (ApplicationValidationErrorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().LogError(ex);
                throw new Exception("O servidor não respondeu.");
            }
        }

        public long CountMunicipios(string texto)
        {
            try
            {
                var spec = MunicipioSpecifications.ConsultaTexto(texto);
                return _municipioRepository.Count(spec);
            }
            catch (ApplicationValidationErrorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                LoggerFactory.CreateLog().LogError(ex);
                throw new Exception("O servidor não respondeu.");
            }
        }

        #endregion

        #region Métodos Privados

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _municipioRepository.Dispose();
        }

        #endregion
    }
}
