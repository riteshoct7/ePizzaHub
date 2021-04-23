CREATE TABLE [dbo].[OrderItem] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [ProductId] INT             NOT NULL,
    [UnitPrice] DECIMAL (18, 2) NOT NULL,
    [Quantity]  INT             NOT NULL,
    [Total]     DECIMAL (18, 2) NOT NULL,
    [OrderId]   NVARCHAR (450)  NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderItem_OrderId]
    ON [dbo].[OrderItem]([OrderId] ASC);

