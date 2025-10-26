using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormRelatorios : Form
    {
        private FormVendas formVendas;
        private FormEstoque formEstoque;

        public FormRelatorios(FormVendas vendas, FormEstoque estoque)
        {
            InitializeComponent();

            formVendas = vendas;
            formEstoque = estoque;

            InicializarComboBoxes();

            // Inicializar os clicks para testar
            btnGerarRelatorio.Click += BtnGerarRelatorio_Click;
            btnExportarExcel.Click += BtnExportarExcel_Click;
        }

        private void InicializarComboBoxes()
        {
            cbPeriodo.Items.Clear();
            cbPeriodo.Items.AddRange(new string[]
            {
                "Hoje",
                "Ontem",
                "Últimos 7 dias",
                "Últimos 30 dias",
                "Este mês",
                "Mês passado",
                "Ano atual"
            });
            cbPeriodo.SelectedIndex = 0;

            cbTipoRelatorio.Items.Clear();
            cbTipoRelatorio.Items.AddRange(new string[]
            {
                "Vendas do período",
                "Produtos mais vendidos",
                "Estoque baixo",
                "Faturamento total",
                "Ticket médio",
                "Resumo de produtos",
                "Tendência de vendas"
            });
            cbTipoRelatorio.SelectedIndex = 0;
        }

        private void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            string tipo = cbTipoRelatorio.SelectedItem.ToString();
            string periodo = cbPeriodo.SelectedItem.ToString();

            if (tipo.Contains("Vendas"))
                AtualizarVendas();
            else
                AtualizarEstoque();
        }

        // -------------------- VENDAS --------------------
        private void AtualizarVendas()
        {
            if (formVendas == null)
            {
                MessageBox.Show("FormVendas não encontrado.");
                return;
            }

            DataTable dtVendas = formVendas.ObterVendasComoDataTable(); // método público que vamos criar

            if (dtVendas.Rows.Count == 0)
            {
                dgvRelatorios.DataSource = null;
                lblTitulo1.Text = lblValor1.Text = "";
                lblTitulo2.Text = lblValor2.Text = "";
                lblTitulo3.Text = lblValor3.Text = "";
                return;
            }

            dgvRelatorios.DataSource = dtVendas;

            lblTitulo1.Text = "Faturamento";
            lblValor1.Text = dtVendas.AsEnumerable()
                                     .Sum(r => Convert.ToDecimal(r["VALOR_TOTAL"])).ToString("C");

            lblTitulo2.Text = "Total de vendas";
            lblValor2.Text = dtVendas.Rows.Count.ToString();

            lblTitulo3.Text = "Ticket médio";
            lblValor3.Text = dtVendas.Rows.Count > 0 ?
                             (dtVendas.AsEnumerable().Sum(r => Convert.ToDecimal(r["VALOR_TOTAL"])) / dtVendas.Rows.Count).ToString("C")
                             : "R$0,00";
        }

        // -------------------- ESTOQUE --------------------
        private void AtualizarEstoque()
        {
            if (formEstoque == null)
            {
                MessageBox.Show("FormEstoque não encontrado.");
                return;
            }

            DataTable dtEstoque = formEstoque.ObterEstoqueComoDataTable(); // método público que criamos no estoque

            if (dtEstoque.Rows.Count == 0)
            {
                dgvRelatorios.DataSource = null;
                lblTitulo1.Text = lblValor1.Text = "";
                lblTitulo2.Text = lblValor2.Text = "";
                lblTitulo3.Text = lblValor3.Text = "";
                return;
            }

            dgvRelatorios.DataSource = dtEstoque;

            lblTitulo1.Text = "Produtos em alerta";
            lblValor1.Text = dtEstoque.AsEnumerable()
                                      .Count(r => Convert.ToInt32(r["QTD_ESTOQUE"]) < Convert.ToInt32(r["QTD_AVISO"]))
                                      .ToString();

            lblTitulo2.Text = "Total de produtos";
            lblValor2.Text = dtEstoque.Rows.Count.ToString();

            lblTitulo3.Text = "";
            lblValor3.Text = "";
        }

        // -------------------- EXPORTAR --------------------
        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvRelatorios.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "Relatorio.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        DataTable dt = dgvRelatorios.DataSource as DataTable;
                        if (dt != null)
                            wb.Worksheets.Add(dt, "Relatorio");

                        wb.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Relatório exportado com sucesso!");
                }
            }
        }
    }
}
