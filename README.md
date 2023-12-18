# zummit-controlefinanceiro-api

PROVA TÉCNICA – Desenvolvedor BackEnd

![.NET Core](https://github.com/silvaAlex/zummit-controlefinanceiro/.github/workflows/.NETCore/badge.svg)
[![License](http://img.shields.io/github/license/silvaAlex/zummit-controlefinanceiro.svg)](LICENSE)

## Como Rodar

```shell
docker-compose up
```

## Requisitos

- ContaBancaria API:
  - [x] Um campo de dados privado do tipo double chamado saldo que representa o saldo atual da conta. O saldo padrão é 0.0.
  - [x] Um campo de dados privado do tipo date chamado dataAbertura que guarda a data da abertura da conta bancária. O valor padrão é a data atual.
        Note que o campo dataAbertura é somente leitura, ou seja, no momento da criação da conta,
        esta variável receberá a data atual e não poderá mais ser alterada.
  - [x] Um método RetornaDataAberturaFormatada() que retorna a data de abertura da conta como uma String.
        Você deverá também formatar a data retornada com o objetivo de exibir algo como "03/09/2021".
  - [x] Um método depositar() que recebe um valor do tipo double e atualiza o saldo atual da conta.
  - [x] Um método RetornaSaldoFormatado() que retorna o saldo atual da conta como uma String e formatado de acordo com o formato de moeda brasileira,
        ou seja, algo como "R$ 23.654,00".
  - [x] Um método sacar() que recebe um valor do tipo double representando o valor a ser sacado.
        Não permita saques que farão com que a conta fique com saldo negativo.

- Auth API
  - [x] o cadastro de usuário (CRUD - contendo nome, email e senha).
  - [x] A autenticação será feita usando email e senha.
