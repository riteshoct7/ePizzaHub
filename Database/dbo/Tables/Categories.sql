CREATE TABLE [dbo].[Categories] (
    [CategoryId]   INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (MAX) NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

