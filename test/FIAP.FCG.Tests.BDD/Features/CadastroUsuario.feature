Feature: Cadastro de Usuários
  Como um novo usuário
  Quero me cadastrar no sistema
  Para poder acessar funcionalidades restritas

  Scenario: Cadastro realizado com sucesso
    Given que informei o nome "Felipe Trosi"
    And informei o email "felipe@fiap.com"
    And informei a senha "F3lipe@123"
    When eu tento me cadastrar
    Then o sistema deve retornar sucesso

  Scenario: Cadastro com email inválido
    Given que informei o nome "Asdruball"
    And informei o email "asdruball-email.com"
    And informei a senha "asdruball@1234"
    When eu tento me cadastrar
    Then o sistema deve retornar erro "Email inválido"

  Scenario: Cadastro com senha fraca
    Given que informei o nome "Mirosvaldo"
    And informei o email "miros_valdo@teste.com"
    And informei a senha "123456"
    When eu tento me cadastrar
    Then o sistema deve retornar erro "Senha inválida"
