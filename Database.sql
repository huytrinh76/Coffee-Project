create database Coffee
go
use Coffee
go
create table TableFood(
	id int identity primary key,
	name nvarchar(100) not null default N'Unnamed table',
	status nvarchar(100) not null default N'Empty',
)
go
create table Account(
	UserName nvarchar(100) PRIMARY KEY,
	DisplayName nvarchar(100) not null default N'IRON FEVER EST 2017',
	PassWord nvarchar(1000) not null default 0,
	Type int not null default 0,
)
go
create table FoodCategory(
	id int identity primary key,
	name nvarchar(100) not null default N'Give a name',
)
go
create table Food(
	id int identity primary key,
	name nvarchar(100) not null default N'Give a name',
	idCategory int not null,
	price int not null default 0,
	foreign key(idCategory) references dbo.FoodCategory(id)
)
go
create table Bill(
	id int identity primary key,
	DateCheckIn date not null default getdate(),
	DateCheckOut date,
	idTable int not null,
	status int not null default 0,
	foreign key(idTable) references dbo.TableFood(id)
)
go
create table BillInfor(
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	count int not null default 0,
	foreign key(idBill) references dbo.Bill(id),
	foreign key(idFood) references dbo.Food(id),
)
go

INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES
(   N'IRFV', -- UserName - nvarchar(100)
    N'IRON FEVER', -- DisplayName - nvarchar(100)
    N'123', -- PassWord - nvarchar(1000)
    1    -- Type - int
    )  

INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES
(   N'staff', -- UserName - nvarchar(100)
    N'Nhân viên', -- DisplayName - nvarchar(100)
    N'123', -- PassWord - nvarchar(1000)
    0    -- Type - int
    )  
GO
    
CREATE PROC USP_GetListAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT*FROM dbo.Account WHERE UserName=@userName
END
GO

EXEC dbo.USP_GetListAccountByUserName @userName = N'IRFV' -- nvarchar(100)
GO 

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
END
GO

SELECT * FROM dbo.Account WHERE UserName='' AND PassWord=N'' OR 1=1--'