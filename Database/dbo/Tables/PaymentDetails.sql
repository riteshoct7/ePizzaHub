CREATE TABLE [dbo].[PaymentDetails] (
    [Id]            NVARCHAR (450)   NOT NULL,
    [TransactionId] NVARCHAR (MAX)   NULL,
    [Tax]           DECIMAL (18, 2)  NOT NULL,
    [Currency]      NVARCHAR (MAX)   NULL,
    [Total]         DECIMAL (18, 2)  NOT NULL,
    [Email]         NVARCHAR (MAX)   NULL,
    [Status]        NVARCHAR (MAX)   NULL,
    [CartId]        UNIQUEIDENTIFIER NOT NULL,
    [UserId]        INT              NOT NULL,
    [GrandTotal]    DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_PaymentDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

