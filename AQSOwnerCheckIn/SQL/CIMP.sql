USE [master]
GO
/****** Object:  Database [CIMP]    Script Date: 3/8/2020 12:51:46 AM ******/
CREATE DATABASE [CIMP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CIMP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CIMP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CIMP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CIMP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CIMP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CIMP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CIMP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CIMP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CIMP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CIMP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CIMP] SET ARITHABORT OFF 
GO
ALTER DATABASE [CIMP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CIMP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CIMP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CIMP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CIMP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CIMP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CIMP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CIMP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CIMP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CIMP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CIMP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CIMP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CIMP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CIMP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CIMP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CIMP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CIMP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CIMP] SET RECOVERY FULL 
GO
ALTER DATABASE [CIMP] SET  MULTI_USER 
GO
ALTER DATABASE [CIMP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CIMP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CIMP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CIMP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CIMP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CIMP', N'ON'
GO
ALTER DATABASE [CIMP] SET QUERY_STORE = OFF
GO
USE [CIMP]
GO
/****** Object:  Table [dbo].[AlertTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertTbl](
	[AlertID] [int] IDENTITY(1,1) NOT NULL,
	[BackDisplayID] [int] NOT NULL,
	[Message] [varchar](3000) NOT NULL,
	[TimeCreated] [datetime] NOT NULL,
	[TimeCompleted] [datetime] NOT NULL,
 CONSTRAINT [PK_AlertTbl] PRIMARY KEY CLUSTERED 
(
	[AlertID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BackDisplayTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackDisplayTbl](
	[BackDisplayID] [int] IDENTITY(1,1) NOT NULL,
	[PetID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Is_Arrived] [bit] NOT NULL,
	[Is_Inspected] [bit] NOT NULL,
	[Is_Released] [bit] NOT NULL,
	[ColourID] [int] NOT NULL,
	[TimeCreated] [datetime] NULL,
 CONSTRAINT [PK_BackDisplayTbl] PRIMARY KEY CLUSTERED 
(
	[BackDisplayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckInTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckInTbl](
	[CheckInID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TimeCreated] [datetime] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_CheckInTbl] PRIMARY KEY CLUSTERED 
(
	[CheckInID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterAlertCustomMessageTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterAlertCustomMessageTbl](
	[AlertCustomMessageID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](3000) NOT NULL,
 CONSTRAINT [PK_MasterAlertCustomMessageTbl] PRIMARY KEY CLUSTERED 
(
	[AlertCustomMessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterColourTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterColourTbl](
	[ColourID] [int] IDENTITY(1,1) NOT NULL,
	[Colour] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ColourMasterTbl] PRIMARY KEY CLUSTERED 
(
	[ColourID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterPetTypeTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterPetTypeTbl](
	[PetTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PetType] [varchar](10) NOT NULL,
 CONSTRAINT [PK_MasterPetTypeTbl] PRIMARY KEY CLUSTERED 
(
	[PetTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterStatusTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterStatusTbl](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](10) NOT NULL,
	[ColourID] [int] NOT NULL,
 CONSTRAINT [PK_MasterStatusTbl] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetTbl](
	[PetID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PetName] [varchar](50) NULL,
	[Microchip] [varchar](10) NOT NULL,
	[PetTypeID] [int] NOT NULL,
 CONSTRAINT [PK_PetTbl] PRIMARY KEY CLUSTERED 
(
	[PetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTbl](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserTbl] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MasterAlertCustomMessageTbl] ON 

INSERT [dbo].[MasterAlertCustomMessageTbl] ([AlertCustomMessageID], [Message]) VALUES (1, N'Hello')
SET IDENTITY_INSERT [dbo].[MasterAlertCustomMessageTbl] OFF
SET IDENTITY_INSERT [dbo].[MasterColourTbl] ON 

INSERT [dbo].[MasterColourTbl] ([ColourID], [Colour]) VALUES (1, N'Red')
INSERT [dbo].[MasterColourTbl] ([ColourID], [Colour]) VALUES (2, N'Yellow')
INSERT [dbo].[MasterColourTbl] ([ColourID], [Colour]) VALUES (3, N'Green')
SET IDENTITY_INSERT [dbo].[MasterColourTbl] OFF
SET IDENTITY_INSERT [dbo].[MasterPetTypeTbl] ON 

INSERT [dbo].[MasterPetTypeTbl] ([PetTypeID], [PetType]) VALUES (1, N'Dog')
SET IDENTITY_INSERT [dbo].[MasterPetTypeTbl] OFF
SET IDENTITY_INSERT [dbo].[MasterStatusTbl] ON 

INSERT [dbo].[MasterStatusTbl] ([StatusID], [StatusName], [ColourID]) VALUES (1, N'Waiting', 1)
SET IDENTITY_INSERT [dbo].[MasterStatusTbl] OFF
ALTER TABLE [dbo].[BackDisplayTbl] ADD  CONSTRAINT [DF_BackDisplayTbl_Is_Arrived]  DEFAULT ((0)) FOR [Is_Arrived]
GO
ALTER TABLE [dbo].[BackDisplayTbl] ADD  CONSTRAINT [DF_BackDisplayTbl_Is_Inspected]  DEFAULT ((0)) FOR [Is_Inspected]
GO
ALTER TABLE [dbo].[AlertTbl]  WITH CHECK ADD  CONSTRAINT [FK_BackDisplayTbl_AlertTbl] FOREIGN KEY([BackDisplayID])
REFERENCES [dbo].[BackDisplayTbl] ([BackDisplayID])
GO
ALTER TABLE [dbo].[AlertTbl] CHECK CONSTRAINT [FK_BackDisplayTbl_AlertTbl]
GO
ALTER TABLE [dbo].[BackDisplayTbl]  WITH CHECK ADD  CONSTRAINT [FK_ColourMasterTbl_BackDisplayTbl] FOREIGN KEY([ColourID])
REFERENCES [dbo].[MasterColourTbl] ([ColourID])
GO
ALTER TABLE [dbo].[BackDisplayTbl] CHECK CONSTRAINT [FK_ColourMasterTbl_BackDisplayTbl]
GO
ALTER TABLE [dbo].[BackDisplayTbl]  WITH CHECK ADD  CONSTRAINT [FK_PetTbl_BackDisplayTbl] FOREIGN KEY([PetID])
REFERENCES [dbo].[PetTbl] ([PetID])
GO
ALTER TABLE [dbo].[BackDisplayTbl] CHECK CONSTRAINT [FK_PetTbl_BackDisplayTbl]
GO
ALTER TABLE [dbo].[BackDisplayTbl]  WITH CHECK ADD  CONSTRAINT [FK_UserTbl_BackDisplayTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTbl] ([UserID])
GO
ALTER TABLE [dbo].[BackDisplayTbl] CHECK CONSTRAINT [FK_UserTbl_BackDisplayTbl]
GO
ALTER TABLE [dbo].[CheckInTbl]  WITH CHECK ADD  CONSTRAINT [FK_MasterStatusTbl_CheckInTbl] FOREIGN KEY([StatusID])
REFERENCES [dbo].[MasterStatusTbl] ([StatusID])
GO
ALTER TABLE [dbo].[CheckInTbl] CHECK CONSTRAINT [FK_MasterStatusTbl_CheckInTbl]
GO
ALTER TABLE [dbo].[CheckInTbl]  WITH CHECK ADD  CONSTRAINT [FK_UserTbl_CheckInTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTbl] ([UserID])
GO
ALTER TABLE [dbo].[CheckInTbl] CHECK CONSTRAINT [FK_UserTbl_CheckInTbl]
GO
ALTER TABLE [dbo].[MasterStatusTbl]  WITH CHECK ADD  CONSTRAINT [FK_MasterColourTbl_MasterStatusTbl] FOREIGN KEY([ColourID])
REFERENCES [dbo].[MasterColourTbl] ([ColourID])
GO
ALTER TABLE [dbo].[MasterStatusTbl] CHECK CONSTRAINT [FK_MasterColourTbl_MasterStatusTbl]
GO
ALTER TABLE [dbo].[PetTbl]  WITH CHECK ADD  CONSTRAINT [FK_MasterPetTypeTbl_PetTbl] FOREIGN KEY([PetTypeID])
REFERENCES [dbo].[MasterPetTypeTbl] ([PetTypeID])
GO
ALTER TABLE [dbo].[PetTbl] CHECK CONSTRAINT [FK_MasterPetTypeTbl_PetTbl]
GO
ALTER TABLE [dbo].[PetTbl]  WITH CHECK ADD  CONSTRAINT [FK_UserTbl_PetTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserTbl] ([UserID])
GO
ALTER TABLE [dbo].[PetTbl] CHECK CONSTRAINT [FK_UserTbl_PetTbl]
GO
/****** Object:  StoredProcedure [dbo].[Create_Alert_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Insert data into AlertTbl
-- =============================================
CREATE PROCEDURE [dbo].[Create_Alert_Proc]
	@BackDisplayID INT,
	@Message VARCHAR(3000)

AS
BEGIN
	
	INSERT INTO [dbo].[AlertTbl](
		BackDisplayID,
		Message,
		TimeCreated
	)
	SELECT
		@BackDisplayID,
		@Message,
		GETDATE()

END
GO
/****** Object:  StoredProcedure [dbo].[Create_BackDisplay_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Insert data into BackDisplayTbl
-- =============================================
CREATE PROCEDURE [dbo].[Create_BackDisplay_Proc]
	@PetID INT

AS
BEGIN
	
	INSERT INTO [dbo].[BackDisplayTbl](
		PetID,
		Is_Arrived,
		Is_Inspected,
		Is_Released,
		ColourID
	)
	SELECT
		@PetID,
		0,
		0,
		0,
		0

END
GO
/****** Object:  StoredProcedure [dbo].[Create_CheckIn_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Insert data into CheckInTbl
-- =============================================
CREATE PROCEDURE [dbo].[Create_CheckIn_Proc]
	@UserID INT
	
AS
BEGIN
	
	INSERT INTO [dbo].[CheckInTbl](
		UserID,
		TimeCreated,
		StatusID
	)
	SELECT
		@UserID,
		GETDATE(),
		1

END
GO
/****** Object:  StoredProcedure [dbo].[Create_Pet_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Insert data into PetTbl
-- =============================================
CREATE PROCEDURE [dbo].[Create_Pet_Proc]
	@UserID INT,
	@PetName VARCHAR(50),
	@Microchip VARCHAR(10)

AS
BEGIN
	
	INSERT INTO[dbo].[PetTbl](
		UserID,
		PetName,
		Microchip,
		PetTypeID
	)
	SELECT
		@UserID,
		@PetName,
		@Microchip,
		1

END
GO
/****** Object:  StoredProcedure [dbo].[Create_User_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Insert data into UserTbl
-- =============================================
CREATE PROCEDURE [dbo].[Create_User_Proc]
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@PhoneNumber VARCHAR(10),
	@Email VARCHAR(50)
	
AS
BEGIN
	
	INSERT INTO [dbo].[UserTbl](
		FirstName,
		LastName,
		PhoneNumber,
		Email
	)
	SELECT
		@FirstName,
		@LastName,
		@PhoneNumber,
		@Email

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Alert_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Completes an Alert
-- =============================================
CREATE PROCEDURE [dbo].[Update_Alert_Proc]
	@AlertID INT
	
AS
BEGIN
	
	DECLARE @ErrorMsg VARCHAR(100)

	-----------
	-- Error Check
	-----------
	IF NOT EXISTS(
		SELECT
			1
		FROM [dbo].[AlertTbl]
		WHERE
			AlertID = @AlertID
	)
	BEGIN
		SET @ErrorMsg = 'We apologize, the record was not found.'
		GOTO ErrorCode
	END

	------------
	-- Update
	------------
	UPDATE [dbo].[AlertTbl]
	SET
		TimeCompleted = GETDATE()
	WHERE
		AlertID = @AlertID

ExitCode:
	SELECT
		1 AS Status,
		'' AS ERROR
	RETURN 1

ErrorCode:
	SELECT
		0 AS Status,
		@ErrorMsg AS Error
	RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[Update_BackDisplay_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Update data into BackDisplayTbl
-- =============================================
CREATE PROCEDURE [dbo].[Update_BackDisplay_Proc]
	@BackDisplayID INT,
	@Is_Arrived BIT,
	@Is_Inspected BIT,
	@Is_Released BIT
	
AS
BEGIN
	
	DECLARE @ErrorMsg VARCHAR(100)
	DECLARE @ColourID INT

	-----------
	-- Error Check
	-----------
	IF NOT EXISTS(
		SELECT
			1
		FROM dbo.BackDisplayTbl
		WHERE
			BackDisplayID = @BackDisplayID
	)
	BEGIN
		SET @ErrorMsg = 'We apologize, the record was not found.'
		GOTO ErrorCode
	END

	------------
	-- Update
	------------
	UPDATE [dbo].[BackDisplayTbl]
	SET
		Is_Arrived = ISNULL(@Is_Arrived, Is_Arrived),
		Is_Inspected = ISNULL(@Is_Inspected, Is_Inspected),
		Is_Released = ISNULL(@Is_Released, Is_Released)
	WHERE
		BackDisplayID = @BackDisplayID

	-- now update the colour depending the situation.
	UPDATE [dbo].[BackDisplayTbl]
	SET
		ColourID = CASE
						WHEN Is_Released = 0 AND Is_Arrived = 0 AND Is_Inspected = 0 THEN 1 -- red
						WHEN Is_Released = 0 AND (Is_Arrived = 1 OR Is_Inspected = 1) THEN 2 -- yellow 
						WHEN Is_Released = 1 THEN 3 -- red
					END
	WHERE
		BackDisplayID = @BackDisplayID
		
ExitCode:
	SELECT
		1 AS Status,
		'' AS ERROR
	RETURN 1

ErrorCode:
	SELECT
		0 AS Status,
		@ErrorMsg AS Error
	RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[View_Alert_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Display CheckIn
-- =============================================
CREATE PROCEDURE [dbo].[View_Alert_Proc]
	
AS
BEGIN
	
	SELECT
		CITbl.CheckInID,
		CITbl.UserID,
		UTbl.FirstName + ' ' + UTbl.LastName AS NAME,
		RIGHT(UTbl.PhoneNumber, 4),
		CITbl.StatusID,
		MSTbl.StatusName
	FROM [dbo].[CheckInTbl] CITbl
	---------------------------
	INNER JOIN UserTbl UTbl ON
	---------------------------
		CITbl.UserID = UTbl.UserID
	---------------------------
	INNER JOIN dbo.MasterStatusTbl MSTbl ON
	---------------------------
		CITBl.StatusID = MSTbl.StatusID
	WHERE
		TimeCreated > CAST(GETDATE() AS DATE) 
END
GO
/****** Object:  StoredProcedure [dbo].[View_BackDisplay_Proc]    Script Date: 3/8/2020 12:51:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Frendy Lio
-- Create date: 3/7/2020
-- Description:	Display BackDisplay
-- =============================================
CREATE PROCEDURE [dbo].[View_BackDisplay_Proc]
	
AS
BEGIN
	
	SELECT
		BDTbl.BackDisplayID,
		BDTbl.PetID,
		PTbl.PetName,
		PTbl.Microchip,
		BDTBL.UserID,
		UTbl.FirstName + ' ' + UTbl.LastName AS Name,
		BDTbl.Is_Arrived,
		BDTbl.Is_Inspected,
		BDTbl.Is_Released,
		BDTbl.ColourID,
		CMTBL.Colour
	FROM [dbo].[BackDisplayTbl] BDTbl
	---------------------------
	INNER JOIN [dbo].[MasterColourTbl] CMTbl ON
	---------------------------
		BDTbl.ColourID = CMTbl.ColourID
	---------------------------
	LEFT JOIN dbo.PetTbl AS PTbl ON
	---------------------------
		BDTbl.PetID = PTbl.PetID
	---------------------------
	LEFT JOIN dbo.UserTbl AS UTbl ON
	---------------------------
		BDTbl.UserID = UTbl.UserID

	WHERE
		TimeCreated > CAST(GETDATE() AS DATE) 
END
GO
USE [master]
GO
ALTER DATABASE [CIMP] SET  READ_WRITE 
GO
