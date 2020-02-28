using System;
using System.Windows.Forms;

namespace ConsoleTrello.Interfaces
{
    public interface IBarraProgresso
    {
        void IncrementarBarra(ref ProgressBar progressBar1, ref ListBox lbxProgresso, string msg = "");
        void FinalizarBarraProgresso(ref ProgressBar progressBar1, ref ListBox lbxProgresso, string msg);
        void IniciarProgresso(ref ProgressBar progressBar1, ref ListBox lbxProgresso, string msg, int maxProgresso);

    }
}
