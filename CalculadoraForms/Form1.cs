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
        bool jaApertado;

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
        }
        private void Operador_Click(object sender, EventArgs e) //Método para Operador
        {
            var botao = (Button)sender;

            jaApertado = false; //Iniciando a var de verif. como false

            if (txbTela.Text == "" && botao.Text != "-") //Condição se botão de operações acionado sem valor
            { 
                jaApertado = true; //Botão apertado valor passa a ser true
                MessageBox.Show("Insira um valor antes de acionar as operações!");
                btnClear.PerformClick(); //Método de clear
            }

            if (jaApertado == false) //Só vai executar se não estiver apertado
            {
                if (txbTela.Text == "" && botao.Text == "-")
                { //Condição para começar com valor negativo
                    txbTela.Text = botao.Text;
                    jaApertado = true;
                }
                else if (jaApertado && txbTela.Text == "-" || botao.Text == "-")
                { //Condição: caso o botão "-" seja pressionado duas vezes
                    MessageBox.Show("Erro!"); //Mensagem de erro
                    btnClear.PerformClick();
                    jaApertado = true;
                }
            }

            if (jaApertado == false) //Se nenhum botão de operação foi acionada previamente
            {
                txbAux.Visible = botao.Visible; //Tela auxiliar de operação aparece

                numero1 = int.Parse(txbTela.Text); //Armazenando o número em uma var
                txbTela.Clear(); //Limpando a tela principal

                txbAux.Text = numero1.ToString() + botao.Text; //Deslocando o número armazenado
                                                               //e o operador para a tela auxiliar
                ultimoOperador = botao.Text; //Armazenando o último operador

                jaApertado = true;


            }

            if (jaApertado == false)
            {
                btnIgual.PerformClick();
                jaApertado = false;
            }

        }
        private void btnIgual_Click(object sender, EventArgs e) //Método para o operador: Igual (=)
        {
            if(ultimoOperador == "") //Condição: botão clicado sem operação selecionada
            {
                MessageBox.Show("Escolha uma operação matemática");
            }

            if (jaApertado == false) //Condição: apenas será executado se o botão de operações
            {                        //Não for a última coisa a ser inserida
                switch (ultimoOperador) //Selecionando o último operador clicado
                {
                    case "+": //Caso operador: Adição(+)
                        txbAux.Visible = false; //Tela auxiliar é ocultada
                        txbAux.Clear();
                        txbTela.Text = (numero1+ int.Parse(txbTela.Text)).ToString();
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
            else
            {
                MessageBox.Show("Erro");
                btnClear.PerformClick();
            }

        }
    }
}
