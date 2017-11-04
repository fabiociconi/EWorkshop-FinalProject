CREATE TABLE [Register].[Customers] (
    [IdCustomer] UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterCustomersIdCustomer] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IdPerson]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_RegisterCustomers] PRIMARY KEY CLUSTERED ([IdCustomer] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterCustomersIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson]),
    CONSTRAINT [UNQ_RegisterCustomersIdPerson] UNIQUE NONCLUSTERED ([IdPerson] ASC)
);

