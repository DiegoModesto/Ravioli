DROP DATABASE admin_reservas
GO

CREATE DATABASE admin_reservas
GO

USE admin_reservas
GO

/*Tabelas de Status - Auxiliadores*/

CREATE TABLE tbUsuarioStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbHistoricoTipo(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbUsuarioDepartamentoStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbPratoStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbRestauranteStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbReservaStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbArtigoStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbPratoCategoriaStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbUsuarioCargoStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbArtigoCategoriaStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbArtigoCategoria(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, statusId INT NOT NULL)
GO

CREATE TABLE tbArtigoComentarioStatus(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbUsuarioExternoTipoPerfil(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbUsuarioNivel(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbUsuarioCargo(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, statusId INT NOT NULL)
GO

CREATE TABLE tbUsuarioDepartamento(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, statusId INT NOT NULL)
GO

CREATE TABLE tbPratoCategoria(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, statusId INT NOT NULL)
GO

CREATE TABLE tbReservaOrigem(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLe tbUsuario(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, email VARCHAR(120) NOT NULL, senha VARCHAR(30) NOT NULL, restauranteId INT NOT NULL, departamentoId INT NOT NULL, statusId INT NOT NULL, nivelId INT NOT NULL, cargoId INT NOT NULL, usuarioId INT NULL, sobre VARCHAR(200) NOT NULL)
GO

CREATE TABLE tbArtigoTags(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, artigoId INT NOT NULL)
GO

CREATE TABLE tbArtigo(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, titulo VARCHAR(60) NOT NULL, subtitulo VARCHAR(120) NOT NULL, imgThumb VARCHAR(30) NULL, conteudo TEXT NOT NULL, usuarioId INT NOT NULL, statusId INT NOT NULL, categoriaId INT NOT NULL, dtCriacao DATETIME NOT NULL, dtPublicacaoInicio DATE NULL, hrPublicacaoInicio TIME NULL, dtPublicacaoFim DATE NULL, hrPublicacaoFim TIME NULL, nomeAutor VARCHAR(60) NULL)
GO

CREATE TABLE tbReserva(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, dtCriacao DATETIME NOT NULL, dataReserva DATE NOT NULL, horaReserva TIME NOT NULL, pessoasReserva INT NOT NULL, observacao VARCHAR(120) NULL, favoritado BIT NOT NULL, usuarioId INT NULL, restauranteId INT NOT NULL, statusId INT NOT NULL, origemId INT NOT NULL, usuarioExternoId INT NOT NULL, efetuado BIT NOT NULL)
GO

CREATE TABLE tbPrato(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, titulo VARCHAR(60) NOT NULL, descricao VARCHAR(120) NOT NULL, valor DECIMAL NULL, statusId INT NOT NULL, categoriaId INT NOT NULL, usuarioId INT NOT NULL, dtCriacao DATETIME NOT NULL)
GO

CREATE TABLE tbRestaurante(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, endereco VARCHAR(120), dtCadastro DATETIME NOT NULL, usuarioId INT NOT NULL, statusId INT NOT NULL)
GO

CREATE TABLE tbPratoRestaurante(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, pratoId INT NOT NULL, restauranteId INT NOT NULL)
GO

CREATE TABLE tbUsuarioExterno(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL, email VARCHAR(120) NOT NULL, celular VARCHAR(16) NULL, telefone VARCHAR(16) NULL, tipoPerfilId INT NOT NULL)
GO

CREATE TABLE tbHistorico(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, mensagem VARCHAR(120) NOT NULL, dataCriacao DATETIME NOT NULL, tipoId INT NOT NULL, usuarioId INT NOT NULL)
GO

CREATE TABLE tbNotificacaoTipo(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbNotificacaoAcao(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbNotificacaoAlvo(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, nome VARCHAR(60) NOT NULL)
GO

CREATE TABLE tbNotificacao(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, tipoId INT NULL, artigoCategoriaId INT NULL, pratoId INT NULL, pratoCategoriaId INT NULL, acaoId INT NOT NULL, usuarioId INT NULL, usuarioExternoId INT NULL, mensagem VARCHAR(120) NULL, alvoId INT NOT NULL)
GO