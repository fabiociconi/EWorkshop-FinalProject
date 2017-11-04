CREATE TABLE [dbo].[Employees] (
    [IdEmployee]     UNIQUEIDENTIFIER NOT NULL,
    [IdPerson]       UNIQUEIDENTIFIER NOT NULL,
    [IdWorkshop]     UNIQUEIDENTIFIER NOT NULL,
    [EmployeeNumber] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([IdEmployee] ASC),
    CONSTRAINT [FK_Employees_People] FOREIGN KEY ([IdPerson]) REFERENCES [dbo].[People] ([IdPerson]),
    CONSTRAINT [FK_Employees_Workshops] FOREIGN KEY ([IdWorkshop]) REFERENCES [dbo].[Workshops] ([IdWorkshop])
);



