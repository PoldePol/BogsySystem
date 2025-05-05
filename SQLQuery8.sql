DELETE FROM RentalInformation;
DBCC CHECKIDENT ('RentalInformation', RESEED, 0);