# case_itau_net_core
Case de engenharia Itau - .Net

1. INTRODUÇÃO

NESTE PROJETO ESTA SENDO UTILIZADA A BASE DE DADOS SQLITE (ARQUIVO dbCaseItau.s3db) COM AS SEGUINTES TABELAS:

	TABELA: TIPO_FUNDO - "LISTA DOS TIPOS DE FUNDOS EXISTENTES"
	- CODIGO      - INT         NOT NULL - PRIMARY KEY
	- NOME        - VARCHAR(20) NOT NULL

	TABELA: FUNDO - "REGISTRO RELACIONADOS AO CADASTRO DE FUNDOS"
	- CODIGO      - VARCHAR(20)  UNIQUE NOT NULL - PRIMARY KEY
	- NOME        - VARCHAR(100)        NOT NULL
	- CNPJ        - VARCHAR(14)  UNIQUE NOT NULL
	- CODIGO_TIPO - INT                 NOT NULL - FOREIGN KEY TIPO_FUNDO(CODIGO)
	- PATRIMONIO  - NUMERIC                 NULL

OBS.: VOCÊ PODE FAZER O USO DO SQLITE ADMIN (http://sqliteadmin.orbmu2k.de/) PARA VISUALIZAR TODAS AS TABELAS E SEUS RESPECTIVOS DADOS

NO PROJETO CaseItau.API FOI DISPONIBILIZADA UMA API DE FUNDOS COM OS MÉTODOS ABAIXO REALIZANDO AÇÕES DIRETAS NA BASE DE DADOS:

	GET                        - LISTAR TODOS OS FUNDOS CADASTRADOS
	GET    {CODIGO}            - RETORNAR OS DETALHES DE UM DETERMINADO FUNDO PELO CÓDIGO
	POST   {FUNDO}             - REALIZA O CADASTRO DE UM NOVO FUNDO
	PUT    {CODIGO}            - EDITA O CADASTRO DE UM FUNDO JÁ EXISTENTE
	DELETE {CODIGO}            - EXCLUI O CADASTRO DE UM FUNDO
	PUT    {CODIGO}/patrimonio - ADICIONA OU SUBTRAI DETERMINADO VALOR DO PATRIMONIO DE UM FUNDO
	
PARA A REALIZAÇÃO DAS AÇÕES ABAIXO, VOCÊ DEVE FAZER UM FORK DO PROJETO NA SUA CONTA DO GITHUB E ENVIAR UMA

2. AÇÕES A SEREM REALIZADAS

A. O CÓDIGO DA API DE FUNDOS ESTA DESATUALIZADO, FAZ MAL USO DOS OBJETOS E NÃO SEGUE BOAS PRÁTICAS. REFATORE O CÓDIGO UTILIZANDO AS MELHORES BIBLIOTECAS, PRÁTICAS E PATTERNS

B. APÓS A INCLUSÃO DE UM NOVO FUNDO, OS MÉTODOS GET DA API DE FUNDOS ESTÃO RETORNANDO ERRO. IDENTIFIQUE E CORRIJA O ERRO

C. CRIE UMA APLICAÇÃO (WEB OU CONSOLE) QUE CONSUMA TODOS OS MÉTODOS DA API DE FUNDOS

D. GARANTA A QUALIDADE DA SUA APLICAÇÃO

