# trabalho-criptografia
Trabalho da disciplina de Segurança e Auditoria de Sistemas de Segurança

## Tem que enviar o link do repo pro martim.dietterle@catolicasc.org.br
taokei

## Links Úteis (colocar aqui)
https://medium.com/@ismailakkila/black-hat-python-encrypt-and-decrypt-with-rsa-cryptography-bd6df84d65bc

## Trabalho Criptografia Assimétrica

Implementar criptografia assimétrica.
Trabalho em trios. Pode ser menos, mas não mais componentes.

Criar um repositório público no github/gitlab para entregar o trabalho e para que o professor
possa verificar o andamento do trabalho. (enviar o link para o email do professor)

Ao inicializar, o programa deve solicitar a geração das chaves de criptografia / descriptografia
que devem ser armazenadas em dois arquivos distintos caso o usuário desejar, poder usar
chaves previamente geradas pelo sistema (neste caso o programa deve ler os arquivos das
chaves). Para isto, seu sistema deve ser capaz de gerar as chaves de criptografia (dica:
pesquisar sobre como gerar chaves RSA).

O programa deverá pedir a ação a ser efetuada (criptografia/descriptografia). Deve em
seguida, solicitar a localização do arquivo original (deve ser um arquivo .txt). Após isso, deve
gravar o arquivo criptografado com uma extensão .crypt.

Deve ser possível descriptografar um arquivo, retornando o mesmo a sua forma original.

Definição de OK: Deve ser possível criptografar/descriptografar um arquivo TXT.
