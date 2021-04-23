CREATE TABLE [dbo].[City] (
    [Cityid]      INT            IDENTITY (1, 1) NOT NULL,
    [CityName]    NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Enabled]     BIT            NOT NULL,
    [StateId]     INT            NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([Cityid] ASC),
    CONSTRAINT [FK_City_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Stateid]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_City_StateId]
    ON [dbo].[City]([StateId] ASC);

