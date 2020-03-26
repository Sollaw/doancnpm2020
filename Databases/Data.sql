create database QuanLyNhaxe
go

use QuanLyNhaXe
go

create table Car
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
	status nvarchar(100) not null default N'Trống',	-- Trống || Có người
)
go

create table Account
(
	UserName nvarchar(100) primary key,
	DisplayName nvarchar(100) not null default N'Guest',
	PassWord nvarchar(1000) not null default 0,
	Type int not null default 0,	-- 1: Admin || 0: Staff
)
go

create table TicketCategory
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
)
go

create table Ticket
(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
	idCategory int not null,
	price float not null default 0,

	foreign key (idCategory) references TicketCategory(id),
)
go

create table Bill
(
	id int identity primary key,
	DateCheckIn date not null default getdate(),
	DateCheckOut date,
	idCar int not null,
	status int not null default 0,	-- 1: Đã thanh toán || 0: Chưa thanh toán

	foreign key (idCar) references Car(id)
)
go

create table BillInfo
(
	id int identity primary key,
	idBill int not null,
	idTicket int not null,
	count int not null default 0,

	foreign key (idBill) references Bill(id),
	foreign key (idTicket) references Ticket(id),
)
go

insert into Account (UserName,DisplayName,PassWord,Type)
values				('DoanDucVu',N'Đoàn Đức Vũ',N'123456',1)
insert into Account (UserName,DisplayName,PassWord,Type)
values				('Sollaw',N'Sol',N'123456',0)
go


declare @i int = 1
while @i < 10
begin
	insert into Car (name)
	values			(N'Xe ' + cast(@i as nvarchar(100)))
	set @i = @i + 1
end
go

insert into TicketCategory (name)
values					   (N'Vé một chiều')
insert into TicketCategory (name)
values					   (N'Vé khứ hồi')
go

insert into Ticket (name,idCategory,price)
values			   (N'Thừa Thiên Huế', 1, 1200000)
insert into Ticket (name,idCategory,price)
values			   (N'Hà Nội', 1, 2000000)
insert into Ticket (name,idCategory,price)
values			   (N'Vũng Tàu', 2, 800000)
insert into Ticket (name,idCategory,price)
values			   (N'Nha Trang', 2, 1400000)
go

insert into Bill (DateCheckIn,DateCheckOut,idCar,status)
values			 (getdate(),null,1,0)
insert into Bill (DateCheckIn,DateCheckOut,idCar,status)
values			 (getdate(),null,2,0)
insert into Bill (DateCheckIn,DateCheckOut,idCar,status)
values			 (getdate(),GETDATE(),3,1)
go

insert into BillInfo (idBill,idTicket,count)
values				 (1,1,2)
insert into BillInfo (idBill,idTicket,count)
values				 (2,4,1)
insert into BillInfo (idBill,idTicket,count)
values				 (3,2,5)
insert into BillInfo (idBill,idTicket,count)
values				 (3,1,3)
go

delete BillInfo
delete Bill
delete Ticket
delete TicketCategory

select * from Bill
select * from BillInfo
select * from Ticket
select * from TicketCategory

select * from Bill where idCar = 3 and status = 1
select * from BillInfo where idBill = 1
select t.name, bi.count, t.price, t.price * bi.count as N'totalPrice' from BillInfo as bi, Bill as b, Ticket as t where bi.idBill = b.id and bi.idTicket = t.id and b.status = 0
go

create proc USP_GetAccountByUserName
@userName nvarchar(100)
as 
begin
	select * from Account where UserName = @userName
end
go

create proc USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
as
begin
	select * from Account where UserName = @userName and PassWord = @passWord
end
go

create proc USP_GetCarList
as select * from Car
go

create proc USP_InsertBill
@idCar int
as
begin
	insert into Bill (DateCheckIn,DateCheckOut,idCar,status)
	values			 (getdate(),null,@idCar,0)
end
go

create proc USP_InsertBillInfo
@idBill int, @idTicket int, @count int
as
begin

	declare @isExistBillInfo int
	declare @ticketCount int = 1

	select @isExistBillInfo = id, @ticketCount = count from BillInfo where idBill = @idBill and idTicket = @idTicket

	if(@isExistBillInfo > 0)
	begin
		declare @newCount int = @ticketCount + @count
		if(@newCount > 0)
			update BillInfo set count = @ticketCount + @count where idTicket = @idTicket
		else
			delete BillInfo where idBill = @idBill and idTicket = @idTicket
	end
	else
	begin
		insert into BillInfo (idBill,idTicket,count)
		values				 (@idBill,@idTicket,@count)
	end
end
go

create trigger UTG_UpdateBillInfo
on BillInfo for insert, update
as
begin
	declare @idBill int
	select @idBill = idBill from inserted

	declare @idCar int
	select @idCar = idCar from Bill where id = @idBill and status = 0

	update Car set status = N'Có người' where id = @idCar
end
go

create trigger UTG_UpdateBill
on Bill for update
as
begin
	declare @idBill int
	select @idBill = id from  inserted

	declare @idCar int
	select @idCar = idCar from Bill where id = @idBill
	
	declare @count int = 0
	select @count = count(*) from Bill where idCar = @idCar and status = 0

	if(@count = 0)
		update Car set status = N'Trống' where id = @idCar
end
go