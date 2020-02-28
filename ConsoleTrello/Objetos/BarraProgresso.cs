using ConsoleTrello.Interfaces;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleTrello
{
    public class BarraProgresso: IBarraProgresso
    {
        protected bool mostraMsgListBox;

        public BarraProgresso(bool mostraMsgListBox)
        {
            this.mostraMsgListBox = mostraMsgListBox;
        }

        public void IncrementarBarra(ref ProgressBar progressBar1, ref ListBox lbxProgresso, string msg = "")
        {
            if (mostraMsgListBox)
            {
                if (progressBar1.Value < progressBar1.Maximum)
                    progressBar1.Value += 1;

                if (!string.IsNullOrEmpty(msg))
                {
                    lbxProgresso.Items.Add(msg);                    
                }

                Application.DoEvents();
            }
        }

        public void FinalizarBarraProgresso(ref ProgressBar progressBar1, ref ListBox lbxProgresso, string msg)
        {
            if (mostraMsgListBox)
            {
                progressBar1.Value = progressBar1.Maximum;
                
                lbxProgresso.Items.Add(string.Empty);
                lbxProgresso.Items.Add(msg);
            }
            else
            {
                Console.WriteLine(msg);
                Console.ReadKey();
            }
        }

        public void IniciarProgresso(ref ProgressBar progressBar1, ref ListBox lbxProgresso, string msg, int maxProgresso)
        {
            if (mostraMsgListBox)
            {
                lbxProgresso.Items.Add(msg);
                progressBar1.Maximum = maxProgresso;
                progressBar1.Value = 1;
                Application.DoEvents();
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }
    }
}
