select * from clientes

select * from produtos

create table produtosNovo(
id int primary key not null identity,
cod varchar(50),
nome varchar(50),
preco varchar(20),
estoque varchar(20)
)

select * from produtosNovo
select * from clientesNovo

delete from produtosNovo
delete from clientesNovo

create table clientesNovo(
id int primary key not null identity,
cpf varchar(50),
nome varchar(50),
telefone varchar(20),
email varchar(50)
)