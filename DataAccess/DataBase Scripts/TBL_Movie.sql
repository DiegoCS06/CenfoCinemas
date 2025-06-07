USE [CenfoCinemas_DB]
GO

/****** Object:  Table [dbo].[TBL_Movie]    Script Date: 6/7/2025 11:04:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Title] [nvarchar](75) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[Genre] [nvarchar](20) NOT NULL,
	[Director] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TBL_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


