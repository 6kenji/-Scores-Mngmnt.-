using Connection_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Score_Mgntm.FormsUsados
{
    public partial class DefinicoesForm : Form
    {
        ///Valores
        public int estado;
        ClasseConexao classecon = new ClasseConexao();

        private string[] semestre1 = new string[] { "Escolha uma opção:", "I SEMESTRE", "II SEMESTRE" };
        private string[] semestre2 = new string[] { "Escolha uma opção:", "I SEMESTRE", "II SEMESTRE" };
        private string[] opcao = new string[] { "Escolha uma opção:" };

        private readonly string[] cadeiras1 = new string[] { "Escolha uma opção:", "Algorítmos e Estruturas de Dados", "Instrumentação e Medida"
                , "Processamento Analógico de Sinais", "Programação para Dispositivos Móveis", "Radiação e Propagação", "Sistemas de Comunicação I" };
        private readonly string[] cadeiras2 = new string[] { "Escolha uma opção:", "Aplicação e Serviços de Internet", "Antenas"
                , "Processamento Digital de Sinais", "Redes IP", "Sistemas de Comunicação II", "Sistemas de Gestão de Base de Dados" };

        private readonly string[] cadeiras3 = new string[] { "Escolha uma opção:", "Algorítmos e Estruturas de Dados", "Instrumentação e Medida"
                , "Processamento Analógico de Sinais", "Programação para Dispositivos Móveis", "Radiação e Propagação", "Sistemas de Comunicação I" };
        private readonly string[] cadeiras4 = new string[] { "Escolha uma opção:", "Aplicação e Serviços Internet", "Antenas"
                , "Processamento Digital de Sinais", "Redes IP", "Sistemas de Comunicação II", "Sistemas de Gestão de Base de Dados" };

        public DefinicoesForm()
        {
            InitializeComponent();
            AtribuirValores();
            EsconderValores();
        }

        private void cbSemestre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSemestre1.SelectedItem.Equals("I SEMESTRE"))
            {
                cbCadeiras1.DataSource = cadeiras1;
            }
            else if (cbSemestre1.SelectedItem.Equals("II SEMESTRE"))
            {
                cbCadeiras1.DataSource = cadeiras2;
            }
            else
            {
                cbCadeiras1.DataSource = opcao;
            }
        }
        private void cbCadeiras1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSemestre1_SelectedIndexChanged(sender, e);
            if (cbCadeiras1.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
            {
                LimpaCampos();
                BuscarAEDA();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Instrumentação e Medida"))
            {
                LimpaCampos();
                BuscarIMED();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Processamento Analógico de Sinais"))
            {
                LimpaCampos();
                BuscarPRAS();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Programação para Dispositivos Móveis"))
            {
                LimpaCampos();
                BuscarPRDM();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Radiação e Propagação"))
            {
                LimpaCampos();
                BuscarRADP();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Sistemas de Comunicação I"))
            {
                LimpaCampos();
                BuscarSISCOM1();
                ValidaCampos();
            }
            if (cbCadeiras1.SelectedItem.Equals("Aplicação e Serviços de Internet"))
            {
                LimpaCampos();
                BuscarASI();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Antenas"))
            {
                LimpaCampos();
                BuscarANTENAS();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Processamento Digital de Sinais"))
            {
                LimpaCampos();
                BuscarPDS();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Redes IP"))
            {
                LimpaCampos();
                BuscarREDESIP();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Sistemas de Comunicação II"))
            {
                LimpaCampos();
                BuscarSISCOM2();
                ValidaCampos();
            }
            else if (cbCadeiras1.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
            {
                LimpaCampos();
                BuscarSGBD();
                ValidaCampos();
            }
            else
            {
                EsconderValores();
            }
        }
        private void cbSemestre2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSemestre2.SelectedItem.Equals("I SEMESTRE"))
            {
                cbCadeiras2.DataSource = cadeiras3;
            }
            else if (cbSemestre2.SelectedItem.Equals("II SEMESTRE"))
            {
                cbCadeiras2.DataSource = cadeiras4;
            }
            else
            {
                cbCadeiras2.DataSource = opcao;
            }
        }
        private void cbCadeiras2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSemestre2_SelectedIndexChanged(sender, e);
        }
        private void bResetAll_Click(object sender, EventArgs e)
        {
            cbCadeiras2_SelectedIndexChanged(sender, e);
            if (cbCadeiras2.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
            {
                ResetAEDA();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Instrumentação e Medida"))
            {
                ResetIMED();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Processamento Analógico de Sinais"))
            {
                ResetPRAS();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Programação para Dispositivos Móveis"))
            {
                ResetPRDM();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Radiação e Propagação"))
            {
                ResetRADP();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Sistemas de Comunicação I"))
            {
                ResetSISCOM1();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Antenas"))
            {
                ResetANTENAS();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Aplicação e Serviços Internet"))
            {
                ResetASI();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Processamento Digital de Sinais"))
            {
                ResetPDS();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Redes IP"))
            {
                ResetREDESIP();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Sistemas de Comunicação II"))
            {
                ResetSISCOM2();
            }
            else if (cbCadeiras2.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
            {
                ResetSGBD();
            }
            MessageBox.Show("Dados apagados com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btResetExames_Click(object sender, EventArgs e)
        {
            if (tbExame1.Text.Equals("0") & !tbExame2.Text.Equals("0")
                || tbExame2.Text.Equals("0") & !tbExame3.Text.Equals("0")
                || tbExame1.Text.Equals("0") & !tbExame3.Text.Equals("0") 
                || tbExame1.Text.Equals("0") & tbExame2.Text.Equals("0") & !tbExame3.Text.Equals("0")
                || tbExame1.Text.Equals("0") & !tbExame2.Text.Equals("0") & !tbExame3.Text.Equals("0")
                || tbExame1.Text.Equals("0") & !tbExame2.Text.Equals("0") & tbExame3.Text.Equals("0")
                || !tbExame1.Text.Equals("0") & tbExame2.Text.Equals("0") & !tbExame3.Text.Equals("0")
                )
            {
                MessageBox.Show("Valor do exame anterior não permetido! O campo do exame seguite não pode ser preenchido antes do primeiro. ", "Erro de inserção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Opcoes();
            }
        }

        ///1 Semestre
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///Busca de dados
        private void BuscarAEDA()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2 FROM TbAEDA ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarIMED()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2 FROM TbIMED ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarPRAS()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbPRAS ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarPRDM()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbPROG ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL); 
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarRADP()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbRADP ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BuscarSISCOM1()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2 FROM TbSISCOM1 ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        ///Busca dos Exames
        private void ExamesAEDA()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbAEDA SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesIMED()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbIMED SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesPRAS()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbPRAS SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesPRDM()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbPROG SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesRADP()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbRADP SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesSISCOM1()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbSISCOM1 SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }

        ///Reset de dados
        private void ResetAEDA()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbAEDA SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1,
                    T2 = @T2,
                    TP1 = @TP1,
                    TP2 = @TP2,
                    DIV1 = @DIV1,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2 ";
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TP1", SqlDbType.Int, 0);
            classecon.AddParam("TP2", SqlDbType.Int, 0);
            classecon.AddParam("DIV1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }

        private void ResetIMED()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbIMED SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    MT3 = @MT3,
                    MT4 = @MT4,  
                    MT5 = @MT5,
                    T1 = @T1, 
                    T2 = @T2,
                    TPC1 = @TPC1,
                    TPC2 = @TPC2,
                    TPC3 = @TPC3,
                    TG1 = @TG1,
                    TG2 = @TG2,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("MT3", SqlDbType.Int, 0);
            classecon.AddParam("MT4", SqlDbType.Int, 0);
            classecon.AddParam("MT5", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TPC2", SqlDbType.Int, 0);
            classecon.AddParam("TPC3", SqlDbType.Int, 0);
            classecon.AddParam("TG1", SqlDbType.Int, 0);
            classecon.AddParam("TG2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            // Executa o update
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetPRAS()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbPRAS SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1, 
                    T2 = @T2,
                    TPC1 = @TPC1,
                    TPC2 = @TPC2,
                    TL1 = @TL1,
                    TL2 = @TL2,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TPC2", SqlDbType.Int, 0);
            classecon.AddParam("TL1", SqlDbType.Int, 0);
            classecon.AddParam("TL2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }

        private void ResetPRDM()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbPROG SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1, 
                    T2 = @T2,
                    TPC1 = @TPC1,
                    TG1 = @TG1,
                    TI1 = @TI1,
                    TI2 = @TI2,
                    PROJ1 = @PROJ1,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TG1", SqlDbType.Int, 0);
            classecon.AddParam("TI1", SqlDbType.Int, 0);
            classecon.AddParam("TI2", SqlDbType.Int, 0);
            classecon.AddParam("PROJ1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetRADP()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbRADP SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1, 
                    T2 = @T2,
                    MT3 = @MT3,
                    T3 = @T3,
                    TPC1 = @TPC1,
                    TP1 = @TP1,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TP1", SqlDbType.Int, 0);
            classecon.AddParam("T3", SqlDbType.Int, 0);
            classecon.AddParam("MT3", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }

        private void ResetSISCOM1()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbSISCOM1 SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 =  @T1, 
                    T2 = @T2,
                    TG1 = @TG1,
                    TG2 = @TG2,
                    TL1 = @TL1,
                    TL2 = @TL2,
                    TL3 = @TL3,
                    TL4 = @TL4,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TG1", SqlDbType.Int, 0);
            classecon.AddParam("TL1", SqlDbType.Int, 0);
            classecon.AddParam("TG2", SqlDbType.Int, 0);
            classecon.AddParam("TL2", SqlDbType.Int, 0);
            classecon.AddParam("TL3", SqlDbType.Int, 0);
            classecon.AddParam("TL4", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);

            // Retorna a quantidade de linhas afetadas
            classecon.ExecutaAtualizacao(SQL);
        }

        ///2 Semestre
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///Busca de dados
        private void BuscarANTENAS()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbANTENAS ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void BuscarASI()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbASI";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarPDS()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbPDS ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarREDESIP()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2 FROM TbREDESIP ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BuscarSISCOM2()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2 FROM TbSISCOM2 ";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void BuscarSGBD()
        {
            try
            {
                classecon.OpenConection();
                string SQL = @"SELECT EXAME1, EXAME2, EXAME3 FROM TbSGBD";
                DataTable result;
                result = classecon.ExecuteConsult(SQL);
                tbExame1.Text = result.Rows[0]["EXAME1"].ToString();
                tbExame2.Text = result.Rows[0]["EXAME2"].ToString();
                tbExame3.Text = result.Rows[0]["EXAME3"].ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        ///Busca dos Exames
        private void ExamesANTENAS()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbANTENAS SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesASI()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbASI SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesPDS()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbPDS SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesREDESIP()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbREDESIP SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesSISCOM2()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbSISCOM2 SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ExamesSGBD()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbSGBD SET
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }

        ///Reset de dados
        private void ResetANTENAS()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbANTENAS SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1,
                    T2 = @T2,
                    T3 = @T3,
                    TP1 = @TP1,
                    TPC1 = @TPC1,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";

            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("T3", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TP1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetASI()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbASI SET
                    MT1 = @MT1,
                    MT2 = @MT2,
                    T1 = @T1, 
                    T2 = @T2,
                    TPC1 = @TPC1,
                    TPC2 = @TPC2,
                    TPC3 = @TPC3,
                    TPC4 = @TPC4, 
                    PROJ = @PROJ,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TPC2", SqlDbType.Int, 0);
            classecon.AddParam("TPC3", SqlDbType.Int, 0);
            classecon.AddParam("TPC4", SqlDbType.Int, 0);
            classecon.AddParam("PROJ", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            // Executa o update
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetPDS()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbPDS SET
                    MT1 = @MT1,
                    MT2 = @MT2,
                    T1 = @T1, 
                    T2 = @T2,
                    TPC1 = @TPC1,
                    TPC2 = @TPC2,
                    TL1 = @TL1,
                    TL2 = @TL2, 
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TPC2", SqlDbType.Int, 0);
            classecon.AddParam("TL1", SqlDbType.Int, 0);
            classecon.AddParam("TL2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            // Executa o update
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetREDESIP()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbREDESIP SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1, 
                    T2 = @T2,
                    TL1 = @TL1,
                    TL2 = @TL2,
                    TI1 = @TI1,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TL1", SqlDbType.Int,0);
            classecon.AddParam("TL2", SqlDbType.Int, 0);
            classecon.AddParam("TI1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetSISCOM2()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbSISCOM2 SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1, 
                    T2 = @T2,
                    TL1 = @TL1,
                    TL2 = @TL2,
                    TPC1 = @TPC1,
                    TPC2 = @TPC2,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TL1", SqlDbType.Int, 0);
            classecon.AddParam("TL2", SqlDbType.Int, 0);
            classecon.AddParam("TPC1", SqlDbType.Int, 0);
            classecon.AddParam("TPC2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }
        private void ResetSGBD()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbSGBD SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    MT3 = @MT3, 
                    T1 = @T1, 
                    T2 = @T2,
                    TP1 = @TP1,
                    TP2 = @TP2,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, 0);
            classecon.AddParam("MT2", SqlDbType.Int, 0);
            classecon.AddParam("MT3", SqlDbType.Int, 0);
            classecon.AddParam("T1", SqlDbType.Int, 0);
            classecon.AddParam("T2", SqlDbType.Int, 0);
            classecon.AddParam("TP1", SqlDbType.Int, 0);
            classecon.AddParam("TP2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME1", SqlDbType.Int, 0);
            classecon.AddParam("EXAME2", SqlDbType.Int, 0);
            classecon.AddParam("EXAME3", SqlDbType.Int, 0);
            classecon.ExecutaAtualizacao(SQL);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///Metodos auxiliares
        private void LimpaCampos()
        {
            tbExame1.Text = "";
            tbExame2.Text = "";
            tbExame3.Text = "";
        }
        private void EsconderValores()
        {
            tbExame1.Enabled = false;
            tbExame2.Enabled = false;
            tbExame3.Enabled = false;

            tbExame1.Text = "";
            tbExame2.Text = "";
            tbExame3.Text = "";
        }
        private void AtribuirValores()
        {
            cbSemestre1.DataSource = semestre1;
            cbCadeiras1.DataSource = opcao;
            cbSemestre2.DataSource = semestre2;
            cbCadeiras2.DataSource = opcao;
        }
        private void ValidaCampos()
        {
            if (!Verifica3Epoca())
            {
                if (tbExame1.Text.ToString().Equals("0") && tbExame2.Text.ToString().Equals("0"))
                {
                    MessageBox.Show("Sem notas por se atualizar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!tbExame1.Text.ToString().Equals("0") && !tbExame2.Text.ToString().Equals("0"))
                {
                    tbExame1.Enabled = true;
                    tbExame2.Enabled = true;
                }
            }
            else if (Verifica3Epoca())
            {
                if (tbExame1.Text.ToString().Equals("0") && tbExame2.Text.ToString().Equals("0") && tbExame3.Text.ToString().Equals("0"))
                {
                    MessageBox.Show("Sem notas por se atualizar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!tbExame1.Text.ToString().Equals("0") && !tbExame2.Text.ToString().Equals("0") && !tbExame3.Text.ToString().Equals("0"))
                {
                    tbExame1.Enabled = true;
                    tbExame2.Enabled = true;
                    tbExame3.Enabled = true;
                }
                else if (!tbExame1.Text.ToString().Equals("0") && !tbExame2.Text.ToString().Equals("0") && tbExame3.Text.ToString().Equals("0"))
                {
                    tbExame1.Enabled = true;
                    tbExame2.Enabled = true;
                    tbExame3.Enabled = false;
                }
                else if (!tbExame1.Text.ToString().Equals("0") && tbExame2.Text.ToString().Equals("0") && tbExame3.Text.ToString().Equals("0"))
                {
                    tbExame1.Enabled = true;
                    tbExame2.Enabled = false;
                    tbExame3.Enabled = false;
                }
            }
        }
        public void Opcoes()
        {
            if (cbCadeiras1.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
            {
                ExamesAEDA();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Instrumentação e Medida"))
            {
                ExamesIMED();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Processamento Analógico de Sinais"))
            {
                ExamesPRAS();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Programação para Dispositivos Móveis"))
            {
                ExamesPRDM();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Radiação e Propagação"))
            {
                ExamesRADP();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Sistemas de Comunicação I"))
            {
                ExamesSISCOM1();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Aplicação e Serviços Internet"))
            {
                ExamesASI();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Antenas"))
            {
                ExamesANTENAS();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Processamento Digital de Sinais"))
            {
                ExamesPDS();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Redes IP"))
            {
                ExamesREDESIP();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Sistemas de Comunicação II"))
            {
                ExamesSISCOM2(); 
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbCadeiras1.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
            {
                ExamesSGBD();
                MessageBox.Show("Notas actualizadas com sucesso!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Escolha um campo par prosseguir! ", "Campo vazio!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private bool Verifica3Epoca()
        {
            bool estado;

            if (cbCadeiras1.SelectedItem.Equals("Processamento Analógico de Sinais")
                || cbCadeiras1.SelectedItem.Equals("Programação para Dispositivos Móveis")
                || cbCadeiras1.SelectedItem.Equals("Radiação e Propagação") || cbCadeiras2.SelectedItem.Equals("Aplicação e Serviços Internet")
                || cbCadeiras2.SelectedItem.Equals("Antenas") || cbCadeiras2.SelectedItem.Equals("Processamento Digital de Sinais")
                || cbCadeiras2.SelectedItem.Equals("Redes IP") || cbCadeiras2.SelectedItem.Equals("Sistemas de Gestão de Base de Dados")
                )
            {
                tbExame3.Visible = true;
                estado = true;
            }
            else
            {
                tbExame3.Visible = false;
                estado = false;
            }
            return estado;
        }

    }
}