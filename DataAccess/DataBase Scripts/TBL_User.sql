USE [CenfoCinemas_DB]
GO

/****** Object:  Table [dbo].[TBL_User]    Script Date: 6/7/2025 10:58:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[UserCode] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nchar](30) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TBL_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


