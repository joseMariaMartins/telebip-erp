using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormViewProduto : FormLoad
    {
        public FormViewProduto()
        {
            InitializeComponent();
            AplicarBordasArredondadas();
        }

        #region Métodos para Bordas Arredondadas
        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = Math.Max(0, radius * 2);
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            wrapper.BackColor = fill;
            wrapper.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);
                using (var path = GetRoundedRect(rect, radius))
                using (var pen = new Pen(border, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
            wrapper.Resize += (s, e) => wrapper.Invalidate();
        }

        private void AplicarBordasArredondadas()
        {
            Color borderColor = Color.FromArgb(60, 62, 80);
            Color fillColor = Color.FromArgb(40, 41, 52);
            int radius = 8;

            // Aplica bordas arredondadas em todos os wrappers de texto
            StyleTextboxWrapperPanel(pnlWrapperObservacao, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperQAviso, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperQEstoque, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperPreco, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperMarca, fillColor, borderColor, radius);
            StyleTextboxWrapperPanel(pnlWrapperNome, fillColor, borderColor, radius);
        }
        #endregion

        // Método para carregar os dados do produto
        public void CarregarProduto(int id, string nome, string marca, decimal preco, int quantidade, int quantidadeAviso, string observacao)
        {
            lblID.Text = id.ToString();
            tbNome.Text = nome;
            tbMarca.Text = marca;
            tbPreco.Text = "R$ " + preco.ToString("N2");
            tbQEstoque.Text = quantidade.ToString();
            tbQAviso.Text = quantidadeAviso.ToString();
            tbObservacao.Text = observacao;

            // Atualiza o título
            lblTitulo.Text = $"Visualizar Produto - {nome}";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}