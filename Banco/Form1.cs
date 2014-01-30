using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Conta conta;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.conta = new ContaCorrente();
            conta.Numero = 1;
            Cliente cliente = new Cliente("victor");
            conta.Titular = cliente;

            textoTitular.Text = conta.Titular.Nome;
            textoNumero.Text = Convert.ToString(conta.Numero);
            textoSaldo.Text = Convert.ToString(conta.Saldo);
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            this.conta.Deposita(valorOperacao);

            textoSaldo.Text = Convert.ToString(this.conta.Saldo);
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);
            this.conta.Saca(valorOperacao);

            textoSaldo.Text = Convert.ToString(this.conta.Saldo);
        }
    }
}
