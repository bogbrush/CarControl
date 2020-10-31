CREATE TABLE [dbo].[Command](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PayLoad] [nvarchar](max) NULL,
	[RequestDate] [datetime] NULL,
	[CompleteDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]