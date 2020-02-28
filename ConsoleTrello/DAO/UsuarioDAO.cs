using System;
using System.Collections.Generic;
using ConsoleTrello.BO;
using br.Factory;
namespace ConsoleTrello.DAO
{
    public class UsuarioDAO : ObjectModel, IEntityManagerCRUD<UsuarioBO>, IDisposable
    {
        private EntityManager<UsuarioBO> entityManager;
        private DataBaseContext dataBase;
        public UsuarioDAO(DataBaseContext dataBase)
        {
            if (dataBase != null)
                this.dataBase = dataBase;
            else
                this.dataBase = new DataBaseContext();

            this.entityManager = new EntityManager<UsuarioBO>(dataBase);
            dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        public UsuarioDAO()
        {
            this.entityManager = new EntityManager<UsuarioBO>();
            this.entityManager.DataBase.OnDataBaseInfoExecute += EventoLog;
            this.dataBase = new DataBaseContext();
            this.dataBase.OnDataBaseInfoExecute += EventoLog;
        }
        protected void EventoLog(object sender, DataBaseInfoExecuteEventArgs e)
        {
        }
        public void Alterar(UsuarioBO obj, bool propriedadesModificadas)
        {
            this.entityManager.Alterar(obj, propriedadesModificadas);
            this.SetResultMessage(this.entityManager);
        }
        public void Alterar(UsuarioBO obj)
        {
            this.entityManager.Alterar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(UsuarioBO obj, CondicaoSql condicaoSql)
        {
            this.entityManager.Consultar(obj, condicaoSql);
            this.SetResultMessage(this.entityManager);
        }
        public void Consultar(UsuarioBO obj)
        {
            this.entityManager.Consultar(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Excluir(UsuarioBO obj)
        {
            this.entityManager.Excluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public void Incluir(UsuarioBO obj)
        {
            this.entityManager.Incluir(obj);
            this.SetResultMessage(this.entityManager);
        }
        public List<UsuarioBO> Listar(CondicaoSql condicaoSql)
        {
            List<UsuarioBO> lista = entityManager.Listar(condicaoSql);
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
        ~UsuarioDAO()
        {
            this.Dispose();
        }
        #endregion

    }
}
