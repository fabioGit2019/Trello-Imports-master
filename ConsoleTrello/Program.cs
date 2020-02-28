using ConsoleTrello.Interfaces;
using System.Configuration;

namespace ConsoleTrello
{
    class Program
    {
        static void Main(string[] args)
        {
            AtualizarTrello();
        }
        private static void AtualizarTrello()
        {
            System.Windows.Forms.ProgressBar pb = new System.Windows.Forms.ProgressBar();
            System.Windows.Forms.ListBox lbx = new System.Windows.Forms.ListBox();
            string pathTrello = "c:\\";

            if (ConfigurationManager.AppSettings["PathTrelloFile"] != null)
                pathTrello = ConfigurationManager.AppSettings["PathTrelloFile"];
            string arqRet = pathTrello + "trello.json"; //"c:\\temp\\trello.json"; 

            IGerenciadorTrello g = new GerenciadorTrello(arqRet, false, false, true);
            g.AtualizarTrello(ref pb, ref lbx);
        }
    }
}
