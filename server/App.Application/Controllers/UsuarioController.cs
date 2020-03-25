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
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("usuario/obterLista")]
        public async Task<IActionResult> ObterLista([FromBody] FiltroUsuario filtroUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var listaUsuario = await _usuarioService.ObterLista(filtroUsuario);
                var listaUsuarioViewModel = listaUsuario
                    .Select(UsuarioViewModel.FromDomainModel)
                    .ToList();

                return Ok(listaUsuarioViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("usuario/obterListaPaginada")]
        public async Task<IActionResult> ObterListaPaginada([FromBody] FiltroUsuario filtroUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var listaPaginadaUsuario = await _usuarioService.ObterListaPaginada(filtroUsuario);
                var listaPaginadaUsuarioViewModel = ListaPaginadaUsuarioViewModel.FromDomainModel(listaPaginadaUsuario);

                return Ok(listaPaginadaUsuarioViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("usuario/obterPeloId")]
        public async Task<IActionResult> ObterPeloId(Guid id)
        {
            try
            {
                var usuario = await _usuarioService.ObterPeloId(id);
                var usuarioViewModel = UsuarioViewModel.FromDomainModel(usuario);

                return Ok(usuarioViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("usuario/inserir")]
        public async Task<IActionResult> Inserir([FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = UsuarioViewModel.ToDomainModel(usuarioViewModel);
                usuario = await _usuarioService.Inserir(usuario);
                usuarioViewModel = UsuarioViewModel.FromDomainModel(usuario);

                return Ok(usuarioViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("usuario/alterar")]
        public async Task<IActionResult> Alterar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = UsuarioViewModel.ToDomainModel(usuarioViewModel);
                usuario = await _usuarioService.Alterar(usuario);
                usuarioViewModel = UsuarioViewModel.FromDomainModel(usuario);

                return Ok(usuarioViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("usuario/excluir")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                await _usuarioService.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}