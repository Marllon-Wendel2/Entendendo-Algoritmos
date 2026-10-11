# Exercício

## É importante que funções hash retornem o mesmo valor de saída quando o mesmo valor de entrada for inserido. Caso contrário, não será possível encontrar o item que você deseja na tabela hash!

### Quais destas funções hash são consistentes?
``
    5.1 f(x) = 1 ❶
    5.2 f(x) = rand() ❷
    5.3 f(x) = proximo_espaco_vazio() ❸
    5.4 f(x) = len(x) ❹
    ❶ Retorna “1” para qualquer entrada.
    ❷ Retorna um número aleatório a cada execução.
    ❸ Retorna o índice do próximo espaço livre da tabela hash.
    ❹ Usa o comprimento da string como índice.
``

    R=> 4 (Observando que estamos verificando CONSISTÊNCIA e não evitando colisão)