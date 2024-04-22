CREATE DATABASE MCEISysRegisAdminDb
GO
USE MCEISysRegisAdminDb
GO
CREATE TABLE [Role](
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL
);
GO
CREATE TABLE [User](
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
IdRole INT NOT NULL FOREIGN KEY REFERENCES [Role](Id),
[Name] VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Email VARCHAR(50) NOT NULL,
[Password] VARCHAR(100) NOT NULL,
[Status] TINYINT NOT NULL,
RegistrationDate DATETIME NOT NULL
);
GO
INSERT INTO [Role] VALUES('Desarrollador');
GO
INSERT INTO [User] (IdRole, [Name], LastName, Email, [Password], [Status], RegistrationDate) 
VALUES (1, 'Flexcode', 'Freelancer', 'DesAdmin@elimizalco.com', 'c8aa131427a72781b156ac723ddb917f', 1, SYSDATETIME());
GO