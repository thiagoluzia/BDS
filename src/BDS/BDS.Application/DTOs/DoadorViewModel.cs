﻿using BDS.Core.Entities;
using BDS.Core.Enums;
using BDS.Core.ValueObjects;

namespace DTOs
{
    public class DoadorViewModel
    {


        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh Fator { get; private set; }
        public List<Doacao> Doacao { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }



        public DoadorViewModel(string nome, string email, DateTime dataNascimento, Genero genero, double peso, TipoSanquineo tipoSanquineo, FatorRh fator, List<Doacao> doacao, Endereco endereco, bool ativo)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            Doacao = doacao;
            Endereco = endereco;
            Ativo = ativo;
        }

    }
}