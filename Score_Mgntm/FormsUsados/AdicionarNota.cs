using Connection_Class;
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Score_Mgntm.FormsUsados
{
    public partial class AdicionarNotaForm : Form
    {
        readonly ClasseConexao classecon = new ClasseConexao();
        readonly int valor = 0;
        ///Valores
        private string[] opcao = new string[] { "Escolha uma opção:" };
        private string[] cadeiras1 = new string[] { "Escolha uma opção:", "Algorítmos e Estruturas de Dados", "Instrumentação e Medida"
                , "Processamento Analógico de Sinais", "Programação para Dispositivos Móveis", "Radiação e Propagação", "Sistemas de Comunicação I" };
        private string[] cadeiras2 = new string[] { "Escolha uma opção:", "Aplicação e Serviços Internet", "Antenas"
                , "Processamento Digital de Sinais", "Redes IP", "Sistemas de Comunicação II", "Sistemas de Gestão de Base de Dados" };
        private string[] turmas = new string[] { "Escolha uma opção:", "LEIT 31", "LEIT 32", "LEIT 33" };
        private string[] semestre = new string[] { "Escolha uma opção:", "I SEMESTRE", "II SEMESTRE" };
        private string[] ano = new string[] { "Escolha uma opção:", "3º Ano" };

        public AdicionarNotaForm()
        {
            InitializeComponent();
            AtribuirValores();
            EsconderValores();
        }

        /// Metodos das minhas accoes
        private void AtribuirValores()
        {
            cbSemestre.DataSource = semestre;
            cbAno.DataSource = opcao;
            cbTurmas.DataSource = opcao;
            cbCadeiras.DataSource = opcao;
        }
        private void AtivarCampos()
        {
            tbDIV1.Enabled = true;
            tbDIV2.Enabled = true;
            tbDIV3.Enabled = true;
            tbDIV4.Enabled = true;
            tbExame1.Enabled = true;
            tbExame2.Enabled = true;
            tbMT1.Enabled = true;
            tbMT2.Enabled = true;
            tbMT3.Enabled = true;
            tbMT4.Enabled = true;
            tbMT5.Enabled = true;
            tbT1.Enabled = true;
            tbT2.Enabled = true;
            tbT3.Enabled = true;
            tbT4.Enabled = true;
            tbTP1.Enabled = true;
            tbTP3.Enabled = true;
            tbTP4.Enabled = true;
            tbTP2.Enabled = true;
            tbTL1.Enabled = true;
            tbTL2.Enabled = true;
            tbTL3.Enabled = true;
            tbTL4.Enabled = true;
            tbTI1.Enabled = true;
            tbTI2.Enabled = true;
            tbTI3.Enabled = true;
            tbTI4.Enabled = true;
            tbTG1.Enabled = true;
            tbTG2.Enabled = true;
            tbTG3.Enabled = true;
            tbTG4.Enabled = true;
            tbTPC1.Enabled = true;
            tbTPC2.Enabled = true;
            tbTPC3.Enabled = true;
            tbTPC4.Enabled = true;
            tbTP1.Enabled = true;
            tbTP2.Enabled = true;
            tbTP3.Enabled = true;
            tbTP4.Enabled = true;
            tbProj1.Enabled = true;
            tbProj2.Enabled = true;
            tbProj3.Enabled = true;
        }
        private void LimpaMaximos()
        {
            lbMaxDIV.Text = "";
            lbMaxExame.Text = "";
            lbMaxMT.Text = "";
            lbMaxProj.Text = "";
            lbMaxT.Text = "";
            lbMaxTI.Text = "";
            lbMaxTL.Text = "";
            lbMaxTP.Text = "";
            lbMaxTPC.Text = "";
            lbMaxTG.Text = "";
            tbNotas020.Text = "";
            lbPontosAcumulados.Text = "";
            lbMediaMaximaCadeira.Text = "";
            lbMaxExame.Text = "";
        }
        private void EsconderValores()
        {
            tbDIV1.Visible = false;
            tbDIV2.Visible = false;
            tbDIV3.Visible = false;
            tbDIV4.Visible = false;

            tbT1.Visible = false;
            tbT2.Visible = false;
            tbT3.Visible = false;
            tbT4.Visible = false;

            tbTG1.Visible = false;
            tbTG2.Visible = false;
            tbTG3.Visible = false;
            tbTG4.Visible = false;

            tbTP1.Visible = false;
            tbTP2.Visible = false;
            tbTP3.Visible = false;
            tbTP4.Visible = false;

            tbTPC1.Visible = false;
            tbTPC2.Visible = false;
            tbTPC3.Visible = false;
            tbTPC4.Visible = false;

            tbMT1.Visible = false;
            tbMT2.Visible = false;
            tbMT3.Visible = false;
            tbMT4.Visible = false;
            tbMT5.Visible = false;

            tbProj1.Visible = false;
            tbProj2.Visible = false;
            tbProj3.Visible = false;

            tbTI1.Visible = false;
            tbTI2.Visible = false;
            tbTI3.Visible = false;
            tbTI4.Visible = false;

            tbTL1.Visible = false;
            tbTL2.Visible = false;
            tbTL3.Visible = false;
            tbTL4.Visible = false;

            tbExame1.Visible = false;
            tbExame2.Visible = false;
            tbExame3.Visible = false;
        }
        private void Provisoria()
        {
            double provisoriaNormal;
            try
            {
                /// 1 Semestre
                if (cbCadeiras.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
                {
                    provisoriaNormal = double.Parse(tbDIV1.Text)
                                + double.Parse(tbMT1.Text)
                                    + double.Parse(tbMT2.Text)
                                    + double.Parse(tbT1.Text)
                                    + double.Parse(tbT2.Text)
                                    + double.Parse(tbTP1.Text)
                                    + double.Parse(tbTP2.Text);
                    ContasEstatisticas(provisoriaNormal, 1100);
                }
                else if (cbCadeiras.SelectedItem.Equals("Instrumentação e Medida"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text) + double.Parse(tbMT2.Text) + double.Parse(tbMT3.Text)
                                + double.Parse(tbMT4.Text) + double.Parse(tbT1.Text) + double.Parse(tbMT5.Text)
                                + double.Parse(tbT2.Text) + double.Parse(tbTPC1.Text) + double.Parse(tbTPC2.Text)
                                 + double.Parse(tbTPC3.Text) + double.Parse(tbTG1.Text) + double.Parse(tbTG2.Text);
                    ContasEstatisticas(provisoriaNormal, 900);
                }
                else if (cbCadeiras.SelectedItem.Equals("Processamento Analógico de Sinais"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text) + double.Parse(tbMT2.Text) + double.Parse(tbT1.Text)
                                + double.Parse(tbT2.Text) + double.Parse(tbTPC1.Text) +
                                double.Parse(tbTPC2.Text) + double.Parse(tbTL1.Text) + double.Parse(tbTL2.Text);
                    ContasEstatisticas(provisoriaNormal, 840);
                }
                else if (cbCadeiras.SelectedItem.Equals("Programação para Dispositivos Móveis"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text) + double.Parse(tbMT2.Text) + double.Parse(tbT1.Text)
                                + double.Parse(tbT2.Text) + double.Parse(tbTI1.Text) + double.Parse(tbProj1.Text) +
                                double.Parse(tbTI2.Text) + double.Parse(tbTG1.Text) + double.Parse(tbTPC1.Text);
                    ContasEstatisticas(provisoriaNormal, 990);
                }
                else if (cbCadeiras.SelectedItem.Equals("Radiação e Propagação"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text) + double.Parse(tbMT2.Text) + double.Parse(tbT1.Text)
                                 + double.Parse(tbT2.Text) + double.Parse(tbMT3.Text) + double.Parse(tbT3.Text) + double.Parse(tbTP1.Text)
                                 + double.Parse(tbTPC1.Text);
                    ContasEstatisticas(provisoriaNormal, 1050);
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação I"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text) + double.Parse(tbMT2.Text) + double.Parse(tbT1.Text)
                                + double.Parse(tbT2.Text) + double.Parse(tbTL1.Text) + double.Parse(tbTL2.Text)
                                + double.Parse(tbTL3.Text) + double.Parse(tbTL4.Text)
                                + double.Parse(tbTG1.Text) + double.Parse(tbTG2.Text);
                    ContasEstatisticas(provisoriaNormal, 1000);
                }

                /// 2 Semestre
                else if (cbCadeiras.SelectedItem.Equals("Aplicação e Serviços Internet"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text)
                                      + double.Parse(tbMT2.Text)
                                      + double.Parse(tbT1.Text)
                                      + double.Parse(tbT2.Text)
                                      + double.Parse(tbTPC1.Text)
                                      + double.Parse(tbTPC2.Text)
                                      + double.Parse(tbTPC3.Text)
                                      + double.Parse(tbTPC4.Text)
                                      + double.Parse(tbProj1.Text);
                    ContasEstatisticas(provisoriaNormal, 660);
                }
                else if (cbCadeiras.SelectedItem.Equals("Antenas"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text)
                                      + double.Parse(tbMT2.Text)
                                      + double.Parse(tbT1.Text)
                                      + double.Parse(tbT2.Text)
                                      + double.Parse(tbT3.Text)
                                      + double.Parse(tbTPC1.Text)
                                      + double.Parse(tbTP1.Text);
                    ContasEstatisticas(provisoriaNormal, 950);
                }
                else if (cbCadeiras.SelectedItem.Equals("Processamento Digital de Sinais"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text)
                                      + double.Parse(tbMT2.Text)
                                      + double.Parse(tbT1.Text)
                                      + double.Parse(tbT2.Text)
                                      + double.Parse(tbTPC1.Text)
                                      + double.Parse(tbTPC2.Text)
                                      + double.Parse(tbTL1.Text)
                                      + double.Parse(tbTL2.Text);
                    ContasEstatisticas(provisoriaNormal, 840);
                }
                else if (cbCadeiras.SelectedItem.Equals("Redes IP"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text)
                                       + double.Parse(tbMT2.Text)
                                       + double.Parse(tbT1.Text)
                                       + double.Parse(tbT2.Text)
                                       + double.Parse(tbTL1.Text)
                                       + double.Parse(tbTL2.Text) 
                                       + double.Parse(tbTI1.Text);
                    ContasEstatisticas(provisoriaNormal, 600);
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação II"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text)
                                       + double.Parse(tbMT2.Text)
                                       + double.Parse(tbT1.Text)
                                       + double.Parse(tbT2.Text)
                                       + double.Parse(tbTL1.Text)
                                       + double.Parse(tbTL2.Text)
                                       + double.Parse(tbTPC1.Text)
                                       + double.Parse(tbTPC2.Text);
                    ContasEstatisticas(provisoriaNormal, 900);
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
                {
                    provisoriaNormal = double.Parse(tbMT1.Text)
                                       + double.Parse(tbMT2.Text)
                                       + double.Parse(tbMT3.Text)
                                       + double.Parse(tbT1.Text)
                                       + double.Parse(tbT2.Text)
                                       + double.Parse(tbTP1.Text)
                                       + double.Parse(tbTP2.Text);
                    ContasEstatisticas(provisoriaNormal, 1200);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Erro no formato inserido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidaCampos(int valor1, int valor2)
        {
            tbExame2.Visible = false;
            tbExame3.Visible = false;
            if (!Verifica3Epoca())
            {
                if (tbExame1.Text.Equals("0") & tbExame2.Text.Equals("0"))
                {
                    tbExame1.Visible = true;
                    tbExame2.Visible = false;
                }
                else if (!tbExame1.Text.Equals("0") & tbExame2.Text.Equals("0"))
                {
                    tbExame1.Visible = true;
                    if (tbExame1.Text.Equals("-1"))
                    {
                        tbExame2.Visible = false;
                    }
                    else if (int.Parse(tbExame1.Text.ToString()) >= valor1 & int.Parse(tbExame1.Text.ToString()) <= valor2)
                    {
                        tbExame2.Visible = false;
                    }
                    else
                    {
                        if (int.Parse(tbExame1.Text.ToString()) < valor1 & (int.Parse(tbExame2.Text.ToString()) == 0))
                        {
                            tbExame2.Visible = true;
                        }
                    }
                }
                else
                {
                    tbExame1.Visible = true;
                    tbExame2.Visible = true;
                }
            }
            else
            {
                if (tbExame1.Text.Equals("0") & tbExame2.Text.Equals("0"))
                {
                    tbExame1.Visible = true;
                    tbExame2.Visible = false;
                }
                else if (!tbExame1.Text.Equals("0") & tbExame2.Text.Equals("0"))
                {
                    tbExame1.Visible = true;
                    if (tbExame1.Text.Equals("-1") || (int.Parse(tbExame1.Text.ToString()) >= valor1 & int.Parse(tbExame1.Text.ToString()) <= valor2))
                    {
                        tbExame2.Visible = false;
                    }
                    else
                    {
                        tbExame2.Visible = true;
                        if (!tbExame2.Text.Equals("0") & !tbExame2.Text.Equals("-1") & int.Parse(tbExame2.Text.ToString()) < valor1)
                            tbExame3.Visible = true;
                        else
                            tbExame3.Visible = false;
                    }
                }
                else if (!tbExame2.Text.Equals("0") & !tbExame2.Text.Equals("-1") & int.Parse(tbExame2.Text.ToString()) < valor1)
                {
                    tbExame1.Visible = true;
                    tbExame2.Visible = true;
                    tbExame3.Visible = true;
                }
                else
                {
                    tbExame1.Visible = true;
                    tbExame2.Visible = true;
                }
            }

        }
        private void TrancaAvaliacoes() ///Tranca as avaliacoes apos um campo de exame ser mexido
        {
            if (!tbExame1.Text.Equals("0"))
            {
                tbMT1.Enabled = tbMT2.Enabled = tbMT3.Enabled = tbMT4.Enabled = tbMT5.Enabled = false;
                tbT1.Enabled = tbT2.Enabled = tbT3.Enabled = tbT4.Enabled = false;
                tbTP1.Enabled = tbTP2.Enabled = tbTP3.Enabled = tbTP4.Enabled = false;
                tbTPC1.Enabled = tbTPC2.Enabled = tbTPC3.Enabled = tbTPC4.Enabled = false;
                tbTI1.Enabled = tbTI2.Enabled = tbTI3.Enabled = tbTI4.Enabled = false;
                tbTL1.Enabled = tbTL2.Enabled = tbTL3.Enabled = tbTL4.Enabled = false;
                tbTG1.Enabled = tbTG2.Enabled = tbTG3.Enabled = tbTG4.Enabled = false;
                tbDIV1.Enabled = tbDIV2.Enabled = tbDIV3.Enabled = tbDIV4.Enabled = false;
                tbProj1.Enabled = tbProj2.Enabled = tbProj3.Enabled = false;

            }
        }
        private void EstadoCadeira(int metadeNotaExame, int maxNotaExame)  ///Estado das cadeiras 
        {
            if (!Verifica3Epoca())
            {
                if (!tbExame1.Text.Equals("0"))
                {
                    if (tbExame1.Text.Equals("-1"))
                    {
                        MessageBox.Show("Aluno reprovado por fraude na primeira chamada.", "Fraude", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbExame1.Enabled = false;
                        tbExame2.Enabled = false;
                    }
                    else
                    {
                        if (int.Parse(tbExame1.Text.ToString()) >= metadeNotaExame & int.Parse(tbExame1.Text.ToString()) <= maxNotaExame)
                        {
                            MessageBox.Show("Congrats! Passaste no exame da primeira chamada.", "Aprovado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbExame1.Enabled = false;
                            tbExame2.Enabled = false;
                        }
                        else if (int.Parse(tbExame1.Text.ToString()) < metadeNotaExame & tbExame2.Text.Equals("0"))
                        {
                            MessageBox.Show("Aluno reprovado no exame da primeira chamada.", "Nota Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbExame1.Enabled = false;
                        }
                        else if (int.Parse(tbExame1.Text.ToString()) < metadeNotaExame & !tbExame2.Text.Equals("0"))
                        {
                            tbExame1.Enabled = false;
                            if (tbExame2.Text.Equals("-1"))
                            {
                                tbExame2.Enabled = false;
                                MessageBox.Show("Aluno reprovado por fraude na segunda chamada.", "Fraude", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (int.Parse(tbExame2.Text.ToString()) >= metadeNotaExame & int.Parse(tbExame2.Text.ToString()) <= maxNotaExame)
                                {
                                    MessageBox.Show("Congrats! Passaste no exame da segunda chamada.", "Aprovado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tbExame2.Enabled = false;
                                }
                                else if (int.Parse(tbExame2.Text.ToString()) < metadeNotaExame & !tbExame2.Text.Equals("0"))
                                {
                                    MessageBox.Show("Foste reprovado no exame da segunda chamada.", "Nota Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tbExame2.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("A nota inserida está fora do itervalo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("A nota inserida está fora do itervalo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else
            {
                if (!tbExame1.Text.Equals("0"))
                {
                    if (tbExame1.Text.Equals("-1"))
                    {
                        MessageBox.Show("Aluno reprovado por fraude na primeira chamada.", "Fraude", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbExame1.Enabled = false;
                        tbExame2.Enabled = false;
                    }
                    else
                    {
                        if (int.Parse(tbExame1.Text.ToString()) >= metadeNotaExame & int.Parse(tbExame1.Text.ToString()) <= maxNotaExame)
                        {
                            MessageBox.Show("Congrats! Passaste no exame da primeira chamada.", "Aprovado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbExame1.Enabled = false;
                            tbExame2.Enabled = false;
                        }
                        else if (int.Parse(tbExame1.Text.ToString()) < metadeNotaExame & tbExame2.Text.Equals("0"))
                        {
                            MessageBox.Show("Aluno reprovado no exame da primeira chamada.", "Nota Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbExame1.Enabled = false;
                        }
                        else if (int.Parse(tbExame1.Text.ToString()) < metadeNotaExame & !tbExame2.Text.Equals("0"))
                        {
                            tbExame1.Enabled = false;
                            if (tbExame2.Text.Equals("-1"))
                            {
                                MessageBox.Show("Aluno reprovado por fraude na segunda chamada.", "Fraude", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tbExame2.Enabled = false;
                            }
                            else
                            {
                                if (int.Parse(tbExame2.Text.ToString()) >= metadeNotaExame & int.Parse(tbExame2.Text.ToString()) <= maxNotaExame)
                                {
                                    MessageBox.Show("Congrats! Passaste no exame da segunda chamada.", "Aprovado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tbExame2.Enabled = false;
                                }
                                else if (int.Parse(tbExame2.Text.ToString()) < metadeNotaExame & tbExame3.Text.Equals("0"))
                                {
                                    MessageBox.Show("Foste reprovado no exame da segunda chamada.", "Nota Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tbExame2.Enabled = false;
                                }
                                else if (int.Parse(tbExame2.Text.ToString()) < metadeNotaExame & !tbExame3.Text.Equals("0"))
                                {
                                    tbExame2.Enabled = false;
                                    tbExame3.Enabled = true;
                                    if (tbExame3.Text.Equals("-1"))
                                    {
                                        MessageBox.Show("Aluno reprovado por fraude na terceira chamada.", "Fraude", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        tbExame3.Enabled = false;
                                    }
                                    else
                                    {
                                        if (int.Parse(tbExame3.Text.ToString()) < metadeNotaExame & !tbExame3.Text.Equals("0"))
                                        {
                                            MessageBox.Show("Foste reprovado no exame da terceira chamada.", "Nota Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            tbExame3.Enabled = false;
                                        }
                                        else if (int.Parse(tbExame3.Text.ToString()) >= metadeNotaExame & int.Parse(tbExame3.Text.ToString()) <= maxNotaExame)
                                        {
                                            MessageBox.Show("Congrats! Passaste no exame da terceira chamada.", "Aprovado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            tbExame3.Enabled = false;
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("A nota inserida está fora do itervalo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("A nota inserida está fora do itervalo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void ContasEstatisticas(double provisoriaNormal, int totalAcmulado) ///Logica das medias acumuladas nas avaliacoes.
        {
            double inns, mediaProvisoria, valor, ope;

            ope = double.Parse(provisoriaNormal.ToString());
            mediaProvisoria = (ope * 20) / totalAcmulado;

            inns = Math.Round((mediaProvisoria - (int)mediaProvisoria) * 10);
            if (inns >= 5)
            {
                valor = (int)mediaProvisoria + 1;
            }
            else
            {
                valor = (int)mediaProvisoria;
            }

            if (valor >= 10)
            {
                tbNotas020.ForeColor = Color.Green;
            }
            else
            {
                tbNotas020.ForeColor = Color.Red;
            }
            tbNotas020.Text = valor.ToString();
            lbPontosAcumulados.Text = provisoriaNormal.ToString();

        }
        private bool Verifica3Epoca()
        {
            bool estado;

            if (cbCadeiras.SelectedItem.Equals("Processamento Analógico de Sinais")
                || cbCadeiras.SelectedItem.Equals("Programação para Dispositivos Móveis")
                || cbCadeiras.SelectedItem.Equals("Radiação e Propagação")
                || cbCadeiras.SelectedItem.Equals("Aplicação e Serviços Internet")
                || cbCadeiras.SelectedItem.Equals("Antenas") 
                || cbCadeiras.SelectedItem.Equals("Processamento Digital de Sinais")
                || cbCadeiras.SelectedItem.Equals("Sistemas de Gestão de Base de Dados")
                )
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            return estado;
        }

        ///Metodos das accoes do componetes
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
            try
            {
                /// 1Semestre
                if (cbCadeiras.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarAEDA();
                    ValidaCampos(300, 600);
                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTP1.Visible = true;
                    tbTP2.Visible = true;
                    tbDIV1.Visible = true;

                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTP1.MaxLength = 3;
                    tbTP2.MaxLength = 3;
                    tbDIV1.MaxLength = 3;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTP.Text = "150";
                    lbMaxDIV.Text = "200";
                    lbMaxExame.Text = "600";

                    lbMediaMaximaCadeira.Text = "1100";
                }
                else if (cbCadeiras.SelectedItem.Equals("Instrumentação e Medida"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarIMED();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "50";
                    lbMaxTPC.Text = "50";
                    lbMaxTG.Text = "50";

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbMT3.Visible = true;
                    tbMT4.Visible = true;
                    tbMT5.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTPC1.Visible = true;
                    tbTPC2.Visible = true;
                    tbTPC3.Visible = true;
                    tbTG1.Visible = true;
                    tbTG2.Visible = true;

                    tbMT1.MaxLength = 2;
                    tbMT2.MaxLength = 2;
                    tbMT3.MaxLength = 2;
                    tbMT4.MaxLength = 2;
                    tbMT5.MaxLength = 2;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTPC1.MaxLength = 2;
                    tbTPC2.MaxLength = 2;
                    tbTPC3.MaxLength = 2;
                    tbTG1.MaxLength = 2;
                    tbTG2.MaxLength = 2;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    lbMediaMaximaCadeira.Text = "900";
                    lbMaxExame.Text = "500";
                }
                else if (cbCadeiras.SelectedItem.Equals("Processamento Analógico de Sinais"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarPRAS();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTPC.Text = "50";
                    lbMaxTL.Text = "70";

                    lbMaxExame.Text = "500";

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTPC1.Visible = true;
                    tbTPC2.Visible = true;
                    tbTL1.Visible = true;
                    tbTL2.Visible = true;

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTPC1.MaxLength = 2;
                    tbTPC2.MaxLength = 2;
                    tbTL1.MaxLength = 2;
                    tbTL2.MaxLength = 2;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;
                    tbExame3.MaxLength = 3;

                    lbMediaMaximaCadeira.Text = "840";
                }
                else if (cbCadeiras.SelectedItem.Equals("Programação para Dispositivos Móveis"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarPRDM();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTPC.Text = "40";
                    lbMaxTI.Text = "50";
                    lbMaxTG.Text = "50";
                    lbMaxProj.Text = "200";

                    lbMaxExame.Text = "500";

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTI1.MaxLength = 2;
                    tbTI2.MaxLength = 2;
                    tbTG1.MaxLength = 2;
                    tbTPC1.MaxLength = 2;
                    tbProj1.MaxLength = 3;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;
                    tbExame3.MaxLength = 3;

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTI1.Visible = true;
                    tbTI2.Visible = true;
                    tbTG1.Visible = true;
                    tbTPC1.Visible = true;
                    tbProj1.Visible = true;

                    lbMediaMaximaCadeira.Text = "990";
                }
                else if (cbCadeiras.SelectedItem.Equals("Radiação e Propagação"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarRADP();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTPC.Text = "50";
                    lbMaxTP.Text = "100";

                    lbMaxExame.Text = "500";

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbMT3.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbT3.MaxLength = 3;
                    tbTPC1.MaxLength = 3;
                    tbTP1.MaxLength = 3;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;
                    tbExame3.MaxLength = 3;

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbMT3.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbT3.Visible = true;
                    tbTPC1.Visible = true;
                    tbTP1.Visible = true;

                    lbMediaMaximaCadeira.Text = "1050";
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação I"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarSISCOM1();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTL.Text = "75";
                    lbMaxTG.Text = "50";

                    lbMaxExame.Text = "500";

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTL1.MaxLength = 2;
                    tbTL2.MaxLength = 2;
                    tbTL3.MaxLength = 2;
                    tbTL4.MaxLength = 2;
                    tbTG1.MaxLength = 2;
                    tbTG2.MaxLength = 2;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTL1.Visible = true;
                    tbTL2.Visible = true;
                    tbTL3.Visible = true;
                    tbTL4.Visible = true;
                    tbTG1.Visible = true;
                    tbTG2.Visible = true;

                    lbMediaMaximaCadeira.Text = "1000";
                }

                /// 2 Semestre 
                else if (cbCadeiras.SelectedItem.Equals("Antenas"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarANTENA();
                    ValidaCampos(250, 500);

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbT3.Visible = true;
                    tbTP1.Visible = true;
                    tbTPC1.Visible = true;

                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbT3.MaxLength = 3;
                    tbTP1.MaxLength = 3;
                    tbTPC1.MaxLength = 2;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;
                    tbExame3.MaxLength = 3;

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTP.Text = "120";
                    lbMaxTPC.Text = "30";
                    lbMaxExame.Text = "500";

                    lbMediaMaximaCadeira.Text = "950";
                }
                else if (cbCadeiras.SelectedItem.Equals("Aplicação e Serviços Internet"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarASI();
                    ValidaCampos(200, 400);

                    lbMaxT.Text = "100";
                    lbMaxMT.Text = "50";
                    lbMaxTPC.Text = "40";
                    lbMaxProj.Text = "200";

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTPC1.Visible = true;
                    tbTPC2.Visible = true;
                    tbTPC3.Visible = true;
                    tbTPC4.Visible = true;
                    tbProj1.Visible = true;

                    tbMT1.MaxLength = 2;
                    tbMT2.MaxLength = 2;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTPC1.MaxLength = 2;
                    tbTPC2.MaxLength = 2;
                    tbTPC3.MaxLength = 2;
                    tbTPC4.MaxLength = 2;
                    tbProj1.MaxLength = 3;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    lbMediaMaximaCadeira.Text = "660";
                    lbMaxExame.Text = "400";
                }
                else if (cbCadeiras.SelectedItem.Equals("Processamento Digital de Sinais"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarPDS();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTPC.Text = "50";
                    lbMaxTL.Text = "70";

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTPC1.Visible = true;
                    tbTPC2.Visible = true;
                    tbTL1.Visible = true;
                    tbTL2.Visible = true;

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTPC1.MaxLength = 2;
                    tbTPC2.MaxLength = 2; 
                    tbTL1.MaxLength = 2;
                    tbTL2.MaxLength = 2;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    lbMediaMaximaCadeira.Text = "840";
                    lbMaxExame.Text = "500";
                }
                else if (cbCadeiras.SelectedItem.Equals("Redes IP"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarREDESIP();
                    ValidaCampos(170, 340);

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTL1.Visible = true;
                    tbTL2.Visible = true;
                    tbTI1.Visible = true;

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 2;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTL1.MaxLength = 2;
                    tbTL2.MaxLength = 2;
                    tbTI1.MaxLength = 3;

                    lbMaxT.Text = "100";
                    lbMaxMT.Text = "50";
                    lbMaxTL.Text = "50";
                    lbMaxTI.Text = "200";
                    lbMaxExame.Text = "340";

                    lbMediaMaximaCadeira.Text = "600";
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação II"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarSISCOM2();
                    ValidaCampos(250, 500);

                    lbMaxT.Text = "200";
                    lbMaxMT.Text = "100";
                    lbMaxTL.Text = "100";
                    lbMaxTPC.Text = "50";

                    lbMaxExame.Text = "500";

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTL1.MaxLength = 3;
                    tbTL2.MaxLength = 3;
                    tbTPC1.MaxLength = 2;
                    tbTPC2.MaxLength = 2;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTL1.Visible = true;
                    tbTL2.Visible = true;
                    tbTPC1.Visible = true;
                    tbTPC2.Visible = true;

                    lbMediaMaximaCadeira.Text = "900";
                }
                else if (cbCadeiras.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                    BuscarSGBD();
                    ValidaCampos(300, 600);

                    lbMaxT.Text = "250";
                    lbMaxMT.Text = "100";
                    lbMaxTP.Text = "200";

                    tbMT1.Visible = true;
                    tbMT2.Visible = true;
                    tbMT3.Visible = true;
                    tbT1.Visible = true;
                    tbT2.Visible = true;
                    tbTP1.Visible = true;
                    tbTP2.Visible = true;

                    tbMT1.MaxLength = 3;
                    tbMT2.MaxLength = 3;
                    tbMT3.MaxLength = 3;
                    tbT1.MaxLength = 3;
                    tbT2.MaxLength = 3;
                    tbTP1.MaxLength = 3;
                    tbTP2.MaxLength = 3;
                    tbExame1.MaxLength = 3;
                    tbExame2.MaxLength = 3;

                    lbMediaMaximaCadeira.Text = "1200";
                    lbMaxExame.Text = "600";
                }

                else
                {
                    EsconderValores();
                    LimpaMaximos();
                    AtivarCampos();
                    LimparValores();
                }
                TrancaAvaliacoes();
                Provisoria();
            }
            catch (SqlException)
            {

                MessageBox.Show("Login com a base de dados falhou.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbAno.SelectedItem.Equals("Escolha uma opção:") & !cbCadeiras.SelectedItem.Equals("Escolha uma opção:")
                & !cbSemestre.SelectedItem.Equals("Escolha uma opção:") & !cbTurmas.SelectedItem.Equals("Escolha uma opção:"))
                {
                    /// 1 Semestre
                    if (cbCadeiras.SelectedItem.Equals("Algorítmos e Estruturas de Dados"))
                    {
                        InserirAEDA();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Instrumentação e Medida"))
                    {
                        InserirIMED();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Processamento Analógico de Sinais"))
                    {
                        InserirPRAS();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Programação para Dispositivos Móveis"))
                    {
                        InserirPRDM();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Radiação e Propagação"))
                    {
                        InserirRADP();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação I"))
                    {
                        InserirSISCOM1();
                    }

                    /// 2 Semestre
                    else if (cbCadeiras.SelectedItem.Equals("Aplicação e Serviços Internet"))
                    {
                        InserirASI();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Antenas"))
                    {
                        InserirANTENA();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Processamento Digital de Sinais"))
                    {
                        InserirPDS();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Redes IP"))
                    {
                        InserirREDESIP();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Sistemas de Comunicação II"))
                    {
                        InserirSISCOM2();
                    }
                    else if (cbCadeiras.SelectedItem.Equals("Sistemas de Gestão de Base de Dados"))
                    {
                        InserirSGBD();
                    }
                    MessageBox.Show("Notas actualizadas com sucesso", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCadeiras_SelectedIndexChanged(sender, e);
                }
                else
                    MessageBox.Show("Escolha todas opções para prosseguir!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.AbortRetryIgnore);
            }
        }
        private void LimparValores()
        {
            tbDIV1.Text = tbDIV2.Text = tbDIV3.Text = tbDIV4.Text = "0";
            tbT1.Text = tbT2.Text = tbT3.Text = tbT4.Text = "0";
            tbTG1.Text = tbTG2.Text = tbTG3.Text = tbTG4.Text = "0";
            tbTP1.Text = tbTP2.Text = tbTP3.Text = tbTP4.Text = "0";
            tbTPC1.Text = tbTPC2.Text = tbTPC3.Text = tbTPC4.Text = "0";
            tbMT1.Text = tbMT2.Text = tbMT3.Text = tbMT4.Text = tbMT5.Text = "0";
            tbProj1.Text = tbProj2.Text = tbProj3.Text = "0";
            tbTI1.Text = tbTI2.Text = tbTI3.Text = tbTI4.Text = "0";
            tbTL1.Text = tbTL2.Text = tbTL3.Text = tbTL4.Text = "0";
            tbExame1.Text = tbExame2.Text = tbExame3.Text = "0";
        }

        ///Metodos para insercao de dados nas TextBoxes de Cada Cadeira

        ///
        /// 1 Semestre
        private void InserirAEDA()
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

            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TP1", SqlDbType.Int, int.Parse(tbTP1.Text));
            classecon.AddParam("TP2", SqlDbType.Int, int.Parse(tbTP2.Text));
            classecon.AddParam("DIV1", SqlDbType.Int, int.Parse(tbDIV1.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirIMED()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("MT3", SqlDbType.Int, int.Parse(tbMT3.Text));
            classecon.AddParam("MT4", SqlDbType.Int, int.Parse(tbMT4.Text));
            classecon.AddParam("MT5", SqlDbType.Int, int.Parse(tbMT5.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TPC2", SqlDbType.Int, int.Parse(tbTPC2.Text));
            classecon.AddParam("TPC3", SqlDbType.Int, int.Parse(tbTPC3.Text));
            classecon.AddParam("TG1", SqlDbType.Int, int.Parse(tbTG1.Text));
            classecon.AddParam("TG2", SqlDbType.Int, int.Parse(tbTG2.Text));
            classecon.AddParam("Exame1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("Exame2", SqlDbType.Int, int.Parse(tbExame2.Text));
            // Executa o update
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirPRAS()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TPC2", SqlDbType.Int, int.Parse(tbTPC2.Text));
            classecon.AddParam("TL1", SqlDbType.Int, int.Parse(tbTL1.Text));
            classecon.AddParam("TL2", SqlDbType.Int, int.Parse(tbTL2.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirPRDM()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TG1", SqlDbType.Int, int.Parse(tbTG1.Text));
            classecon.AddParam("TI1", SqlDbType.Int, int.Parse(tbTI1.Text));
            classecon.AddParam("TI2", SqlDbType.Int, int.Parse(tbTI2.Text));
            classecon.AddParam("PROJ1", SqlDbType.Int, int.Parse(tbProj1.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirRADP()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TP1", SqlDbType.Int, int.Parse(tbTP1.Text));
            classecon.AddParam("T3", SqlDbType.Int, int.Parse(tbT3.Text));
            classecon.AddParam("MT3", SqlDbType.Int, int.Parse(tbMT3.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirSISCOM1()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TG1", SqlDbType.Int, int.Parse(tbTG1.Text));
            classecon.AddParam("TL1", SqlDbType.Int, int.Parse(tbTL1.Text));
            classecon.AddParam("TG2", SqlDbType.Int, int.Parse(tbTG2.Text));
            classecon.AddParam("TL2", SqlDbType.Int, int.Parse(tbTL2.Text));
            classecon.AddParam("TL3", SqlDbType.Int, int.Parse(tbTL3.Text));
            classecon.AddParam("TL4", SqlDbType.Int, int.Parse(tbTL4.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            // Retorna a quantidade de linhas afetadas
            classecon.ExecutaAtualizacao(SQL);
        }

        ///
        /// 2 Semestre
        private void InserirANTENA()
        {
            classecon.LimparParametros();
            string SQL = @"UPDATE TbANTENAS SET
                    MT1 = @MT1,
                    MT2 = @MT2, 
                    T1 = @T1, 
                    T2 = @T2,
                    T3 = @T3,
                    TPC1 = @TPC1,
                    TP1 = @TP1,
                    EXAME1 = @EXAME1,
                    EXAME2 = @EXAME2,
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("T3", SqlDbType.Int, int.Parse(tbT3.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TP1", SqlDbType.Int, int.Parse(tbTP1.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirASI()
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
                    EXAME3 = @EXAME3";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TPC2", SqlDbType.Int, int.Parse(tbTPC2.Text));
            classecon.AddParam("TPC3", SqlDbType.Int, int.Parse(tbTPC3.Text));
            classecon.AddParam("TPC4", SqlDbType.Int, int.Parse(tbTPC4.Text));
            classecon.AddParam("PROJ", SqlDbType.Int, int.Parse(tbProj1.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirPDS()
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
                    EXAME3 = @EXAME3";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TPC2", SqlDbType.Int, int.Parse(tbTPC2.Text));
            classecon.AddParam("TL1", SqlDbType.Int, int.Parse(tbTL1.Text));
            classecon.AddParam("TL2", SqlDbType.Int, int.Parse(tbTL2.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirREDESIP()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TL1", SqlDbType.Int, int.Parse(tbTL1.Text));
            classecon.AddParam("TL2", SqlDbType.Int, int.Parse(tbTL2.Text));
            classecon.AddParam("TI1", SqlDbType.Int, int.Parse(tbTI1.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirSISCOM2()
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
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TL1", SqlDbType.Int, int.Parse(tbTL1.Text));
            classecon.AddParam("TL2", SqlDbType.Int, int.Parse(tbTL2.Text));
            classecon.AddParam("TPC1", SqlDbType.Int, int.Parse(tbTPC1.Text));
            classecon.AddParam("TPC2", SqlDbType.Int, int.Parse(tbTPC2.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.ExecutaAtualizacao(SQL);
        }
        private void InserirSGBD()
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
                    EXAME3 = @EXAME3 ";
            // Adiciona os parâmetros da instrução SQL
            classecon.AddParam("MT1", SqlDbType.Int, int.Parse(tbMT1.Text));
            classecon.AddParam("MT2", SqlDbType.Int, int.Parse(tbMT2.Text));
            classecon.AddParam("MT3", SqlDbType.Int, int.Parse(tbMT3.Text));
            classecon.AddParam("T1", SqlDbType.Int, int.Parse(tbT1.Text));
            classecon.AddParam("T2", SqlDbType.Int, int.Parse(tbT2.Text));
            classecon.AddParam("TP1", SqlDbType.Int, int.Parse(tbTP1.Text));
            classecon.AddParam("TP2", SqlDbType.Int, int.Parse(tbTP2.Text));
            classecon.AddParam("EXAME1", SqlDbType.Int, int.Parse(tbExame1.Text));
            classecon.AddParam("EXAME2", SqlDbType.Int, int.Parse(tbExame2.Text));
            classecon.AddParam("EXAME3", SqlDbType.Int, int.Parse(tbExame3.Text));
            classecon.ExecutaAtualizacao(SQL);
        }

        ///Metodos para busca de dados na tabela

        ///
        /// 1 Semestre
        private void BuscarAEDA()
        {
            string SQL = @"SELECT
                MT1, MT2, T1, T2, TP1, TP2, DIV1, EXAME1,
                EXAME2
                FROM TbAEDA ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTP1.Text = result.Rows[valor]["TP1"].ToString();
            tbTP2.Text = result.Rows[valor]["TP2"].ToString();
            tbDIV1.Text = result.Rows[valor]["DIV1"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            EstadoCadeira(300, 600);
        }
        private void BuscarIMED()
        {
            string SQL = @"SELECT
                            MT1, MT2, MT3, MT4, MT5, T1, T2, TPC1, TPC2, TPC3, TG1, TG2, EXAME1,
                            EXAME2
                            FROM TbIMED ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbMT3.Text = result.Rows[valor]["MT3"].ToString();
            tbMT4.Text = result.Rows[valor]["MT4"].ToString();
            tbMT5.Text = result.Rows[valor]["MT5"].ToString();
            tbTPC3.Text = result.Rows[valor]["TPC3"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTPC2.Text = result.Rows[valor]["TPC2"].ToString();
            tbTG1.Text = result.Rows[valor]["TG1"].ToString();
            tbTG2.Text = result.Rows[valor]["TG2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarPRAS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2, EXAME1,
                            EXAME2, EXAME3
                            FROM TbPRAS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTPC2.Text = result.Rows[valor]["TPC2"].ToString();
            tbTL1.Text = result.Rows[valor]["TL1"].ToString();
            tbTL2.Text = result.Rows[valor]["TL2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarPRDM()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TG1,  TI1, TI2, PROJ1, EXAME1,
                            EXAME2, EXAME3
                            FROM TbPROG ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbProj1.Text = result.Rows[valor]["PROJ1"].ToString();
            tbTG1.Text = result.Rows[valor]["TG1"].ToString();
            tbTI1.Text = result.Rows[valor]["TI1"].ToString();
            tbTI2.Text = result.Rows[valor]["TI2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarRADP()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, T3, MT3, TPC1, TP1, EXAME1,
                            EXAME2, EXAME3
                            FROM TbRADP ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbT3.Text = result.Rows[valor]["T3"].ToString();
            tbMT3.Text = result.Rows[valor]["MT3"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTP1.Text = result.Rows[valor]["TP1"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarSISCOM1()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TL3, TL4, TG1, TG2, EXAME1,
                            EXAME2
                            FROM TbSISCOM1 ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTG1.Text = result.Rows[valor]["TG1"].ToString();
            tbTG2.Text = result.Rows[valor]["TG2"].ToString();
            tbTL1.Text = result.Rows[valor]["TL1"].ToString();
            tbTL2.Text = result.Rows[valor]["TL2"].ToString();
            tbTL3.Text = result.Rows[valor]["TL3"].ToString();
            tbTL4.Text = result.Rows[valor]["TL4"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            EstadoCadeira(250, 500);
        }

        ///
        /// 2 Semestre
        private void BuscarANTENA()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, T3,  TPC1, TP1, EXAME1,
                            EXAME2, EXAME3
                            FROM TbANTENAS ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbT3.Text = result.Rows[valor]["T3"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTP1.Text = result.Rows[valor]["TP1"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarASI()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2,TPC3, TPC4, PROJ, EXAME1,
                            EXAME2, EXAME3
                            FROM TbASI ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTPC2.Text = result.Rows[valor]["TPC2"].ToString();
            tbTPC3.Text = result.Rows[valor]["TPC3"].ToString();
            tbTPC4.Text = result.Rows[valor]["TPC4"].ToString();
            tbProj1.Text = result.Rows[valor]["PROJ"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(200, 400);
        }
        private void BuscarPDS()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TPC1, TPC2, TL1, TL2, EXAME1,
                            EXAME2, EXAME3
                            FROM TbPDS";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTPC2.Text = result.Rows[valor]["TPC2"].ToString();
            tbTL1.Text = result.Rows[valor]["TL1"].ToString();
            tbTL2.Text = result.Rows[valor]["TL2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarREDESIP()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TI1, EXAME1,
                            EXAME2
                            FROM TbREDESIP ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTI1.Text = result.Rows[valor]["TI1"].ToString();
            tbTL1.Text = result.Rows[valor]["TL1"].ToString();
            tbTL2.Text = result.Rows[valor]["TL2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            EstadoCadeira(170, 340);
        }
        private void BuscarSISCOM2()
        {
            string SQL = @"SELECT
                            MT1, MT2, T1, T2, TL1, TL2, TPC1, TPC2, EXAME1,
                            EXAME2
                            FROM TbSISCOM2 ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTPC1.Text = result.Rows[valor]["TPC1"].ToString();
            tbTPC2.Text = result.Rows[valor]["TPC2"].ToString();
            tbTL1.Text = result.Rows[valor]["TL1"].ToString();
            tbTL2.Text = result.Rows[valor]["TL2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            EstadoCadeira(250, 500);
        }
        private void BuscarSGBD()
        {
            string SQL = @"SELECT
                            MT1, MT2, MT3, T1, T2, TP1, TP2, EXAME1,
                            EXAME2, EXAME3 FROM TbSGBD ";
            DataTable result;
            result = classecon.ExecuteConsult(SQL);
            tbMT1.Text = result.Rows[valor]["MT1"].ToString();
            tbMT2.Text = result.Rows[valor]["MT2"].ToString();
            tbMT3.Text = result.Rows[valor]["MT3"].ToString();
            tbT1.Text = result.Rows[valor]["T1"].ToString();
            tbT2.Text = result.Rows[valor]["T2"].ToString();
            tbTP1.Text = result.Rows[valor]["TP1"].ToString();
            tbTP2.Text = result.Rows[valor]["TP2"].ToString();
            tbExame1.Text = result.Rows[valor]["EXAME1"].ToString();
            tbExame2.Text = result.Rows[valor]["EXAME2"].ToString();
            tbExame3.Text = result.Rows[valor]["EXAME3"].ToString();
            EstadoCadeira(300, 600);
        }
        
    }
}