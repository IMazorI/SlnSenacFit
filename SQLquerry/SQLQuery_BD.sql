drop table Avaliacao
drop table Dieta
drop table Profissional
drop table Usuario

drop procedure pi_Profissional
drop procedure pi_Usuario

select * from Usuario
select * from Profissional



Create table Usuario
(
idUsuario int identity primary key,
nomeUsu varchar(30) not null,
loginUsu varchar(20) unique not null,
senhaUsu varchar(100) not null,
dataNascimentoUsu date not null,
perfilUsu char(12) not null,  /*Cliente ou Profissional*/
telefoneUsu char(11) not null
)


Create table Profissional
(
idProfissional int identity primary key,
credencial varchar(4) unique not null,
nomePro varchar(30) not null,
loginPro varchar(20) unique not null,
senhaPro varchar(100) not null,
dataNascimentoPro date not null,
perfilPro char(12) not null,  /*Cliente ou Profissional*/
telefonePro char(11) not null
)



Create table Avaliacao
(
idAvaliacao int identity primary key,
idUsuario int,
idProfissional int,
dataAval date not null,
peso numeric (4,1) not null,
altura numeric (3,2) not null,
resultado numeric (3,1) not null
constraint fk_idUsuario foreign key(idUsuario) references Usuario (idUsuario),
constraint fk_idProfissional foreign key(idProfissional) references Profissional (idProfissional)
)


Create table Dieta
(
idDieta int identity primary key,
idUsuario int,
idProfissional int,
idAvaliacao int,
restricoesAlimentares varchar(500),
dieta varchar(1000),
dataDieta date,
constraint fk_idUsuarioDieta foreign key(idUsuario) references Usuario (idUsuario),
constraint fk_idProfissionalDieta foreign key(idProfissional) references Profissional (idProfissional),
constraint fk_idAvaliacao foreign key(idAvaliacao) references Avaliacao (idAvaliacao)
)

create procedure pi_Usuario
/*parametros*/
@nomeUsu varchar(30),
@loginUsu varchar(20),
@senhaUsu char(100),
@dataNascimentoUsu date,
@perfilUsu char(12),
@telefoneUsu char(11) 
as
/*corpo*/
insert into Usuario
(nomeUsu, loginUsu,senhaUsu,dataNascimentoUsu,perfilUsu, telefoneUsu)
values (@nomeUsu,@loginUsu, @senhaUsu, @dataNascimentoUsu,@perfilUsu,@telefoneUsu)


create procedure pu_Usuario
/*parametros*/
@nomeUsu varchar(30),
@loginUsu varchar(20),
@senhaUsu char(100),
@dataNascimentoUsu date,
@perfilUsu char(12),
@telefoneUsu char(11) 
as
/*corpo*/
update Usuario
set
nomeUsu = @nomeUsu,
loginUsu = @loginUsu,
senhaUsu = @senhaUsu,
dataNascimentoUsu = @dataNascimentoUsu,
perfilUsu = @perfilUsu,
telefoneUsu = @telefoneUsu


create procedure pi_Profissional
/*parametros*/
@credencial varchar(4),
@nomePro varchar(30),
@loginPro varchar(20),
@senhaPro varchar(100),
@dataNascimentoPro date,
@perfilPro char(12),
@telefonePro char(11)
as
/*corpo*/
insert into Profissional
(credencial,nomePro,loginPro,senhaPro,dataNascimentoPro,perfilPro,telefonePro)
values (@credencial,@nomePro, @loginPro, @senhaPro,@dataNascimentoPro,@perfilPro,@telefonePro)


create procedure pu_Profissional
/*parametros*/
@credencial varchar(4),
@nomePro varchar(30),
@loginPro varchar(20),
@senhaPro varchar(100),
@dataNascimentoPro date,
@perfilPro char(12),
@telefonePro char(11)
as
/*corpo*/
update Profissional
set
credencial = @credencial,
nomePro = @nomePro,
loginPro = @loginPro,
senhaPro = @senhaPro,
dataNascimentoPro = @dataNascimentoPro,
perfilPro = @perfilPro,
telefonePro = @telefonePro


create procedure pi_Avaliacao
@idUsuario int,
@idProfissional int,
@dataAval date,
@peso numeric(4,1),
@altura numeric(3,2)
as
insert into Avaliacao (idUsuario, idProfissional, dataAval, peso, altura)
values (@idUsuario, @idProfissional, @dataAval, @peso, @altura)


create procedure pi_Dieta
@idUsuario int,
@idProfissional int,
@idAvaliacao int,
@restricoesAlimentares varchar(500),
@dieta varchar(1000),
@dataDieta date
as
insert into Dieta (idUsuario, idProfissional, idAvaliacao, restricoesAlimentares, dieta, dataDieta)
values (@idUsuario, @idProfissional, @idAvaliacao, @restricoesAlimentares, @dieta, @dataDieta)


create procedure ps_validaLogin
@login varchar(20),
@senha varchar(100)
as
select loginUsu,senhaUsu,loginPro,senhaPro from Usuario, Profissional
where loginUsu=@login and senhaUsu=@senha or loginPro = @login and SenhaPro = @senha



create procedure ps_Imc
@nomeUsu varchar(30),
@dataAval date
as
select peso, altura from Avaliacao
inner join Usuario
on Avaliacao.idUsuario = Usuario.idUsuario
where nomeUsu=@nomeUsu and dataAval=@dataAval


create procedure ps_Dieta
@nomeUsu varchar(30),
@dataDieta date
as
select dieta from Dieta
inner join Usuario
on Dieta.idUsuario = Usuario.idUsuario
where nomeUsu=@nomeUsu and dataDieta=@dataDieta


create procedure ps_InfoUsuario
@nomeUsu varchar(30),
@dataAval date
as
select peso, altura, dataAval, restricoesAlimentares, dieta, dataDieta from Avaliacao
inner join Usuario
on Avaliacao.idUsuario = Usuario.idUsuario
inner join Dieta
on Dieta.idUsuario = Usuario.idUsuario
where nomeUsu=@nomeUsu and dataAval=@dataAval


create procedure ps_ListaUsuarios
(
	@nomeUsu varchar(30)
)
as
	select * from Usuario where nomeUsu LIKE @nomeUsu + '%'


