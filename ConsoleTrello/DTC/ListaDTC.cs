﻿using System;
using System.Collections.Generic;
using br.Factory;
using ConsoleTrello.BO;
using ConsoleTrello.DAO;
namespace ConsoleTrello.DTC
 {   
    public class ListaDTC : ObjectModel, IDisposable
    {
        DataBaseContext _database = null;
        public ListaDTC()
        {
        }
        public ListaDTC(DataBaseContext database)
        {
            _database = database;
        }
        /// <summary>
        /// Incluir um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Incluir(ListaBO objBO)
        {
            ListaDAO objDAO = new ListaDAO();
            if (_database != null)
                objDAO = new ListaDAO(_database);
            objDAO.Incluir(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Alterar um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Alterar(ListaBO objBO)
        {
            ListaDAO objDAO = new ListaDAO();
            if (_database != null)
                objDAO = new ListaDAO(_database);
            objDAO.Alterar(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Alterar um item  setando a obrigatoriedade do processo
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        /// <param name="propriedadesModificadas">Setar obrigatoriedade</param>
        public void Alterar(ListaBO objBO, bool propriedadesModificadas)
        {
            ListaDAO objDAO = new ListaDAO();
            if (_database != null)
                objDAO = new ListaDAO(_database);
            objDAO.Alterar(objBO, propriedadesModificadas);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Excluir um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Excluir(ListaBO objBO)
        {
            ListaDAO objDAO = new ListaDAO();
            if (_database != null)
                objDAO = new ListaDAO(_database);
            objDAO.Excluir(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Consultar um item 
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        public void Consultar(ListaBO objBO)
        {
            ListaDAO objDAO = new ListaDAO();
            if (_database != null)
                objDAO = new ListaDAO(_database);
            objDAO.Consultar(objBO);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Consultar um item descrevendo a Query
        /// </summary>
        /// <param name="objBO" >Objeto com os dados Carros</param>
        /// <param name="condicaoSql" >Query</param>
        public void Consultar(ListaBO objBO, CondicaoSql condicaoSql)
        {
            ListaDAO objDAO = new ListaDAO();
            if (_database != null)
                objDAO = new ListaDAO(_database);
            objDAO.Consultar(objBO, condicaoSql);
            this.SetResultMessage(objDAO);
        }
        /// <summary>
        /// Lista uma coleção de OBJ
        /// </summary>
        /// <param name="condicaoSql" >Query</param>
        public List<ListaBO> Listar(CondicaoSql condicaoSql)
        {
            using (ListaDAO objDAO = new ListaDAO())
            {
                List<ListaBO> lista = objDAO.Listar(condicaoSql);
                this.SetResultMessage(objDAO);
                return lista;
            }
        }

        public bool Vazio()
        {
            CondicaoSql cond = new CondicaoSql();
            cond.SetLimiteSql(1);
            using (ListaDAO objDAO = new ListaDAO())
            {
                cond.SetCondicaoSql("1", CondicaoSqlEnum.Igual, "1");
                List<ListaBO> lista = objDAO.Listar(cond);
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
        ~ListaDTC()
        {
            this.Dispose();            
        }
        #endregion
    }

}
