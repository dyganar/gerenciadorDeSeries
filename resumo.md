## Classes abstratas
    Não podem ser instanciadas
    define como os métodos devem ser implementados
    possue atributos
    os métodos devem ser implementados pela classe que herda
    Como se fosse um molde.

## Classes interfaces
    Interfaces possuem uma lista de métodos que devem ser implementados;
    não possue atributos.


## Passos do projeto:
    EntidadeBase.cs (Classe abstrata)
    Serie.cs (herda da entidade base)
    Repositorio.cs (implementa a interface IRepositorio, acessa a base de dados)
    ClassePrincipal (implementa a interação com o usuário)