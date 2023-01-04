/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT * FROM DBO.Luggages)
BEGIN
    INSERT INTO DBO.Animals (animalID,animalType,maxWeight,PTPrice)
    VALUES (1,'Dog',30,59.99),
           (2,'Cat',25,45.90),
           (3,'Rabbit',20,42.30);
    INSERT INTO DBO.Luggages (luggageID,luggageType,maxWeight,luggagePrice)
    VALUES (1,'Small',10,25.50),
           (2,'Medium',20,58.90),
           (3,'Big',30,82.20),
           (4,'Humongous',40,125.50);
END