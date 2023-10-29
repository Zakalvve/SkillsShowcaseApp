CREATE TABLE [dbo].[Poll] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [EventId]  INT           NOT NULL,
    [Deadline] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK__Polls__3214EC07C8756764] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([Id]) ON DELETE CASCADE
);

