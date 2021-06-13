/* Use this script only for ASP.NET MVC User Identity database */

USE Store;
GO

CREATE TABLE Games(
	ID int IDENTITY(1,1) NOT NULL,
	[Title] nvarchar(850) NOT NULL,
	BasePrice decimal(9, 2) NOT NULL CONSTRAINT DF_Game_BasePrice DEFAULT (0.0), -- Началната цена на продукта
	Discount decimal(3, 2) NOT NULL CONSTRAINT DF_Game_Discount DEFAULT (1.0), -- По подразбиране продукта няма намаление
	ReleaseDate date NOT NULL,
	FaviconPath nvarchar(max) NOT NULL CONSTRAINT DF_Game_Favicon DEFAULT ('\Store\Data\Images\favicon.*'),
	CoverPath nvarchar(max) NOT NULL,
	[Description] nvarchar(max) NOT NULL CONSTRAINT DF_Game_Description DEFAULT ('No description'), -- Главното описание на играта

	CONSTRAINT PK_Games PRIMARY KEY(ID),
	CONSTRAINT UQ_Games_Title UNIQUE([Title]),
	CONSTRAINT CK_Games_Discount CHECK(Discount BETWEEN 0.0 AND 1.0)
);
GO

	CREATE TABLE Genres(
		ID int IDENTITY(1, 1) NOT NULL,
		[Name] nvarchar(30) NOT NULL,
	
		CONSTRAINT PK_Genres PRIMARY KEY (ID),
		CONSTRAINT UQ_Genres_Name UNIQUE([Name])
	);
	GO

		CREATE TABLE GameGenre(
			GameID int NOT NULL,
			GenreID int NOT NULL,

			CONSTRAINT UQ_GameGenre UNIQUE(GameID, GenreID), -- Само един жанр може да се отнася към една игра
			CONSTRAINT FK_GameGenre_GameID FOREIGN KEY(GameID) REFERENCES Games(ID),
			CONSTRAINT FK_GameGenre_GenreID FOREIGN KEY(GenreID) REFERENCES Genres(ID)
		);
		GO

	CREATE TABLE Platforms(
		ID int IDENTITY(1, 1) NOT NULL,
		[Name] nvarchar(30) NOT NULL,

		CONSTRAINT PK_Platforms PRIMARY KEY (ID),
		CONSTRAINT UQ_Platforms_Name UNIQUE([Name])
	);
	GO

		/* Нататък 'SysReq' в името на таблица означава системни изисквания за игра, посочени в таблиците */

		CREATE TABLE SysReqPlatform(
			GameID int NOT NULL,
			PlatformID int NOT NULL,

			CONSTRAINT UQ_SysReqPlatform UNIQUE(GameID, PlatformID), -- Само една платформа може да се отнася към една игра
			CONSTRAINT FK_SysReqPlatform_GameID FOREIGN KEY(GameID) REFERENCES Games(ID),
			CONSTRAINT FK_SysReqPlatform_PlatformID FOREIGN KEY(PlatformID) REFERENCES Platforms(ID)
		);
		GO

	CREATE TABLE Magazines(
		ID int IDENTITY(1, 1) NOT NULL,
		[Name] nvarchar(50) NOT NULL,
		LogoPath nvarchar(max),

		CONSTRAINT PK_Magazines PRIMARY KEY (ID),
		CONSTRAINT UQ_Magazines_Name UNIQUE ([Name])
	);
	GO

		CREATE TABLE MagazineNote(
			MagazineID int NOT NULL,
			GameID int NOT NULL,
			Note int NOT NULL,
	
			CONSTRAINT UQ_MagazineNote_MagazineID_GameID UNIQUE(MagazineID, GameID), -- Едно издание може да остави само една оценка на всяка една игра
			CONSTRAINT FK_MagazineNote_MagazineID FOREIGN KEY(MagazineID) REFERENCES Magazines(ID),
			CONSTRAINT FK_MagazineNote_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
		);
		GO

	CREATE TABLE GalleryVideosPaths(
		ID int NOT NULL IDENTITY(1, 1),
		[Path] nvarchar(max) NOT NULL,
		GameID int NOT NULL,

		CONSTRAINT PK_GalleryVideosPaths PRIMARY KEY(ID),
		CONSTRAINT FK_GalleryVideosPaths FOREIGN KEY(GameID) REFERENCES Games(ID)
	);
	GO

	CREATE TABLE GalleryImagesPaths(
		ID int NOT NULL IDENTITY(1, 1),
		[Path] nvarchar(max) NOT NULL,
		GameID int NOT NULL,

		CONSTRAINT PK_GalleryImagesPaths PRIMARY KEY(ID),
		CONSTRAINT FK_GalleryImagesPaths FOREIGN KEY(GameID) REFERENCES Games(ID)
	);
	GO

	CREATE TABLE CPUManufacturers(
		ID int NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(50) NOT NULL,

		CONSTRAINT PK_CPUManufacturers PRIMARY KEY(ID),
		CONSTRAINT UQ_CPUManufacturers_Name UNIQUE([Name])
	);
	GO
		
	CREATE TABLE CPUModels(
		ID int NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(50) NOT NULL,

		CONSTRAINT PK_CPUModels PRIMARY KEY(ID),
		CONSTRAINT UQ_CPUModels_Name UNIQUE([Name]),
	);
	GO
		
	CREATE TABLE CPUSeries(
		ID int NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(50) NOT NULL,

		CONSTRAINT PK_CPUSeries PRIMARY KEY(ID),
		CONSTRAINT UQ_CPUSeries_Name UNIQUE([Name]),
	);
	GO
		
	CREATE TABLE CPUClockFreqs(
		ID int NOT NULL IDENTITY(1, 1),
		FrequencyMGh int NOT NULL,

		CONSTRAINT PK_CPUClockFreqs PRIMARY KEY(ID),
		CONSTRAINT UQ_CPUClockFreqs_FrequencyMGh UNIQUE(FrequencyMGh)
	);
	GO
	
		CREATE TABLE CPUs(
			ID int NOT NULL IDENTITY(1, 1),
			ManufacturerID int,
			ModelID int,
			SeriesID int,
			FrequencyMGhID int,

			CONSTRAINT PK_CPUs PRIMARY KEY(ID),
			CONSTRAINT UQ_CPUs UNIQUE(ManufacturerID, ModelID, SeriesID, FrequencyMGhID),
			CONSTRAINT FK_CPUs_ManufacturerID FOREIGN KEY(ManufacturerID) REFERENCES CPUManufacturers(ID),
			CONSTRAINT FK_CPUs_ModelID FOREIGN KEY(ModelID) REFERENCES CPUModels(ID),
			CONSTRAINT FK_CPUs_SeriesID FOREIGN KEY(SeriesID) REFERENCES CPUSeries(ID),
			CONSTRAINT FK_CPUs_FrequencyMGhID FOREIGN KEY(FrequencyMGhID) REFERENCES CPUClockFreqs(ID)
		);
		GO
		
			CREATE TABLE MinSysReqCPU(
				CPUID int NOT NULL,
				GameID int NOT NULL,
				
				CONSTRAINT UQ_MinSysReqCPU UNIQUE(CPUID, GameID),
				CONSTRAINT FK_MinSysReqCPU_CPUID FOREIGN KEY(CPUID) REFERENCES CPUs(ID),
				CONSTRAINT FK_MinSysReqCPU_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
			);
			GO
		
	CREATE TABLE RAMSizes(
		ID int IDENTITY(1, 1) NOT NULL,
		SizeMB int NOT NULL,

		CONSTRAINT PK_RAMSizes PRIMARY KEY (ID),
		CONSTRAINT UQ_RAMSizes_SizeMB UNIQUE(SizeMB)
	);
	GO

		CREATE TABLE MinSysReqRAMSize(
			RAMSizeID int NOT NULL,
			GameID int NOT NULL,

			CONSTRAINT UQ_MinSysReqRAMSize UNIQUE(RAMSizeID, GameID),
			CONSTRAINT FK_MinSysReqRAMSize_RAMSizeID FOREIGN KEY(RAMSizeID) REFERENCES RAMSizes(ID),
			CONSTRAINT FK_MinSysReqRAMSize_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
		);
		GO

	CREATE TABLE GPUManufacturers(
		ID int NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(50) NOT NULL,

		CONSTRAINT PK_GPUManufacturers PRIMARY KEY(ID),
		CONSTRAINT UQ_GPUManufacturers_Name UNIQUE([Name])
	);
	GO
		
	CREATE TABLE GPUModels(
		ID int NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(50) NOT NULL,

		CONSTRAINT PK_GPUModels PRIMARY KEY(ID),
		CONSTRAINT UQ_GPUModels_Name UNIQUE([Name]),
	);
	GO
		
	CREATE TABLE GPUSeries(
		ID int NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(50) NOT NULL,

		CONSTRAINT PK_GPUSeries PRIMARY KEY(ID),
		CONSTRAINT UQ_GPUSeries_Name UNIQUE([Name]),
	);
	GO

	CREATE TABLE GPU_VRAMs(
		ID int NOT NULL IDENTITY(1, 1),
		SizeMB int,

		CONSTRAINT PK_GPU_VRAMs PRIMARY KEY(ID),
		CONSTRAINT UQ_GPU_VRAMs_SizeMB UNIQUE(SizeMB)
	);
	GO

	CREATE TABLE GPUClockFreqs(
		ID int NOT NULL IDENTITY(1, 1),
		FrequencyMGh int NOT NULL,

		CONSTRAINT PK_GPUClockFreqs PRIMARY KEY(ID),
		CONSTRAINT UQ_GPUClockFreqs_FrequencyMGh UNIQUE(FrequencyMGh)
	);
	GO
		
		CREATE TABLE GPUs(
			ID int NOT NULL IDENTITY(1, 1),
			ManufacturerID int,
			ModelID int,
			SeriesID int,
			FrequencyMGhID int,
			VRAM_MB_ID int,

			CONSTRAINT PK_GPUs PRIMARY KEY(ID),
			CONSTRAINT UQ_GPUs UNIQUE(ManufacturerID, ModelID, SeriesID, FrequencyMGhID, VRAM_MB_ID),
			CONSTRAINT FK_GPUs_ManufacturerID FOREIGN KEY(ManufacturerID) REFERENCES GPUManufacturers(ID),
			CONSTRAINT FK_GPUs_ModelID FOREIGN KEY(ModelID) REFERENCES GPUModels(ID),
			CONSTRAINT FK_GPUs_SeriesID FOREIGN KEY(SeriesID) REFERENCES GPUSeries(ID),
			CONSTRAINT FK_GPUs_VRAM_MB_ID FOREIGN KEY(VRAM_MB_ID) REFERENCES GPU_VRAMs(ID),
			CONSTRAINT FK_GPUs_FrequencyMGhID FOREIGN KEY(FrequencyMGhID) REFERENCES GPUClockFreqs(ID)
		);
		GO

			CREATE TABLE MinSysReqGPU(
				GPUID int NOT NULL,
				GameID int NOT NULL,
				
				CONSTRAINT UQ_MinSysReqGPU UNIQUE(GPUID, GameID),
				CONSTRAINT FK_MinSysReqGPU_GPUID FOREIGN KEY(GPUID) REFERENCES GPUs(ID),
				CONSTRAINT FK_MinSysReqGPU_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
			);
			GO

	CREATE TABLE DirectXVersions(
		ID int NOT NULL IDENTITY(1, 1),
		[Version] nvarchar(30),

		CONSTRAINT PK_DirectXVersions PRIMARY KEY(ID),
		CONSTRAINT UQ_DirectXVersions_Version UNIQUE([Version])
	);
	GO

		CREATE TABLE MinSysReqDirectXVersion(
			VersionID int NOT NULL,
			GameID int NOT NULL,
	
			CONSTRAINT FK_MinSysReqDirectXVersion_VersionID FOREIGN KEY(VersionID) REFERENCES DirectXVersions(ID),
			CONSTRAINT FK_MinSysReqDirectXVersion_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
		);
		GO

	CREATE TABLE StorageFreeSpaces(
		ID bigint NOT NULL IDENTITY(1, 1),
		FreeSpaceMB bigint,

		CONSTRAINT PK_StorageFreeSpaces PRIMARY KEY(ID),
		CONSTRAINT UQ_StorageFreeSpaces_FreeSpaceMB UNIQUE(FreeSpaceMB)
	);
	GO

		CREATE TABLE MinSysReqFreeSpace(
			FreeSpaceMBID bigint NOT NULL,
			GameID int NOT NULL,
	
			CONSTRAINT FK_MinSysReqFreeSpace_FreeSpaceMBID FOREIGN KEY(FreeSpaceMBID) REFERENCES StorageFreeSpaces(ID),
			CONSTRAINT FK_MinSysReqFreeSpace_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
		);
		GO

