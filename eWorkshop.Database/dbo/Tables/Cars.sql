CREATE TABLE [dbo].[Cars] (
    [IdCar]        UNIQUEIDENTIFIER NOT NULL,
    [Brand]        VARCHAR (50)     NOT NULL,
    [Color]        VARCHAR (50)     NOT NULL,
    [Year]         INT              NOT NULL,
    [Trasmission]  INT              NOT NULL,
    [LicensePlate] VARCHAR (50)     NOT NULL,
    [FuelType]     INT              NOT NULL,
    [DateTime]     ROWVERSION       NOT NULL,
    [IdCustomer]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([IdCar] ASC),
    CONSTRAINT [FK_Cars_Customers] FOREIGN KEY ([IdCustomer]) REFERENCES [dbo].[Customers] ([idCustomer])
);

