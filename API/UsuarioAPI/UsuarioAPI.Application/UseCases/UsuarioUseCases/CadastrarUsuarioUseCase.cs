﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Application.DTOs.Base;
using UsuarioAPI.Domain.Entities.Base;
using UsuarioAPI.Domain.Exceptions;
using UsuarioAPI.Domain.Repositories;
using UsuarioAPI.Domain.Services;

namespace UsuarioAPI.Application.UseCases.PacienteUseCases
{
    public class CadastrarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISecurityService _securityRepository;
        private readonly IMapper _mapper;

        public CadastrarUsuarioUseCase(IUsuarioRepository pacienteRepository, IMapper mapper, ISecurityService securityRepository)
        {
            _usuarioRepository = pacienteRepository;
            _mapper = mapper;
            _securityRepository = securityRepository;
        }

        public async Task<RetornoUsuarioCadastrado> Executar(UsuarioDTO usuarioDTO)
        {
            UsuarioBase usuario = _mapper.Map<UsuarioBase>(usuarioDTO);
            List<string> listaErros = await ObterErrosValidacaoAsync(usuario);

            if (listaErros.Any())
                throw new UserBaseExceptions(listaErros);

            usuario.Senha = _securityRepository.CriptografarSenha(usuario.Senha);
            usuario.Tipo = String.IsNullOrEmpty(usuarioDTO.CRM) ? "P" : "M";

            usuario.UserName = usuario.Tipo == "M" ? usuarioDTO.CRM : usuario.Email;
            //UsuarioBase usuarioCadastrado = await _usuarioRepository.Adicionar(usuario);

            IdentityResult resultado = await _usuarioRepository.CadastraAsync(usuario);

            return _mapper.Map<RetornoUsuarioCadastrado>(usuario);
        }

        private async Task<List<string>> ObterErrosValidacaoAsync(UsuarioBase usuario)
        {
            List<string> listaErros = new List<string>();

            if (await _usuarioRepository.VerificarExistenciaCPF(usuario.CPF))
                listaErros.Add("O CPF informado já está cadastrado no sistema.");

            if (await _usuarioRepository.VerificarExistenciaEmail(usuario.Email))
                listaErros.Add("O E-mail informado já está cadastrado no sistema.");


            return listaErros;
        }
    }
}
