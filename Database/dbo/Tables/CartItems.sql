CREATE TABLE [dbo].[CartItems] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [Cartid]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId] INT              NOT NULL,
    [UnitPrice] DECIMAL (18, 2)  NOT NULL,
    [Quantity]  INT              NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CartItems_Carts_Cartid] FOREIGN KEY ([Cartid]) REFERENCES [dbo].[Carts] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CartItems_Cartid]
    ON [dbo].[CartItems]([Cartid] ASC);

