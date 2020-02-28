using System;
using System.Collections.Generic;
using br.Factory;
using ConsoleTrello.BO;
using ConsoleTrello.DAO;
namespace ConsoleTrello.DTC
 {   
    public class CartaoDTC : ObjectModel, IDisposable
    {
        DataBaseContext _database = null;
        public CartaoDTC()
        {
        }
        public CartaoDTC(DataBaseContext database)
        {
            _database = database;
        }
        /// <summary>
        /// Incluir um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Incluir(CartaoBO objBO)
        {
            CartaoDAO objDAO = new CartaoDAO();
            if (_database != null)
                objDAO = new CartaoDAO(_database);
            objDAO.Incluir(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Alterar um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Alterar(CartaoBO objBO)
        {
            CartaoDAO objDAO = new CartaoDAO();
            if (_database != null)
                objDAO = new CartaoDAO(_database);
            objDAO.Alterar(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Alterar um item  setando a obrigatoriedade do processo
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        /// <param name="propriedadesModificadas">Setar obrigatoriedade</param>
        public void Alterar(CartaoBO objBO, bool propriedadesModificadas)
        {
            CartaoDAO objDAO = new CartaoDAO();
            if (_database != null)
                objDAO = new CartaoDAO(_database);
            objDAO.Alterar(objBO, propriedadesModificadas);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Excluir um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Excluir(CartaoBO objBO)
        {
            CartaoDAO objDAO = new CartaoDAO();
            if (_database != null)
                objDAO = new CartaoDAO(_database);
            objDAO.Excluir(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Consultar um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Consultar(CartaoBO objBO)
        {
            CartaoDAO objDAO = new CartaoDAO();
            if (_database != null)
                objDAO = new CartaoDAO(_database);
            objDAO.Consultar(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Consultar um item descrevendo a Query
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        /// <param name="condicaoSql" >Query</param>
        public void Consultar(CartaoBO objBO, CondicaoSql condicaoSql)
        {
            CartaoDAO objDAO = new CartaoDAO();
            if (_database != null)
                objDAO = new CartaoDAO(_database);
            objDAO.Consultar(objBO, condicaoSql);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Lista uma coleção de OBJ
        /// </summary>
        /// <param name="condicaoSql" >Query</param>
        public List<CartaoBO> Listar(CondicaoSql condicaoSql)
        {
            using (CartaoDAO objDAO = new CartaoDAO())
            {
                List<CartaoBO> lista = objDAO.Listar(condicaoSql);
                this.SetResultMessage(objDAO);
                return lista;
            }
        }

        public bool Vazio()
        {
            CondicaoSql cond = new CondicaoSql();
            cond.SetLimiteSql(1);
            using (CartaoDAO objDAO = new CartaoDAO())
            {
                cond.SetCondicaoSql("1", CondicaoSqlEnum.Igual, "1");
                List<CartaoBO> lista = objDAO.Listar(cond);
                this.SetResultMessage(objDAO);
                return (lista.Count == 0);
            }
        }

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
        ~CartaoDTC()
        {
            this.Dispose();            
        }
        #endregion
    }

}
