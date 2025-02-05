﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioAPI.Domain.Entities.Medico;

namespace UsuarioAPI.Domain.Repositories
{
    public interface IMedicoRepository
    {
        /// <summary>
        /// Responsável por adicionar um novo médico.
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        Task<Medico> Adicionar (Medico medico);

        /// <summary>
        /// Contrato responsável por verificar a existencia de um CRM
        /// </summary>
        /// <param name="numeroCRM"></param>
        /// <returns></returns>
        Task<bool> VerificarExistenciaCRM(string numeroCRM);
    }
}
