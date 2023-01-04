CREATE TABLE [dbo].[Animals]
(
	[animaID] INT NOT NULL PRIMARY KEY, 
    [animalType] NVARCHAR(50) NOT NULL, 
    [maxWeight] NUMERIC(18, 2) NOT NULL, 
    [PTPrice] NUMERIC(18, 2) NOT NULL
)
