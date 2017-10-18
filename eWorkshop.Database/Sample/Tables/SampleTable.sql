CREATE TABLE [Sample].[SampleTable] (
    [IdSample] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Value]    VARCHAR (MAX)    NULL,
    PRIMARY KEY CLUSTERED ([IdSample] ASC)
);

