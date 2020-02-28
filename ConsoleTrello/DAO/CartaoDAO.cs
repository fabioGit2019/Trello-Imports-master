using System;
using System.Collections.Generic;
using ConsoleTrello.BO;
using br.Factory;
namespace ConsoleTrello.DAO
{
    public class CartaoDAO : ObjectModel, IEntityManagerCRUD<CartaoBO>, IDisposable
    {
        private EntityManager<CartaoBO> entityManager;
        private DataBaseContext dataBase;
        public CartaoDAO(DataBaseContext dataBase)
        {
            if (dataBase != null)
                this.dataBase = dataBase;
            else
                this.dataBase = new DataBaseContext();

            this.entityManager = new EntityManager<CartaoBO>(dataBase);
            dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        public CartaoDAO()
        {
            this.entityManager = new EntityManager<CartaoBO>();
            this.entityManager.DataBase.OnDataBaseInfoExecute += EventoLog;
            this.dataBase = new DataBaseContext();
            this.dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        protected void EventoLog(object sender, DataBaseInfoExecuteEventArgs e)
        {
        }
        public void Alterar(CartaoBO obj, bool propriedadesModificadas)
        {
            this.entityManager.Alterar(obj, propriedadesModificadas);
            this.SetResultMessage(this.entityManager);
        }
        public void Alterar(CartaoBO obj)
        {
            this.entityManager.Alterar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(CartaoBO obj, CondicaoSql condicaoSql)
        {
            this.entityManager.Consultar(obj, condicaoSql);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(CartaoBO obj)
        {
            this.entityManager.Consultar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Excluir(CartaoBO obj)
        {
            this.entityManager.Excluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Incluir(CartaoBO obj)
        {
            this.entityManager.Incluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public List<CartaoBO> Listar(CondicaoSql condicaoSql)
        {
            List<CartaoBO> lista = entityManager.Listar(condicaoSql);
            this.SetResultMessage(entityManager);
            return lista;
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
        ~CartaoDAO()
        {
            this.Dispose();
        }
        #endregion

    }
}
