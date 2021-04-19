CREATE TABLE [dbo].[Person] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (20) NULL,
    [LastName]  VARCHAR (50) NULL,
    [BirthDate] DATE         NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

