CREATE TABLE [Sample].[SampleTable] (
    [IdSample] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Value]    VARCHAR (MAX)    NULL,
    [Valid]    BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdSample] ASC)
);



