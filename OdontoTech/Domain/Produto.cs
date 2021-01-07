﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoEmbalagem TipoEmbalagem { get; set; }
        public double Preco { get; set; }
        public DateTime DataCompra { get; set; } //TEMPORÁRIO, ver como vai ficar

        public Produto(int id, string nome, TipoEmbalagem tipoEmbalagem, double preco, DateTime dataCompra)
        {
            Id = id;
            Nome = nome;
            TipoEmbalagem = tipoEmbalagem;
            Preco = preco;
            DataCompra = dataCompra;
        }
    }
}
