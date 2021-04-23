CREATE TABLE [dbo].[Products] (
    [Productid]   INT             IDENTITY (1, 1) NOT NULL,
    [ProductName] NVARCHAR (MAX)  NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [UnitPrice]   DECIMAL (18, 2) NOT NULL,
    [CategoryId]  INT             NOT NULL,
    [ImageUrl]    NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Productid] ASC),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId]
    ON [dbo].[Products]([CategoryId] ASC);

