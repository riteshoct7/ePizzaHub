CREATE TABLE [dbo].[Order] (
    [Id]             NVARCHAR (450) NOT NULL,
    [UserId]         INT            NOT NULL,
    [PaymentId]      NVARCHAR (MAX) NULL,
    [StreetAddress1] NVARCHAR (MAX) NULL,
    [StreetAddress2] NVARCHAR (MAX) NULL,
    [StreetAddress3] NVARCHAR (MAX) NULL,
    [ZipCode]        NVARCHAR (MAX) NULL,
    [PhoneNumber]    NVARCHAR (MAX) NULL,
    [Locality]       NVARCHAR (MAX) NULL,
    [City]           NVARCHAR (MAX) NULL,
    [CreatedDate]    DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC)
);

