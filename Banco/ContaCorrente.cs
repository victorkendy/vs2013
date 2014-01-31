using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaCorrente : Conta, ITributavel
    {
        public override void Deposita(double valorOperacao)
        {
            this.Saldo += valorOperacao - 0.05;
        }

        public override void Saca(double valorOperacao)
        {
            this.Saldo -= valorOperacao + 0.10;
        }

        public double CalculaTributos()
        {
            return this.Saldo * 0.05;
        }
    }
}
