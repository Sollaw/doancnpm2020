CREATE DATABASE QuanLyNhaXe
GO

USE QuanLyNhaXe
GO

--Ticket
--Seat
--TicketCategory
--Account
--Bill
--BillInfo

CREATE TABLE Seat
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống', --Trống || Có người
)
GO

CREATE TABLE Account
(
	LoginName NVARCHAR(100) PRIMARY KEY,
	UserName NVARCHAR(100) NOT NULL DEFAULT N'Chưa có tên',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0, -- 1-Manager && 0-Staff
)
GO

CREATE TABLE TicketCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100),
)
GO

CREATE TABLE Ticket
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	Price FLOAT NOT NULL DEFAULT 0,

	FOREIGN KEY (idCategory) REFERENCES TicketCategory(id),
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	BookedDate DATE NOT NULL DEFAULT getdate(),
	DepartureDate DATE,
	idSeat INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- Đã thanh toán || Chưa thanh toán

	FOREIGN KEY (idSeat) REFERENCES Seat(id),
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idTicket INT NOT NULL,
	count int DEFAULT 0,

	FOREIGN KEY (idBill) REFERENCES Bill(id),
	FOREIGN KEY (idTicket) REFERENCES Ticket(id),
)
GO

--Values
INSERT INTO Account (LoginName,UserName,PassWord,Type)
VALUES				(N'DoanDucVu',N'Đoàn Đức Vũ',N'123456',1),
					(N'SOLLAW',N'Sollaw',N'123456',0)
GO

DECLARE @i INT = 1

WHILE @i <= 32
BEGIN
	INSERT INTO Seat (name) VALUES (N'Ghế ' + CAST(@i AS NVARCHAR(100)))
	SET @i = @i + 1
END
GO

SELECT * FROM Account
GO

SELECT * FROM Seat
GO


--Ticket Category
INSERT INTO TicketCategory (name)
VALUES					   (N'Vé khứ hồi giường nằm')
INSERT INTO TicketCategory (name)
VALUES					   (N'Vé một chiều giường nằm')
INSERT INTO TicketCategory (name)
VALUES					   (N'Vé khứ hồi ghế ngồi')
INSERT INTO TicketCategory (name)
VALUES					   (N'Vé một chiều ghế ngồi')
GO

--Ticket
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Bình Thuận', 1, 400000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Bình Thuận', 2, 200000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Nha Trang', 3, 900000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Nha Trang', 4, 450000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Thừa Thiên Huế', 3, 1200000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Thừa Thiên Huế', 4, 600000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Sapa', 1, 3200000)
INSERT INTO Ticket (name, idCategory, Price)
VALUES			   (N'Sapa', 2, 1600000)
GO

--delete Bill
--drop table Bill
INSERT INTO Bill (BookedDate,DepartureDate,idSeat,status)
VALUES			 (GETDATE(),NULL,2,0)
INSERT INTO Bill (BookedDate,DepartureDate,idSeat,status)
VALUES			 (GETDATE(),NULL,3,0)
INSERT INTO Bill (BookedDate,DepartureDate,idSeat,status)
VALUES			 (GETDATE(),GETDATE(),4,1)
INSERT INTO Bill (BookedDate,DepartureDate,idSeat,status)
VALUES			 (GETDATE(),GETDATE(),8,1)
GO

--delete BillInfo
--drop table BillInfo
INSERT INTO BillInfo (idBill, idTicket)
VALUES				 (1, 1)
INSERT INTO BillInfo (idBill, idTicket)
VALUES				 (2, 2)
INSERT INTO BillInfo (idBill, idTicket)
VALUES				 (3, 3)
INSERT INTO BillInfo (idBill, idTicket)
VALUES				 (4, 4)
GO