Funcionalidade: Cadastrar cliente
	como um novo cliente eu quero realizar
	o cadastro da minha conta

@API_CadastroCliente

Cenario: Cadastro de cliente com sucesso
	permitir que um cliente realize o cadastro com sucesso

Dado que preciso gerar um usuario cliente
Quando requisito API de cadastro com nome e email validos
Entao deve cadastrar com sucesso 

