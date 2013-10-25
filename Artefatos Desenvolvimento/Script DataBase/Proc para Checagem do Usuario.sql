SELECT
	U.id AS [IdUsuario],
	R.id AS [IdRestaurante],
	UD.id AS [IdDepartamento],
	UP.id AS [IdUsuarioPai],
	UC.id AS [IdCargo],
	U.nome AS [NomeUsuario],
	U.email AS [EMailUsuario],
	U.senha AS [SenhaUsuario],
	R.nome AS [NomeRestaurante],
	UD.nome AS [NomeDepartamento],
	UP.nome AS [NomeUsuarioPai]
FROM
	tbUsuario U
	INNER JOIN tbUsuarioDepartamento UD ON U.departamentoId = UD.id
	INNER JOIN tbUsuarioCargo UC ON U.cargoId = UC.id
	LEFT JOIN tbRestaurante R ON R.id = U.restauranteId
	LEFT JOIN tbUsuario UP ON U.usuarioId = UP.id
WHERE U.email = 'diego@ravioli.com.br'
	AND U.senha = '123mudar'