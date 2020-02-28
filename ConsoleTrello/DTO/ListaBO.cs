using System;
using br.Factory;
using System.Runtime.Serialization;

namespace ConsoleTrello.BO
{
    
    [Table(Nome = "LISTAS", Descricao = "Tabela de listas")]
    public class ListaBO : ObjectModel, IDisposable
    {
        /// <summary> Campo:  Id da Lista
        /// </summary>    
        [Column(NomeColuna = "IDLISTA", Id = true, Tamanho = 10, Descricao = " Campo:  ID DO lista")]
        ///  [Generator(GeneratorStrategy = GeneratorStrategyTypeEnum.Identity)]
        public StringField ListaId { set; get; }        
        /// <summary> Campo:  lista (nome da lista)
        /// </summary>    
   	    [Column(NomeColuna = "LISTA", Tamanho = 100, Descricao = " Campo:  TEXTO")]
        public StringField Lista { set; get; }
      
         

        #region Dispose 
        private Boolean disposed = false;
        public void Dispose()
        {
            this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    GC.Collect(0, GCCollectionMode.Optimized);
                    GC.WaitForPendingFinalizers();
                }
                this.disposed = true;
            }
        }
        ~ListaBO()
        {
            this.Dispose();
        }
        #endregion
    }
}
