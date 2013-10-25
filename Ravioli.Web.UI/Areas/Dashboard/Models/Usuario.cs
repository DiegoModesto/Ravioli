using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ravioli.DAL;

namespace Ravioli.Web.UI.Areas.Dashboard.Models
{
    public class Usuario
    {
        public string Pagina { get; set; }
        public UsuarioDados Dados { get; set; }
        public List<UsuarioNotificacao> Notificacao { get; set; }
        public List<UsuarioMenuEsquerdo> MenuEsquerdo { get; set; }
        public List<UsuarioListaReservas> ListaReservas { get; set; }
        public List<UsuarioListaBlog> ListaBlog { get; set; } 

        public Usuario(string email)
        {
            Dados = new UsuarioDados();
            Notificacao = new List<UsuarioNotificacao>();
            MenuEsquerdo = new List<UsuarioMenuEsquerdo>();

            using (var ctx = new Entities())
            {
                //TODO: Verificar numero de visitas
                Dados.NmVisitas = ctx.tbUsuarioExterno.Count(x => x.statusId.Equals(1)).ToString();
                Dados.NmComentario = ctx.tbArtigoComentario.Count(x => x.statusId.Equals(1)).ToString();
                Dados.NmReservas = ctx.tbReserva.Count(x => x.statusId.Equals(1)).ToString();
                Dados.NmCardapio = ctx.tbPrato.Count(x => x.statusId.Equals(1)).ToString();
                Dados.UEmail = email;
                DadosUsuario(email);

                //TODO: Verificar TipoUsuario para MENU-LATERAL
            }
            Notificacao = BuscarUltimasNotificacoes(Dados.UId);
            MenuEsquerdo = ListarMenuEsquerdo(Dados.UId);
            ListaReservas = ListarReservas();
            ListaBlog = ListarBlog();
        }

