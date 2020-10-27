CREATE TABLE [dbo].[Address]
(
	[Id]         INT                  NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CountryId]  INT                  NULL, 
    [PostalCode] NVARCHAR(15)         NULL, 
    [City]       NVARCHAR(100)        NULL, 
    [Street]     NVARCHAR(100)        NULL, 
    [Number]     NVARCHAR(10)         NULL, 
    [Floor]      NVARCHAR(50)         NULL, 
    [CreatedOn]  DATETIME2            NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn] DATETIME2            NULL, 
    [DeletedOn]  DATETIME2            NULL,
    CONSTRAINT   [FK_Address_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id])
)
GO
CREATE INDEX [IX_Address_Country] ON [dbo].[Address] ([CountryId])