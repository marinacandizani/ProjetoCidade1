create database bancoTop;

use bancoTop;

create table Usuário(
Id int primary key auto_increment,
Nome varchar (80),
Email varchar (100),
Senha varchar (50)
);

create table Produto(
Id int primary key auto_increment,
NomeProd varchar (80),
Descricao varchar (100),
Preco decimal (10,2),
Quantidade int
);

