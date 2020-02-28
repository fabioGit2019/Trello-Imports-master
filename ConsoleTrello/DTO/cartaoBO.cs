using System;
using br.Factory;
using System.Runtime.Serialization;

namespace ConsoleTrello.BO
{
    
    [Table(Nome = "CARTAO", Descricao = "Tabela de Cartoes")]
    public class CartaoBO : ObjectModel, IDisposable
    {
        /// <summary> Campo:  Id do cartao
        /// </summary>    
        [Column(NomeColuna = "CARTAOID", Id = true, Tamanho = 10, Descricao = " Campo:  ID DO CARTAO")]
        ///  [Generator(GeneratorStrategy = GeneratorStrategyTypeEnum.Identity)]
        public StringField CartaoId { set; get; }        
        [Column(NomeColuna = "TEXTO", Tamanho = 100, Descricao = " Campo:  TEXTO")]
        public StringField Texto { set; get; }
        /// <summary> Campo:  data prometida
        /// </summary>                
        [Column(NomeColuna = "DATAPROMETIDA", Tamanho = 20, Descricao = " Campo:  DATA PROMETIDA")]
        public DateTimeField DataPrometida { set; get; }
        /// <summary> Campo: Data ultima atividade
        /// </summary>        
        [Column(NomeColuna = "DATAULTIMAATIVIDADE", Tamanho =20, Descricao = " Campo:  ATIVIDADE")]
        public DateTimeField DataUltimaAtividade { set; get; }

        [Column(NomeColuna = "LINK", Tamanho = 8, Descricao = " Campo:  link do cartao")]
        public StringField Link { set; get; }

        [Column(NomeColuna = "IDLISTA", Tamanho =30, Descricao = " Campo:  Id Board")]
        public StringField IdLista { set; get; }

        [Column(NomeColuna = "USUARIOID", Tamanho = 30, Descricao = " Campo:  id do usuario")]
        public StringField UsuarioId { set; get; }

        [Column(NomeColuna = "FINALIZADO", Tamanho = 1, Descricao = " Campo:  FINALIZADO")]
        public IntegerField Finalizado { set; get; }

        [Column(NomeColuna = "TIPO", Tamanho = 50, Descricao = " Campo:  tipo do Chamado do usuario")]
        public StringField Tipo { set; get; }
        /// <summary> Campo:  data analise
        /// </summary>                
        [Column(NomeColuna = "DATAANALISE", Tamanho = 20, Descricao = " Campo:  DATA inicio Analise")]
        public DateTimeField DataAnalise { set; get; }
        /// <summary> Campo:  data analise
        /// </summary>                
        [Column(NomeColuna = "DATAFIMANALISE", Tamanho = 20, Descricao = " Campo:  DATA fim Analise")]
        public DateTimeField DataFimAnalise { set; get; }
        /// <summary> Campo:  data analise
        /// </summary>                
        [Column(NomeColuna = "DATAINICIODEV", Tamanho = 20, Descricao = " Campo:  DATA inicio DEV")]
        public DateTimeField DataInicioDev { set; get; }
        /// <summary> Campo:  data fim DEV
        /// </summary>                
        [Column(NomeColuna = "DATAFIMDEV", Tamanho = 20, Descricao = " Campo:  DATA fim Analise")]
        public DateTimeField DataFimDev { set; get; }
        /// <summary>Campo: Arquivado
        /// </summary>
        [Column(NomeColuna = "ARQUIVADO", Tamanho = 1, Descricao = " Campo:  ARQUIVADO")]
        public IntegerField Arquivado{set; get;}        
        /// <summary>: Retrabalho        
        /// </summary>
        [Column(NomeColuna = "RETRABALHO", Tamanho = 1, Descricao = "Campo:  RETRABALHO")]
        public IntegerField Retrabalho{set; get;}
        /// <summary>: UltraCargo        
        /// </summary>
        [Column(NomeColuna = "ULTRACARGO", Tamanho = 1, Descricao = "Campo:  ULTRACARGO")]
        public IntegerField UltraCargo{set; get;}
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
        ~CartaoBO()
        {
            this.Dispose();
        }
        #endregion
    }
}
