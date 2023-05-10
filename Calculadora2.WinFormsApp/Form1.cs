namespace Calculadora2.WinFormsApp
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora;

        public Form1()
        {
            InitializeComponent();
            calculadora = new Calculadora();
            ConfigurarClickBotoes();
        }

        private void ConfigurarClickBotoes()
        {
            btn0.Click += AtribuirNumero;
            btn1.Click += AtribuirNumero;
            btn2.Click += AtribuirNumero;
            btn3.Click += AtribuirNumero;
            btn4.Click += AtribuirNumero;
            btn5.Click += AtribuirNumero;
            btn6.Click += AtribuirNumero;
            btn7.Click += AtribuirNumero;
            btn8.Click += AtribuirNumero;
            btn9.Click += AtribuirNumero;
            btnVirgula.Click += AtribuirNumero;

            btnSomar.Click += RegistrarOperacao;
            btnSubtrair.Click += RegistrarOperacao;
            btnDividir.Click += RegistrarOperacao;
            btnMultiplicar.Click += RegistrarOperacao;
            btnPorcentagem.Click += RegistrarOperacao;
            btnApagar.Click += Limpar;
            btnResultado.Click += ExecutarCalculo;
        }

        private void AtribuirNumero(object? sender, EventArgs e)
        {
            Button btnClicado = (Button)sender;
            txtNumeros.Text += btnClicado.Text;
        }
        private void RegistrarOperacao(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeros.Text))
                return;
            calculadora.primeiroNumero = Convert.ToDecimal(txtNumeros.Text);
            Button btnClicado = (Button)sender;
            calculadora.operacao = Convert.ToString(btnClicado.Tag);
            txtCalculo.Text = txtNumeros.Text + " " + btnClicado.Text;
            txtNumeros.Text = "";
        }
        private void ExecutarCalculo(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeros.Text))
                return;
            calculadora.segundoNumero = Convert.ToDecimal(txtNumeros.Text);
            try
            {
                txtCalculo.Text = calculadora.Calcular();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Matematica nao permite divisor ser igual a 0");
            }
            txtNumeros.Text = "";
        }
        private void Limpar(object? sender, EventArgs e)
        {
            txtCalculo.ResetText();
            txtNumeros.ResetText();
            calculadora.Limpar();
        }
    }
}