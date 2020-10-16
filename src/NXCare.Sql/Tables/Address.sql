CREATE TABLE [dbo].[Address]
(
	[Id]         INT                  NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CountryId]  INT                  NOT NULL, 
    [PostalCode] NVARCHAR(15)         NOT NULL, 
    [City]       NVARCHAR(100)        NOT NULL, 
    [Street]     NVARCHAR(100)        NOT NULL, 
    [Number]     NVARCHAR(10)         NOT NULL, 
    [Floor]      NVARCHAR(50)         NULL, 
    [CreatedOn]  DATETIME2            NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn] DATETIME2            NULL, 
    [DeletedOn]  DATETIME2            NULL,
    CONSTRAINT   [FK_Address_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id])
)
GO
CREATE INDEX [IX_Address_Country] ON [dbo].[Address] ([CountryId])