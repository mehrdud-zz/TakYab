USE [TakYab]
GO

DECLARE @SubModelId AS uniqueidentifier
DECLARE @ProvinceId AS uniqueidentifier
DECLARE @BuildYearId AS uniqueidentifier
DECLARE @PriceRangeId AS uniqueidentifier
DECLARE @PriorityId AS uniqueidentifier
DECLARE @AdStatusId AS uniqueidentifier
DECLARE @OutsideColourId AS uniqueidentifier
DECLARE @InsideColourId AS uniqueidentifier
DECLARE @FuelTypeId AS uniqueidentifier
DECLARE @InsuranceTypeId AS uniqueidentifier
DECLARE @CarStatusId AS uniqueidentifier
DECLARE @Name AS NVARCHAR(50)
DECLARE @Description AS NVARCHAR(50)
DECLARE @Price AS MONEY
DECLARE @SortOrder AS INT
DECLARE @AdCreatedDate AS DATETIME
DECLARE @AdValidUntil AS DATETIME
DECLARE @GearType AS NVARCHAR(50)
DECLARE @PhoneNumber AS NVARCHAR(50)
DECLARE @ImageURI1 AS NVARCHAR(50)
DECLARE @ImageURI2 AS NVARCHAR(50)
DECLARE @ImageURI3 AS NVARCHAR(50)
DECLARE @ImageURI4 AS NVARCHAR(50)
DECLARE @ImageURI5 AS NVARCHAR(50)
DECLARE @Milage AS BIGINT  

INSERT INTO [dbo].[Car]
           ( [SubModelId]
           ,[ProvinceId]
           ,[AdTypeId]
           ,[BuildYearId]
           ,[PriceRangeId]
           ,[PriorityId]
           ,[AdStatusId]
           ,[OutsideColourId]
           ,[InsideColourId]
           ,[FuelTypeId]
           ,[InsuranceTypeId]
           ,[CarStatusId]
           ,[Name]
           ,[Description]
           ,[Price]
           ,[SortOrder]
           ,[AdCreatedDate]
           ,[AdValidUntil]
           ,[GearType]
           ,[PhoneNumber]
           ,[ImageURI1]
           ,[ImageURI2]
           ,[ImageURI3]
           ,[ImageURI4]
           ,[ImageURI5]
           ,[Milage])
     VALUES
           @CarId, 
           @SubModelId, 
           @ProvinceId,
           @AdTypeId, 
           @BuildYearId, 
           @PriceRangeId,
           @PriorityId,
           @AdStatusId, 
           @OutsideColourId, 
           @InsideColourId, uniqueidentifier,>
           @FuelTypeId, uniqueidentifier,>
           @InsuranceTypeId, uniqueidentifier,>
           @CarStatusId, uniqueidentifier,>
           @Name, nvarchar(50),>
           @Description, nvarchar(2000),>
           @Price, money,>
           @SortOrder, int,>
           @AdCreatedDate, datetime,>
           @AdValidUntil, datetime,>
           @GearType, nvarchar(50),>
           @PhoneNumber, nvarchar(50),>
           @ImageURI1, nvarchar(500),>
           @ImageURI2, nvarchar(500),>
           @ImageURI3, nvarchar(500),>
           @ImageURI4, nvarchar(500),>
           @ImageURI5, nvarchar(500),>
           @Milage, bigint,>)
GO


