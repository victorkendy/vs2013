using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Contas
{
    class ContaPoupanca : Conta
    {
        public override void Saca(double valorOperacao)
        {
            if (valorOperacao + 0.10 > this.Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            this.Saldo -= valorOperacao + 0.10;
        }

        public override void Deposita(double valorOperacao)
        {
            if (valorOperacao < 0.0)
            {
                throw new ArgumentException();
            }
            this.Saldo += valorOperacao;
        }
    }
}
