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
    public partial class VerStatsForm : Form
    {
        ClasseConexao classecon = new ClasseConexao();
        double chancesPassar, chancesReprovar, acumulado = 0;
        int aprovadas1Sem = 0, reprovadas1Sem = 0, aprovadas2Sem = 0, reprovadas2Sem = 0, valorExame = 0,
            contN1Sem = 0, contP1Sem = 0, contN2Sem = 0, contP2Sem = 0, acmAEDA, acmIMED, acmPRAS, acmPROG, acmRADP, acmSISCOM1, acmAnNTENAS, acmASI, acmPDS, acmREDESIP, acmSISCOM2, acmSGBD, 
            controlador1 = 0, controlador2 = 0;


        private string[] opcao = new string[] { "Escolha uma opção:" };
        private string[] cadeiras1 = new string[] { "Escolha uma opção:", "Algorítmos e Estruturas de Dados", "Instrumentação e Medida"
                , "Processamento Analógico de Sinais", "Programação para Dispositivos Móveis", "Radiação e Propagação", "Sistemas de Comunicação I" };
        private string[] cadeiras2 = new string[] { "Escolha uma opção:", "Aplicação e Serviços Internet", "Antenas"
                , "Processamento Digital de Sinais", "Redes IP", "Sistemas de Comunicação II", "Sistemas de Gestão de Base de Dados" };

        private string[] semestre = new string[] { "Escolha uma opção:", "I SEMESTRE", "II SEMESTRE" };

        public VerStatsForm()
        {
            InitializeComponent();
            AtribuirValores();
        }

        private void AprovadosReprovados1Sem()
        {
            do
            {
                controlador1++;
                if (controlador1 == 1)
                {
                    string SQLAEDA = @"SELECT MT1, MT2, T1, T2, TP1, TP2, DIV1, EXAME1, EXAME2 
                         FROM TbAEDA ";
                    DataTable resultAEDA;
                    resultAEDA = classecon.ExecuteConsult(SQLAEDA);
                    acmAEDA = int.Parse(resultAEDA.Rows[0]["MT1"].ToString()) + int.Parse(resultAEDA.Rows[0]["MT2"].ToString()) +
                         int.Parse(resultAEDA.Rows[0]["T1"].ToString()) + int.Parse(resultAEDA.Rows[0]["T2"].ToString()) +
                         int.Parse(resultAEDA.Rows[0]["TP1"].ToString()) + int.Parse(resultAEDA.Rows[0]["TP2"].ToString()) +
                         int.Parse(resultAEDA.Rows[0]["DIV1"].ToString());
                    ValoresNaCadeira(acmAEDA, resultAEDA, 300, 1700);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLIMED = @"SELECT
                            MT1, MT2, MT3, MT4, MT5, T1, T2, TPC1, TPC2, TPC3, TG1, TG2, EXAME1,
                            EXAME2
                            FROM TbIMED ";
                    DataTable resultIMED;
                    resultIMED = classecon.ExecuteConsult(SQLIMED);
                    acmIMED = int.Parse(resultIMED.Rows[0]["MT1"].ToString()) + int.Parse(resultIMED.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultIMED.Rows[0]["MT3"].ToString()) + int.Parse(resultIMED.Rows[0]["MT4"].ToString()) +
                        int.Parse(resultIMED.Rows[0]["MT5"].ToString()) + int.Parse(resultIMED.Rows[0]["T1"].ToString()) +
                        int.Parse(resultIMED.Rows[0]["T2"].ToString()) + int.Parse(resultIMED.Rows[0]["TPC1"].ToString()) +
                        int.Parse(resultIMED.Rows[0]["TPC2"].ToString()) + int.Parse(resultIMED.Rows[0]["TPC3"].ToString()) +
                         int.Parse(resultIMED.Rows[0]["TG1"].ToString()) + int.Parse(resultIMED.Rows[0]["TG2"].ToString());
                    ValoresNaCadeira(acmIMED, resultIMED, 250, 1400);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLPRAS = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2, EXAME1,
                            EXAME2, EXAME3
                            FROM TbPRAS ";
                    DataTable resultPRAS;
                    resultPRAS = classecon.ExecuteConsult(SQLPRAS);
                    acmPRAS = int.Parse(resultPRAS.Rows[0]["MT1"].ToString()) + int.Parse(resultPRAS.Rows[0]["MT2"].ToString()) +
                       int.Parse(resultPRAS.Rows[0]["T1"].ToString()) + int.Parse(resultPRAS.Rows[0]["T2"].ToString()) +
                       int.Parse(resultPRAS.Rows[0]["TPC1"].ToString()) + int.Parse(resultPRAS.Rows[0]["TPC2"].ToString()) +
                        int.Parse(resultPRAS.Rows[0]["TL1"].ToString()) + int.Parse(resultPRAS.Rows[0]["TL2"].ToString());
                    ValoresNaCadeiraEspecial(acmPRAS, resultPRAS, 250, 1340);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLPROG = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TG1,  TI1, TI2, PROJ1, EXAME1,
                            EXAME2, EXAME3 
                            FROM TbPROG ";
                    DataTable resultPROG;
                    resultPROG = classecon.ExecuteConsult(SQLPROG);
                    acmPROG = int.Parse(resultPROG.Rows[0]["MT1"].ToString()) + int.Parse(resultPROG.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultPROG.Rows[0]["T1"].ToString()) + int.Parse(resultPROG.Rows[0]["T2"].ToString()) +
                        int.Parse(resultPROG.Rows[0]["TPC1"].ToString()) + int.Parse(resultPROG.Rows[0]["TG1"].ToString()) +
                         int.Parse(resultPROG.Rows[0]["TI1"].ToString()) + int.Parse(resultPROG.Rows[0]["TI2"].ToString())
                         + int.Parse(resultPROG.Rows[0]["PROJ1"].ToString());
                    ValoresNaCadeiraEspecial(acmPROG, resultPROG, 250, 1490);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    string SQLRADP = @"SELECT
                            MT1, MT2, T1, T2, T3, MT3, TPC1, TP1, EXAME1,
                            EXAME2, EXAME3
                                FROM TbRADP ";
                    DataTable resultRADP;
                    resultRADP = classecon.ExecuteConsult(SQLRADP);
                    acmRADP = int.Parse(resultRADP.Rows[0]["MT1"].ToString()) + int.Parse(resultRADP.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultRADP.Rows[0]["MT3"].ToString()) + int.Parse(resultRADP.Rows[0]["T1"].ToString()) +
                        int.Parse(resultRADP.Rows[0]["T2"].ToString()) + int.Parse(resultRADP.Rows[0]["T3"].ToString()) +
                         int.Parse(resultRADP.Rows[0]["TPC1"].ToString()) + int.Parse(resultRADP.Rows[0]["TP1"].ToString());
                    ValoresNaCadeiraEspecial(acmRADP, resultRADP, 250, 1550);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLSISCOM1 = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TL3, TL4, TG1, TG2, EXAME1,
                            EXAME2
                            FROM TbSISCOM1 ";
                    DataTable resultSISCOM1;
                    resultSISCOM1 = classecon.ExecuteConsult(SQLSISCOM1);
                    acmSISCOM1 = int.Parse(resultSISCOM1.Rows[0]["MT1"].ToString()) + int.Parse(resultSISCOM1.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultSISCOM1.Rows[0]["T1"].ToString()) + int.Parse(resultSISCOM1.Rows[0]["T2"].ToString()) +
                        int.Parse(resultSISCOM1.Rows[0]["TL1"].ToString()) + int.Parse(resultSISCOM1.Rows[0]["TL2"].ToString()) +
                         int.Parse(resultSISCOM1.Rows[0]["TL3"].ToString()) + int.Parse(resultSISCOM1.Rows[0]["TL4"].ToString()) +
                         int.Parse(resultSISCOM1.Rows[0]["TG1"].ToString()) + int.Parse(resultSISCOM1.Rows[0]["TG2"].ToString());
                    ValoresNaCadeira(acmSISCOM1, resultSISCOM1, 250, 1500);
                }
                break;
            } while (controlador1 < 1);
            aprovadas1Sem = contP1Sem;
            reprovadas1Sem = contN1Sem;
        }
        
        private void AprovadosReprovados2Sem()
        {
            do
            {
                controlador2++;
                if (controlador2 == 1)
                {
                    string SQLANTENAS = @"SELECT MT1, MT2, T1, T2, T3, TP1, TPC1, EXAME1, EXAME2, EXAME3
                         FROM TbANTENAS";
                    DataTable resultATENAS;
                    resultATENAS = classecon.ExecuteConsult(SQLANTENAS);
                    acmAnNTENAS = int.Parse(resultATENAS.Rows[0]["MT1"].ToString()) + int.Parse(resultATENAS.Rows[0]["MT2"].ToString()) +
                         int.Parse(resultATENAS.Rows[0]["T1"].ToString()) + int.Parse(resultATENAS.Rows[0]["T2"].ToString()) +
                         int.Parse(resultATENAS.Rows[0]["T3"].ToString()) + int.Parse(resultATENAS.Rows[0]["TP1"].ToString()) +
                         int.Parse(resultATENAS.Rows[0]["TPC1"].ToString());
                    ValoresNaCadeiraEspecial(acmAnNTENAS, resultATENAS, 250, 1450);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLASI = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TPC3, TPC4, PROJ, EXAME1, EXAME2, EXAME3
                            FROM TbASI ";
                    DataTable resultASI;
                    resultASI = classecon.ExecuteConsult(SQLASI);
                    acmASI = int.Parse(resultASI.Rows[0]["MT1"].ToString()) + int.Parse(resultASI.Rows[0]["MT2"].ToString())
                        + int.Parse(resultASI.Rows[0]["T1"].ToString()) + int.Parse(resultASI.Rows[0]["T2"].ToString()) 
                        + int.Parse(resultASI.Rows[0]["TPC1"].ToString()) + int.Parse(resultASI.Rows[0]["TPC2"].ToString()) 
                        + int.Parse(resultASI.Rows[0]["TPC3"].ToString()) + int.Parse(resultASI.Rows[0]["TPC4"].ToString())
                         + int.Parse(resultASI.Rows[0]["PROJ"].ToString());
                    ValoresNaCadeiraEspecial(acmASI, resultASI, 330, 1060);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLPDS = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2, EXAME1, EXAME2, EXAME3
                            FROM TbPDS";
                    DataTable resultPDS;
                    resultPDS = classecon.ExecuteConsult(SQLPDS);
                    acmPDS = int.Parse(resultPDS.Rows[0]["MT1"].ToString()) + int.Parse(resultPDS.Rows[0]["MT2"].ToString()) + 
                        int.Parse(resultPDS.Rows[0]["T1"].ToString()) + int.Parse(resultPDS.Rows[0]["T2"].ToString()) + 
                        int.Parse(resultPDS.Rows[0]["TPC1"].ToString()) + int.Parse(resultPDS.Rows[0]["TPC2"].ToString()) + 
                        int.Parse(resultPDS.Rows[0]["TL1"].ToString()) + int.Parse(resultPDS.Rows[0]["TL2"].ToString());
                    ValoresNaCadeiraEspecial(acmPDS, resultPDS, 200, 1340);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLREDESIP = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TI1 , EXAME1, EXAME2
                            FROM TbREDESIP ";
                    DataTable resultREDESIP;
                    resultREDESIP = classecon.ExecuteConsult(SQLREDESIP);
                    acmREDESIP = int.Parse(resultREDESIP.Rows[0]["MT1"].ToString()) + int.Parse(resultREDESIP.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultREDESIP.Rows[0]["T1"].ToString()) + int.Parse(resultREDESIP.Rows[0]["T2"].ToString()) +
                        int.Parse(resultREDESIP.Rows[0]["TL1"].ToString()) + int.Parse(resultREDESIP.Rows[0]["TL2"].ToString()) +
                        int.Parse(resultREDESIP.Rows[0]["TI1"].ToString());
                    ValoresNaCadeira(acmREDESIP, resultREDESIP, 170, 940);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLSISCOM2 = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TPC1, TPC2, EXAME1, EXAME2
                            FROM TbSISCOM2 ";
                    DataTable resultSISCOM2;
                    resultSISCOM2 = classecon.ExecuteConsult(SQLSISCOM2);
                    acmSISCOM2 = int.Parse(resultSISCOM2.Rows[0]["MT1"].ToString()) + int.Parse(resultSISCOM2.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultSISCOM2.Rows[0]["T1"].ToString()) + int.Parse(resultSISCOM2.Rows[0]["T2"].ToString()) +
                        int.Parse(resultSISCOM2.Rows[0]["TL1"].ToString()) + int.Parse(resultSISCOM2.Rows[0]["TL2"].ToString()) +
                         int.Parse(resultSISCOM2.Rows[0]["TPC1"].ToString()) + int.Parse(resultSISCOM2.Rows[0]["TPC2"].ToString());
                    ValoresNaCadeira(acmSISCOM2, resultSISCOM2, 250, 1350);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string SQLSGBD = @"SELECT
                            MT1, MT2, MT3, T1, T2, TP1, TP2, EXAME1, EXAME2, EXAME3
                            FROM TbSGBD ";
                    DataTable resultSGBD;
                    resultSGBD = classecon.ExecuteConsult(SQLSGBD);
                    acmSGBD = int.Parse(resultSGBD.Rows[0]["MT1"].ToString()) + int.Parse(resultSGBD.Rows[0]["MT2"].ToString()) +
                        int.Parse(resultSGBD.Rows[0]["MT3"].ToString()) +
                        int.Parse(resultSGBD.Rows[0]["T1"].ToString()) + int.Parse(resultSGBD.Rows[0]["T2"].ToString()) +
                         int.Parse(resultSGBD.Rows[0]["TP1"].ToString()) + int.Parse(resultSGBD.Rows[0]["TP2"].ToString());
                    ValoresNaCadeiraEspecial(acmSGBD, resultSGBD, 300, 1800);
                }
                break;
            } while (controlador2 < 1);
            aprovadas2Sem = contP2Sem;
            reprovadas2Sem = contN2Sem;
        }

        private void LimpaValores()
        {
            if (cbSemestre.SelectedItem.Equals("I SEMESTRE"))
            {
                tbCadeirasAprovadas.Text = aprovadas1Sem.ToString();
                tbCadeirasReprovadas.Text = reprovadas1Sem.ToString();
            }
            else if (cbSemestre.SelectedItem.Equals("II SEMESTRE"))
            {
                tbCadeirasAprovadas.Text = aprovadas2Sem.ToString();
                tbCadeirasReprovadas.Text = reprovadas2Sem.ToString();
            }
            else
            {
                tbCadeirasAprovadas.Text = "";
                tbCadeirasReprovadas.Text = "";
            }
            tbMaxPontos.Text = "";
            tbNotaPrecisada.Text = "";
            tbUltimoExame.Text = "";
            tbNotaMaxima.Text = "";
            lbNotaAcumuladaView.Text = "";
            lbStatusView.Text = "";
            tbNotaMinima.Text = "";
            tbChancesPassar.Text = "";
            tbChancesReprovar.Text = "";
        }

        private void AtribuirValores()
        {
            cbSemestre.DataSource = semestre;
            cbCadeiras.DataSource = opcao;
            tbCadeirasAprovadas.Text = "";
            tbCadeirasReprovadas.Text = "";
        }

        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSemestre.SelectedItem.Equals("I SEMESTRE"))
            {
                LimpaValores();
                AprovadosReprovados1Sem();
                cbCadeiras.DataSource = cadeiras1;
            }
            else if (cbSemestre.SelectedItem.Equals("II SEMESTRE"))
            {
                LimpaValores();
                AprovadosReprovados2Sem();
                cbCadeiras.DataSource = cadeiras2;
            }
            else
            {
                cbCadeiras.DataSource = opcao;
            }
        }

        private void cbCadeiras_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSemestre_SelectedIndexChanged(sender, e);
            try
            {
                if (cbCadeiras.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
                {
                    LimpaValores();
                    OeracoesAEDA();
                }
                else if (cbCadeiras.SelectedItem.Equals("Instrumentação e Medida"))
                {
                    LimpaValores();
                    OeracoesIMED();
                }
                else if (cbCadeiras.SelectedItem.Equals("Processamento Analógico de Sinais"))
                {
                    LimpaValores();
                    OeracoesPRAS();
                }
                else if (cbCadeiras.SelectedItem.Equals("Programação para Dispositivos Móveis"))
                {
                    LimpaValores();
                    OeracoesPRDM();
                }
                else if (cbCadeiras.SelectedItem.Equals("Radiação e Propagação"))
                {
                    LimpaValores();
                    OeracoesRADP();
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação I"))
                {
                    LimpaValores();
                    OeracoesSISCOM1();
                }

                else if (cbCadeiras.SelectedItem.Equals("Aplicação e Serviços Internet"))
                {
                    LimpaValores();
                    OperacoesASI();
                }
                else if (cbCadeiras.SelectedItem.Equals("Antenas"))
                {
                    LimpaValores();
                    OperacoesANTENAS();
                }
                else if (cbCadeiras.SelectedItem.Equals("Processamento Digital de Sinais"))
                {
                    LimpaValores();
                    OperacoesPDS();
                }
                else if (cbCadeiras.SelectedItem.Equals("Redes IP"))
                {
                    LimpaValores();
                    OperacoesREDESIP();
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação II"))
                {
                    LimpaValores();
                    OperacoesSISCOM2();
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
                {
                    LimpaValores();
                    OperacoesSGBD();
                }
                else
                {
                    LimpaValores();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        
        }

        /// 1 Semestre
        private void OeracoesAEDA()
        {   
            string SQL = @"SELECT
                MT1, MT2, T1, T2, TP1, TP2, DIV1
                FROM TbAEDA ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                 int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                 int.Parse(result.Rows[0]["TP1"].ToString()) + int.Parse(result.Rows[0]["TP2"].ToString()) +
                 int.Parse(result.Rows[0]["DIV1"].ToString());
            Operacoes(acumulado, 1100, 550);
            BuscarAEDA();
        }
        private void OeracoesIMED()
        {
            string SQL = @"SELECT
                            MT1, MT2, MT3, MT4, MT5, T1, T2, TPC1, TPC2, TPC3, TG1, TG2
                            FROM TbIMED ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["MT3"].ToString()) + int.Parse(result.Rows[0]["MT4"].ToString()) +
                int.Parse(result.Rows[0]["MT5"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) +
                int.Parse(result.Rows[0]["TPC2"].ToString()) + int.Parse(result.Rows[0]["TPC3"].ToString()) +
                 int.Parse(result.Rows[0]["TG1"].ToString()) + int.Parse(result.Rows[0]["TG2"].ToString());
            Operacoes(acumulado, 900, 450);
            BuscarIMED();
        }
        private void OeracoesPRAS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2
                            FROM TbPRAS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString())+
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TPC2"].ToString()) +
                 int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString());
            Operacoes(acumulado, 840, 420);
            BuscarPRAS();
        }
        private void OeracoesPRDM()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TG1,  TI1, TI2, PROJ1
                            FROM TbPROG ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TG1"].ToString()) +
                 int.Parse(result.Rows[0]["TI1"].ToString()) + int.Parse(result.Rows[0]["TI2"].ToString())
                 + int.Parse(result.Rows[0]["PROJ1"].ToString());
            Operacoes(acumulado, 990, 495);
            BuscarPRDM();

        }
        private void OeracoesRADP()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, T3, MT3, TPC1, TP1
                            FROM TbRADP ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["MT3"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["T3"].ToString()) +
                 int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TP1"].ToString());
            Operacoes(acumulado, 1050, 525);
            BuscarRADP();

        }
        private void OeracoesSISCOM1()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TL3, TL4, TG1, TG2
                            FROM TbSISCOM1 ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString()) +
                 int.Parse(result.Rows[0]["TL3"].ToString()) + int.Parse(result.Rows[0]["TL4"].ToString()) +
                 int.Parse(result.Rows[0]["TG1"].ToString()) + int.Parse(result.Rows[0]["TG2"].ToString());
            Operacoes(acumulado, 1000, 500);
            BuscarSISCOM1();
        }
        private void BuscarAEDA() 
        {
            string SQL = @"SELECT
                MT1, MT2, T1, T2, TP1, TP2, DIV1, EXAME1, EXAME2
                FROM TbAEDA ";

            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                 int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                 int.Parse(result.Rows[0]["TP1"].ToString()) + int.Parse(result.Rows[0]["TP2"].ToString()) +
                 int.Parse(result.Rows[0]["DIV1"].ToString());
            lbNotaAcumuladaView.Text = acumulado.ToString();
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            VerificarValoresNaCadeira(200, acumulado, result, 300, 600, 1700, 1100, 300, exame1, exame2);
        }
        private void BuscarIMED()
        {
            string SQL = @"SELECT
                            MT1, MT2, MT3, MT4, MT5, T1, T2, TPC1, TPC2, TPC3, TG1, TG2, EXAME1,
                            EXAME2
                            FROM TbIMED ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["MT3"].ToString()) + int.Parse(result.Rows[0]["MT4"].ToString()) +
                int.Parse(result.Rows[0]["MT5"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) +
                int.Parse(result.Rows[0]["TPC2"].ToString()) + int.Parse(result.Rows[0]["TPC3"].ToString()) +
                 int.Parse(result.Rows[0]["TG1"].ToString()) + int.Parse(result.Rows[0]["TG2"].ToString());
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            VerificarValoresNaCadeira(100, acumulado, result, 250, 500, 1400, 900, 250, exame1, exame2);
        }
        private void BuscarPRAS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2, EXAME1,
                            EXAME2, EXAME3 
                            FROM TbPRAS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
               int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
               int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TPC2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString());
            lbNotaAcumuladaView.Text = acumulado.ToString();
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            VerificarValoresNaCadeiraEspecial(100, acumulado, result, 250, 500, 1340, 840, 250, exame1, exame2, exame3);
        }
        private void BuscarPRDM()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TG1,  TI1, TI2, PROJ1, EXAME1,
                            EXAME2 , EXAME3
                            FROM TbPROG ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TG1"].ToString()) +
                 int.Parse(result.Rows[0]["TI1"].ToString()) + int.Parse(result.Rows[0]["TI2"].ToString())
                 + int.Parse(result.Rows[0]["PROJ1"].ToString());
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString(); 
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            VerificarValoresNaCadeiraEspecial(100, acumulado, result, 250, 500, 1490, 990, 250, exame1, exame2, exame3);
        }
        private void BuscarRADP()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, T3, MT3, TPC1, TP1, EXAME1,
                            EXAME2, EXAME3
                            FROM TbRADP ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["MT3"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["T3"].ToString()) +
                 int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TP1"].ToString());
            VerificarValoresNaCadeiraEspecial(100, acumulado, result, 250, 500, 1550, 1050, 250, exame1, exame2, exame3);
        }
        private void BuscarSISCOM1()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TL3, TL4, TG1, TG2, EXAME1,
                            EXAME2
                            FROM TbSISCOM1 "; ;
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString()) +
                 int.Parse(result.Rows[0]["TL3"].ToString()) + int.Parse(result.Rows[0]["TL4"].ToString()) +
                 int.Parse(result.Rows[0]["TG1"].ToString()) + int.Parse(result.Rows[0]["TG2"].ToString());
            VerificarValoresNaCadeira(100, acumulado, result, 250, 500, 1500, 1000, 250, exame1, exame2);
        }

        /// 2 Semestre
        private void OperacoesANTENAS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, T3, TPC1, TP1
                            FROM TbANTENAS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);

            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) 
                + int.Parse(result.Rows[0]["T3"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) 
                + int.Parse(result.Rows[0]["TP1"].ToString());
            Operacoes(acumulado, 950, 475);
            BuscarANTENAS();
        }
        private void OperacoesASI()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TPC3, TPC4, PROJ
                            FROM TbASI ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) +
                 int.Parse(result.Rows[0]["TPC2"].ToString()) + int.Parse(result.Rows[0]["TPC3"].ToString()) + int.Parse(result.Rows[0]["TPC4"].ToString())
                 + int.Parse(result.Rows[0]["PROJ"].ToString());
            Operacoes(acumulado, 660, 330);
            BuscarASI();
        }
        private void OperacoesPDS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2
                            FROM TbPDS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) +
                 int.Parse(result.Rows[0]["TPC2"].ToString()) + int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString());
            Operacoes(acumulado, 800, 400);
            BuscarPDS();
        }
        private void OperacoesREDESIP()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TI1
                            FROM TbREDESIP ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString()) +
                 int.Parse(result.Rows[0]["TI1"].ToString());
            Operacoes(acumulado, 600, 300);
            BuscarREDESIP();
        }
        private void OperacoesSISCOM2()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TPC1, TPC2
                            FROM TbSISCOM2 ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString()) +
                 int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TPC2"].ToString());
            Operacoes(acumulado, 900, 450);
            BuscarSISCOM2();
        }
        private void OperacoesSGBD()
        {
            string SQL = @"SELECT
                            MT1, MT2, MT3, T1, T2, TP1, TP2
                            FROM TbSGBD ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) + int.Parse(result.Rows[0]["MT3"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                 int.Parse(result.Rows[0]["TP1"].ToString()) + int.Parse(result.Rows[0]["TP2"].ToString());
            Operacoes(acumulado, 1200, 600);
            BuscarSGBD();
        }


        private void BuscarANTENAS()
        {
            string SQL = @"SELECT
                MT1, MT2, T1, T2, T3, TP1, TPC1, EXAME1, EXAME2, EXAME3
                FROM TbANTENAS ";

            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            ///Acumulado
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                 int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["T3"].ToString()) +
                 int.Parse(result.Rows[0]["TP1"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString());
            lbNotaAcumuladaView.Text = acumulado.ToString();
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            VerificarValoresNaCadeiraEspecial(100, acumulado, result, 250, 500, 1450, 950, 250, exame1, exame2, exame3);
        }
        private void BuscarASI()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TPC3, TPC4, PROJ, EXAME1,
                            EXAME2, EXAME3
                            FROM TbASI ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) +
                 int.Parse(result.Rows[0]["TPC2"].ToString()) + int.Parse(result.Rows[0]["TPC3"].ToString()) + int.Parse(result.Rows[0]["TPC4"].ToString())
                 + int.Parse(result.Rows[0]["PROJ"].ToString());
            VerificarValoresNaCadeiraEspecial(100, acumulado, result, 200, 400, 1060, 660, 200, exame1, exame2, exame3);
        }
        private void BuscarPDS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2, EXAME1,
                            EXAME2, EXAME3
                            FROM TbPDS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) + int.Parse(result.Rows[0]["TPC1"].ToString()) +
                 int.Parse(result.Rows[0]["TPC2"].ToString()) + int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString());
            VerificarValoresNaCadeiraEspecial(120, acumulado, result, 250, 500, 1340, 840, 250, exame1, exame2, exame3);
        }
        private void BuscarREDESIP()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TI1, EXAME1,
                            EXAME2
                            FROM TbREDESIP ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString()) +
                 int.Parse(result.Rows[0]["TI1"].ToString());
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            VerificarValoresNaCadeira(100, acumulado, result, 170, 340, 940, 600, 170, exame1, exame2);
        }
        private void BuscarSISCOM2()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TPC1, TPC2, EXAME1,
                            EXAME2
                            FROM TbSISCOM2 ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["T1"].ToString()) + int.Parse(result.Rows[0]["T2"].ToString()) +
                int.Parse(result.Rows[0]["TL1"].ToString()) + int.Parse(result.Rows[0]["TL2"].ToString()) +
                 int.Parse(result.Rows[0]["TPC1"].ToString()) + int.Parse(result.Rows[0]["TPC2"].ToString());
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            VerificarValoresNaCadeira(100, acumulado, result, 225, 450, 1350, 900, 225, exame1, exame2);
        }
        private void BuscarSGBD()
        {
            string SQL = @"SELECT
                            MT1, MT2, MT3, T1, T2, TP1, TP2, EXAME1,
                            EXAME2, EXAME3
                            FROM TbSGBD ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            string exame1 = result.Rows[0]["EXAME1"].ToString();
            string exame2 = result.Rows[0]["EXAME2"].ToString();
            string exame3 = result.Rows[0]["EXAME3"].ToString();
            acumulado = int.Parse(result.Rows[0]["MT1"].ToString()) + int.Parse(result.Rows[0]["MT2"].ToString()) +
                int.Parse(result.Rows[0]["MT3"].ToString()) + int.Parse(result.Rows[0]["T1"].ToString()) +
                int.Parse(result.Rows[0]["T2"].ToString()) +  int.Parse(result.Rows[0]["TP1"].ToString()) + int.Parse(result.Rows[0]["TP2"].ToString());
            VerificarValoresNaCadeiraEspecial(120, acumulado, result, 300, 600, 1800, 1200, 300, exame1, exame2, exame3);
        }

        ///Operacoes
        private void Operacoes(double acumulado, int notaMax, int metadeProvisoria)
        {
            lbNotaAcumuladaView.Text = acumulado.ToString();

            if (acumulado >= metadeProvisoria)
            {
                lbNotaAcumuladaView.ForeColor = Color.DarkGreen;
            }
            else
            {
                lbNotaAcumuladaView.ForeColor = Color.Red;
            }
            tbMaxPontos.Text = notaMax.ToString();

            chancesPassar = Math.Round((double)acumulado / notaMax * 100);
            tbChancesPassar.Text = chancesPassar.ToString() + "%";
            chancesReprovar = 100 - chancesPassar;
            tbChancesReprovar.Text = chancesReprovar.ToString() + "%";
        }

        /// Busca o total de aprovacoes ou reprovacoes nas cadeiras
        private void ValoresNaCadeira(int acumulado, DataTable resultado, int metadeNota, int notaMaxima)
        {
            if (cbSemestre.SelectedItem.Equals("I SEMESTRE"))
            {
                if (resultado.Rows[0]["EXAME1"].ToString().Equals("-1") || resultado.Rows[0]["EXAME2"].ToString().Equals("-1"))
                {
                    contN1Sem += 1;
                }
                else if (int.Parse(resultado.Rows[0]["EXAME2"].ToString()) < metadeNota & int.Parse(resultado.Rows[0]["EXAME2"].ToString()) != 0)
                {
                    contN1Sem += 1;
                }
                else if (
                    (((int.Parse(resultado.Rows[0]["EXAME1"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME1"].ToString()) >= metadeNota)
                    || ((int.Parse(resultado.Rows[0]["EXAME2"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME2"].ToString()) >= metadeNota
                    )
                {
                    contP1Sem += 1;
                }
            }
            else if (cbSemestre.SelectedItem.Equals("II SEMESTRE"))
            {
                if (resultado.Rows[0]["EXAME1"].ToString().Equals("-1") || resultado.Rows[0]["EXAME2"].ToString().Equals("-1"))
                {
                    contN2Sem += 1;
                }
                else if (int.Parse(resultado.Rows[0]["EXAME2"].ToString()) < metadeNota & int.Parse(resultado.Rows[0]["EXAME2"].ToString()) != 0)
                {
                    contN2Sem += 1;
                }
                else if (
                    (((int.Parse(resultado.Rows[0]["EXAME1"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME1"].ToString()) >= metadeNota)
                    || ((int.Parse(resultado.Rows[0]["EXAME2"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME2"].ToString()) >= metadeNota
                    )
                {
                    contP2Sem += 1;
                }
            }
        }
        
        /// Busca o total de aprovacoes ou reprovacoes nas cadeiras(Caso de cadeiras especiais)
        private void ValoresNaCadeiraEspecial(int acumulado, DataTable resultado, int metadeNota, int notaMaxima)
        {
            if (cbSemestre.SelectedItem.Equals("I SEMESTRE"))
            {
                if (resultado.Rows[0]["EXAME1"].ToString().Equals("-1") || resultado.Rows[0]["EXAME2"].ToString().Equals("-1") || resultado.Rows[0]["EXAME3"].ToString().Equals("-1"))
                {
                    contN1Sem += 1;
                }
                else if (int.Parse(resultado.Rows[0]["EXAME3"].ToString()) < metadeNota & int.Parse(resultado.Rows[0]["EXAME3"].ToString()) != 0)
                {
                    contN1Sem += 1;
                }
                else if (
                    (((int.Parse(resultado.Rows[0]["EXAME1"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME1"].ToString()) >= metadeNota)
                    || (((int.Parse(resultado.Rows[0]["EXAME2"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME2"].ToString()) >= metadeNota)
                    || (((int.Parse(resultado.Rows[0]["EXAME3"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME3"].ToString()) >= metadeNota)
                    )
                {
                    contP1Sem += 1;
                }
            }
            else if (cbSemestre.SelectedItem.Equals("II SEMESTRE"))
            {
                if (resultado.Rows[0]["EXAME1"].ToString().Equals("-1") || resultado.Rows[0]["EXAME2"].ToString().Equals("-1") || resultado.Rows[0]["EXAME3"].ToString().Equals("-1"))
                {
                    contN2Sem += 1;
                }
                else if (int.Parse(resultado.Rows[0]["EXAME3"].ToString()) < metadeNota & int.Parse(resultado.Rows[0]["EXAME3"].ToString()) != 0)
                {
                    contN2Sem += 1;
                }
                else if (
                    (((int.Parse(resultado.Rows[0]["EXAME1"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME1"].ToString()) >= metadeNota)
                    || (((int.Parse(resultado.Rows[0]["EXAME2"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME2"].ToString()) >= metadeNota)
                    || (((int.Parse(resultado.Rows[0]["EXAME3"].ToString()) + acumulado) * 20 / notaMaxima) >= 9.5 & int.Parse(resultado.Rows[0]["EXAME3"].ToString()) >= metadeNota)
                    )
                {
                    contP2Sem += 1;
                }
            }
        }

        /// Busca a nota do ultimo exame realizado e estado da cadeira selecionada 
        private void VerificarValoresNaCadeira(double val, double acumulado, DataTable res, int metadeNota, int notaMaxExame, int totalCadeira, int provMaxima, int nec, string exm1, string exm2)
        {
            if (!exm1.Equals("0"))
            {
                if (exm1.Equals("-1"))
                {
                    exm1.Equals(res.Rows[0]["EXAME1"].ToString());
                    tbUltimoExame.Text = exm1;
                }
                else
                {
                    if (int.Parse(exm1.ToString()) >= metadeNota & int.Parse(exm1.ToString()) <= notaMaxExame)
                    {
                        exm1.Equals(res.Rows[0]["EXAME1"].ToString());
                        tbUltimoExame.Text = exm1;
                    }
                    else if (int.Parse(exm1.ToString()) < metadeNota & (int.Parse(exm2.ToString()) == 0))
                    {
                        exm1.Equals(res.Rows[0]["EXAME1"].ToString());
                        tbUltimoExame.Text = exm1;
                    }
                    else if (int.Parse(exm1.ToString()) < metadeNota & (int.Parse(exm2.ToString()) != 0))
                    {
                        if (exm2.Equals("-1"))
                        {
                            exm2.Equals(res.Rows[0]["EXAME2"].ToString());
                            tbUltimoExame.Text = exm2;
                        }
                        else
                        {
                            exm2.Equals(res.Rows[0]["EXAME2"].ToString());
                            tbUltimoExame.Text = exm2;
                        }
                    }
                }
            }
            else
            {
                tbUltimoExame.Text = "0";
            }
            valorExame = int.Parse(tbUltimoExame.Text);

            val = 20 - Math.Round(acumulado * 20 / provMaxima);

            if (Math.Round(acumulado * 20 / provMaxima) >= 5 & Math.Round(acumulado * 20 / provMaxima) < 10)
            {
                tbNotaMinima.Text = val.ToString();
                tbNotaPrecisada.Text = (20 + val * notaMaxExame / 20).ToString() + " a " + ((20 + val * notaMaxExame / 20) + val + 5).ToString();
                /// tbNotaPrecisada.Text =  ((val * notaMaxExame / 20) + val + 20).ToString();

            }
            else if (Math.Round(acumulado * 20 / provMaxima) >= 10)
            {
                tbNotaPrecisada.Text = nec.ToString();
                tbNotaMinima.Text = (nec * 20 / notaMaxExame).ToString();
            }
            else
            {
                tbNotaPrecisada.Text = "Impossível aprovar!";
                tbNotaMinima.Text = "Impossível aprovar!";
            }


            if (((valorExame + acumulado) * 20 / totalCadeira) >= 9.5 & (valorExame >= metadeNota) & valorExame != 0)
            {
                lbStatusView.ForeColor = Color.DarkGreen;
                lbStatusView.Text = "Aprovado:" + Math.Round((valorExame + acumulado) * 20 / totalCadeira);

            }
            else if (valorExame == 0)
            {
                lbStatusView.ForeColor = Color.GreenYellow;
                lbStatusView.Text = "Pendente";
            }
            else
            {
                lbStatusView.ForeColor = Color.Red;
                lbStatusView.Text = "Reprovado";
            }

            tbNotaMaxima.Text = (Math.Round((notaMaxExame + acumulado) * 20 / totalCadeira)).ToString();
        }

        /// Busca a nota do ultimo exame realizado e estado da cadeira selecionada (Caso de cadeiras especiais)
        private void VerificarValoresNaCadeiraEspecial(double val, double acumulado, DataTable res, int metadeNota, int notaMaxExame, int totalCadeira, int provMaxima, int nec, string exm1, string exm2, string exm3)
        {
            if (!exm1.Equals("0"))
            {
                if (exm1.Equals("-1"))
                {
                    exm1.Equals(res.Rows[0]["EXAME1"].ToString());
                    tbUltimoExame.Text = exm1;
                }
                else
                {
                    if (int.Parse(exm1.ToString()) >= metadeNota & int.Parse(exm1.ToString()) <= notaMaxExame)
                    {
                        exm1.Equals(res.Rows[0]["EXAME1"].ToString());
                        tbUltimoExame.Text = exm1;
                    }
                    else if (int.Parse(exm1.ToString()) < metadeNota & (int.Parse(exm2.ToString()) == 0))
                    {
                        exm1.Equals(res.Rows[0]["EXAME1"].ToString());
                        tbUltimoExame.Text = exm1;
                    }
                    else if (int.Parse(exm1.ToString()) < metadeNota & (int.Parse(exm2.ToString()) != 0))
                    {
                        if (exm2.Equals("-1"))
                        {
                            exm2.Equals(res.Rows[0]["EXAME2"].ToString());
                            tbUltimoExame.Text = exm2;
                        }
                        else
                        {
                            if (int.Parse(exm2.ToString()) >= metadeNota & int.Parse(exm2.ToString()) <= notaMaxExame)
                            {
                                exm2.Equals(res.Rows[0]["EXAME2"].ToString());
                                tbUltimoExame.Text = exm2;
                            }
                            else if (int.Parse(exm2.ToString()) < metadeNota & (int.Parse(exm3.ToString()) == 0))
                            {
                                exm2.Equals(res.Rows[0]["EXAME2"].ToString());
                                tbUltimoExame.Text = exm2;
                            }
                            else if (int.Parse(exm2.ToString()) < metadeNota & (int.Parse(exm3.ToString()) != 0))
                            {
                                exm3.Equals(res.Rows[0]["EXAME3"].ToString());
                                tbUltimoExame.Text = exm3;
                                if ((int.Parse(exm3.ToString()) >= metadeNota & int.Parse(exm3.ToString()) <= notaMaxExame) || int.Parse(exm2.ToString()) < metadeNota
                                    || exm3.Equals("-1")
                                    )
                                {
                                    tbUltimoExame.Text = exm3;
                                }
                            
                            }
                        }
                    }
                }
            }
            else 
            { 
                tbUltimoExame.Text = "0";
            }
            valorExame = int.Parse(tbUltimoExame.Text);

            val = 20 - Math.Round(acumulado * 20 / provMaxima);

            if (Math.Round(acumulado * 20 / provMaxima) >= 4 & Math.Round(acumulado * 20 / provMaxima) < 10)
            {
                tbNotaMinima.Text = val.ToString();
                tbNotaPrecisada.Text = (20 + val * notaMaxExame / 20).ToString() + " a " + ((20 + val * notaMaxExame / 20) + val + 5).ToString();
                /// tbNotaPrecisada.Text =  ((val * notaMaxExame / 20) + val + 20).ToString();

            }
            else if (Math.Round(acumulado * 20 / provMaxima) >= 10)
            {
                tbNotaPrecisada.Text = nec.ToString();
                tbNotaMinima.Text = (nec * 20 / notaMaxExame).ToString();
            }
            else
            {
                tbNotaPrecisada.Text = "Impossível aprovar!";
                tbNotaMinima.Text = "Impossível aprovar!";
            }


            if (((valorExame + acumulado) * 20 / totalCadeira) >= 9.5 & (valorExame >= metadeNota) & valorExame != 0)
            {
                lbStatusView.ForeColor = Color.DarkGreen;
                lbStatusView.Text = "Aprovado:" + Math.Round((valorExame + acumulado) * 20 / totalCadeira);

            }
            else if (valorExame == 0)
            {
                lbStatusView.ForeColor = Color.GreenYellow;
                lbStatusView.Text = "Pendente";
            }
            else
            {
                lbStatusView.ForeColor = Color.Red;
                lbStatusView.Text = "Reprovado";
            }
            tbNotaMaxima.Text = (Math.Round((notaMaxExame + acumulado) * 20 / totalCadeira)).ToString();
        }
    }
}