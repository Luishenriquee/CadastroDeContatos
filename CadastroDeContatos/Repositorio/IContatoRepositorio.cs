﻿using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        public ContatoModel Adicionar(ContatoModel contato);
    }
}