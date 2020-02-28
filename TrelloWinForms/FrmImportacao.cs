using ConsoleTrello;
using ConsoleTrello.Interfaces;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace TrelloWinForms
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if ((!rbWebApi.Checked) && (!rbArquivo.Checked))
            {
                MessageBox.Show("Selecione uma opção de importação", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtPathArquivo.Text))
            {
                IGerenciadorTrello p = new GerenciadorTrello(txtPathArquivo.Text, true, rbWebApi.Checked, cbxCartArquivado.Checked);
                p.AtualizarTrello(ref progressBar1, ref listBox1);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog()
            {
                InitialDirectory = ConfigurationManager.AppSettings["PathTrelloFile"]
            };

            txtPathArquivo.Text = (opd.ShowDialog() == DialogResult.OK) ? opd.FileName : string.Empty;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Cor Default
            Brush myBrush = Brushes.Gray;

            if (listBox1.Items.Count <= 0) return;

            // Cor de acordo com o número da linha
            if (!string.IsNullOrEmpty(listBox1.Items[e.Index].ToString()) ){
                if (listBox1.Items[e.Index].ToString().Substring(0, 3) == "ERR")
                {
                    myBrush = Brushes.Red;
                }
                else
                if (listBox1.Items[e.Index].ToString().Substring(0, 3) == "WAR")
                {
                    myBrush = Brushes.Orange;
                }
                else
                if (listBox1.Items[e.Index].ToString().Substring(0, 3) == "OK:")
                {
                    myBrush = Brushes.Green;
                }
            }

            //Cor da linha selecionada
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.Yellow);
            }

            e.DrawBackground();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void rbArquivo_CheckedChanged(object sender, EventArgs e)
        {
            btnLocalizar.Enabled = rbArquivo.Checked;
            txtPathArquivo.Enabled = rbArquivo.Checked;
        }

        private void rbArquivo_Click(object sender, EventArgs e)
        {
            if ((RadioButton)sender == rbArquivo)
                rbArquivo.Checked = !rbWebApi.Checked;
            else
                rbWebApi.Checked = !rbArquivo.Checked;
        }
    }
}
