# Notification.API
Este é um projeto feito para estudo de mensageria utilizando o <strong>RabbitMQ</strong> com <strong>MassTransit.</strong>
Foi implementado a WebAPI como produtor de mensagens e uma camada de Worker como o consumidor. Além das camadas de Infraestrutura e Domínio compartilhadas.

## GitHub Actions
O Github Actions está sendo utilizado para controle da pipeline. Onde, toda vez que ocorre uma alteração no código, são executados os passos de validação do código, build, etc, além da execução dos testes unitários e integrados.

## Usage - Testes na aplicação
Para testar localmente, executar o docker-compose disponível no repositório. Ele irá subir a instância local do RabbitMQ e também o sql local para armazenamento das mensagens na tabela dbo.Notification.
Subir a aplicação com múltiplos startup projects, definindo o worker e a WebApi para inicialização. O endpoint SendMessage irá enviar a mensagem para a fila do RabbitMQ e o Worker irá consumir essa mensagem, inserindo no banco de dados local Sql.

### 1. Criar uma nova mensagem

- **URL:** `http://localhost:5117/api/Notification/SendMessage`
- **Método HTTP:** POST
- **Descrição:** Cria uma nova mensagem.

Exemplo mensagem:
{
  "message": "string",
  "creationDate": "2024-01-10"
}

## Implementação dos testes automatizados
A aplicação possui testes automatizados implementados com as seguintes bibliotecas:

- NUnit: Framework de teste unitário.
- MoQ: Utilizado para criar mocks durante os testes.
- FluentAssertions: Facilita a criação de asserções legíveis nos testes.
- AutoFixture: Para facilitar a geração de dados dos mocks.
