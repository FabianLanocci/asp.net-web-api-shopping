CREATE TABLE [dbo].[Products]
(
	[ProductId] INT IDENTITY(1,1) NOT NULL, 
    [CategoryId] INT NULL, 
    [Name] VARCHAR(72) NULL, 
    [Description] VARCHAR(255) NULL, 
    [Price] FLOAT NULL, 
    [Image_Url] VARCHAR(100) NULL
    CONSTRAINT PK_ProductId PRIMARY KEY (ProductId),
	CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
)
