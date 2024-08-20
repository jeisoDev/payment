# Mercado Pago API Integration

Este projeto é uma API construída em .NET Core que integra com a **API do Mercado Pago** para realizar pagamentos via diferentes métodos, como **PIX**, **cartão de crédito**, e **boleto bancário**. 
A API também possui endpoints para adicionar cartões, verificar o status dos pagamentos e listar pagamentos realizados.

## Sumário

- [Instalação](#instalação)
- [Configuração](#configuração)
- [Endpoints Disponíveis](#endpoints-disponíveis)
  - [Pagamento com PIX](#Payment/create/Pix)
  - [Pagamento com Cartão de Crédito](#Payment/create/credit-card)
  - [Pagamento com Boleto](#api/Boleto/create/Boleto)
  - [Adicionar Cartão](#api/Card/create-card)
  - [Verificar Status de Pagamento](#Payment/status/{paymentId})
  - [Listar Pagamentos](#api/PaymentRequest/Payment/List)
  - [Refounds](#api/PaymentRefound/Payment/Refound)

## Instalação

Para rodar este projeto localmente, siga os seguintes passos:

1. Clone este repositório:
    ```bash
    git clone https://github.com/jeisoDev/payment.git
    ```

2. Navegue até o diretório do projeto:
    ```bash
    cd seu-repositorio
    ```

3. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

4. Compile o projeto:
    ```bash
    dotnet build
    ```

5. Execute o projeto:
    ```bash
    dotnet run
    ```

## Configuração

### Mercado Pago API Key

Para que a API funcione corretamente, você precisará de uma chave de acesso à API do Mercado Pago.


