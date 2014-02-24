using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("texto.txt"))
            {
                using(Stream entrada = File.Open("texto.txt", FileMode.Open))
                using(StreamReader leitor = new StreamReader(entrada))
                {
                    textoConteudo.Text = leitor.ReadToEnd();
                }
            }
        }

        private void botaoGrava_Click(object sender, EventArgs e)
        {
            using(Stream saida = File.Open("texto.txt", FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(saida))
            {
                escritor.Write(textoConteudo.Text);
            }
        }

        private void botaoBusca_Click(object sender, EventArgs e)
        {
            string busca = textoBusca.Text;
            string textoDoEditor = textoConteudo.Text;
            int resultado = textoDoEditor.IndexOf(busca);
            if (resultado >= 0)
            {
                MessageBox.Show("achei o texto " + busca);
            }
            else
            {
                MessageBox.Show("não achei");
            }
        }

        private void botaoReplace_Click(object sender, EventArgs e)
        {
            textoConteudo.Text = textoConteudo.Text.Replace(textoBusca.Text, textoReplace.Text);
        }

        private void botaoToUpper_Click(object sender, EventArgs e)
        {
            int inicioSelecao = textoConteudo.SelectionStart;
            int tamanhoSelecao = textoConteudo.SelectionLength;
            string textoSelecionado = textoConteudo.Text.Substring(inicioSelecao, tamanhoSelecao);
            string antes = textoConteudo.Text.Substring(0, inicioSelecao);
            string depois = textoConteudo.Text.Substring(inicioSelecao + tamanhoSelecao);

            textoConteudo.Text = antes + textoSelecionado.ToUpper() + depois;
        }

        private void botaoToLower_Click(object sender, EventArgs e)
        {
            textoConteudo.Text = textoConteudo.Text.ToLower();
        }
    }
}
