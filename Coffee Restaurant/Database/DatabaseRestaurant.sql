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

--UPDATE dbo.TableFood SET status=N'Đã có người' WHERE id=8

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
--Khai vị
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

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Xà lách trộn dầu dấm', 1, 55000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Khoai tây chiên', 1, 55000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Bánh đúc nóng', 1, 26000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Há cảo tôm cua', 1, 60000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Bánh bao chay', 1, 35000)

--Món chính
INSERT dbo.Food(name, idCategory, price)
VALUES(N'Bún chả kẹp que tre Hà Nội', 2, 70000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Mực một nắng chiên giòn (size S)', 2, 375000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Gỏi cuốn tôm thịt', 2, 25000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Nem cua bể', 2, 90000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Lẩu bông Miền Tây', 2, 420000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chả cá Hà Nội', 2, 140000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Cơm chiên hải sản', 2, 125000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Cơm lam gà nướng', 2, 98000)

--Tráng miệng
INSERT dbo.Food(name, idCategory, price)
VALUES(N'Tào phớ', 3, 22000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chè sương sa hạt lựu', 3, 30000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chè hoa cau', 3, 26000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chè ba màu', 3, 30000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chè chuối hấp nước dừa', 3, 26000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chè thập cẩm', 3, 30000)

INSERT dbo.Food(name, idCategory, price)
VALUES(N'Chè hạt sen', 3, 30000)

--thêm bill
INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    1,         -- idTable - int
    0          -- status - int
    )

INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    2,         -- idTable - int
    0          -- status - int
    )

INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    GETDATE(), -- DateCheckOut - date
    2,         -- idTable - int
    1          -- status - int
    )

--theem bill in4
INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   1, -- idBill - int
    1, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   1, -- idBill - int
    4, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   1, -- idBill - int
    3, -- idFood - int
    4  -- count - int
    )

INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   3, -- idBill - int
    5, -- idFood - int
    1  -- count - int
    )

INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   2, -- idBill - int
    1, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   2, -- idBill - int
    6, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfor
(
    idBill,
    idFood,
    count
)
VALUES
(   3, -- idBill - int
    4, -- idFood - int
    2  -- count - int
    )
GO

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill
	(
	    DateCheckIn,
	    DateCheckOut,
	    idTable,
	    status
	)
	VALUES
	(   GETDATE(), -- DateCheckIn - date
	    NULL, -- DateCheckOut - date
	    @idTable,         -- idTable - int
	    0         -- status - int
	    )
END
GO

CREATE PROC USP_InsertBillInfor
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitsBillInfor INT
	DECLARE @foodCount INT =1

	SELECT @isExitsBillInfor=id, @foodCount=b.count 
	FROM dbo.BillInfor AS b 
	WHERE idBill= @idBill AND idFood=@idFood

	IF (@isExitsBillInfor>0)
	BEGIN
		DECLARE @newCount INT =@foodCount+@count
		IF(@newCount>0)
			UPDATE dbo.BillInfor SET count=@foodCount +@count WHERE idFood=@idFood
			
		ELSE
			DELETE dbo.BillInfor WHERE idBill=@idBill AND idFood=@idFood
	END
	ELSE
		BEGIN
			INSERT dbo.BillInfor
	(
	    idBill,
		idFood,
		count
   )
   VALUES
	(   @idBill, -- idBill - int
		@idFood, -- idFood - int
		@count  -- count - int
  )
		END
		
END
GO

CREATE TRIGGER UTG_UpdateBillInfor
ON dbo.BillInfor FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill= idBill FROM Inserted
	DECLARE @idTable INT
	SELECT @idTable=idTable FROM dbo.Bill WHERE id=@idBill AND status=0
	DECLARE @count INT
	SELECT @count=COUNT(*) FROM dbo.BillInfor WHERE idBill=@idBill
	IF(@count>0)
		BEGIN
			UPDATE dbo.TableFood SET status=N'Có người' WHERE id=@idTable
		END
	ELSE
		BEGIN
			UPDATE dbo.TableFood SET status=N'Trống' WHERE id=@idTable
        END
END
GO

DELETE dbo.BillInfor
DELETE dbo.Bill
GO


CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE 
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill=id FROM Inserted
	DECLARE @idTable INT
	SELECT @idTable=idTable FROM dbo.Bill WHERE id=@idBill
	DECLARE @count INT =0
	SELECT @count=COUNT(*) FROM dbo.Bill WHERE idTable=@idTable AND status=0
	IF(@count=0)
		UPDATE dbo.TableFood SET status=N'Trống' WHERE id=@idTable
