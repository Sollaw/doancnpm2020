create database QuanLyNhaXe
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
	discount int default 0,
	totalPrice float,

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

delete BillInfo
delete Bill
delete Ticket
delete TicketCategory

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
values			   (N'Thừa Thiên Huế', 1, 120000)
insert into Ticket (name,idCategory,price)
values			   (N'Hà Nội', 1, 100000)
insert into Ticket (name,idCategory,price)
values			   (N'Thành phố Hồ Chí Minh', 1, 100000)
insert into Ticket (name,idCategory,price)
values			   (N'Đà Nẵng', 1, 100000)
insert into Ticket (name,idCategory,price)
values			   (N'Vũng Tàu', 2, 110000)
insert into Ticket (name,idCategory,price)
values			   (N'Nha Trang', 2, 140000)
insert into Ticket (name,idCategory,price)
values			   (N'Đồng Nai', 2, 140000)
insert into Ticket (name,idCategory,price)
values			   (N'Cà Mau', 2, 140000)
go


--------------------------------------------
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
	insert into Bill (DateCheckIn,DateCheckOut,idCar,status,discount)
	values			 (getdate(),null,@idCar,0,0)
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

	declare @count int
	select @count = count(*) from BillInfo where idBill = @idBill

	if(@count > 0)
		update Car set status = N'Có người' where id = @idCar
	else
		update Car set status = N'Trống' where id = @idCar
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

create proc USP_SwitchCar
@idCar1 int, @idCar2 int
as begin
	declare @idFirstBill int
	declare @idSecondBill int

	declare @isFirstCarEmpty int = 1
	declare @isSecondCarEmpty int = 1

	select @idFirstBill = id from Bill where idCar = @idCar1 and status = 0
	select @idSecondBill = id from Bill where idCar = @idCar2 and status = 0

	if(@idFirstBill is null)
	begin
		insert into Bill (DateCheckIn,DateCheckOut,idCar,status,discount)
		values			 (getdate(),null,@idCar1,0,0)

		select @idFirstBill = max(id) from Bill where idCar = @idCar1 and status = 0
	end

	select @isFirstCarEmpty = count(*) from BillInfo where idBill = @idFirstBill

	if(@idSecondBill is null)
	begin
		insert into Bill (DateCheckIn,DateCheckOut,idCar,status,discount)
		values			 (getdate(),null,@idCar2,0,0)

		select @idSecondBill = max(id) from Bill where idCar = @idCar2 and status = 0
	end

	select @isSecondCarEmpty = count(*) from BillInfo where idBill = @idSecondBill

	select id into IDBillInfoCar from BillInfo where idBill = @idSecondBill

	update BillInfo set idBill = @idSecondBill where idBill = @idFirstBill
	update BillInfo set idBill = @idFirstBill where id in (select * from IDBillInfoCar)

	drop table IDBillInfoCar

	if(@isFirstCarEmpty = 01)
		update Car set status = N'Trống' where id = @idCar2

	if(@isSecondCarEmpty = 0)
		update Car set status = N'Trống' where id = @idCar1
end
go

create proc USP_GetListBillByDate
@checkIn date, @checkOut date
as begin
	select c.name as [Tên xe], DateCheckIn as [Ngày đặt], DateCheckOut as [Ngày thanh toán], discount as [Giảm giá], b.totalPrice as [Tổng tiền]
	from Bill as b, Car as c
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status = 1
	and c.id = b.idCar
end
go

create proc USP_UpdateAccount
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @newPassWord nvarchar(100)
as begin
	declare @isRightPass int = 0
	select @isRightPass = count(*) from Account where UserName = @userName and PassWord = @passWord

	if(@isRightPass = 1)
	begin
		if(@newPassWord = null or @newPassWord = '')
		begin
			update Account set DisplayName = @displayName where UserName = @userName
		end
		else
			update Account set DisplayName = @displayName, PassWord = @newPassWord where UserName = @userName
	end
end
go

create trigger UTG_DeleteBillInfo
on BillInfo for delete
as begin
	declare @idBillInfo int
	declare @idBill int
	select @idBillInfo = id, @idBill = deleted.idBill from deleted

	declare @idCar int
	select @idCar = idCar from Bill where id = @idBill

	declare @count int = 0
	select @count = count(*) from BillInfo as bi, Bill as b where b.id = bi.idBill and b.id = @idBill and b.status = 0

	if(@count = 0)
		update Car set status = N'Trống' where id = @idCar
end
go

create proc USP_GetListBillByDateForReport
@checkIn date, @checkOut date
as begin
	select c.name, DateCheckIn, DateCheckOut, discount, b.totalPrice
	from Bill as b, Car as c
	where DateCheckIn >= @checkIn and DateCheckOut <= @checkOut and b.status = 1
	and c.id = b.idCar
end
go