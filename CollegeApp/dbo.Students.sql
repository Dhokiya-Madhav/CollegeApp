CREATE TABLE [dbo].[Students] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [noteTitle] NVARCHAR (MAX) NOT NULL,
    [noteDesc]  NVARCHAR (MAX) NOT NULL,
	[noteDate] DATE NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([id] ASC)
);

