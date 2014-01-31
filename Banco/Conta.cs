﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public abstract class Conta
    {
        public int Numero { get; set; }

        public double Saldo { get; protected set; }

        public Cliente Titular { get; set; }

        public abstract void Deposita(double valorOperacao);

        public abstract void Saca(double valorOperacao);
    }
}
