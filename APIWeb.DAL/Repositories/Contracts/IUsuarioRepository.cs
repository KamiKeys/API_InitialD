using APIWeb.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeb.DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        bool Login(UsuarioDTO usuarioDTO);
        void Add(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Get();
    }
}
