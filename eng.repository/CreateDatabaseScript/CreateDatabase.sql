IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'EngAPI')
BEGIN
	CREATE DATABASE EngAPI
END
GO

use [EngAPI]

IF object_id('Users', 'U') is null
BEGIN
	CREATE TABLE Users (
		Id UNIQUEIDENTIFIER,
		Name varchar(100),
		Birthdate DATE,
		Active bit,
		PRIMARY KEY (Id)
	)
END
