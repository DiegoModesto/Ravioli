/*

SELECT
	G1.titulo AS [Artigo],
	P1.titulo AS [Prato],
	R1.nome AS [Restaurante],
	U1.nome AS [UsrCadastro],
	U2.nome AS [UsrExterno],
	A2.nome AS [Tipo],
	A2.id AS [ID],
	A4.nome AS [Acao],
	A3.nome AS [Alvo],
	A1.mensagem AS [Mensagem]
FROM tbNotificacao A1
	INNER JOIN tbNotificacaoTipo A2 ON A1.tipoId = A2.id
	INNER JOIN tbNotificacaoAlvo A3 ON A1.alvoId = A3.id
	INNER JOIN tbNotificacaoAcao A4 ON A1.acaoId = A4.id
	LEFT JOIN tbRestaurante R1 ON R1.id = A1.restauranteId
	LEFT JOIN tbUsuario U1 ON U1.id = A1.usuarioId
	LEFT JOIN tbUsuarioExterno U2 ON U2.id = A1.usuarioExternoId
	LEFT JOIN tbPrato P1 ON P1.id = A1.pratoId
	LEFT JOIN tbArtigo G1 ON G1.id = A1.artigoId


tbNotificacaoAcao
id	nome
1	Adicionar
2	Excluir
3	Bloquear
4	Alterar

tbNotificacaoAlvo
id	nome
1	Usuário Interno
2	Usuário Externo
3	Restaurante
4	Sistema
5	Próprio
6	Artigos

tbNotificacaoTipo
id	nome
1	Global.......................Funciona para Qualquer UsuarioCategoria
2	Adm. Geral...................Funciona para UsuarioCategoria = 3
3	Adm. Comercial...............Funciona para UsuarioCategoria = 5
4	Adm. Conteúdo................Funciona para UsuarioCategoria = 4
5	Adm. Comercial com Geral.....Funciona para UsuarioCategoria = 5 e 3
6	Adm. Conteúdo com Geral......Funciona para UsuarioCategoria = 4 e 3

UPDATE tbNotificacao SET artigoId = 0, usuarioId = 1, mensagem = 'Dados alterados' WHERE id = 5

tbRestaurante
id	nome						endereco										dtCadastro					usuarioId	statusId
1	Empório Ravioli				Rua Fidêncio Ramos, 18 - Vila Olimpia			2013-10-15 12:20:15.810		1			1
2	Ravioli Cucina Casalinga	Rua Joaquim Antunes, 197 - Jardim Paulistano	2013-10-15 12:20:15.810		3			2
3	La Madonnina Ravioli		Rua Hélio Pellegrino, 204 - Vl. Nova Conceição	2013-10-15 12:20:15.810		4			1

tbArtigo
id	usuarioId
2	3
3	4
*/



SELECT * FROM tbNotificacao
SELECT * FROM tbUsuarioNotificacao