        /// <summary>
        /// Efetua a busca das notificaçöes pertencentes ao usuário
        /// </summary>
        private List<UsuarioNotificacao> BuscarUltimasNotificacoes(int usrId)
        {
            using (var ctx = new Entities())
            {
                var lstAdmUsuarioNotificacao = new List<UsuarioNotificacao>();

                #region [Query de Notificações]

                int departamento = Convert.ToInt32((from u in ctx.tbUsuario
                                                    where u.id == usrId
                                                    select u.departamentoId).ToList()[0].ToString());

                var tipo = new List<int>();
                switch (departamento)
                {
                    case 2:
                        tipo.Add(1);
                        tipo.Add(2);
                        tipo.Add(3);
                        tipo.Add(4);
                        tipo.Add(5);
                        tipo.Add(6);
                        break;
                    case 3:
                        tipo.Add(2);
                        tipo.Add(5);
                        tipo.Add(6);
                        break;
                    case 4:
                        tipo.Add(4);
                        tipo.Add(6);
                        break;
                    case 5:
                        tipo.Add(3);
                        tipo.Add(5);
                        break;
                    default:
                        tipo.Add(1);
                        break;
                }

                var busca = from NotfyTipo in ctx.tbNotificacaoTipo
                            join Notfy in ctx.tbNotificacao on NotfyTipo.id equals Notfy.tipoId into ps
                            from Notfy in ps.DefaultIfEmpty()
                            //Left Join

                            join NotfyAlvo in ctx.tbNotificacaoAlvo on Notfy.alvoId equals NotfyAlvo.id
                            //Inner Join
                            join NotfyAcao in ctx.tbNotificacaoAcao on Notfy.acaoId equals NotfyAcao.id
                            //Inner Join

                            join Artigo in ctx.tbArtigo on Notfy.artigoId equals Artigo.id into ap
                            from Artigo in ap.DefaultIfEmpty()
                            //Left Join
                            join Prato in ctx.tbPrato on Notfy.pratoId equals Prato.id into up
                            from Prato in up.DefaultIfEmpty()
                            //Left Join
                            join Usuario in ctx.tbUsuario on Notfy.usuarioId equals Usuario.id into xs
                            from Usuario in xs.DefaultIfEmpty()
                            //Left Join
                            join UsuarioEx in ctx.tbUsuarioExterno on Notfy.usuarioExternoId equals UsuarioEx.id into es
                            from UsuarioEx in es.DefaultIfEmpty()
                            //Left Join

                            where tipo.Contains(Notfy.tipoId)

                            orderby Notfy.id

                            select new
                            {
                                Id = Notfy.id,
                                TipoId = (NotfyTipo.id != null ? NotfyTipo.id : 0),
                                TipoNome = NotfyTipo.nome,
                                ArtigoId = (Artigo.id != null ? Artigo.id : 0),
                                PratoId = (Prato.id != null ? Prato.id : 0),
                                AcaoId = (NotfyAcao.id != null ? NotfyAcao.id : 0),
                                UsuarioId = (Usuario.id != null ? Usuario.id : 0),
                                UsuarioExId = (UsuarioEx.id != null ? UsuarioEx.id : 0),
                                AlvoId = (NotfyAlvo.id != null ? NotfyAlvo.id : 0),
                                Mensagem = Notfy.mensagem
                            };

                #endregion [Query de Notificações]

                if (busca.Count() != 0)
                {
                    int i = 1;
                    foreach (var tabela in busca.ToList())
                    {
                        var objeto = new UsuarioNotificacao();
                        objeto.Id = tabela.Id;
                        objeto.TipoId = tabela.TipoId;
                        objeto.TipoNome = tabela.TipoNome;
                        objeto.ArtigoId = tabela.ArtigoId;
                        objeto.PratoId = tabela.PratoId;
                        objeto.AcaoId = tabela.AcaoId;
                        objeto.UsuarioId = tabela.UsuarioId;
                        objeto.UsuarioExternoId = tabela.UsuarioExId;
                        objeto.AlvoId = tabela.AlvoId;
                        objeto.Mensagem = tabela.Mensagem;
                        objeto.Link = "./Admin/Notificacao/" + tabela.Id;

                        lstAdmUsuarioNotificacao.Add(objeto);
                        i++;
                        if(i > 5)
                            break;
                    }
                }
                else
                    lstAdmUsuarioNotificacao = null;
                return lstAdmUsuarioNotificacao;
            }
        }

        /// <summary>
        /// Efetua a busca da categoria, e popula os itens para o menur lateral
        /// </summary>
        private List<UsuarioMenuEsquerdo> ListarMenuEsquerdo(int usrId)
        {
            #region Departamento Conteudo
            List<int> Conteudo = new List<int>();
            Conteudo.Add(2);
            Conteudo.Add(3);
            Conteudo.Add(4);
            #endregion

            #region Departamento Comercial
            List<int> Comercial = new List<int>();
            Comercial.Add(2);
            Comercial.Add(3);
            Comercial.Add(5);
            #endregion

            List<UsuarioMenuEsquerdo> lst = new List<UsuarioMenuEsquerdo>();
            using (var ctx = new Entities())
            {
                #region [Populando Menu]

                int departamento = Convert.ToInt32(ctx.tbUsuario.Where(x => x.id.Equals(usrId)).Select(x => x.departamentoId).ToList()[0].ToString());

                lst.Add(new UsuarioMenuEsquerdo()
                {
                    Permissao = true,
                    DataOriginalTitle = "Tenha uma visão geral de toda sua área.",
                    DataPlacement = "right",
                    DataToggle = "tooltip",
                    Id = "esq-visao-geral",
                    LinkAction = "../visao-geral",
                    Texto = "Visão Geral",
                    LinkClass = "visao-geral"
                }
                );

                lst.Add(new UsuarioMenuEsquerdo()
                {
                    Permissao = Comercial.Contains( departamento ),
                    DataOriginalTitle = "Veja as reservas do restaurante.",
                    DataPlacement = "right",
                    DataToggle = "tooltip",
                    Id = "esq-reservas",
                    LinkAction = "../reservas",
                    Texto = "Reservas",
                    LinkClass = "reservas"
                }
                );

                lst.Add(new UsuarioMenuEsquerdo()
                {
                    Permissao = Conteudo.Contains(departamento),
                    DataOriginalTitle = "Veja o blog completo.",
                    DataPlacement = "right",
                    DataToggle = "tooltip",
                    Id = "esq-blog",
                    LinkAction = "../blog",
                    Texto = "Blog",
                    LinkClass = "blog"
                }
                );

                lst.Add(new UsuarioMenuEsquerdo()
                {
                    Permissao = Comercial.Contains(departamento),
                    DataOriginalTitle = "Veja o cardápio.",
                    DataPlacement = "right",
                    DataToggle = "tooltip",
                    Id = "esq-cardapio",
                    LinkAction = "../cardapio",
                    Texto = "Cardápio",
                    LinkClass = "cardapio"
                }
                );

                lst.Add(new UsuarioMenuEsquerdo()
                {
                    Permissao = Comercial.Contains(departamento),
                    DataOriginalTitle = "Veja os clientes cadastrados.",
                    DataPlacement = "right",
                    DataToggle = "tooltip",
                    Id = "esq-clientes",
                    LinkAction = "../clientes",
                    Texto = "Clientes",
                    LinkClass = "clientes"
                }
                );

                #endregion [Populando Menu]
            }
            return lst;
        }

