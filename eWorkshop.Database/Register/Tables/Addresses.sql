CREATE TABLE [Register].[Addresses] (
    [IdAddress]    UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterAddressesIdAddress] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdPerson]     UNIQUEIDENTIFIER NOT NULL,
    [Street]       VARCHAR (50)     NOT NULL,
    [StreetNumber] VARCHAR (10)     NOT NULL,
    [City]         VARCHAR (50)     NOT NULL,
    [PostalCode]   VARCHAR (50)     NOT NULL,
    [Type]         INT              NOT NULL,
    [Longitude]    NUMERIC (9, 6)   CONSTRAINT [DF__Addresses__Longi__2D27B809] DEFAULT ((0)) NOT NULL,
    [Latitude]     NUMERIC (9, 6)   CONSTRAINT [DF__Addresses__Latit__2E1BDC42] DEFAULT ((0)) NOT NULL,
    [Province]     VARCHAR (30)     NOT NULL,
    [Country]      VARCHAR (100)    NOT NULL,
    CONSTRAINT [PK_RegisterAddresses] PRIMARY KEY CLUSTERED ([IdAddress] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterAddressesIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson])
);







