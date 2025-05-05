DELETE FROM CustomerLibrary;
DBCC CHECKIDENT ('CustomerLibrary', RESEED, 0);