END
GO

ALTER TABLE dbo.Bill 
ADD discount INT
GO

UPDATE dbo.Bill SET discount=0
GO

CREATE PROC USP_SwitchTable
@idTable1 INT, @idTable2 INT
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSecondBill INT

	DECLARE @isFirstTableEmpty INT=1
	DECLARE @isSecondTableEmpty INT=1

	SELECT @idSecondBill=id FROM dbo.Bill WHERE idTable=@idTable2 AND status=0
	SELECT @idFirstBill=id FROM dbo.Bill WHERE idTable=@idTable1 AND status=0

	IF(@idFirstBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill
		(
		    DateCheckIn,
		    DateCheckOut,
		    idTable,
		    status
		)
		VALUES
		(   GETDATE(), -- DateCheckIn - date
		    NULL, -- DateCheckOut - date
		    @idTable1,         -- idTable - int
		    0       -- status - int
		    )
		SELECT @idFirstBill =MAX(id) FROM dbo.Bill WHERE idTable=@idTable1 AND status=0
		
	END

	SELECT @isFirstTableEmpty=COUNT(*) FROM dbo.BillInfor WHERE idBill=@idFirstBill

	IF(@idSecondBill IS NULL)
	BEGIN
		INSERT INTO dbo.Bill
		(
		    DateCheckIn,
		    DateCheckOut,
		    idTable,
		    status
		)
		VALUES
		(   GETDATE(), -- DateCheckIn - date
		    NULL, -- DateCheckOut - date
		    @idTable2,         -- idTable - int
		    0       -- status - int
		    )
		SELECT @idSecondBill =MAX(id) FROM dbo.Bill WHERE idTable=@idTable2 AND status=0
	END

	SELECT @isSecondTableEmpty=COUNT(*) FROM dbo.BillInfor WHERE idBill=@idSecondBill

	SELECT id INTO IDBillInforTable FROM dbo.BillInfor WHERE idBill=@idSecondBill
	UPDATE dbo.BillInfor SET idBill=@idSecondBill WHERE idBill=@idFirstBill
	UPDATE dbo.BillInfor SET idBill=@idFirstBill WHERE id IN (SELECT*FROM dbo.IDBillInforTable)
	DROP TABLE dbo.IDBillInforTable

	IF(@isFirstTableEmpty=0)
		UPDATE dbo.TableFood SET status=N'Trống' WHERE id=@idTable2
	IF(@isSecondTableEmpty=0)
		UPDATE dbo.TableFood SET status=N'Trống' WHERE id=@idTable1
END
GO

ALTER TABLE dbo.Bill ADD totalPrice INT
GO

CREATE PROC USP_GetListBillByDate
@checkIn DATE, @checkOut DATE
AS
BEGIN
	SELECT t.name AS [Bàn], b.totalPrice AS [Tổng hóa đơn], b.DateCheckIn AS [Ngày vào], b.DateCheckOut AS [Ngày ra], b.discount AS [Giảm giá]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE b.status=1 AND t.id=b.idTable AND b.DateCheckIn>=@checkIn AND b.DateCheckOut<=@checkOut
END
GO

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @passWord NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT=0
	SELECT @isRightPass =COUNT(*) FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
	IF(@isRightPass=1)
		BEGIN
			IF(@newPassword=NULL OR @newPassword='')
				BEGIN
					UPDATE dbo.Account SET DisplayName=@displayName WHERE UserName=@userName
				END
			ELSE
				UPDATE dbo.Account SET DisplayName=@displayName, PassWord=@newPassword WHERE UserName=@userName
		END
END
GO

CREATE TRIGGER UTG_DeleteBillInfor
ON dbo.BillInfor FOR DELETE
AS
BEGIN
	DECLARE @idBillInfor INT
	DECLARE @idBill INT
	SELECT @idBillInfor=id, @idBill=Deleted.idBill FROM Deleted

	DECLARE @idTable INT
	SELECT @idTable=idTable FROM dbo.Bill WHERE id=@idBill
	
	DECLARE @count INT =0
	SELECT @count=COUNT(*) FROM dbo.BillInfor AS bi, dbo.Bill AS b WHERE b.id=bi.idBill AND b.id=@idBill AND b.status=0

	IF(@count>0)
		UPDATE dbo.TableFood SET status=N'Trống' WHERE id=@idTable
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO