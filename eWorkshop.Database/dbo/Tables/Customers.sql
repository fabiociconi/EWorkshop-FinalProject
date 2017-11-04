CREATE TABLE [dbo].[Customers] (
    [idCustomer] UNIQUEIDENTIFIER NOT NULL,
    [idPerson]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([idCustomer] ASC),
    CONSTRAINT [FK_Customers_People] FOREIGN KEY ([idPerson]) REFERENCES [dbo].[People] ([IdPerson])
);



