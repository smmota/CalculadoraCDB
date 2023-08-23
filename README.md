# Calculadora de investimentos CDB

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

## 📋 Objetivo

Criar uma calculadora de investimentos CDB que receba o valor da aplicação financeira e o prazo que a investimento ficará aplicado. O retorno do cálculo é o valor bruto do investimento e o valor líquido, já com o imposto de renda descontado

## 🛠️ Construído com

Abaixo estão listadas as ferramentas utilizadas para o desenvolvimento dos projetos

### 📌 IDE's utilizadas:
- Visual Studio 2022
- Visual Studio Code 1.81.1

### 📌 Frameworks utilizados:

#### Backend 
- .Net Core 7.0 

#### Frontend 
- Angular CLI 16.2.0
- Node.js 18.17.1
- NPM 9.6.7
- Bootstrap 4.1.3
- Jquery 3.3.1
- Popper.js 1.14.3

#### Verionamento
- Git 2.40.1

### 🔧 Instalação

#### Clone do projeto

Para fazer o clone do projeto do repositório remoto para o repositório local, na aba <> Code, clique no botão verde <> Code e copie a url informada na aba HTTPS.

Imagem Aqui

Selecione o diretório onde ficará localizado o repositório local e com o botão direito do mouse, clique na opção "Git Bash Here" para executar o terminal do git

Imagem Aqui

No terminal digite o comando "$ git clone -b <branch> <url do repositório remoto>" informando a branch e a url do repositório do projeto e clique em enter para iniciar o clone no repositório local

Imagem Aqui

Imagem Aqui

#### Executando o projeto backend no Visual Studio 2022

Na pasta criada após clone é possível visualizar todos os arquivos do projeto. Para executar o projeto backend utilizando a IDE do Visual Studio 2022, efetue o duplo clique no arquivo da solução "CalculoCDBWebAPI.sln" e aguarde o carregamento.
Com a solução carregada na IDE, altere o projeto StartUp para "CalculoCDBWebAPI.Presentation" e clique no botão "https".

Imagem Aqui

Imagem Aqui

A solução será compilada e seguida o swaager da Web API será carregado no browser

Imagem Aqui

#### Executando o projeto frontend no Visual Studio Code

Entre na pasta "CalculoCDBWebApp" e digite "cmd" na barra de endereço do Windows Explore e aperte enter. No prompt de comando do windows digite o comando "code ." e aperte enter.

Imagem Aqui

Imagem Aqui


Na aba "Terminal", clique na opção "New Terminal". Em seguida digite o comando "npm install" para instalar todas as dependências do projeto.

Imagem Aqui

Imagem Aqui

Após a instalação das dependências, digite o comando "ng serve". ao concluir a compilação com sucesso, clique na url para visualizar a página frontend da aplicação.


Imagem Aqui

Imagem Aqui

## ⚙️ Executando os testes

Os testes foram realizados com dados mock para validar se o cálculo foram realizados corretamente