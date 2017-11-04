CREATE TABLE [dbo].[CustomerRatings] (
    [IdCustomerRating] UNIQUEIDENTIFIER NOT NULL,
    [RateValue]        INT              NOT NULL,
    [Comments]         VARBINARY (50)   NOT NULL,
    [DateTime]         ROWVERSION       NOT NULL,
    [IdCustomer]       UNIQUEIDENTIFIER NOT NULL,
    [IdWorkshop]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CustomerRatings] PRIMARY KEY CLUSTERED ([IdCustomerRating] ASC),
    CONSTRAINT [FK_CustomerRatings_Customers] FOREIGN KEY ([IdCustomer]) REFERENCES [dbo].[Customers] ([idCustomer]),
    CONSTRAINT [FK_CustomerRatings_Workshops] FOREIGN KEY ([IdWorkshop]) REFERENCES [dbo].[Workshops] ([IdWorkshop])
);

