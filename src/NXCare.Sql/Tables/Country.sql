CREATE TABLE [dbo].[Country] (
  Id                   int                      IDENTITY(1,1) NOT NULL,
  Alpha2Code           varchar(2)               NOT NULL,
  NameTranslationKey   varchar(80)              NOT NULL,
  Alpha3Code           varchar(3)NOT            NULL,
  NumericCode          int                      NOT NULL,
  PhoneCode            int                      NOT NULL,
  [CreatedOn]          DATETIME2                NOT NULL DEFAULT GETUTCDATE(), 
  [ModifiedOn]         DATETIME2                NULL, 
  [DeletedOn]          DATETIME2                NULL,
  CONSTRAINT           [PK_Country]             PRIMARY KEY CLUSTERED ([Id] ASC),
  CONSTRAINT           [UC_Country_Alpha2Code]  UNIQUE NONCLUSTERED ([Alpha2Code] ASC)
) 