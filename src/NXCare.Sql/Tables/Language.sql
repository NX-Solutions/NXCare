CREATE TABLE [dbo].[Language]
(
	[Id]                 INT          NOT NULL PRIMARY KEY IDENTITY(1,1),
	[NativeName]         NVARCHAR(80) NOT NULL,
	[NameTranslationKey] VARCHAR(80)  NOT NULL,
	[Alpha2Code]         VARCHAR(2)   NOT NULL,
	[Alpha3Code]         VARCHAR(3)   NOT NULL,
    [CreatedOn]          DATETIME2    NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn]         DATETIME2    NULL, 
    [DeletedOn]          DATETIME2    NULL,
)
GO
CREATE UNIQUE INDEX [IX_Language_Alpha2Code] ON [dbo].[Language] ([Alpha2Code])
GO
CREATE UNIQUE INDEX [IX_Language_Alpha3Code] ON [dbo].[Language] ([Alpha3Code])