        /// <summary>
        /// Efetua a busca do usuário por e-mail e popula propriedades
        /// </summary>
        private void DadosUsuario(string email)
        {
            using (var ctx = new Entities())
            {
                var busca = (from u in ctx.tbUsuario
                             where u.email.Equals(email)
                             select u).ToList();

                Dados.UId = Convert.ToInt32(busca[0].id);
                Dados.UNome = busca[0].nome;
                Dados.URestaurante = busca[0].restauranteId;
                Dados.UDepartamento = busca[0].departamentoId;
                Dados.UNivel = busca[0].nivelId;
                Dados.UCargo = busca[0].cargoId;
                Dados.UUsuarioPai = busca[0].usuarioId;
                Dados.UFoto = busca[0].caminhoFoto == null ? "./Assets/Images/img-default.png" : ("./Artefatos/UsrImg/" + busca[0].caminhoFoto);
            }
        }

        /// <summary>
        /// Lista últimas reservas cadastradas
        /// </summary>
        private List<UsuarioListaReservas> ListarReservas()
        {
            using (var ctx = new Entities())
            {
                List<UsuarioListaReservas> lstReserva = new List<UsuarioListaReservas>();
                var busca = ctx.tbReserva.OrderByDescending(x => x.id).Take(5).ToList();
                foreach (var reserva in busca)
                {
                    UsuarioListaReservas res = new UsuarioListaReservas();
                    res.Id = reserva.id;
                    res.Data = reserva.dataReserva;
                    res.Nome = reserva.tbUsuarioExterno.nome;
                    res.Pessoas = reserva.pessoasReserva;
                    res.Hora = reserva.horaReserva;
                    res.Status =
                            ctx.tbReservaStatus.Where(x => x.id.Equals(reserva.statusId))
                           .Select(x => x.nome)
                           .Take(1)
                           .ToList()[0]
                           .ToString();
                    switch (reserva.statusId)
                    {
                        case 1:
                            res.ClasseStatus = "rtl-er";
                            break;
                        case 2:
                            res.ClasseStatus = "rtl-ok";
                            break;
                        default:
                        case 3:
                            res.ClasseStatus = "rtl-cl";
                            break;
                        case 4:
                            res.ClasseStatus = "rtl-ex";
                            break;
                    }
                    res.UsuarioId = reserva.usuarioId;
                    res.UsuarioExId = reserva.usuarioExternoId;
                    lstReserva.Add(res);
                }
                return lstReserva;
            }
        }

