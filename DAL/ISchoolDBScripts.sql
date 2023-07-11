/****** Object:  ForeignKey [FK_Settings_SettingsGroup]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[core_Settings]'))
ALTER TABLE [dbo].[core_Settings] DROP CONSTRAINT [FK_Settings_SettingsGroup]
GO
/****** Object:  ForeignKey [FK_Accounts_Coa]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts] DROP CONSTRAINT [FK_Accounts_Coa]
GO
/****** Object:  ForeignKey [FK_CustomerAccounts_Customers]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]'))
ALTER TABLE [dbo].[gl_CustomerAccounts] DROP CONSTRAINT [FK_CustomerAccounts_Customers]
GO
/****** Object:  ForeignKey [FK_TransactionTypes_Trasactions]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]'))
ALTER TABLE [dbo].[gl_TransactionTypes] DROP CONSTRAINT [FK_TransactionTypes_Trasactions]
GO
/****** Object:  ForeignKey [FK_sec_Rights_sec_Roles]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Rights]'))
ALTER TABLE [dbo].[sec_Rights] DROP CONSTRAINT [FK_sec_Rights_sec_Roles]
GO
/****** Object:  ForeignKey [FK_sec_Users_sec_Roles]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Users]'))
ALTER TABLE [dbo].[sec_Users] DROP CONSTRAINT [FK_sec_Users_sec_Roles]
GO
/****** Object:  Table [dbo].[core_Settings]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_Settings]') AND type in (N'U'))
DROP TABLE [dbo].[core_Settings]
GO
/****** Object:  Table [dbo].[gl_Accounts]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Accounts]
GO
/****** Object:  Table [dbo].[gl_TransactionTypes]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]') AND type in (N'U'))
DROP TABLE [dbo].[gl_TransactionTypes]
GO
/****** Object:  Table [dbo].[sec_Rights]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Rights]') AND type in (N'U'))
DROP TABLE [dbo].[sec_Rights]
GO
/****** Object:  Table [dbo].[gl_CustomerAccounts]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]') AND type in (N'U'))
DROP TABLE [dbo].[gl_CustomerAccounts]
GO
/****** Object:  Table [dbo].[sec_Users]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Users]') AND type in (N'U'))
DROP TABLE [dbo].[sec_Users]
GO
/****** Object:  Table [dbo].[Commands]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
DROP TABLE [dbo].[Commands]
GO
/****** Object:  Table [dbo].[gl_Customers]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Customers]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Customers]
GO
/****** Object:  Table [dbo].[sec_Roles]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[sec_Roles]
GO
/****** Object:  Table [dbo].[gl_Trasactions]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Trasactions]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Trasactions]
GO
/****** Object:  Table [dbo].[gl_Coa]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Coa]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Coa]
GO
/****** Object:  Table [dbo].[core_SettingsGroup]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_SettingsGroup]') AND type in (N'U'))
DROP TABLE [dbo].[core_SettingsGroup]
GO
/****** Object:  Table [dbo].[core_SettingsGroup]    Script Date: 10/03/2012 08:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_SettingsGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[core_SettingsGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [int] NOT NULL,
 CONSTRAINT [PK_SettingsGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[core_SettingsGroup] ON
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (1, N'Settings', 0)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (2, N'General', 1)
SET IDENTITY_INSERT [dbo].[core_SettingsGroup] OFF
/****** Object:  Table [dbo].[gl_Coa]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Coa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Coa](
	[Id] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nchar](30) COLLATE Latin1_General_CI_AS NOT NULL,
	[Level] [int] NOT NULL,
	[Parent] [nvarchar](20) COLLATE Latin1_General_CI_AS NOT NULL,
	[Lorder] [int] NOT NULL,
 CONSTRAINT [PK_Coa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'A                   ', N'ASSET                         ', 0, N'0                   ', 1)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'C                   ', N'CAPITAL                       ', 0, N'0                   ', 5)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'E                   ', N'EXPENSES                      ', 0, N'0                   ', 4)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'I                   ', N'INCOME                        ', 0, N'0                   ', 3)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'L                   ', N'LIABILITIES                   ', 0, N'0                   ', 2)
/****** Object:  Table [dbo].[gl_Trasactions]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Trasactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Trasactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[TrasactionType] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[TransRef] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContraRef] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Amount] [money] NOT NULL,
	[Narrative1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Narrative2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserId] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Authorizer] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostDate] [datetime] NOT NULL,
	[ValueDate] [datetime] NOT NULL,
	[RecDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Trasactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[sec_Roles]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sec_Roles](
	[RoleId] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleDescription] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_sec_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'ADMIN', N'Administrator Role')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'DBADMIN', N'Database Administrator')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'DECLERK', N'Data Entry Clerk')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'LOANOFFICER', N'Loan Officer')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'MANAGER', N'Manager')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'SUPERVISOR', N'FOSA Supervisor')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'SYSADMIN', N'System Adminsitrator')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'TELLER', N'FOSA Teller')
/****** Object:  Table [dbo].[gl_Customers]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[NationalID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessLicenseNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DrivingLicenseNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PIN] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShortName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FirstName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecondName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThirdName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Surname] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AlternativesName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostalAddress] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StreetAddress1A] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StreetAddress1B] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StreetAddress1C] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[streetAddress1D] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Province] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Country] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[District] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Postalcode] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CountryCode] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AreaCode] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TelephoneType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmailType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telex] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Customertype1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerType2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerType3] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SICTypeCode] [int] NULL,
	[OtherTypeCodes] [int] NULL,
	[Branch] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProductUsageReason] [varchar](850) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CampaignResponse] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerReferral] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrimaryAccountOfficer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecondaryAccountOfficer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OfficerReferral] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherAccountOfficers] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SwiftSwift] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CHCode1] [int] NULL,
	[CHCode2] [int] NULL,
	[CHCode3] [int] NULL,
	[CorrespondenceType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorrespondenceHold] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AddressToUse] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Salutation] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntraSaccoingIndicator] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntrasaccoingPassword] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntraSaccoingPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InternetSaccoing] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InternetPasser] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InternetPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ATMNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ATMPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HomeSaccoing] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneSaccoingPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherDeliveryData] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TypeOfEmployment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Employer] [int] NULL,
	[EmployerAddress] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YearsEmployed] [int] NULL,
	[AnnualSalary] [money] NULL,
	[Title] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OccupationDate] [datetime] NULL,
	[EmploymentStatus] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OccupationType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ForeignID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Citizenship] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NetWorth] [money] NULL,
	[Gender] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EducationLevel] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CertificationDate] [datetime] NULL,
	[BirthDay] [datetime] NULL,
	[Spouse] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NumberofDependants] [int] NULL,
	[Ages] [datetime] NULL,
	[AgeGroup] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HousingOwnershipType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YearsInHome] [int] NULL,
	[OutstandingMortgage] [decimal](18, 0) NULL,
	[Language] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Religion] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DeathNotificationDate] [datetime] NULL,
	[DeathDay] [datetime] NULL,
	[CompanyLicense] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AnnualSales] [decimal](18, 0) NULL,
	[SignatoryRestriction] [decimal](18, 0) NULL,
	[IncorporationDate] [datetime] NULL,
	[NumberofEmployees] [int] NULL,
	[Relationships] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreditRating] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GeographicArea] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebtLevelSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebtLevelDate] [datetime] NULL,
	[BusinessAgeSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessAgeDate] [datetime] NULL,
	[RevenueSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RevenueSegmentDate] [datetime] NULL,
	[EmployeeCountSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmployeeCountSegmDate] [datetime] NULL,
	[GrowthRateSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GrowthRateSegmentDate] [datetime] NULL,
	[CapitalizationSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CapitalizationSegmentDate] [datetime] NULL,
	[ProfitabilitySegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProfitabilitySegmentDate] [datetime] NULL,
	[LifeCycleStatus] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EstablishDate] [datetime] NULL,
	[DissolvedDate] [datetime] NULL,
	[DebtClassSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerGradeSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LongTermDebtToFinanceRatio] [int] NULL,
	[DebtToEquityRatio] [int] NULL,
	[AssetTurnOver] [money] NULL,
	[PriceRatio] [int] NULL,
	[EarnPerShare] [money] NULL,
	[ReturnOnEquity] [money] NULL,
	[ReturnOnNetTotalAssets] [money] NULL,
	[ReturnOnTotalAssets] [money] NULL,
	[ReturnOnCapitalEmployed] [money] NULL,
	[AnnualSaleRevenue] [money] NULL,
	[AnnualPreTaxProfit] [money] NULL,
	[CapitalandReserves] [money] NULL,
	[TotalBorrowing] [money] NULL,
	[CurrentAssets] [money] NULL,
	[FixedAssets] [money] NULL,
	[DepositAccountNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Count] [int] NULL,
	[Amount] [money] NULL,
	[InterestYTD] [money] NULL,
	[JointOwnership] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DepositHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LineAmount] [money] NULL,
	[BalanceOutstanding] [money] NULL,
	[InterestRate] [int] NULL,
	[CreditAvailable] [money] NULL,
	[CreditCardInterestYTD] [money] NULL,
	[LateFees] [money] NULL,
	[DueDate] [datetime] NULL,
	[CreditInfo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CredidcardHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanAccNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OriginalLoan] [money] NULL,
	[PrincipalAmount] [money] NULL,
	[AnnualYield] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccruedInterest] [money] NULL,
	[CurrentBalance] [money] NULL,
	[PayOffAmount] [money] NULL,
	[LoanAccountHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrincipalPaid] [money] NULL,
	[InterestPaid] [money] NULL,
	[CostofFunds] [money] NULL,
	[SourceofFunds] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Commands]    Script Date: 10/03/2012 08:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Commands](
	[CommanId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AssemblyPath] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Class] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Method] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Commands] ([CommanId], [AssemblyPath], [Class], [Method]) VALUES (N'CreateCustomer', N'CIS', N'Repository', N'CreateCustomer')
/****** Object:  Table [dbo].[sec_Users]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sec_Users](
	[UserName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FullNames] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Role] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[sec_Users] ([UserName], [FullNames], [Password], [Role]) VALUES (N'joan', N'Joan Wanjuki', N'sys', N'DBADMIN')
INSERT [dbo].[sec_Users] ([UserName], [FullNames], [Password], [Role]) VALUES (N'kevin', N'kevin', N'kevin', N'ADMIN')
INSERT [dbo].[sec_Users] ([UserName], [FullNames], [Password], [Role]) VALUES (N'sys', N'system administrator', N'sys', N'ADMIN')
/****** Object:  Table [dbo].[gl_CustomerAccounts]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_CustomerAccounts](
	[CustomerId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Mandate] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_CustomerAccounts] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[sec_Rights]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Rights]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sec_Rights](
	[RightId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Object] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ObjectType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CanView] [bit] NULL,
	[CanRead] [bit] NULL,
	[CanDelete] [bit] NULL,
	[CanExecute] [bit] NULL,
 CONSTRAINT [PK_Rights_1] PRIMARY KEY CLUSTERED 
(
	[RightId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[sec_Rights] ON
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (1, N'DBADMIN', N'USERADMINMODULE', N'MODULE', N'SHELL', NULL, NULL, NULL, NULL)
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (2, N'DBADMIN', N'ADDRIGHTVIEW', N'VIEW', N'USERADMINMODULE', 1, 1, NULL, 1)
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (3, N'TELLER', N'TELLERMODULE', N'MODULE', N'SHELL', NULL, NULL, NULL, NULL)
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (4, N'TELLER', N'INQUIRYMODULE', N'MODULE', N'SHELL', NULL, NULL, NULL, NULL)
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (5, N'LOANOFFICER', N'LOANMODULE', N'MODULE', N'SHELL', NULL, NULL, NULL, NULL)
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (6, N'LOANOFFICER', N'INQUIRYMODULE', N'MODULE', N'SHELL', NULL, NULL, NULL, NULL)
INSERT [dbo].[sec_Rights] ([RightId], [Role], [Object], [ObjectType], [Parent], [CanView], [CanRead], [CanDelete], [CanExecute]) VALUES (7, N'DBADMIN', N'SAVECOMMAND', N'COMMAND', N'ADDRIGHTVIEW', 1, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[sec_Rights] OFF
/****** Object:  Table [dbo].[gl_TransactionTypes]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_TransactionTypes](
	[TransactionTypeId] [int] NOT NULL,
	[DebitCredit] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShortCode] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultAmount] [money] NULL,
	[DefaultCrAccount] [int] NULL,
	[DefaultDrAccount] [int] NULL,
	[DefaultDrNarrative] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultCrNarrative] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Accounts]    Script Date: 10/03/2012 08:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Accounts](
	[AccountID] [int] NOT NULL,
	[COA] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountType] [int] NULL,
	[AccountName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountingPeriod] [datetime] NULL,
	[DateofEntry] [datetime] NULL,
	[TimeofEntry] [datetime] NULL,
	[Authorizer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GLNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClearedBalance] [money] NULL,
	[BookBalance] [money] NULL,
	[AccruedInterest] [money] NULL,
	[InterestYTD] [money] NULL,
	[JointOwnership] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanAccountNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrincipalAmount] [decimal](18, 0) NULL,
	[Annualyield] [decimal](18, 0) NULL,
	[CurrentBalance] [decimal](18, 0) NULL,
	[PayoffAmount] [decimal](18, 0) NULL,
	[Costoffunds] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Accounts_1] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[COA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[core_Settings]    Script Date: 10/03/2012 08:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[core_Settings](
	[SSKey] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SSValue] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SSValueType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SGroup] [int] NOT NULL,
	[SSSystem] [bit] NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SSKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'DBVERSION', N'1.0.0', N'S', N'Database Version', 2, 0)
/****** Object:  ForeignKey [FK_Settings_SettingsGroup]    Script Date: 10/03/2012 08:49:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[core_Settings]'))
ALTER TABLE [dbo].[core_Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_SettingsGroup] FOREIGN KEY([SGroup])
REFERENCES [dbo].[core_SettingsGroup] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[core_Settings]'))
ALTER TABLE [dbo].[core_Settings] CHECK CONSTRAINT [FK_Settings_SettingsGroup]
GO
/****** Object:  ForeignKey [FK_Accounts_Coa]    Script Date: 10/03/2012 08:49:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Coa] FOREIGN KEY([COA])
REFERENCES [dbo].[gl_Coa] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts] CHECK CONSTRAINT [FK_Accounts_Coa]
GO
/****** Object:  ForeignKey [FK_CustomerAccounts_Customers]    Script Date: 10/03/2012 08:49:10 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]'))
ALTER TABLE [dbo].[gl_CustomerAccounts]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAccounts_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[gl_Customers] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]'))
ALTER TABLE [dbo].[gl_CustomerAccounts] CHECK CONSTRAINT [FK_CustomerAccounts_Customers]
GO
/****** Object:  ForeignKey [FK_TransactionTypes_Trasactions]    Script Date: 10/03/2012 08:49:10 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]'))
ALTER TABLE [dbo].[gl_TransactionTypes]  WITH CHECK ADD  CONSTRAINT [FK_TransactionTypes_Trasactions] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[gl_Trasactions] ([TransactionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]'))
ALTER TABLE [dbo].[gl_TransactionTypes] CHECK CONSTRAINT [FK_TransactionTypes_Trasactions]
GO
/****** Object:  ForeignKey [FK_sec_Rights_sec_Roles]    Script Date: 10/03/2012 08:49:10 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Rights]'))
ALTER TABLE [dbo].[sec_Rights]  WITH CHECK ADD  CONSTRAINT [FK_sec_Rights_sec_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[sec_Roles] ([RoleId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Rights]'))
ALTER TABLE [dbo].[sec_Rights] CHECK CONSTRAINT [FK_sec_Rights_sec_Roles]
GO
/****** Object:  ForeignKey [FK_sec_Users_sec_Roles]    Script Date: 10/03/2012 08:49:10 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Users]'))
ALTER TABLE [dbo].[sec_Users]  WITH CHECK ADD  CONSTRAINT [FK_sec_Users_sec_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[sec_Roles] ([RoleId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Users]'))
ALTER TABLE [dbo].[sec_Users] CHECK CONSTRAINT [FK_sec_Users_sec_Roles]
GO
