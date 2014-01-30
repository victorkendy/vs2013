using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class ContaPoupanca : Conta
    {
        public override void Saca(double valorOperacao)
        {
            this.Saldo -= valorOperacao + 0.10;
        }
    }
}
