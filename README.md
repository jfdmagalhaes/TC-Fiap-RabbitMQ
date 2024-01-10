# Notification.API
Este é um projeto feito para estudo de mensageria utilizando o <strong>RabbitMQ</strong> com <strong>MassTransit.</strong>
Foi implementado a WebAPI como produtor de mensagens e uma camada de Worker como o consumidor. Além das camadas de Infraestrutura e Domínio compartilhadas.

## GitHub Actions
O Github Actions está sendo utilizado para controle da pipeline. Onde, toda vez que ocorre uma alteração no código, são executados os passos de validação do código, build, etc, além da execução dos testes unitários e integrados.

## Usage - Testes na aplicação
Para testar localmente:

Execute o docker-compose disponível no repositório. Isso iniciará uma instância local do RabbitMQ e do SQL para armazenar as mensagens na tabela dbo.Notification.
```docker-compose up```
Inicie a aplicação com múltiplos projetos de inicialização, configurando o Worker e a WebAPI como startup. O endpoint SendMessage enviará mensagens para a fila do RabbitMQ, enquanto o Worker consumirá essas mensagens, inserindo-as no banco de dados SQL local.

### 1. Criar uma nova mensagem

- **URL:** `http://localhost:5117/api/Notification/SendMessage`
- **Método HTTP:** POST
- **Descrição:** Cria uma nova mensagem.

Exemplo mensagem:
```
{
  "message": "Primeira notificação teste",
  "creationDate": "2024-01-10"
}
```

## Implementação dos testes automatizados
A aplicação possui testes automatizados implementados com as seguintes bibliotecas:

- NUnit: Framework de teste unitário.
- MoQ: Utilizado para criar mocks durante os testes.
- FluentAssertions: Facilita a criação de asserções legíveis nos testes.
- AutoFixture: Para facilitar a geração de dados dos mocks.
