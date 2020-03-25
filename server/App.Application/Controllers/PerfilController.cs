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
    public class PerfilController : Controller
    {
        private readonly PerfilService _perfilService;

        public PerfilController(PerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpPost]
        [Route("perfil/obterLista")]
        public async Task<IActionResult> ObterLista([FromBody] FiltroPerfil filtroPerfil)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var listaPerfil = await _perfilService.ObterLista(filtroPerfil);
                var listaPerfilViewModel = listaPerfil
                    .Select(PerfilViewModel.FromDomainModel)
                    .ToList();

                return Ok(listaPerfilViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("perfil/obterListaPaginada")]
        public async Task<IActionResult> ObterListaPaginada([FromBody] FiltroPerfil filtroPerfil)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var listaPaginadaPerfil = await _perfilService.ObterListaPaginada(filtroPerfil);
                var listaPaginadaPerfilViewModel = ListaPaginadaPerfilViewModel.FromDomainModel(listaPaginadaPerfil);

                return Ok(listaPaginadaPerfilViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("perfil/obterPeloId")]
        public async Task<IActionResult> ObterPeloId(Guid id)
        {
            try
            {
                var perfil = await _perfilService.ObterPeloId(id);
                var perfilViewModel = PerfilViewModel.FromDomainModel(perfil);

                return Ok(perfilViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("perfil/inserir")]
        public async Task<IActionResult> Inserir([FromBody] PerfilViewModel perfilViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var perfil = PerfilViewModel.ToDomainModel(perfilViewModel);
                perfil = await _perfilService.Inserir(perfil);
                perfilViewModel = PerfilViewModel.FromDomainModel(perfil);

                return Ok(perfilViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("perfil/alterar")]
        public async Task<IActionResult> Alterar([FromBody] PerfilViewModel perfilViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var perfil = PerfilViewModel.ToDomainModel(perfilViewModel);
                perfil = await _perfilService.Alterar(perfil);
                perfilViewModel = PerfilViewModel.FromDomainModel(perfil);

                return Ok(perfilViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("perfil/excluir")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _perfilService.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}