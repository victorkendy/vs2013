using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public class Conta
    {
        public int Numero { get; set; }

        public double Saldo { get; protected set; }

        public Cliente Titular { get; set; }

        public virtual void Deposita(double valorOperacao)
        {
            this.Saldo += valorOperacao;
        }

        public virtual void Saca(double valorOperacao)
        {
            this.Saldo -= valorOperacao;
        }
    }
}
