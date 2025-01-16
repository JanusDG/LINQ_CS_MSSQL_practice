-- /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '&e!dXne}' -i db_setup.sql

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Task1NumbersTable') AND type = N'U')
BEGIN
    CREATE TABLE Task1NumbersTable (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Value INT UNIQUE
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Task4NumbersTable') AND type = N'U') 
BEGIN 
CREATE TABLE Task4NumbersTable (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Value INT);
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Task5SymbolsTable') AND type = N'U') 
BEGIN 
CREATE TABLE Task5SymbolsTable (
     Id INT IDENTITY(1,1) PRIMARY KEY,
    Value CHAR(255) NOT NULL)
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Task6DatesTable') AND type = N'U') 
BEGIN 
CREATE TABLE Task6DatesTable (
     Id INT IDENTITY(1,1) PRIMARY KEY,
     Value DATE UNIQUE NOT NULL);
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Task8StringsTable') AND type = N'U') 
BEGIN 
CREATE TABLE Task8StringsTable (
     Id INT IDENTITY(1,1) PRIMARY KEY,
    Value CHAR(255) NOT NULL)
END;
