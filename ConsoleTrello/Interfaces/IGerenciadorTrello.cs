using System.Windows.Forms;

namespace ConsoleTrello.Interfaces
{
    public interface IGerenciadorTrello
    {
        bool AtualizarTrello(ref ProgressBar progressBar1, ref ListBox lbxProgresso);
    }
}
