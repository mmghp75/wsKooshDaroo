USE [KooshDaroo]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 12/20/2019 4:05:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[isInactive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pharmacy]    Script Date: 12/20/2019 4:05:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pharmacy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[is24h] [bit] NOT NULL,
	[isInactive] [bit] NOT NULL,
	[City] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[X] [float] NOT NULL,
	[Y] [float] NOT NULL,
	[PhoneNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PharmacyConnection]    Script Date: 12/20/2019 4:05:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PharmacyConnection](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PharmacyId] [int] NOT NULL,
	[DateOfConnectionState] [datetime] NOT NULL,
	[StateOf] [int] NOT NULL,
 CONSTRAINT [PK_PharmacyConnection] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescribe]    Script Date: 12/20/2019 4:05:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescribe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Prescription] [varbinary](max) NOT NULL,
	[DateOf] [datetime] NOT NULL,
	[X] [float] NOT NULL,
	[Y] [float] NOT NULL,
	[isCancelled] [bit] NOT NULL,
	[PhoneNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Prescribes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrescribeResource]    Script Date: 12/20/2019 4:05:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrescribeResource](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PrescribeId] [int] NOT NULL,
	[PharmacyId] [int] NOT NULL,
	[Item01] [bit] NOT NULL,
	[Item02] [bit] NOT NULL,
	[Item03] [bit] NOT NULL,
	[Item04] [bit] NOT NULL,
	[Item05] [bit] NOT NULL,
	[Item06] [bit] NOT NULL,
	[Item07] [bit] NOT NULL,
	[Item08] [bit] NOT NULL,
	[Item09] [bit] NOT NULL,
	[Item10] [bit] NOT NULL,
	[PharmacyAccepted] [bit] NOT NULL,
	[PharmacyAcceptDateOf] [datetime] NOT NULL,
	[MemberAccepted] [bit] NOT NULL,
	[MemberAcceptDateOf] [datetime] NOT NULL,
	[MemberTakesDrugs] [bit] NOT NULL
) ON [PRIMARY]
GO
