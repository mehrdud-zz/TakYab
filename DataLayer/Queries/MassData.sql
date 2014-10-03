USE [TakYab]
GO

DECLARE @SubModelId AS uniqueidentifier
DECLARE @ProvinceId AS uniqueidentifier
DECLARE @BuildYearId AS uniqueidentifier
DECLARE @PriceRangeId AS uniqueidentifier
DECLARE @PriorityId AS uniqueidentifier
DECLARE @AdStatusId AS uniqueidentifier
DECLARE @AdTypeId AS uniqueidentifier
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




SET @SubModelId = (SELECT TOP(1) [SubModelId] from [SubModel] ORDER BY [SortOrder])
SET @ProvinceId  = (SELECT TOP(1) [ProvinceId] from [Province] ORDER BY [SortOrder])
SET @BuildYearId  = (SELECT TOP(1) [BuildYearId] from [BuildYear] ORDER BY [SortOrder])
SET @PriceRangeId  = (SELECT TOP(1) [PriceRangeId] from [PriceRange] ORDER BY [SortOrder])
SET @PriorityId  = (SELECT TOP(1) [PriorityId] from [Priority] ORDER BY [SortOrder])
SET @AdStatusId  = (SELECT TOP(1) [AdStatusId] from [AdStatus] ORDER BY [SortOrder])
SET @AdTypeId  = (SELECT TOP(1) [AdTypeId] from [AdType] ORDER BY [SortOrder])
SET @OutsideColourId  = (SELECT TOP(1) [ColourId] from [Colour] ORDER BY [SortOrder])
SET @InsideColourId  = (SELECT TOP(1) [ColourId] from [Colour] ORDER BY [SortOrder])
SET @FuelTypeId  = (SELECT TOP(1) [FuelTypeId] from [FuelType] ORDER BY [SortOrder])
SET @InsuranceTypeId  = (SELECT TOP(1) [InsuranceTypeId] from [InsuranceType] ORDER BY [SortOrder])
SET @CarStatusId  = (SELECT TOP(1) [CarStatusId] from [CarStatus] ORDER BY [SortOrder])
SET @Name = 'Test'
SET @Description = 'Test'
SET @Price =10000000
SET @SortOrder= 2
SET @AdCreatedDate = NULL
SET @AdValidUntil = NULL
SET @GearType = 'Test'
SET @PhoneNumber = 'Test' 
SET @Milage =10000
SET @ImageURI1 = (SELECT TOP(1) [ImageURI1] from [Car] ORDER BY [SortOrder])
SET @ImageURI2 = (SELECT TOP(1) [ImageURI2] from [Car] ORDER BY [SortOrder])

WHILE(@SortOrder<30001)
BEGIN
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
           ,[AdCreatedDate]
           ,[AdValidUntil]
           ,[GearType]
           ,[PhoneNumber]
           ,[ImageURI1] 
		   ,[ImageURI2] 
           ,[Milage]
		   ,[SortOrder])
     VALUES  
           (@SubModelId, 
           @ProvinceId,
           @AdTypeId, 
           @BuildYearId, 
           @PriceRangeId,
           @PriorityId,
           @AdStatusId, 
           @OutsideColourId, 
           @InsideColourId,
           @FuelTypeId,
           @InsuranceTypeId,
           @CarStatusId,
           @Name,
           @Description, 
           @Price, 
           @AdCreatedDate,
           @AdValidUntil,
           @GearType, 
           @PhoneNumber,
           @ImageURI1, 
           @ImageURI2, 
           @Milage,		   
           @SortOrder)
 
 SET @SortOrder = @SortOrder + 1

END