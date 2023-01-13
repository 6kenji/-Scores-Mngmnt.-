using Connection_Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Score_Mgntm.FormsUsados
{
    public partial class VerScoresForm : Form
    {
        ClasseConexao classecon = new ClasseConexao();

        private string[] opcao = new string[] { "Escolha uma opção:" };
        private string[] cadeiras1 = new string[] { "Escolha uma opção:", "Algorítmos e Estruturas de Dados", "Instrumentação e Medida"
                , "Processamento Analógico de Sinais", "Programação para Dispositivos Móveis", "Radiação e Propagação", "Sistemas de Comunicação I" };
        private string[] cadeiras2 = new string[] { "Escolha uma opção:", "Aplicação e Serviços Internet", "Antenas"
                , "Processamento Digital de Sinais", "Redes IP", "Sistemas de Comunicação II", "Sistemas de Gestão de Base de Dados" };
        private string[] turmas = new string[] { "Escolha uma opção:", "LEIT 31", "LEIT 32", "LEIT 33" };
        private string[] semestre = new string[] { "Escolha uma opção:", "I SEMESTRE", "II SEMESTRE" };
        private string[] ano = new string[] { "Escolha uma opção:", "3º Ano" };

        public VerScoresForm()
        {
            InitializeComponent();
            AtribuirValores();
        }

        private void AtribuirValores()
        {
            cbSemestre.DataSource = semestre;
            cbAno.DataSource = opcao;
            cbTurmas.DataSource = opcao;
            cbCadeiras.DataSource = opcao;
        }
        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSemestre.SelectedItem.Equals("I SEMESTRE"))
                cbAno.DataSource = ano;
            else if (cbSemestre.SelectedItem.Equals("II SEMESTRE"))
                cbAno.DataSource = ano;
            else
            {
                cbAno.DataSource = opcao;
                cbTurmas.DataSource = opcao;
                cbCadeiras.DataSource = opcao;
            }
        }
        private void cbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSemestre_SelectedIndexChanged(sender, e);

            if (cbAno.SelectedItem.Equals("3º Ano") && cbSemestre.SelectedItem.Equals("I SEMESTRE"))
                cbTurmas.DataSource = turmas;
            else if (cbAno.SelectedItem.Equals("3º Ano") && cbSemestre.SelectedItem.Equals("II SEMESTRE"))
                cbTurmas.DataSource = turmas;
            else
            {
                cbTurmas.DataSource = opcao;
                cbCadeiras.DataSource = opcao;
            }
        }
        private void cbTurmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAno_SelectedIndexChanged(sender, e);

            if (cbSemestre.SelectedItem.Equals("I SEMESTRE") & (cbTurmas.SelectedItem.Equals("LEIT 31") || cbTurmas.SelectedItem.Equals("LEIT 32") ||
                 cbTurmas.SelectedItem.Equals("LEIT 33"))
                )
            { cbCadeiras.DataSource = cadeiras1; }
            else if (cbSemestre.SelectedItem.Equals("II SEMESTRE") & (cbTurmas.SelectedItem.Equals("LEIT 31") || cbTurmas.SelectedItem.Equals("LEIT 32") ||
                cbTurmas.SelectedItem.Equals("LEIT 33"))
                )
            { cbCadeiras.DataSource = cadeiras2; }
            else
            { cbCadeiras.DataSource = opcao; }
        }
        private void cbCadeiras_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTurmas_SelectedIndexChanged(sender, e);

            if (cbCadeiras.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
            {
                BuscarAEDA();
            }
            else if (cbCadeiras.SelectedItem.Equals("Instrumentação e Medida"))
            {
                BuscarIMED();
            }
            else if (cbCadeiras.SelectedItem.Equals("Processamento Analógico de Sinais"))
            {
                BuscarPRAS();
            }
            else if (cbCadeiras.SelectedItem.Equals("Programação para Dispositivos Móveis"))
            {
                BuscarPRDM();
            }
            else if (cbCadeiras.SelectedItem.Equals("Radiação e Propagação"))
            {
                BuscarRADP();
            }
            else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação I"))
            {
                BuscarSISCOM1();
            }
            else if (cbCadeiras.SelectedItem.Equals("Aplicação e Serviços Internet"))
            {
                BuscarASI();
            }
            else if (cbCadeiras.SelectedItem.Equals("Antenas"))
            {
                BuscarANTENAS();
            }
            else if (cbCadeiras.SelectedItem.Equals("Processamento Digital de Sinais"))
            {
                BuscarPDS();
            }
            else if (cbCadeiras.SelectedItem.Equals("Redes IP"))
            {
                BuscarREDESIP();
            }
            else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação II"))
            {
                BuscarSISCOM2();
            }
            else if (cbCadeiras.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
            {
                BuscarSGBD();
            }
            else
            {
                GridDados.DataSource = " ";
            }

        }

        private void BuscarAEDA()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbAEDA ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarIMED()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbIMED ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarPRAS()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbPRAS ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarPRDM()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbPROG ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarRADP()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbRADP ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarSISCOM1()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbSISCOM1 ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarASI()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbASI ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarANTENAS()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbANTENAS ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarPDS()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbPDS ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarREDESIP()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbREDESIP ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarSISCOM2()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbSISCOM2 ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarSGBD()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT * FROM TbSGBD ";
                classecon.ShowDataInGridView(SQL, GridDados);
                classecon.CloseConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}