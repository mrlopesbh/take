# Premissas

 Não poderia ser utilizada nenhuma biblioteca ou componente externo a da linguagem. Sendo assim, não utilzei o Injeção de Dependencia nem biblitecas para facilitar o Mock dos testes.

 Foi feito utilizando o .NET Core 3.1
# Comportamento do Programa

 Primeiro carregar os arquivos necessários em transformar em uma estrutura interna.
 
 Após isto, iniciar procura de possiveis Rotas.
 
 Acredito que as encomendas seriam maiores que as possiveis rotas, sendo assim, ao iniciar o processamento de rotas, já monto todas as possíveis rotas para depois facilitar a busca, ao invés de ficar sempre "montando" a procura.
 
# Para compilar/executar:
 
 Abra a pasta ConsoleApp no PowerShell
 
 dotnet build para compilar
 
 dotnet run "caminho_trecho.txt" "caminho_encomenda" "caminho_rota"
 
 Exemplo:
 dotnet run "C:\Users\marce\source\repos\TesteCoreNet\Arquivos\trechos2.txt" "C:\Users\marce\source\repos\TesteCoreNet\Arquivos\encomendas2.txt" "C:\Users\marce\source\repos\TesteCoreNet\Arquivos\out2222.txt"

# Estrutura do Projeto:

Pastas Logger e UI são autoexplicativas, mas basicamente para concentrar a inteligencia especifica nestes pontos, para não ficar espalhando "conhecimentos" desnecessários em todos os níveis.

Processador é a pasta onde fica a Inteligencia do projeto em sí, tanto de Leitura e Escrita de Arquivos, quanto do processamento de Rotas em sí. Porem tudo bem separado.

O CorreiosProgram é o centralizador do aplicativo. mas não tem inteligência específica. Sendo responsável apenas por encaminhamentos e chamadas.

# Testes

Não testei tudo, não tive tempo. Mas testei algumas coisas para vocês terem uma amostragem.

# Observações

Há muita coisa a ser melhorada no código, principalmente na elaboração de possiveis rotas e também na procura de rotas, poderia ficar mais rápido e mais limpo, porem não deu tempo.

Achei o teste um pouco extenso, para fase inicial de um processo de seleção. Pode pegar mal eu "reclamar" deste jeito, mas realmente achei e pode servir como um feedback para vocês. 



Obrigado.