create database Coffee
go
use Coffee
go
create table TableFood(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên bàn',
	status nvarchar(100) not null default N'Trống',
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
	name nvarchar(100) not null default N'Chưa đặt tên',
)
go
create table Food(
	id int identity primary key,
	name nvarchar(100) not null default N'Chưa đặt tên',
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

--thêm bàn
DECLARE @i INT =0
WHILE @i <=10
BEGIN
	INSERT dbo.TableFood(name)
VALUES
(   N'Bàn ' + CAST(@i AS NVARCHAR(100)))
SET @i=@i+1
END 
GO

CREATE PROC USP_GetTableList
AS SELECT *FROM dbo.TableFood
GO

UPDATE dbo.TableFood SET status=N'Đã có người' WHERE id=9
GO

--thêm loại món ăn
INSERT dbo.FoodCategory
(
    name
)
VALUES
(N'Khai vị' -- name - nvarchar(100)
    )
INSERT dbo.FoodCategory
(
    name
)
VALUES
(N'Món chính' -- name - nvarchar(100)
    )
INSERT dbo.FoodCategory
(
    name
)
VALUES
(N'Tráng miệng' -- name - nvarchar(100)
    )

--Thêm món
INSERT dbo.Food
(
    name,
    idCategory,
    price
)
VALUES
(   N'Bánh xèo nhân tôm thịt', -- name - nvarchar(100)
    1,   -- idCategory - int
    82000    -- price - int
    )

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Nộm bò khô', 1, 70000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Bánh hỏi heo quay cuốn bánh tráng', 1, 135000)

SELECT *FROM dbo.Bill
GO
SELECT *FROM dbo.BillInfor