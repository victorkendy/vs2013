using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Contas
{
    public abstract class Conta
    {
        private static int numeroDeContas;

        public int Numero { get; set; }

        public double Saldo { get; protected set; }

        public Cliente Titular { get; set; }

        public Conta()
        {
            Conta.numeroDeContas++;
            this.Numero = Conta.numeroDeContas;
        }

        public abstract void Deposita(double valorOperacao);

        public abstract void Saca(double valorOperacao);

        public static int ProximoNumero()
        {
            return numeroDeContas + 1;
        }
    }
}
