CREATE TABLE [dbo].[Blog] (
    [Id]      INT        IDENTITY (1, 1) NOT NULL,
    [Title]   NCHAR (10) NULL,
    [Content] NVARCHAR(MAX) NULL,
    [AdminID] INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Blog_ToTable] FOREIGN KEY ([AdminID]) REFERENCES [dbo].[Userlogin] ([AdminID])
);

