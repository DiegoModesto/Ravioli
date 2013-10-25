-- =============================================
-- Author:		Diego Sanches
-- Create date: 16/10/2013
-- Description:	Insere uma nova notificação, retorna 1 para alterado, 0 para nada feito.
-- =============================================
/*
ALTER PROCEDURE [dbo].[Sys_NotificacaoInsere]
	@acao AS INT,
	@usuarioId AS INT,
	@usuarioExId AS INT = NULL,

	@artigoId AS INT = NULL,
	@comentarioId AS INT = NULL,
	@pratoId AS INT = NULL,
	@restauranteId AS INT = NULL,
	@reservaId AS INT = NULL,

	@usuarioInseridoId AS INT = NULL,
	@usuarioInteridoExId AS INT = NULL
AS
BEGIN*/
	DECLARE @mensagemId AS INT = 0
	DECLARE @departamentoId AS INT = 0
	--======================================TESTES===================================================
	/*
	CREATE TABLE #tbNotificacao(
		id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
		mensagemId int NOT NULL,
		tipoId int NOT NULL,
		usuarioInseridoId int NULL,
		usuarioInseridoExId int NULL,
		reservaId int NULL,
		artigoId int NULL,
		pratoId int NULL,
		comentarioId int NULL,
		usuarioId int NULL,
		usuarioExId int NULL,
		restauranteId int NULL
	)
	*/
	DECLARE @acao AS INT = NULL
	DECLARE @usuarioId AS INT = NULL
	DECLARE @usuarioExId AS INT = NULL

	DECLARE @artigoId AS INT = NULL
	DECLARE @comentarioId AS INT = NULL
	DECLARE @pratoId AS INT = NULL
	DECLARE @restauranteId AS INT = NULL
	DECLARE @reservaId AS INT = NULL

	DECLARE @usuarioInseridoId AS INT = NULL
	DECLARE @usuarioInteridoExId AS INT = NULL
	--======================================TESTES===================================================

	--====================================Verificação================================================
		IF @acao = 1 --Inclusão
	BEGIN
		IF @artigoId IS NOT NULL
			BEGIN
				SET @mensagemId = 10
				SET @departamentoId = 4
			END
		ELSE IF @comentarioId IS NOT NULL
			BEGIN
				SET @mensagemId = 16
				SET @departamentoId = 4
			END
		ELSE IF @pratoId IS NOT NULL
			BEGIN
				SET @mensagemId = 13
				SET @departamentoId = 4
			END
		ELSE IF @restauranteId IS NOT NULL
			BEGIN
				SET @mensagemId = 20
				SET @departamentoId = 3
			END
		ELSE IF @reservaId IS NOT NULL
			BEGIN
				SET @mensagemId = 7
				SET @departamentoId = 5
			END
		ELSE IF @usuarioInseridoId IS NOT NULL
			BEGIN
				SET @mensagemId = 1
				SET @departamentoId = 3
			END
		ELSE IF @usuarioInteridoExId IS NOT NULL
			BEGIN
				SET @mensagemId = 4
				SET @departamentoId = 3
			END
	END
	ELSE IF @acao = 2 --Modificação
	BEGIN
		IF @artigoId IS NOT NULL
			BEGIN
				SET @mensagemId = 11
				SET @departamentoId = 4
			END
		ELSE IF @comentarioId IS NOT NULL
			BEGIN
				SET @mensagemId = 17
				SET @departamentoId = 4
			END
		ELSE IF @pratoId IS NOT NULL
			BEGIN
				SET @mensagemId = 14
				SET @departamentoId = 4
			END
		ELSE IF @restauranteId IS NOT NULL
			BEGIN
				SET @mensagemId = 21
				SET @departamentoId = 3
			END
		ELSE IF @reservaId IS NOT NULL
			BEGIN
				SET @mensagemId = 8
				SET @departamentoId = 5
			END
		ELSE IF @usuarioInseridoId IS NOT NULL
			BEGIN
				SET @mensagemId = 2
				SET @departamentoId = 3
			END
		ELSE IF @usuarioInteridoExId IS NOT NULL
			BEGIN
				SET @mensagemId = 5
				SET @departamentoId = 3
			END
	END
	ELSE IF @acao = 3 --Exclusão
	BEGIN
		IF @artigoId IS NOT NULL
			BEGIN
				SET @mensagemId = 12
				SET @departamentoId = 4
			END
		ELSE IF @comentarioId IS NOT NULL
			BEGIN
				SET @mensagemId = 18
				SET @departamentoId = 4
			END
		ELSE IF @pratoId IS NOT NULL
			BEGIN
				SET @mensagemId = 15
				SET @departamentoId = 4
			END
		ELSE IF @restauranteId IS NOT NULL
			BEGIN
				SET @mensagemId = 22
				SET @departamentoId = 3
			END
		ELSE IF @reservaId IS NOT NULL
			BEGIN
				SET @mensagemId = 9
				SET @departamentoId = 5
			END
		ELSE IF @usuarioInseridoId IS NOT NULL
			BEGIN
				SET @mensagemId = 3
				SET @departamentoId = 3
			END
		ELSE IF @usuarioInteridoExId IS NOT NULL
			BEGIN
				SET @mensagemId = 6
				SET @departamentoId = 3
			END
	END
	--====================================Verificação================================================
	
	IF @departamentoId != 0 AND @mensagemId != 0
		BEGIN
			INSERT INTO #tbNotificacao
			(
				mensagemId,
				tipoId,
				usuarioInseridoId,
				usuarioInseridoExId,
				reservaId,
				artigoId,
				pratoId,
				comentarioId,
				usuarioId,
				usuarioExId,
				restauranteId
			)
			VALUES
			(
				@mensagemId,
				@acao,
				@usuarioInseridoId,
				@usuarioInteridoExId,
				@reservaId,
				@artigoId,
				@pratoId,
				@comentarioId,
				@usuarioId,
				@usuarioExId,
				@restauranteId
			)
			SELECT 1
		END
	ELSE
		BEGIN
			SELECT 0
		END
	

/*END*/