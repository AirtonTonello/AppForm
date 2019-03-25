using System;
using System.Net;
using System.Net.Mail;

namespace AppForms.Model
{
    class Email
    {
        public void EnviarEmail(Alarmes alarme)
        {

            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("enviodeemailtesteairton@gmail.com", "@teste1994");

                MailMessage mail = new MailMessage();
                mail.Sender = new MailAddress("enviodeemailtesteairton@gmail.com", "Teste de Email Airton");
                mail.From = new MailAddress("enviodeemailtesteairton@gmail.com", "Teste de Email Airton");
                mail.To.Add(new MailAddress("abcd@abc.com.br"));
                mail.Subject = "Alerta - Novo Alarme Cadastrado!";
                mail.Body = string.Format(@"Novo Alarme Cadastrado como URGENTE --> Alarme: {0}", alarme.Descricao);
                mail.Priority = MailPriority.High;

                client.Send(mail);
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.RegistrarLog("Falha ao enviar e-mail: " + ex.Message);
            }
            
        }
    }
}
