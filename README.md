# Programa para enviar email
Demostrativo de programa usado para enviar e-mail.


Referência de:
> using System.Net.Mail;

E um programa simples só para mostrar como criar utilizando o c#, este programa utiliza 
algumas configurações do outlook que são:


* Servidor SMTP para a aplicação acessar.
* Login e senha do e-mail correspondente a SMTP.
* Porta de acesso .


Este programa esta configurado para acessar o SMTP do gmail, ele usa a porta 587, com ele você pode
definir:

* O e-mail do destinatario.
* A nível de prioridade da mensagem enviada.
* O assunta da mensagem.
* O corpo da mensagem que foi criada separadamente, você pode definir se vai usar 
HTML ou não em 'Mail.IsBodyHtml'.
* E possível anexa arquivos.
* E definir a autenticação SSL se a caso o e-mail utilizar este recusro.


Este programa é bem simples com o objetivo de mostrar como trabalha com a referência acima. No corpo da mensagem
tem uma estrutura formatada em HTML, uma tabela com a imagem para mostrar como a  mensagem qualquer tirada 
da internet para ver como fica depois de enviada.


Ilustação 1:


![](https://user-images.githubusercontent.com/34901033/58580840-6cf5ea80-8224-11e9-96da-006f0e244e1d.png)


Ilustação 2:



![](https://user-images.githubusercontent.com/34901033/58581139-35d40900-8225-11e9-9bef-739eee5717fa.png)