/* Following instructions are used only for ASP.NET MVC User Identity database */

ALTER TABLE AspNetUsers ADD RegistrationDate date NOT NULL CONSTRAINT DF_Users_RegistrationDate DEFAULT SYSDATETIME();
ALTER TABLE AspNetUsers ADD Age tinyint;

ALTER TABLE AspNetUsers ADD CONSTRAINT UQ_Users_Email UNIQUE(Email);
ALTER TABLE AspNetUsers ADD CONSTRAINT CK_Users_Email CHECK(LEN(Email) <= 256);

CREATE TABLE UsersReviews(
	ID bigint NOT NULL IDENTITY(1, 1),
	DatetimeWritten datetime2 NOT NULL CONSTRAINT DF_UsersReviews_DatetimeWritten DEFAULT(SYSDATETIME()),
	Content nvarchar(max), -- Съдержанието на коментара
	UserID nvarchar(450) NOT NULL,
	GameID int NOT NULL,

	CONSTRAINT PK_UsersReviews PRIMARY KEY(ID),
	CONSTRAINT FK_UsersReviews_UserID FOREIGN KEY(UserID) REFERENCES AspNetUsers(ID),
	CONSTRAINT FK_UsersReviews_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
);
GO

CREATE TABLE Checks(
	Number bigint IDENTITY(1, 1) NOT NULL,
	CheckDatetime datetime2 NOT NULL CONSTRAINT DF_Checks_DatetimeCheck DEFAULT(SYSDATETIME()), -- Времето, когато бележката е издадена (момента на купуване)
	GeneralSum decimal(9, 2) /*NOT NULL CONSTRAINT DF_Checks_General_Sum DEFAULT(0.0)*/, -- Обща сума на всички продукти в бележката
	UserID nvarchar(450) NOT NULL,

	CONSTRAINT PK_Checks PRIMARY KEY(Number),
	CONSTRAINT UQ_Checks_Number_User UNIQUE(Number, UserID),
	CONSTRAINT FK_Checks_UserID FOREIGN KEY(UserID) REFERENCES AspNetUsers(Id)
);
GO

	CREATE TABLE CheckEntry(
		GameID int NOT NULL,
		BasePrice decimal(9, 2) NOT NULL CONSTRAINT DF_CheckEntry_BasePrice DEFAULT (0.0), -- Цена за един продукт
		Quantity int NOT NULL CONSTRAINT DF_CheckEntry_Quantity DEFAULT (1),
		Number bigint NOT NULL,
		
		CONSTRAINT UQ_CheckEntry_GameID_Number UNIQUE(GameID, Number),
		CONSTRAINT CK_CheckEntry_Quantity CHECK(Quantity >= 1),
		CONSTRAINT FK_CheckEntry_Number FOREIGN KEY(Number) REFERENCES Checks(Number),
		CONSTRAINT FK_CheckEntry_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
	);
	GO

CREATE TABLE LibraryItem(
	UserID nvarchar(450) NOT NULL,
	GameID int NOT NULL,

	CONSTRAINT UQ_LibraryItem UNIQUE(UserID, GameID), -- Само една игра може да се отнася към един потребител
	CONSTRAINT FK_LibraryItem_UserID FOREIGN KEY(UserID) REFERENCES AspNetUsers(Id),
	CONSTRAINT FK_LibraryItem_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
);
GO

CREATE TABLE WishlistEntry(
	UserID nvarchar(450) NOT NULL,
	GameID int NOT NULL,

	CONSTRAINT UQ_WishlistEntry UNIQUE(UserID, GameID), -- Само една игра може да се отнася към списъка с желания на потребителя
	CONSTRAINT FK_WishlistEntry_UserID FOREIGN KEY(UserID) REFERENCES AspNetUsers(Id),
	CONSTRAINT FK_WishlistEntry_GameID FOREIGN KEY(GameID) REFERENCES Games(ID)
);
