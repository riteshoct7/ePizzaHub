CREATE TABLE [dbo].[Countries] (
    [CountryId]   INT            IDENTITY (1, 1) NOT NULL,
    [CountryName] NVARCHAR (MAX) NOT NULL,
    [ISDCode]     NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Enabled]     BIT            NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

