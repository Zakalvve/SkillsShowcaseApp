CREATE TABLE [dbo].[PollOption] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [PollId] INT          NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    [Votes]  INT          DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_poll] FOREIGN KEY ([PollId]) REFERENCES [dbo].[Poll] ([Id]) ON DELETE CASCADE
);

