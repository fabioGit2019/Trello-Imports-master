using System;
using br.Factory;
using System.Runtime.Serialization;

namespace ConsoleTrello.BO
{
    
    [Table(Nome = "ACOES", Descricao = "Tabela de Acoes - Atividades")]
    public class AcaoBO : ObjectModel, IDisposable
    {
        /// <summary> Campo:  Id da ACAO
        /// </summary>    
        [Column(NomeColuna = "ACAOID", Id = true, Tamanho = 10, Descricao = " Campo:  ID DA ACAO")]
        ///  [Generator(GeneratorStrategy = GeneratorStrategyTypeEnum.Identity)]
        public StringField AcaoId { set; get; }        
		 /// <summary> Campo:  Id do CARTAO
        /// </summary>   
        [Column(NomeColuna = "CARTAOID", Tamanho = 100, Descricao = " Campo:  ID DO CARTAO")]
        public StringField CartaoId { set; get; }        
		/// <summary> Campo:  data da Acao
        /// </summary>                
        [Column(NomeColuna = "DATAACAO", Tamanho = 20, Descricao = " Campo:  DATA DA ACAO")]
        public DateTimeField DataAcao { set; get; }
        /// <summary> Campo: Id da Lista
        /// </summary>        
        [Column(NomeColuna = "LISTAID", Tamanho =20, Descricao = " Campo:  LISTA")]
        public StringField ListaId { set; get; }
        /// <summary> Campo: USUARIO
        /// </summary>        
        [Column(NomeColuna = "USUARIOID", Tamanho = 30, Descricao = " Campo:  id do usuario")]
        public StringField UsuarioId { set; get; }
        /// <summary> Campo: FINALIZADO
        /// </summary>        
        [Column(NomeColuna = "FINALIZADO", Tamanho = 1, Descricao = " Campo:  FINALIZADO")]
        public IntegerField Finalizado { set; get; }
        /// <summary> Campo: Lista anterior
        /// </summary>        
        [Column(NomeColuna = "LISTAIDOLD", Tamanho = 1, Descricao = " Campo:  LISTAIDOLD")]
        public StringField ListaIdOld { set; get; }
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
        ~AcaoBO()
        {
            this.Dispose();
        }
        #endregion
    }
}
