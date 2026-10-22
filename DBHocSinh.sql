-- Script tạo cơ sở dữ liệu và dữ liệu mẫu cho Phần 9: Quản lý Học sinh
-- Môn: Lập trình Windows với C#
-- Tác giả bài giảng: ThS. Lương Trần Hy Hiến

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DBHocSinh')
BEGIN
    CREATE DATABASE DBHocSinh;
END
GO

USE DBHocSinh;
GO

-- 1. Xóa bảng cũ nếu tồn tại
IF OBJECT_ID('dbo.HocSinh', 'U') IS NOT NULL DROP TABLE dbo.HocSinh;
IF OBJECT_ID('dbo.Lop', 'U') IS NOT NULL DROP TABLE dbo.Lop;
GO

-- 2. Tạo bảng Lop
CREATE TABLE Lop (
    MaLop varchar(20) PRIMARY KEY,
    TenLop nvarchar(100) NOT NULL,
    SiSo smallint NULL
);
GO

-- 3. Tạo bảng HocSinh
CREATE TABLE HocSinh (
    MaHS varchar(20) PRIMARY KEY,
    TenHS nvarchar(100) NOT NULL,
    NgaySinh datetime NULL,
    DiaChi nvarchar(150) NULL,
    DTB real NULL,
    MaLop varchar(20) NULL FOREIGN KEY REFERENCES Lop(MaLop) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- 4. Thêm dữ liệu mẫu theo giáo trình (trang 26 & 31)
INSERT INTO Lop (MaLop, TenLop, SiSo) VALUES
('10A1', N'Lớp 10A1', 30),
('10A2', N'Lớp 10A2', 25),
('10A3', N'Lớp 10A3', 22),
('10A4', N'Lớp 10A4', 11);
GO

INSERT INTO HocSinh (MaHS, TenHS, NgaySinh, DiaChi, DTB, MaLop) VALUES
('HS0001', N'Nguyễn Thanh Tùng', '1995-02-11', N'123 Ký Con, Q12', 7.77, '10A3'),
('HS0002', N'Trần Thị Mai', '1995-05-15', N'45 Hai Bà Trưng, Q1', 8.5, '10A1'),
('HS0003', N'Lê Hoàng Nam', '1995-08-20', N'78 Lê Lợi, Q3', 6.8, '10A2'),
('HS0004', N'Phạm Minh Tuấn', '1995-01-05', N'12 Quang Trung, Gò Vấp', 9.0, '10A1'),
('HS0005', N'Đỗ Phương Thảo', '1995-09-18', N'67 Hùng Vương, Q5', 7.2, '10A4'),
('HS0006', N'Nguyễn Thanh Bình', '1995-10-12', N'89 Nguyễn Trãi, Q5', 8.0, '10A3');
GO
