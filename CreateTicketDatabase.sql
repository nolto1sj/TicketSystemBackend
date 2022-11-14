CREATE DATABASE TicketDb;

CREATE TABLE Ticket
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(25) NOT NULL,
	Category NVARCHAR(25) NOT NULL,
	Detail NVARCHAR(500) NOT NULL,
	Created DATE NOT NULL,
	OpenedByName NVARCHAR(25),
	OpenedByEmail NVARCHAR(50),
	CompletedByName NVARCHAR(25),
	CompletedByEmail NVARCHAR(50),
	Completed BIT NOT NULL
)

CREATE TABLE Bookmark 
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	UserId NCHAR(5),
	TicketId INT FOREIGN KEY REFERENCES Ticket(Id)
)

INSERT INTO Ticket (Name, Category, Detail, Created, Completed)
VALUES ('Print Screen cmd broken!', 'Urgent', 'My print screen command has been broken for literally days. 
I need to be able to print my screen to do my job as a screen printer. I have lost thousands of dollars!', '11/10/2022', 'false')

INSERT INTO Ticket (Name, Category, Detail, Created, Completed)
VALUES ('Squeaky chair', 'Noncritical', 
'So, basically every time that I lean back in my chair, it squeaks a bit. It really only bothers me when I do a lot of leaning', 
'11/11/2022', 'false')

INSERT INTO Ticket (Name, Category, Detail, Created, OpenedByName, OpenedByEmail, CompletedByName, CompletedByEmail, Completed)
VALUES ('Scaffold DbContext fail', 'Critical', 
'When I go to scaffold my DbContext, it says that the certificate cannot be trusted', 
'11/14/2022', 'Benjamin Jerry', 'bjerry@company.com', 'Spencer Nolton', 'sjnolton@company.com', 'true')

INSERT INTO Ticket (Name, Category, Detail, Created, OpenedByName, OpenedByEmail, Completed)
VALUES ('Server is offline', 'Urgent', 
'The server that hosts all the data for the website exploded. I am scared. Please fix it', 
'11/12/2022', 'Carson Lewis', 'clewis@company.com', 'false')

INSERT INTO Ticket (Name, Category, Detail, Created, OpenedByName, OpenedByEmail, CompletedByName, CompletedByEmail, Completed)
VALUES ('Need a web app', 'Noncritical', 
'I need a new web app that displays tickets on a screen. I should be able to see all of them, sort through them etc.', 
'11/11/2022', 'Penelope Grainger', 'pgrainger@company.com', 'Spencer Nolton', 'sjnolton@company.com', 'true')

INSERT INTO Ticket (Name, Category, Detail, Created, OpenedByName, OpenedByEmail, CompletedByName, CompletedByEmail, Completed)
VALUES ('Server is online', 'Urgent', 
'The server that hosts all the data for the website is working. I am scared. please make it broken', 
'11/11/2022', 'Carson Lewis', 'clewis@company.com', 'Benjamin Jerry', 'bjerry@company.com', 'true')