        /// <summary>
        /// Listar últimos posts do blog
        /// </summary>
        /// <returns></returns>
        private List<UsuarioListaBlog> ListarBlog()
        {
            using (var ctx = new Entities())
            {
                List<UsuarioListaBlog> lstBlog = new List<UsuarioListaBlog>();
                var busca = ctx.tbArtigo.OrderByDescending(x => x.id).Take(5).ToList();
                foreach (var artigo in busca)
                {
                    CultureInfo culture = new CultureInfo("pt-BR");
                    UsuarioListaBlog blog = new UsuarioListaBlog();
                    blog.Id = artigo.id;
                    blog.Titulo = artigo.titulo;
                    blog.DataPublicacao = Convert.ToDateTime(artigo.dtPublicacaoInicio,culture).ToString("d");
                    blog.NomeAutor = artigo.nomeAutor;
                    blog.NomeUsuario = ctx.tbUsuario.Where(x => x.id.Equals(artigo.usuarioId)).Select(x => x.nome).Take(1).ToList()[0].ToString();
                    blog.UsuarioId = artigo.usuarioId;
                    blog.QtdComentarios = ctx.tbArtigoComentario.Where(x => x.tbArtigo.id.Equals(artigo.id)).Count();
                    blog.QtdCompartilhados = ctx.tbArtigoCompartilhado.Where(x => x.tbArtigo.id.Equals(artigo.id)).Count();
                    lstBlog.Add(blog);
                }
                return lstBlog;
            }
        }
    }

    [SerializableAttribute]
    public class UsuarioDados
    {
        #region [Dados Usuário]

        public int UId { get; set; }
        public string UNome { get; set; }
        public string UEmail { get; set; }
        public int? URestaurante { get; set; }
        public int UDepartamento { get; set; }
        public int UNivel { get; set; }
        public int UCargo { get; set; }
        public int? UUsuarioPai { get; set; }
        public string UFoto { get; set; }

        #endregion [Dados Usuário]

        #region [Itens para Dashboard]

        public string NmVisitas { get; set; }
        public string NmReservas { get; set; }
        public string NmComentario { get; set; }
        public string NmCardapio { get; set; }
        public List<UsuarioNotificacao> LstNotificacao { get; set; }

        #endregion [Itens para Dashboard]

        #region [Itens para Menu Esquerdo]

        public bool MenuVisaoGeral { get; set; }
        public bool MenuReservas { get; set; }
        public bool MenuBlog { get; set; }
        public bool MenuCardapio { get; set; }
        public bool MenuClientes { get; set; }

        #endregion [Itens para Menu Esquerdo]
    }

    [SerializableAttribute]
    public class UsuarioNotificacao
    {
        #region [Itens de Notificação]

        public int Id { get; set; }
        public int? TipoId { get; set; }
        public string TipoNome { get; set; }
        public int? ArtigoId { get; set; }
        public int? PratoId { get; set; }
        public int AcaoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? UsuarioExternoId { get; set; }
        public int AlvoId { get; set; }
        public string Mensagem { get; set; }
        public string Link { get; set; }

        #endregion [Itens de Notificação]
    }

    [SerializableAttribute]
    public class UsuarioMenuEsquerdo
    {
        #region [Itens de Lista]

        public string Id { get; set; }
        public bool Permissao { get; set; }
        public string DataToggle { get; set; }
        public string DataPlacement { get; set; }
        public string DataOriginalTitle { get; set; }
        public string LinkAction { get; set; }
        public string LinkClass { get; set; }
        public string Texto { get; set; }

        #endregion
    }

    [SerializableAttribute]
    public class UsuarioListaReservas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public int Pessoas { get; set; }
        public TimeSpan Hora { get; set; }
        public string Status { get; set; }
        public string ClasseStatus { get; set; }
        public int? UsuarioId { get; set; }
        public int UsuarioExId { get; set; }
    }

    [SerializableAttribute]
    public class UsuarioListaBlog
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string DataPublicacao { get; set; }
        public string NomeAutor { get; set; }
        public string NomeUsuario { get; set; }
        public int UsuarioId { get; set; }
        public int QtdComentarios { get; set; }
        public int QtdCompartilhados { get; set; }
    }
}