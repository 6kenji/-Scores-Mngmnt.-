
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Score_Mgntm.FormsUsados
{
    public enum TextPosition
    {
        Left,
        Right,
        Center,
        None,
        Sliding
    }

    class MeuProgressBar : ProgressBar
    {
        //Campos
        private Color corCanal = Color.LightSteelBlue;
        private Color corDoSlider = Color.DarkCyan;
        private Color corForeGround = Color.DarkCyan;
        private int tamanhoCanal = 6;
        private int tamanhoSlider = 6;
        private TextPosition mostrarValor = TextPosition.Right;

        //Outros
        private bool pintadoAtras = false;
        private bool paraPintagem = false;
        

        //Contrutor
        public MeuProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.White;

        }

        //Propriedades
        [Category("Khalidy Safar's custom Class")]
        public Color CorCanal { get { return corCanal; } set { corCanal = value; this.Invalidate(); } }
        [Category("Khalidy Safar's custom Class")]
        public Color CorDoSlider { get { return corDoSlider; } set { corDoSlider = value; this.Invalidate(); } }
        [Category("Khalidy Safar's custom Class")]
        public Color CorForeGround { get { return corForeGround; } set { corForeGround = value; this.Invalidate(); } }
        [Category("Khalidy Safar's custom Class")]
        public int TamanhoCanal { get { return tamanhoCanal; } set { tamanhoCanal = value; this.Invalidate(); } }
        [Category("Khalidy Safar's custom Class")]
        public int TamanhoSlider { get { return tamanhoSlider; } set { tamanhoSlider = value; this.Invalidate(); } }
        [Category("Khalidy Safar's custom Class")]
        public TextPosition MostrarValor { get { return mostrarValor; } set { mostrarValor = value; this.Invalidate(); } }

        [Category("Khalidy Safar's custom Class")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Category("Khalidy Safar's custom Class")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = ForeColor;
            }
        }

        // Cor do BACKGROUND

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (paraPintagem == false)
            {
                if (pintadoAtras == false)
                {
                    //Campos
                    Graphics graf = pevent.Graphics;
                    Rectangle rect = new Rectangle(0, 0, this.Width, tamanhoCanal);
                    using (var brusherCanal = new SolidBrush(corCanal))
                    {
                        if (tamanhoCanal >= tamanhoSlider)
                        
                            rect.Y = this.Height - tamanhoCanal;
                        
                        else
                        
                            rect.Y = this.Height - ((tamanhoCanal + tamanhoSlider) / 2);
                        

                        //Pintura
                        graf.Clear(this.Parent.BackColor); //Superficie
                        graf.FillRectangle(brusherCanal, rect);//Canal

                        //Para de pintar atras e o canal
                        if (this.DesignMode == false)
                        
                            pintadoAtras = true;
                        
                    }
                }

                //Reseta a pintura atras e do canal
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                
                    pintadoAtras = false;
                
            }
        }
        // Cor do SLIDER 
        protected override void OnPaint(PaintEventArgs e)
        {
            if (paraPintagem == false)
            {
                //Campos
                Graphics graf = e.Graphics;
                double fatorEscala = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int widhtSlider = (int)(this.Width * fatorEscala);
                Rectangle rectangulo = new Rectangle(0, 0, widhtSlider, tamanhoSlider);
                using (var brusherSlider = new SolidBrush(corDoSlider))
                {
                    if (widhtSlider >= tamanhoCanal)
                        rectangulo.Y = this.Height - tamanhoSlider;
                    else
                        rectangulo.Y = this.Height - ((tamanhoSlider + tamanhoCanal) / 2);

                    //Para de pintar atras e o canal
                    if (widhtSlider > 1)
                        graf.FillRectangle(brusherSlider, rectangulo);
                    if (mostrarValor != TextPosition.None)
                        DrawValueText(graf, widhtSlider, rectangulo);
                }
            }
            if (this.Value == this.Maximum) paraPintagem = true;
            else paraPintagem = false;
        }

        //Cor do VALOR DE TEXTO

        private void DrawValueText(Graphics graf, int widhtSlider, Rectangle rectangulo)
        {
            //Campos
            string texto = Value.ToString() + "%";
            var tamanhoTexto = TextRenderer.MeasureText(texto, this.Font);
            var textoRectangulo = new Rectangle(0, 0, tamanhoTexto.Width, tamanhoTexto.Height + 2);
            using (var brusherText = new SolidBrush(this.ForeColor))
            using (var brusherTextBack = new SolidBrush(corForeGround))
            using (var formatoTexto = new StringFormat())
            {
                switch (mostrarValor)
                {
                    case TextPosition.Left:
                        textoRectangulo.X = 0;
                        formatoTexto.Alignment = StringAlignment.Near;
                        break;

                    case TextPosition.Right:
                        textoRectangulo.X = this.Width - tamanhoTexto.Width;
                        formatoTexto.Alignment = StringAlignment.Far;
                        break;
                    
                    case TextPosition.Center:
                        textoRectangulo.X = (this.Width - tamanhoTexto.Width)/2;
                        formatoTexto.Alignment = StringAlignment.Center;
                        break;
                    
                    case TextPosition.Sliding:
                        textoRectangulo.X = widhtSlider - tamanhoTexto.Width;
                        formatoTexto.Alignment = StringAlignment.Center;

                        using (var brusherLimpa = new SolidBrush(this.Parent.BackColor))
                        {
                            var rect = rectangulo;
                            rect.Y = rectangulo.Y;
                            rect.Height = textoRectangulo.Height;
                            graf.FillRectangle(brusherLimpa,rect);
                        }
                        break;
                }
                //Pintura
                graf.FillRectangle(brusherTextBack, textoRectangulo);
                graf.DrawString(texto, this.Font, brusherText, rectangulo, formatoTexto);

            }
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

}
