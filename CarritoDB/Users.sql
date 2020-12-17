CREATE TABLE [dbo].[Users]
(
	[UserId] INT  IDENTITY(1,1) NOT NULL, 
    [TypeId] INT NOT NULL, 
    [Name] VARCHAR(72) NOT NULL, 
    [Email] VARCHAR(72) NOT NULL, 
    [Password] VARCHAR(32) NOT NULL
    CONSTRAINT PK_UserId PRIMARY KEY (UserId),
    CONSTRAINT FK_UserTypeId FOREIGN KEY (TypeId) REFERENCES UserTypes(TypeId),
)
