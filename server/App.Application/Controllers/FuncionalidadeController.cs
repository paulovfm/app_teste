using System;
using System.Linq;
using System.Threading.Tasks;
using App.Application.ViewModels;
using App.Application.ViewModels.ListasPaginadas;
using App.Domain.Services;
using App.Domain.ValueObject.Filtros;
using Microsoft.AspNetCore.Mvc;

namespace App.Application.Controllers
{
    public class FuncionalidadeController : Controller
    {
        private readonly FuncionalidadeService _funcionalidadeService;

        public FuncionalidadeController(FuncionalidadeService funcionalidadeService)
        {
            _funcionalidadeService = funcionalidadeService;
        }

        [HttpPost]
        [Route("funcionalidade/obterLista")]
        public async Task<IActionResult> ObterLista([FromBody] FiltroFuncionalidade filtroFuncionalidade)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var listaFuncionalidade = await _funcionalidadeService.ObterLista(filtroFuncionalidade);
                var listaFuncionalidadeViewModel = listaFuncionalidade
                    .Select(FuncionalidadeViewModel.FromDomainModel)
                    .ToList();

                return Ok(listaFuncionalidadeViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("funcionalidade/obterListaPaginada")]
        public async Task<IActionResult> ObterListaPaginada([FromBody] FiltroFuncionalidade filtroFuncionalidade)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var listaPaginadaFuncionalidade = await _funcionalidadeService.ObterListaPaginada(filtroFuncionalidade);
                var listaPaginadaFuncionalidadeViewModel = ListaPaginadaFuncionalidadeViewModel.FromDomainModel(listaPaginadaFuncionalidade);

                return Ok(listaPaginadaFuncionalidadeViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("funcionalidade/obterPeloId")]
        public async Task<IActionResult> ObterPeloId(Guid id)
        {
            try
            {
                var funcionalidade = await _funcionalidadeService.ObterPeloId(id);
                var funcionalidadeViewModel = FuncionalidadeViewModel.FromDomainModel(funcionalidade);

                return Ok(funcionalidadeViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("funcionalidade/inserir")]
        public async Task<IActionResult> Inserir([FromBody] FuncionalidadeViewModel funcionalidadeViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var funcionalidade = FuncionalidadeViewModel.ToDomainModel(funcionalidadeViewModel);
                funcionalidade = await _funcionalidadeService.Inserir(funcionalidade);
                funcionalidadeViewModel = FuncionalidadeViewModel.FromDomainModel(funcionalidade);

                return Ok(funcionalidadeViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("funcionalidade/alterar")]
        public async Task<IActionResult> Alterar([FromBody] FuncionalidadeViewModel funcionalidadeViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var funcionalidade = FuncionalidadeViewModel.ToDomainModel(funcionalidadeViewModel);
                funcionalidade = await _funcionalidadeService.Alterar(funcionalidade);
                funcionalidadeViewModel = FuncionalidadeViewModel.FromDomainModel(funcionalidade);

                return Ok(funcionalidadeViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("funcionalidade/excluir")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _funcionalidadeService.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}