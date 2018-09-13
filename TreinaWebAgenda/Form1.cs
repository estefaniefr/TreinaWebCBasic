using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreinaWebAgenda.Entidades;

namespace TreinaWebAgenda
{
    public partial class frmAgendaContatos : Form
    {
        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            AlterarEstadoBotoesCancelarESalvar(false);
            AlterarEstadoBotoesIncluirAlterarExcluir(true);
             CarregarContatos();
        }

        private void AlterarEstadoBotoesCancelarESalvar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        private void AlterarEstadoBotoesIncluirAlterarExcluir(bool estado)
        {
            btnIncluir.Enabled = estado;
            btnExcluir.Enabled = estado;
            btnAlterar.Enabled = estado;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AlterarEstadoBotoesCancelarESalvar(true);
            AlterarEstadoBotoesIncluirAlterarExcluir(false);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarEstadoBotoesCancelarESalvar(true);
            AlterarEstadoBotoesIncluirAlterarExcluir(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text
            };

            List<Contato> contatos = new List<Contato>();
            foreach (Contato contatoList in lsbContato.Items)
            {
                contatos.Add(contatoList);
            }
            contatos.Add(contato);
            ManipularArquivo.EscreverArquivo(contatos);
            CarregarContatos();
            AlterarEstadoBotoesCancelarESalvar(false);
            AlterarEstadoBotoesIncluirAlterarExcluir(true);
            LimparCampos();
        }

        private void CarregarContatos()
        {
            lsbContato.Items.Clear();
            lsbContato.Items.AddRange(ManipularArquivo.LerArquivo().ToArray());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarEstadoBotoesCancelarESalvar(false);
            AlterarEstadoBotoesIncluirAlterarExcluir(true);
        }

        private void LimparCampos()
        {
            txtEmail.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
        }
    }
}
