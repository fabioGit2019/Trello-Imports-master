using ConsoleTrello.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ConsoleTrello.Objetos
{
    public class Email: IEmail
    {
        public bool EnviarEmail()
        {
            try
            {
                List<string> listaEmail = new List<string>();
                listaEmail.Add(ConfigurationManager.AppSettings["EmailGerente"].ToString());

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;                
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in listaEmail)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }

                //Add CC
                //Outlook.Recipient oCCRecip = oRecips.Add("darivaldo.sousa@softtek.com");
                //oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                //oCCRecip.Resolve();

                //Add Assunto
                oMailItem.Subject = "View de consulta ao Trello Atualizada (Mensagem automática).";

                StringBuilder strEmail = new StringBuilder();
                strEmail.Append("<html>");
                strEmail.AppendFormat("Olá Sr(a). {0}, {1}", ConfigurationManager.AppSettings["NomeGerente"].ToString(), Environment.NewLine);                
                strEmail.AppendFormat("A base de consulta ao Trello foi atualizada em: {0} e está disponível para consultas.", DateTime.Now);
                strEmail.Append("</html>");

                oMailItem.HTMLBody = strEmail.ToString();                
                oMailItem.Display(true);
                return true;
            }
            catch (Exception objEx)
            {
                Console.Write(objEx.ToString());
                return false;
            }
        }
    }
}
