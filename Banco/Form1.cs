﻿using Banco.Contas;
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
        private List<Conta> contas;
        private Dictionary<string, Conta> dicionario;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dicionario = new Dictionary<string, Conta>();
            this.contas = new List<Conta>();

            Conta c1 = new ContaPoupanca();
            c1.Titular = new Cliente("victor");
            c1.Numero = 1;
            this.AdicionaConta(c1);

            Conta c2 = new ContaPoupanca();
            c2.Titular = new Cliente("mauricio");
            c2.Numero = 2;
            this.AdicionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("osni");
            c3.Numero = 3;
            this.AdicionaConta(c3);
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            Conta selecionada = (Conta)comboContas.SelectedItem;
            double valor = Convert.ToDouble(textoValor.Text);
            try
            {
                selecionada.Deposita(valor);
                textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Argumento Inválido");
            }
            
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            Conta selecionada = (Conta)comboContas.SelectedItem;
            double valor = Convert.ToDouble(textoValor.Text);
            try
            {
                selecionada.Saca(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show("Saldo Insuficiente");
            }
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = this.contas[indice];
            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        public void AdicionaConta(Conta conta)
        {
            this.contas.Add(conta);
            comboContas.Items.Add(conta);

            this.dicionario.Add(conta.Titular.Nome, conta);
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formularioCadastro = new FormCadastroConta(this);
            formularioCadastro.ShowDialog();
        }

        private void botaoImpostos_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Deposita(200.0);

            SeguroDeVida sv = new SeguroDeVida();

            TotalizadorDeTributos totalizador = new TotalizadorDeTributos();
            totalizador.Adiciona(conta);

            MessageBox.Show("Total = " + totalizador.Total);

            totalizador.Adiciona(sv);
            MessageBox.Show("Total = " + totalizador.Total);
        }

        private void botaoBusca_Click(object sender, EventArgs e)
        {
            string nomeTitular = textoBuscaTitular.Text;
            Conta conta = this.dicionario[nomeTitular];

            comboContas.SelectedItem = conta;
        }

        private void botaoRelatorio_Click(object sender, EventArgs e)
        {
            FormRelatorios form = new FormRelatorios(this.contas);
            form.ShowDialog();
        }
    }
}
