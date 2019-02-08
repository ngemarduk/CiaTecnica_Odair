CREATE OR REPLACE PROCEDURE PESSOA_JURIDICA_DADOS (:ID IN PESSOA_JURIDICA.ID%TYPE) AS 
BEGIN
	SELECT 
		PJ.ID, 
		PJ.CNPJ, 
		PJ.NOMEFANTASIA, 
		PJ.RAZAOSOCIAL, 
		E.CEP, 
		E.BAIRRO,
		E.CIDADE,
		E.LOGRADOURO,
		E.COMPLEMENTO,
		E.NUMERO,
		E.UFCOMPLETO
	FROM 
		PESSOA_JURIDICA PJ
		JOIN
		ENDERECO E
			ON
			PJ.IDENDERECO = E.IDENDERECO
	WHERE
		PJ.ID = :ID
	;
    
END PESSOA_JURIDICA_DADOS;