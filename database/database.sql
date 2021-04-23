PRINT 'Iniciando scripts'
GO
 IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'FavoDeMelDb')
    BEGIN
		PRINT 'Iniciando a criacao do banco de dados.....'
        CREATE DATABASE FavoDeMelDb;
		PRINT 'Finalizando a criacao do banco de dados.....'
    END

GO
USE FavoDeMelDb;
GO
IF NOT EXISTS (SELECT name FROM sysobjects WHERE name='Garcom' and xtype='U')
	BEGIN
		PRINT 'Criando Tabela de Garcom'
		CREATE TABLE Garcom (
			IDGarcom UNIQUEIDENTIFIER PRIMARY KEY,
			Nome varchar(150),
			Cpf varchar(14) unique
		)	
		PRINT 'Tabela Garcom criado com sucesso'
	END
GO

IF NOT EXISTS (SELECT name FROM sysobjects WHERE name='Produto' and xtype='U')
	BEGIN
		PRINT 'Criando Tabela de Produto'
		CREATE TABLE Produto (
			IDProduto UNIQUEIDENTIFIER PRIMARY KEY,
			Nome varchar(200),
			Valor decimal(19,2)
		)
		PRINT 'Tabela Produto com sucesso'
	END

GO

IF NOT EXISTS (SELECT name FROM sysobjects WHERE name='Comanda' and xtype='U')
	BEGIN
		PRINT 'Criando Tabela de Comanda'
		CREATE TABLE Comanda (
			IDComanda UNIQUEIDENTIFIER PRIMARY KEY,			
			DataCriacao Datetime,
			Mesa int,
			Status int	
		)
		PRINT 'Tabela Comanda com sucesso'
	END

GO

IF NOT EXISTS (SELECT name FROM sysobjects WHERE name='Pedido' and xtype='U')
	BEGIN
		PRINT 'Criando Tabela de Pedido'
		CREATE TABLE Pedido (
			IDPedido UNIQUEIDENTIFIER PRIMARY KEY,
			IDComanda UNIQUEIDENTIFIER,
			IDGarcom UNIQUEIDENTIFIER,
			DataPedido Datetime,			
			Situacao int,
			FOREIGN KEY (IDComanda) REFERENCES Comanda(IDComanda),
			FOREIGN KEY (IDGarcom) REFERENCES Garcom(IDGarcom)
		)
		PRINT 'Tabela Pedido com sucesso'
	END

GO

IF NOT EXISTS (SELECT name FROM sysobjects WHERE name='PedidoProduto' and xtype='U')
	BEGIN
		PRINT 'Criando Tabela de PedidoProduto'
		CREATE TABLE PedidoProduto (
			IDPedidoProduto UNIQUEIDENTIFIER PRIMARY KEY,
			IDPedido UNIQUEIDENTIFIER,
			IDProduto UNIQUEIDENTIFIER,
			Quantidade int,
			ValorTotal decimal(19,2),
			FOREIGN KEY (IDPedido) REFERENCES Pedido(IDPedido),
			FOREIGN KEY (IDProduto) REFERENCES Produto(IDProduto)
		)
		PRINT 'Tabela PedidoProduto com sucesso'
	END

GO