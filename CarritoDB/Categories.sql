CREATE TABLE [dbo].[Categories]
(
	[CategoryId] INT IDENTITY(1,1) NOT NULL, 
    [Name] VARCHAR(72) NULL
	CONSTRAINT PK_CategoryId PRIMARY KEY (CategoryId),
)
