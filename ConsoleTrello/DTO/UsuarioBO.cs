using System;
using br.Factory;
using System.Runtime.Serialization;

namespace ConsoleTrello.BO
{
    
    [Table(Nome = "USUARIOS", Descricao = "Tabela de Cartoes")]
    public class UsuarioBO : ObjectModel, IDisposable
    {
        /// <summary> Campo:  Id do cartao
        /// </summary>    
        [Column(NomeColuna = "USUARIOID", Id = true, Tamanho = 30, Descricao = " Campo:  ID DO usuario")]
        ///  [Generator(GeneratorStrategy = GeneratorStrategyTypeEnum.Identity)]
        public StringField UsuarioId { set; get; }        
        [Column(NomeColuna = "NOME", Tamanho = 30, Descricao = " Campo:  TEXTO")]
        public StringField Nome { set; get; }
        /// <summary> Campo:  Email
        /// </summary>                
        [Column(NomeColuna = "EMAIL", Tamanho = 100, Descricao = " Campo:  EMAIL")]
        public StringField Email { set; get; }
               

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
        ~UsuarioBO()
        {
            this.Dispose();
        }
        #endregion
    }
}
