﻿CREATE TABLE [dbo].[States] (
    [Stateid]     INT            IDENTITY (1, 1) NOT NULL,
    [StateName]   NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Enabled]     BIT            NOT NULL,
    [CountryId]   INT            NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([Stateid] ASC),
    CONSTRAINT [FK_States_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_States_CountryId]
    ON [dbo].[States]([CountryId] ASC);

