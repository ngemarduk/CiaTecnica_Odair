CREATE OR REPLACE PROCEDURE PESSOA_JURIDICA_CADASTRA (
	:CNPJ IN PESSOA_JURIDICA.CNPJ%TYPE,
	:NOMEFANTASIA IN PESSOA_JURIDICA.NOMEFANTASIA%TYPE,
	:RAZAOSOCIAL IN PESSOA_JURIDICA.RAZAOSOCIAL%TYPE,
	:CEP IN ENDERECO.CEP%TYPE,
	:BAIRRO IN ENDERECO.BAIRRO%TYPE,
	:CIDADE IN ENDERECO.CIDADE%TYPE,
	:LOGRADOURO IN ENDERECO.LOGRADOURO%TYPE,
	:COMPLEMENTO IN ENDERECO.COMPLEMENTO%TYPE,
	:NUMERO IN ENDERECO.NUMERO%TYPE,
	:UF IN ENDERECO.UF%TYPE
	
) AS
DECLARE
  enderecoID int;
  pessoaID int;
BEGIN

	INSERT INTO 
		PESSOA_JURIDICA
		( 
		CNPJ, 
		NOMEFANTASIA, 
		RAZAOSOCIAL
		) 
	VALUES
		(
		:CNPJ, 
		:NOMEFANTASIA, 
		:RAZAOSOCIAL);
	
	INSERT INTO 
		ENDERECO
		(
		CEP,
		BAIRRO,
		CIDADE,
		LOGRADOURO,
		COMPLEMENTO,
		NUMERO,
		UFCOMPLETO
		)
	VALUES
		(
		:CEP,
		:BAIRRO,
		:CIDADE,
		:LOGRADOURO,
		:COMPLEMENTO,
		:NUMERO,
		:UFCOMPLETO
		);
	
	SELECT ENDERECOSEQ.currval into enderecoID FROM dual;
	SELECT PESSOA_JURIDICASEQ.currval into pessoaID FROM dual;
	
	UPDATE
		PESSOA_JURIDICA
	SET
		IDENDERECO = enderecoID
	WHERE
		ID = pessoaID;
	
	
	COMMIT;
	
END PESSOA_JURIDICA_CADASTRA;