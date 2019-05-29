using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage Mail = new MailMessage();
                //Digite aqui o servidor SMTP para a aplicação acessar
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //A porta de acesso
                int port = 587;

                string MeuEmail = "seuEmail@gmail.com";
                string MeuPassword = "senha";

                //Digite aqui o e-mail que enviara a mensagem e o nome mostrado(remetente)
                Mail.From = new MailAddress(MeuEmail, "Seu nome");
                //Digite o e-amil da pessoa que vai recebe (destinatario)
                Mail.To.Add(txtPara.Text);
                //Nivel de prioridade da mensagem
                Mail.Priority = MailPriority.High;
                //Assunto da mensagem
                Mail.Subject = txtAssunto.Text;

                //Corpo da página com o recurso html ligado.
                Mail.Body = corpoDaMensagem(txtNome.Text, txtMensagem.Text);

                //Permite que seja inserido uma estrutura html na mensagem.
                Mail.IsBodyHtml = true;

                //Anexa arquivo na mensagem
                if (txtAnexo.Text != "") Mail.Attachments.Add(new Attachment(txtAnexo.Text));

                //Porta utilizada no servidor SMTP
                SmtpServer.Port = port;

                //Digite aqui a credencial de e-mail e senha válidos para acessar.
                SmtpServer.Credentials = new System.Net.NetworkCredential(MeuEmail, MeuPassword);
                //A autenticação de segura do e-mail - SSL
                SmtpServer.EnableSsl = true;
                //SmtpServer.Timeout = 10000;
                SmtpServer.Send(Mail);

                string a = txtNome.Text;

                limparCaixasDeTextos();

                MessageBox.Show("E-mail enviado com sucesso para " + a + "!", "Pronto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                //Se acaso der algum erro
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //Para pegar o anexo.
            ofdProcurar.ShowDialog();
            txtAnexo.Text = ofdProcurar.FileName;
        }

        /// <summary>
        /// Cria o corpo da página.
        /// </summary>
        /// <param name="nome">Recebe o nome do destinatário.</param>
        /// <param name="mensagem">Recebe uma mensagem escrita.</param>
        /// <returns>Retorna o corpo com as informações inseridas.</returns>
        public string corpoDaMensagem(string nome, string mensagem )
        {
            string a = "c1.staticflickr.com/5/4185/34282917092_d57050bf2c_b.jpg";
            string body = "<div style=\"font-family: Arial, Helvetica, sans-serif;\">" +
                                "E-mail de teste do 'Programa para enviar e-mail' em c#<br/><br/>" +
                                "<table width=\"429\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border: 2px solid #09F;text-align:center;\">" +
                                    "<tr>" +
                                        "<td width=\"397\" height=\"93\" style=\"border: 2px solid #09F; font-size:20px;color: " +
                                        "#FFF; background:#09F\"><b> Nome do contato:</b> " + txtNome.Text + "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td style=\"border: 2px solid #09F; padding:10px; text-align:left;\"><p><b>Mensagem:</b></p>" +
                                            "<p>" + txtMensagem.Text + "</p></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td style=\"border: 2px solid #09F; background:#0CF; padding:10px;\"><p><b>Imagem modelo:</b></p>" +
                                            "<p><img src=\"http://" + a + " \" width=\"313\" height=\"204\" /></p></td>" +
                                    "</tr>" +
                                "</table>" +
                            "</div>";
            return body;
        }

        /// <summary>
        /// Limpa as caixa de textos do formulário.
        /// </summary>
        public void limparCaixasDeTextos()
        {
            txtNome.Text = "";
            txtPara.Text = "";
            txtAnexo.Text = "";
            txtAssunto.Text = "";
            txtMensagem.Text = "";
        }
    }
}
