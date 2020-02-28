using System;
using System.Collections.Generic;
using ConsoleTrello.BO;
using br.Factory;
namespace ConsoleTrello.DAO
{
    public class AcaoDAO : ObjectModel, IEntityManagerCRUD<AcaoBO>, IDisposable
    {
        private EntityManager<AcaoBO> entityManager;
        private DataBaseContext dataBase;
        public AcaoDAO(DataBaseContext dataBase)
        {
            if (dataBase != null)
                this.dataBase = dataBase;
            else
                this.dataBase = new DataBaseContext();

            this.entityManager = new EntityManager<AcaoBO>(dataBase);
            dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        public AcaoDAO()
        {
            this.entityManager = new EntityManager<AcaoBO>();
            this.entityManager.DataBase.OnDataBaseInfoExecute += EventoLog;
            this.dataBase = new DataBaseContext();
            this.dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        protected void EventoLog(object sender, DataBaseInfoExecuteEventArgs e)
        {
        }
        public void Alterar(AcaoBO obj, bool propriedadesModificadas)
        {
            this.entityManager.Alterar(obj, propriedadesModificadas);
            this.SetResultMessage(this.entityManager);
        }
        public void Alterar(AcaoBO obj)
        {
            this.entityManager.Alterar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(AcaoBO obj, CondicaoSql condicaoSql)
        {
            this.entityManager.Consultar(obj, condicaoSql);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(AcaoBO obj)
        {
            this.entityManager.Consultar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Excluir(AcaoBO obj)
        {
            this.entityManager.Excluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Incluir(AcaoBO obj)
        {
            this.entityManager.Incluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public List<AcaoBO> Listar(CondicaoSql condicaoSql)
        {
            List<AcaoBO> lista = entityManager.Listar(condicaoSql);
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
        ~AcaoDAO()
        {
            this.Dispose();
        }
        #endregion

    }
}
