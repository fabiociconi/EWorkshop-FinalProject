CREATE TABLE [dbo].[Addresses] (
    [IdAddress]      UNIQUEIDENTIFIER NOT NULL,
    [Street]         VARCHAR (50)     NOT NULL,
    [City]           VARCHAR (50)     NOT NULL,
    [Zipcode]        CHAR (6)         NOT NULL,
    [Type]           INT              NOT NULL,
    [GpsCoordinateX] FLOAT (53)       NOT NULL,
    [GpsCoordinateY] FLOAT (53)       NOT NULL,
    [DateTime]       ROWVERSION       NOT NULL,
    [IdWorkshop]     UNIQUEIDENTIFIER NULL,
    [IdUser]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([IdAddress] ASC),
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[People] ([IdPerson]),
    CONSTRAINT [FK_Addresses_Workshops] FOREIGN KEY ([IdWorkshop]) REFERENCES [dbo].[Workshops] ([IdWorkshop])
);



