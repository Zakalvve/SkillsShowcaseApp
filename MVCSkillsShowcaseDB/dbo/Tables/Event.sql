CREATE TABLE [dbo].[Event] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [Location]    NVARCHAR (50)  NOT NULL,
    [Time]        DATETIME2 (7)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

