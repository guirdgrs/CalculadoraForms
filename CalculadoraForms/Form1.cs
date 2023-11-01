using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int numero1;
        string ultimoOperador;
        bool jaApertado = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e) //Método para limpar a tela
        {
            txbTela.Clear();
        }
        private void Numero_Click(object sender, EventArgs e) //Método para números
        {
            var botao = (Button)sender;

            txbTela.Text += botao.Text; //Armazenando o botão que foi clicado
        }
        private void Operador_Click(object sender, EventArgs e) //Método para Operador
        {
            var botao = (Button)sender;

            if (txbTela.Text == "" && botao.Text == "-") //Condição para começar com valor negativo
            {
                jaApertado = true;

                txbTela.Text = botao.Text;
            }

            if (txbTela.Text == "" && botao.Text != "-") //Condição se botão de operações acionado sem valor
            { 
                jaApertado = true;

                MessageBox.Show("Insira um valor antes de acionar as operações!");

                txbTela.Text = "";
            }

            if(jaApertado == false)
            {
                txbAux.Visible = botao.Visible; //Tela auxiliar de operação aparece

                numero1 = int.Parse(txbTela.Text); //Armazenando o número em uma var

                txbTela.Clear(); //Limpando a tela principal

                txbAux.Text = numero1.ToString() + botao.Text; //Deslocando o número armazenado
                                                           //e o opeardor para a tela auxiliar
                ultimoOperador = botao.Text; //Armazenando o último operador
            }

        }
        private void btnIgual_Click(object sender, EventArgs e) //Método para o operador: Igual (=)
        {
            switch (ultimoOperador) //Selecionando o último operador clicado
            {
                case "+": //Caso operador: Adição(+)
                    txbAux.Visible = false; //Tela auxiliar é ocultada
                    txbAux.Clear();
                    txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                    break;

                case "-": //Caso operador: Subtração(-)
                    txbAux.Visible = false;
                    txbAux.Clear();
                    txbTela.Text = (numero1 - int.Parse(txbTela.Text)).ToString();
                    break;

                case "x": //Caso operador: Multiplicação(x)
                    txbAux.Visible = false;
                    txbAux.Clear();
                    txbTela.Text = (numero1 * Double.Parse(txbTela.Text)).ToString();
                    break;

                case "÷": //Caso operador: Divisão(÷)
                    if (numero1 == 0 || int.Parse(txbTela.Text) == 0) //Condição: var numero1 = 0 
                    {                                                    //Ou número na tela = 0
                        MessageBox.Show("Erro! Divisão por zero");
                        txbAux.Visible = false;
                    }
                    else //Resultado da divisão
                    {
                        txbAux.Visible = false;
                        txbAux.Clear();
                        txbTela.Text = (numero1 / Double.Parse(txbTela.Text)).ToString();
                    }
                    break;


            }
        }
    }
}
