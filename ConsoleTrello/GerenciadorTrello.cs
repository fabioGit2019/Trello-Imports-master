using br.Factory;
using ConsoleTrello.BO;
using ConsoleTrello.DTC;
using ConsoleTrello.Interfaces;
using ConsoleTrello.Objetos;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ConsoleTrello
{
    public class GerenciadorTrello : IGerenciadorTrello
    {
        #region propriedades        
        protected string lBackLog
        {
            get
            {
                return "5d6d25bf6330e8379d698585";
            }
        }
        protected string lAnaliseUltraCargo
        {
            get
            {
                return "5d6d2604a3128b7660b6d354";
            }
        }

        protected string lSelGrooming
        {
            get
            {
                return "5d6d261ad7f14a847de50357";
            }
        }

        protected string lDesenvolvimento
        {
            get
            {
                return "5d6d262916bfba7c3a83a2f1";
            }
        }

        protected string lUatDes
        {
            get
            {
                return "5d6d264cf742f075ef752c62";
            }
        }

        protected string lReadyForHML
        {
            get
            {
                return "5d6d2668d7f14a847de51634";
            }
        }

        protected string lUatHML
        {
            get
            {
                return "5d6d266e8575e71d8e5b95d3";
            }
        }

        protected string lPRD
        {
            get
            {
                return "5d6d26b47dd6de7db7572373";
            }
        }

        protected string lReadyForPRD
        {
            get
            {
                return "5d836c1ef3f67c32a79de120";
            }
        }

        protected string lHold
        {
            get
            {
                return "5db1cc23d5139302e1e53473";
            }
        }

        protected string lLblCorretivo
        {
            get
            {
                return "5d70736d21f62b8400fc7f89";
            }
        }

        protected string lLblMelhoria
        {
            get
            {
                return "5d7073db3c380f850c258ab5";
            }
        }

        protected string lLblRetrabalho
        {
            get
            {
                return "5d7073f691cd771b02366b6e";
            }
        }

        protected string arqRet { get; set; }

        protected bool mostraMsgListBox { get; set; }

        protected bool importacaoWEB { get; set; }

        protected string myKey
        {
            get
            {
                //gerar em: https://trello.com/app-key
                return ConfigurationManager.AppSettings["myKeyTrello"];
            }
        }
        protected string myToken
        {
            get
            {
                //gerar em: https://trello.com/app-key
                return ConfigurationManager.AppSettings["myTokenTrello"];
            }
        }
        protected string myBoard
        {
            get
            {
                return "hRfXzW40";
            }
        }

        protected bool importarCartoesArquivados { get; set; }
        #endregion

        #region obetos
        IBarraProgresso bp;
        System.Net.WebClient webclient;
        #endregion

        public GerenciadorTrello(string pathTrello, bool mostraMsgListBox, bool importacaoWEB, bool importarCartoesArquivados)
        {
            this.arqRet = pathTrello;
            this.mostraMsgListBox = mostraMsgListBox;
            this.importacaoWEB = importacaoWEB;
            this.importarCartoesArquivados = importarCartoesArquivados;

            bp = new BarraProgresso(this.mostraMsgListBox);
        }

        #region Importações da API Trello
        private void SerializarObjeto()
        {
            webclient = new System.Net.WebClient();            
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
        }
        private List1[] ObterTodasListas()
        {                        
            SerializarObjeto();                                   
            String content = webclient.DownloadString(string.Format("https://api.trello.com/1/boards/{0}/lists?fields=all&filter=all&key={1}&token={2}", myBoard, myKey, myToken));
            return JsonConvert.DeserializeObject<List1[]>(content);
        }

        private Member2[] ObterTodosUsuarios()
        {
            SerializarObjeto();
            String content = webclient.DownloadString(string.Format("https://api.trello.com/1/boards/{0}/members/?fields=all&key={1}&token={2}", myBoard, myKey, myToken));
            return JsonConvert.DeserializeObject<Member2[]>(content);
        }

        private Card1[] ObterTodosCartoes(bool Arquivado)
        {
            SerializarObjeto();
            String content = webclient.DownloadString(string.Format("https://api.trello.com/1/boards/{0}/cards/?{3}fields=all&key={1}&token={2}", myBoard, myKey, myToken, Arquivado ? "filter=all&" : string.Empty));
            return JsonConvert.DeserializeObject<Card1[]>(content);
        }

        private Action[] ObterTodasAcoes()
        {
            SerializarObjeto();
            String content = webclient.DownloadString(string.Format("https://api.trello.com/1/boards/{0}/actions/?filter=all&fields=all&key={1}&token={2}", myBoard, myKey, myToken));
            return JsonConvert.DeserializeObject<Action[]>(content);
        }

        private customFieldItems[] ObterCustomFieldItemsCartao(string myCard)
        {
            SerializarObjeto();
            String content = webclient.DownloadString(string.Format("https://api.trello.com/1/cards/{0}/customFieldItems/?filter=all&key={1}&token={2}", myCard, myKey, myToken));
            return JsonConvert.DeserializeObject<customFieldItems[]>(content);
        }

        private Action[] obterActionsCartao(string myCard)
        {
            SerializarObjeto();
            String content = webclient.DownloadString(string.Format("http://api.trello.com/1/cards/{0}/actions/?filter=all&key={1}&token={2}", myCard, myKey, myToken));
            return JsonConvert.DeserializeObject<Action[]>(content);
        }
        private Label1[] obterTodasLabels()
        {
            SerializarObjeto();
            String content = webclient.DownloadString(string.Format("http://api.trello.com/1/boards/{0}/labels/?&filter=all&fields=all&key={1}&token={2}", myBoard, myKey, myToken));
            return JsonConvert.DeserializeObject<Label1[]>(content);
        }
        #endregion

        #region Persistencias
        private void AtualizaListaAnteriorAcoes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseDefault"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("dbo.SP_AtlzListaAnterior", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        private void PersistirAcoes(ref Action[] minhasAcoes, ref ProgressBar progressBar1, ref ListBox lbxProgresso, DataBaseContext dtb, string idCartao)
        {
            //var dtcCartao = new CartaoDTC(dtb);
            var dtcAcao = new AcaoDTC(dtb);


            if (string.IsNullOrEmpty(idCartao))
                bp.IniciarProgresso(ref progressBar1, ref lbxProgresso, "LOG: Atualizando Fases dos Chamados...", minhasAcoes.Length);

            foreach (var item in minhasAcoes)
            {
                if (string.IsNullOrEmpty(idCartao))
                    bp.IncrementarBarra(ref progressBar1, ref lbxProgresso);

                using (AcaoBO acao = new AcaoBO())
                {
                    acao.AcaoId = item.id;
                    dtcAcao.Consultar(acao);
                    if (item.data.card != null)
                    {
                        acao.CartaoId = item.data.card.id;
                        acao.DataAcao = item.date;

                        if (item.data.list != null)
                        {
                            acao.ListaId = item.data.list.id;
                        }
                        else if (item.data.listAfter != null)
                        {
                            acao.ListaId = item.data.listAfter.id;
                        }
                        else
                        {
                            acao.ListaId = string.Empty;
                        }
                        //else
                        //{
                        //    using (CartaoBO cartaoBO = new CartaoBO())
                        //    {
                        //        cartaoBO.CartaoId = item.data.card.id;
                        //        dtcCartao.Consultar(cartaoBO);

                        //        if (cartaoBO.IdLista != null)
                        //            acao.ListaId = cartaoBO.IdLista;
                        //    }
                        //}

                        if (item.data.member == null)
                            acao.UsuarioId = item.memberCreator.id;
                        else
                            acao.UsuarioId = item.data.member.id;

                        acao.Finalizado = (item.data.card.closed ? 1 : 0);

                        if (dtcAcao.ResultState == ResultTypeEnum.DataFound)
                            dtcAcao.Alterar(acao);
                        else
                            dtcAcao.Incluir(acao);
                    }
                }
            }
        }
        #endregion

        public bool AtualizarTrello(ref ProgressBar progressBar1, ref ListBox lbxProgresso)
        {
            try
            {                
                #region converte o JSON em classe .NET
                Trellos cartao = null;
                lbxProgresso.Items.Clear();

                if (!importacaoWEB)
                {
                    bp.IncrementarBarra(ref progressBar1, ref lbxProgresso, "LOG: Carregando arquivo Trello [" + arqRet + " ]");

                    if (!File.Exists(arqRet))
                    {
                        bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "ERROR: Arquivo Trello[" + arqRet + "] não  Localizado");
                        return false;
                    }

                    StreamReader txt = new StreamReader(arqRet, System.Text.Encoding.Default);
                    String content = txt.ReadToEnd();
                    txt.Close();

                    try
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Converters.Add(new JavaScriptDateTimeConverter());
                        serializer.NullValueHandling = NullValueHandling.Ignore;
                        cartao = JsonConvert.DeserializeObject<Trellos>(content);
                    }
                    catch (Exception ex)
                    {
                        bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "ERROR: Erro fazendo Leitura(de - serialização) do arquivo Trello, \nO processo não poderá ser seguido, extraia o arquivo e tente novamente " + ex.Message);
                        return false;
                    }
                }
                #endregion

                using (DataBaseContext dtb = new DataBaseContext())
                {
                    try
                    {
                        dtb.BeginTransaction();
                        List1[] minhasListas;
                        Member2[] meusUsuarios;
                        Card1[] meusCartoes;
                        Action[] minhasAcoes;

                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                        #region Listas                         
                        if (!importacaoWEB)
                            minhasListas = cartao.lists;
                        else
                            minhasListas = ObterTodasListas();

                        var dtcLista = new ListaDTC(dtb);
                        var dtcCartao = new CartaoDTC(dtb);

                        bp.IniciarProgresso(ref progressBar1, ref lbxProgresso, "LOG: Atualizando Listas...", minhasListas.Length);
                        foreach (var item in minhasListas)
                        {
                            bp.IncrementarBarra(ref progressBar1, ref lbxProgresso);
                            using (ListaBO lista = new ListaBO())
                            {
                                lista.ListaId = item.id;
                                lista.Lista = item.name;

                                dtcLista.Consultar(lista);
                                if (dtcLista.ResultState == ResultTypeEnum.DataFound)
                                    dtcLista.Alterar(lista);
                                else
                                    dtcLista.Incluir(lista);
                            }
                        }
                        #endregion

                        #region usuarios                          
                        if (!importacaoWEB)
                            meusUsuarios = cartao.members;
                        else
                            meusUsuarios = ObterTodosUsuarios();

                        bp.IniciarProgresso(ref progressBar1, ref lbxProgresso, "LOG: Atualizando usuários...", meusUsuarios.Length);
                        foreach (var item in meusUsuarios)
                        {
                            using (UsuarioBO usuario = new UsuarioBO())
                            {
                                bp.IncrementarBarra(ref progressBar1, ref lbxProgresso);
                                var dtcUser = new UsuarioDTC(dtb);
                                usuario.UsuarioId = item.id;
                                dtcUser.Consultar(usuario);
                                usuario.Nome = item.fullName;
                                usuario.Email = item.username + "@";

                                if (dtcUser.ResultState == ResultTypeEnum.DataFound)
                                    dtcUser.Alterar(usuario);
                                else
                                    dtcUser.Incluir(usuario);
                            }
                        }
                        #endregion

                        #region cartoes - Chamados                           
                        if (!importacaoWEB)
                            meusCartoes = cartao.cards;
                        else
                            meusCartoes = ObterTodosCartoes(this.importarCartoesArquivados);

                        bp.IniciarProgresso(ref progressBar1, ref lbxProgresso, "LOG: Atualizando Cartões...", meusCartoes.Length);
                        foreach (var item in meusCartoes)
                        {
                            bp.IncrementarBarra(ref progressBar1, ref lbxProgresso);
                            using (CartaoBO card = new CartaoBO())
                            {
                                card.CartaoId = item.id;
                                dtcCartao.Consultar(card);

                                card.Texto = item.name;
                                card.Finalizado = 0;
                                if (item.due != null)
                                    card.DataPrometida = (DateTimeField)item.due;

                                card.Link = item.shortUrl;
                                if (item.labels.Length > 0)
                                {
                                    card.Tipo = item.labels.Where(ct => ct.id == lLblCorretivo).ToList().Count() > 0 ? "Corretivo" :
                                                item.labels.Where(ct => ct.id == lLblMelhoria).ToList().Count() > 0 ? "Melhoria" : string.Empty;
                                    if (card.Tipo == string.Empty)
                                        card.Tipo = item.labels[0].name;
                                }

                                if (item.idMembers.Length > 0)
                                    card.UsuarioId = item.idMembers[0].ToString();

                                if (item.dateLastActivity != null)
                                    card.DataUltimaAtividade = item.dateLastActivity;

                                card.Retrabalho = item.labels.Where(r => r.id == lLblRetrabalho).ToList().Count();

                                if (!importacaoWEB)
                                    card.UltraCargo = item.customFieldItems.Where(f => f.value.Checked).ToList().Count;
                                else
                                    card.UltraCargo = ObterCustomFieldItemsCartao(item.id).Where(f => f.value.Checked).ToList().Count;

                                card.IdLista = item.idList;

                                if (!importacaoWEB)
                                    minhasAcoes = cartao.actions;
                                else
                                {
                                    minhasAcoes = obterActionsCartao(item.id);
                                    PersistirAcoes(ref minhasAcoes, ref progressBar1, ref lbxProgresso, dtb, item.id);                                                                       
                                }

                                //Consulta direto no arquivo Json
                                foreach (var c in minhasAcoes)
                                {
                                    if (c.data.list != null)
                                    {
                                        if ((c.data.list.id == lSelGrooming) && (c.data.card.id == item.id))
                                        {
                                            card.DataAnalise = card.DataUltimaAtividade;
                                        }
                                        if ((c.data.list.id == lDesenvolvimento) && (c.data.card.id == item.id))
                                        {
                                            card.DataInicioDev = card.DataUltimaAtividade;
                                        }
                                        if ((c.data.list.id == lUatDes) && (c.data.card.id == item.id))
                                        {
                                            card.DataFimDev = card.DataUltimaAtividade;
                                        }
                                        if (((c.data.list.id == lPRD) || (c.data.list.id == lReadyForPRD)) && (c.data.card.id == item.id))
                                        {
                                            card.Finalizado = 1;
                                        }
                                    }
                                }

                                card.Arquivado = (item.closed ? 1 : 0);

                                // Atualiza o cartão/chamado
                                if (dtcCartao.ResultState == ResultTypeEnum.DataFound)
                                    dtcCartao.Alterar(card);
                                else
                                    dtcCartao.Incluir(card);
                            }
                        }
                        #endregion

                        #region ações - Steps (somente se gerar com arquivo)
                        if (!importacaoWEB)
                        {
                            minhasAcoes = cartao.actions;
                            PersistirAcoes(ref minhasAcoes, ref progressBar1, ref lbxProgresso, dtb, string.Empty);
                        }
                        #endregion                       

                        #region finalizando atualizações
                        dtb.Commit();
                        
                        bp.IniciarProgresso(ref progressBar1, ref lbxProgresso, "LOG: Atualizando Listas anteriores...", 1);
                        dtb.BeginTransaction();
                        AtualizaListaAnteriorAcoes();
                        dtb.Commit();

                        bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "LOG: Gerando e-mail de notificação ao gerente do projeto.");
                        IEmail mail = new Email();

                        if (mail.EnviarEmail())
                            bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "OK: Fim da Atualização com sucesso " + DateTime.Now.ToString());
                        else
                            bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "WARNING: Base foi atualizada, mas ocorreu um erro ao gerar e-mail de notificação.");
                        #endregion
                    }
                    catch (Exception ext)
                    {
                        dtb.Rollback();
                        bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "ERROR: Erro na Atualização[ " + ext.Message + "] - Nenhum registro atualizado");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                bp.FinalizarBarraProgresso(ref progressBar1, ref lbxProgresso, "ERROR: Erro - Atualização não Inicializada " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
