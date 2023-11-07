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
        string ultimoOperador = "";
        bool verErro = true,apertouOperador = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e) //Método para limpar a tela
        {
            txbAux.Clear();
            txbTela.Clear();
        }
        private void Numero_Click(object sender, EventArgs e) //Método para números
        {
            var botao = (Button)sender;

            txbTela.Text += botao.Text; //Armazenando o botão que foi clicado
            apertouOperador = false;
        }
        private void Operador_Click(object sender, EventArgs e) //Método para Operador
        {
            var botao = (Button)sender;

            if (txbTela.Text == "" && txbAux.Text == "" && botao.Text != "-")
            { //Condição se botão de operações acionado sem valor
                MessageBox.Show("Insira um valor antes de acionar as operações!");
                btnClear.PerformClick(); //Método de clear
                verErro = false; //Botão "desativa"
            }
            else if (txbTela.Text == "" && botao.Text == "-")
            { //Condição para começar com valor negativo
                ultimoOperador = "-";
                txbTela.Text = botao.Text; //Colocando o "-" na tela
                verErro = false;
                apertouOperador = false;
            }
            else if (verErro && txbTela.Text == "-" && botao.Text != null)
            { //Condição: caso o botão de operação seja acionado seguidamente sem valores
                MessageBox.Show("Erro!"); //Mensagem de erro
                btnClear.PerformClick();
                verErro = false;
            }

            if (verErro == true)
            { //Só irá excecutar se nenhum erro tiver sido executado
                txbAux.Visible = botao.Visible; //Tela auxiliar de operação aparece

                numero1 = int.Parse(txbTela.Text); //Armazenando o número em uma var
                txbTela.Clear(); //Limpando a tela principal

                txbAux.Text = numero1.ToString() + botao.Text; //Deslocando o número armazenado
                                                               //e o operador para a tela auxiliar
                ultimoOperador = botao.Text; //Armazenando o último operador

                apertouOperador = true;
            }

            if (apertouOperador && txbTela.Text != "" && txbAux.Text != "")
            {
                btnIgual.PerformClick();
            }

        }
        private void btnIgual_Click(object sender, EventArgs e) //Método para o operador: Igual (=)
        {
            if(ultimoOperador == "" && txbTela.Text == "")
            { //Condição: botão clicado sem operação selecionada
                MessageBox.Show("Escolha uma operação matemática");
            }

            if (verErro && txbTela.Text == "" || txbAux.Text == "")
            { //Impedir execução com último valor sendo um operador
                MessageBox.Show("Erro!");
                btnClear.PerformClick();
            }
            else
            {
                apertouOperador = false;
                switch (ultimoOperador)
                { //Selecionando o último operador clicado

                    case "+": //Caso operador: Adição(+)
                        txbAux.Visible = false; //Tela auxiliar é ocultada
                        txbAux.Clear();
                        txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                        //var numero1 (texto auxiliar) + valor na tela
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
                        if (numero1 == 0 || int.Parse(txbTela.Text) == 0)
                        { //Condição: var numero1 = 0 ou número na tela = 0
                            MessageBox.Show("Erro! Divisão por zero");
                            btnClear.PerformClick();
                            txbAux.Visible = false;
                        }
                        else
                        { //Resultado da divisão
                            txbAux.Visible = false;
                            txbAux.Clear();
                            txbTela.Text = (numero1 / Double.Parse(txbTela.Text)).ToString();
                        }
                        break;
                }
            }



        }
    }
}
