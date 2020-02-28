using System;
using System.Collections.Generic;
using ConsoleTrello.BO;
using br.Factory;
namespace ConsoleTrello.DAO
{
    public class ListaDAO : ObjectModel, IEntityManagerCRUD<ListaBO>, IDisposable
    {
        private EntityManager<ListaBO> entityManager;
        private DataBaseContext dataBase;
        public ListaDAO(DataBaseContext dataBase)
        {
            if (dataBase != null)
                this.dataBase = dataBase;
            else
                this.dataBase = new DataBaseContext();

            this.entityManager = new EntityManager<ListaBO>(dataBase);
            dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        public ListaDAO()
        {
            this.entityManager = new EntityManager<ListaBO>();
            this.entityManager.DataBase.OnDataBaseInfoExecute += EventoLog;
            this.dataBase = new DataBaseContext();
            this.dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        protected void EventoLog(object sender, DataBaseInfoExecuteEventArgs e)
        {
        }
        public void Alterar(ListaBO obj, bool propriedadesModificadas)
        {
            this.entityManager.Alterar(obj, propriedadesModificadas);
            this.SetResultMessage(this.entityManager);
        }
        public void Alterar(ListaBO obj)
        {
            this.entityManager.Alterar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(ListaBO obj, CondicaoSql condicaoSql)
        {
            this.entityManager.Consultar(obj, condicaoSql);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(ListaBO obj)
        {
            this.entityManager.Consultar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Excluir(ListaBO obj)
        {
            this.entityManager.Excluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Incluir(ListaBO obj)
        {
            this.entityManager.Incluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public List<ListaBO> Listar(CondicaoSql condicaoSql)
        {
            List<ListaBO> lista = entityManager.Listar(condicaoSql);
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
        ~ListaDAO()
        {
            this.Dispose();
        }
        #endregion

    }
}
