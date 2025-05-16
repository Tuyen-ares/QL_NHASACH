CREATE DATABASE QL_NHASACH
GO 

USE QL_NHASACH
GO

-- TẠO BẢNG TACGIA
CREATE TABLE TACGIA (
    MATG VARCHAR(10) NOT NULL,
    TENTG NVARCHAR(100),
	CONSTRAINT PK_TG PRIMARY KEY (MATG)
)

-- TẠO BẢNG LOAISACH
CREATE TABLE LOAISACH (
    MALOAI VARCHAR(10) NOT NULL,
    TENLOAI NVARCHAR(100),
	CONSTRAINT PK_LSH PRIMARY KEY (MALOAI)
)
--TẠO BẢNG NHÀ XUẤT BẢN
CREATE TABLE NhaXuatBan 
(
    MaNXB CHAR(6) NOT NULL,
    TenNXB NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
	CONSTRAINT PK_NXB PRIMARY KEY (MaNXB)
);



-- TẠO BẢNG SACH
CREATE TABLE SACH (
    MASH VARCHAR(10) NOT NULL,
    TENSH NVARCHAR(100),    
    GIANHAP FLOAT,
    GIABAN FLOAT,
    TONKHO INT,
	MALOAI VARCHAR(10) NOT NULL,
	MaNXB CHAR(6)
	CONSTRAINT PK_S PRIMARY KEY (MASH),
    CONSTRAINT FK_S_L FOREIGN KEY (MALOAI) REFERENCES LOAISACH(MALOAI),
	CONSTRAINT FK_S_NXB FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
);


-- TẠO BẢNG PHIEUNHAP
CREATE TABLE PHIEUNHAP (
    MAPN VARCHAR(10) NOT NULL,
    NGAYLAP DATETIME,
    TONGTIEN FLOAT,
	CONSTRAINT PK_PN PRIMARY KEY (MAPN),
);

-- TẠO BẢNG CT_PHIEUNHAP (CHI TIẾT PHIẾU NHẬP)
CREATE TABLE CT_PHIEUNHAP (
    MAPN VARCHAR(10) NOT NULL,
    MASH VARCHAR(10) NOT NULL,
    SOLUONG INT,
    GIANHAP FLOAT,
    THANHTIEN FLOAT,
    CONSTRAINT PK_CTPN PRIMARY KEY (MAPN, MASH) ,
    CONSTRAINT FK_CTPN_PN FOREIGN KEY (MAPN) REFERENCES PHIEUNHAP(MAPN),
    CONSTRAINT FK_CTPNP_S FOREIGN KEY (MASH) REFERENCES SACH(MASH)
);

-- TẠO BẢNG KHACHHANG
CREATE TABLE KHACHHANG (
    MAKH VARCHAR(10) NOT NULL,
    TENKH NVARCHAR(100),
    SDT VARCHAR(20),
    GIOITINH NVARCHAR(10),
	CONSTRAINT PK_KH PRIMARY KEY (MAKH)
);

CREATE TABLE CHUCVU (
    MACV VARCHAR(10) NOT NULL,
    TENCV NVARCHAR(100),
	CONSTRAINT CHUCVU_CV PRIMARY KEY (MACV),
);
-- TẠO BẢNG NHANVIEN
CREATE TABLE NHANVIEN (
    MANV VARCHAR(10) NOT NULL,
    TENNV NVARCHAR(100),
    MK VARCHAR(100),
    SDT VARCHAR(20),
    GIOITINH NVARCHAR(10),
	MACV VARCHAR(10),
	CONSTRAINT PK_NV PRIMARY KEY (MANV),
	CONSTRAINT FK_NHANVIEN_CV FOREIGN KEY (MACV) REFERENCES CHUCVU(MACV)
);



-- TẠO BẢNG HOADON
CREATE TABLE HOADON (
    MAHD VARCHAR(10) NOT NULL,
    NGAYLAP DATETIME,
    MAKH VARCHAR(10),
    MANV VARCHAR(10),
    TONGTIEN FLOAT,
	CONSTRAINT PK_HD PRIMARY KEY (MAHD),
    CONSTRAINT FK_HD_KH FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH),
    CONSTRAINT FK_HD_NV FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);

-- TẠO BẢNG CT_HOADON (CHI TIẾT HÓA ĐƠN)
CREATE TABLE CT_HOADON (
    MAHD VARCHAR(10),
    MASH VARCHAR(10),
    SOLUONG INT,
    THANHTIEN FLOAT,
    CONSTRAINT PK_CTHD PRIMARY KEY (MAHD, MASH) ,
    CONSTRAINT FK_CTHD_HD FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD),
    CONSTRAINT FK_CTHD_S FOREIGN KEY (MASH) REFERENCES SACH(MASH)
);

CREATE TABLE CHITIETTACGIA (
	MATG VARCHAR(10),	
	MASH VARCHAR(10)
	CONSTRAINT FK_CHITIETTACGIA_MATG FOREIGN KEY (MATG) REFERENCES TACGIA(MATG),
    CONSTRAINT FK_CHITIETTACGIA_MASH FOREIGN KEY (MASH) REFERENCES SACH(MASH)
)



-- trigger 
go
CREATE TRIGGER TR_UPDATE_THANHTIEN_CTHD
ON CT_HOADON
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật thành tiền cho từng chi tiết hóa đơn
    UPDATE CT_HOADON
    SET THANHTIEN = SOLUONG * (SELECT GIABAN FROM SACH WHERE SACH.MASH = CT_HOADON.MASH)
    WHERE MAHD IN (SELECT MAHD FROM INSERTED);
END

go

CREATE TRIGGER TR_UPDATE_TONGTIEN_HOADON
ON CT_HOADON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật tổng tiền cho hóa đơn
    UPDATE HOADON
    SET TONGTIEN = (SELECT SUM(THANHTIEN) FROM CT_HOADON WHERE MAHD = HOADON.MAHD)
    WHERE MAHD IN (SELECT MAHD FROM INSERTED)
       OR MAHD IN (SELECT MAHD FROM DELETED);
END

select * 
from HOADON
-- DỮ LIỆU BẢNG TACGIA
INSERT INTO TACGIA (MATG, TENTG) VALUES 
('TG001', N'Nguyễn Nhật Ánh'),
('TG002', N'J.K. Rowling'),
('TG003', N'Dan Brown'),
('TG004', N'Haruki Murakami'),
('TG005', N'Paulo Coelho'),
('TG006', N'Stephen King'),
('TG007', N'George Orwell'),
('TG008', N'F. Scott Fitzgerald'),
('TG009', N'Jane Austen'),
('TG010', N'Mark Twain'),
('TG011', N'Agatha Christie'),
('TG012', N'Isaac Asimov'),
('TG013', N'Ernest Hemingway'),
('TG014', N'Leo Tolstoy'),
('TG015', N'Charles Dickens'),
('TG016', N'Arthur Conan Doyle'),
('TG017', N'Gabriel Garcia Marquez'),
('TG018', N'John Grisham'),
('TG019', N'J.R.R. Tolkien'),
('TG020', N'Yuval Noah Harari');


--
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SoDienThoai, Email) 
VALUES 
('NXB001', N'NXB Trẻ', N'TP Hồ Chí Minh', '0901234567', 'nxbtre@nxb.vn'),
('NXB002', N'NXB Hội Nhà Văn', N'Hà Nội', '0912345678', 'hoinhavan@nxb.vn'),
('NXB003', N'NXB Văn Học', N'Hà Nội', '0923456789', 'vanhoc@nxb.vn'),
('NXB004', N'NXB Tổng Hợp', N'Đà Nẵng', '0934567890', 'tonghop@nxb.vn'),
('NXB005', N'NXB Lao Động', N'TP Hồ Chí Minh', '0945678901', 'laodong@nxb.vn'),
('NXB006', N'NXB Văn Nghệ', N'Cần Thơ', '0956789012', 'vannghe@nxb.vn'),
('NXB007', N'NXB Chính Trị Quốc Gia', N'Hà Nội', '0967890123', 'chinhtri@nxb.vn'),
('NXB008', N'NXB Khoa Học Tự Nhiên', N'Hà Nội', '0978901234', 'khoahoc@nxb.vn');

-- DỮ LIỆU BẢNG LOAISACH
INSERT INTO LOAISACH (MALOAI, TENLOAI) VALUES 
('LS001', N'Văn học'),
('LS002', N'Khoa học viễn tưởng'),
('LS003', N'Trinh thám'),
('LS004', N'Tiểu thuyết'),
('LS005', N'Kinh doanh'),
('LS006', N'Lịch sử'),
('LS007', N'Kỹ năng sống'),
('LS008', N'Tâm lý học'),
('LS009', N'Giáo dục'),
('LS010', N'Thiếu nhi'),
('LS011', N'Philosophy'),
('LS012', N'Biography'),
('LS013', N'Fantasy'),
('LS014', N'Science'),
('LS015', N'Romance'),
('LS016', N'Mystery'),
('LS017', N'Thriller'),
('LS018', N'Horror'),
('LS019', N'Drama'),
('LS020', N'Adventure');


-- DỮ LIỆU BẢNG SACH
INSERT INTO SACH (MASH, TENSH, GIANHAP, GIABAN, TONKHO, MALOAI, MaNXB) VALUES 
('SH001', N'Tôi thấy hoa vàng trên cỏ xanh', 50000, 80000, 20, 'LS001','NXB004'),
('SH002', N'Harry Potter và Hòn đá phù thủy', 70000, 120000, 15, 'LS013','NXB003'),
('SH003', N'Mật mã Da Vinci', 80000, 150000, 10, 'LS003','NXB007'),
('SH004', N'Rừng Na Uy', 60000, 100000, 8, 'LS004','NXB002'),
('SH005', N'Nhà giả kim', 55000, 90000, 12, 'LS004','NXB006'),
('SH006', N'The Shining', 65000, 110000, 9, 'LS018','NXB008'),
('SH007', N'1984', 70000, 130000, 5, 'LS002','NXB001'),
('SH008', N'The Great Gatsby', 60000, 95000, 7, 'LS019','NXB006'),
('SH009', N'Pride and Prejudice', 50000, 85000, 10, 'LS015','NXB007'),
('SH010', N'Sherlock Holmes', 75000, 140000, 11, 'LS016','NXB006'),
('SH011', N'I, Robot', 80000, 135000, 6, 'LS014','NXB005'),
('SH012', N'Old Man and The Sea', 40000, 75000, 14, 'LS019','NXB004'),
('SH013', N'War and Peace', 85000, 160000, 3, 'LS020','NXB008'),
('SH014', N'Oliver Twist', 45000, 80000, 20, 'LS001','NXB004'),
('SH015', N'One Hundred Years of Solitude', 70000, 125000, 9, 'LS019','NXB001'),
('SH016', N'The Firm', 50000, 90000, 8, 'LS017','NXB006'),
('SH017', N'The Hobbit', 55000, 105000, 13, 'LS013','NXB003'),
('SH018', N'Sapiens', 60000, 115000, 7, 'LS006','NXB003'),
('SH019', N'Becoming', 45000, 95000, 11, 'LS012','NXB007'),
('SH020', N'Man''s Search for Meaning', 50000, 100000, 12, 'LS008','NXB005');


-- DỮ LIỆU BẢNG CHITIETTACGIA
INSERT INTO CHITIETTACGIA (MATG, MASH) VALUES 
('TG001', 'SH001'),
('TG002', 'SH002'),
('TG003', 'SH003'),
('TG003', 'SH004'),
('TG004', 'SH005'),
('TG006', 'SH006'),
('TG007', 'SH007'),
('TG008', 'SH008'),
('TG009', 'SH009'),
('TG010', 'SH010'),
('TG011', 'SH010'),
('TG012', 'SH011'),
('TG013', 'SH012'),
('TG014', 'SH013'),
('TG015', 'SH014'),
('TG016', 'SH015'),
('TG017', 'SH016'),
('TG018', 'SH017'),
('TG019', 'SH018'),
('TG020', 'SH019');



-- DỮ LIỆU BẢNG CHUCVU
INSERT INTO CHUCVU (MACV, TENCV) VALUES
('CV001', N'Quản Lý'),
('CV002', N'Nhân Viên Bán Hàng'),
('CV003', N'Nhân Viên Kho');

-- DỮ LIỆU BẢNG NHANVIEN
INSERT INTO NHANVIEN (MANV, TENNV, MK, SDT, GIOITINH, MACV) VALUES 
('NV001', N'Nguyễn Thị Thanh Hương', '123456', '0912345678', N'Nữ', 'CV001'),
('NV002', N'Trần Văn Nam', 'abcdef', '0934567890', N'Nam', 'CV002'),
('NV003', N'Lê Văn Phú', 'password', '0987654321', N'Nam', 'CV003'),
('NV004', N'Phạm Thị Bích Ngọc', 'qwerty', '0923456789', N'Nữ', 'CV002'),
('NV005', N'Hoàng Thị Hải Yến', 'zxcvbn', '0976543210', N'Nữ', 'CV002'),
('NV006', N'Đỗ Minh Tuấn', '123abc', '0901122334', N'Nam', 'CV002'),
('NV007', N'Đinh Thị Ngọc Bích', '654321', '0942233445', N'Nữ', 'CV002'),
('NV008', N'Phạm Minh Quân', 'letmein', '0933221100', N'Nam', 'CV003'),
('NV009', N'Lê Quốc Bảo', 'mypassword', '0914556677', N'Nam', 'CV002'),
('NV010', N'Trần Thị Thu Hà', 'newpass', '0988997766', N'Nữ', 'CV002'),
('NV011', N'Bùi Văn Hùng', 'pass123', '0933556677', N'Nam', 'CV002'),
('NV012', N'Phan Văn Khôi', 'adminpass', '0916677889', N'Nam', 'CV002'),
('NV013', N'Nguyễn Văn Nghĩa', 'changeme', '0944556677', N'Nam', 'CV003'),
('NV014', N'Hoàng Thị Thu Trang', 'iloveyou', '0988776655', N'Nữ', 'CV002'),
('NV015', N'Vũ Thị Mỹ Duyên', '1234pass', '0909876543', N'Nữ', 'CV002'),
('NV016', N'Nguyễn Hữu Nghĩa', 'phuc123', '0934556678', N'Nam', 'CV001'),
('NV017', N'Lê Thị Hồng Nhung', 'mypass123', '0913456677', N'Nữ', 'CV002'),
('NV018', N'Trần Văn Thắng', 'letmein123', '0943667788', N'Nam', 'CV003'),
('NV019', N'Đặng Thị Mỹ Linh', 'hello123', '0902112345', N'Nữ', 'CV002'),
('NV020', N'Nguyễn Anh Dũng', 'securepass', '0977333444', N'Nam', 'CV002');

-- DỮ LIỆU BẢNG KHACHHANG
INSERT INTO KHACHHANG (MAKH, TENKH, SDT, GIOITINH) VALUES 
('KH001', N'Nguyễn Thị Minh Châu', '0123456789', N'Nữ'),
('KH002', N'Trần Văn Khánh', '0987654321', N'Nam'),
('KH003', N'Lê Thanh Hùng', '0912345678', N'Nam'),
('KH004', N'Phạm Thị Hoa', '0943212345', N'Nữ'),
('KH005', N'Hoàng Văn Đức', '0934567890', N'Nam'),
('KH006', N'Đặng Thị Mai', '0923456789', N'Nữ'),
('KH007', N'Vũ Thanh Phong', '0919876543', N'Nam'),
('KH008', N'Phan Thị Lan', '0981122334', N'Nữ'),
('KH009', N'Lý Minh Tuấn', '0900123456', N'Nam'),
('KH010', N'Bùi Thị Hồng', '0971234567', N'Nữ'),
('KH011', N'Dương Văn Sơn', '0934567123', N'Nam'),
('KH012', N'Phạm Minh Long', '0945671234', N'Nam'),
('KH013', N'Trần Thị Hương', '0912233445', N'Nữ'),
('KH014', N'Lê Văn Bình', '0987654432', N'Nam'),
('KH015', N'Ngô Thị Thanh', '0922334455', N'Nữ'),
('KH016', N'Phan Văn Toàn', '0945566778', N'Nam'),
('KH017', N'Đỗ Thị Kim Liên', '0916655443', N'Nữ'),
('KH018', N'Trần Văn Khoa', '0933445566', N'Nam'),
('KH019', N'Vũ Thị Lan Anh', '0977889900', N'Nữ'),
('KH020', N'Nguyễn Hoàng Tùng', '0921122334', N'Nam');



-- DỮ LIỆU BẢNG HOADON
INSERT INTO HOADON (MAHD, NGAYLAP, MAKH, MANV, TONGTIEN) VALUES
('HD001', '2024-11-01', 'KH001', 'NV001', 150000),
('HD002', '2024-11-02', 'KH002', 'NV002', 250000),
('HD003', '2024-11-03', 'KH003', 'NV003', 100000),
('HD004', '2024-11-04', 'KH004', 'NV004', 200000),
('HD005', '2024-11-05', 'KH005', 'NV005', 180000),
('HD006', '2024-11-06', 'KH006', 'NV006', 300000),
('HD007', '2024-11-07', 'KH007', 'NV007', 120000),
('HD008', '2024-11-08', 'KH008', 'NV008', 220000),
('HD009', '2024-11-09', 'KH009', 'NV009', 190000),
('HD010', '2024-11-10', 'KH010', 'NV010', 350000),
('HD011', '2024-11-11', 'KH011', 'NV011', 275000),
('HD012', '2024-11-12', 'KH012', 'NV012', 500000),
('HD013', '2024-11-13', 'KH013', 'NV013', 150000),
('HD014', '2024-11-14', 'KH014', 'NV014', 450000),
('HD015', '2024-11-15', 'KH015', 'NV015', 600000),
('HD016', '2024-11-16', 'KH016', 'NV016', 225000),
('HD017', '2024-11-17', 'KH017', 'NV017', 125000),
('HD018', '2024-11-18', 'KH018', 'NV018', 400000),
('HD019', '2024-11-19', 'KH019', 'NV019', 320000),
('HD020', '2024-11-20', 'KH020', 'NV020', 275000);

-- DỮ LIỆU BẢNG CT_HOADON (CHI TIẾT HÓA ĐƠN)
INSERT INTO CT_HOADON (MAHD, MASH, SOLUONG, THANHTIEN) VALUES
('HD001', 'SH001', 2, 50000),
('HD001', 'SH002', 1, 100000),
('HD002', 'SH003', 3, 75000),
('HD002', 'SH004', 1, 175000),
('HD003', 'SH005', 2, 50000),
('HD004', 'SH006', 4, 50000),
('HD005', 'SH007', 1, 180000),
('HD006', 'SH008', 3, 100000),
('HD006', 'SH009', 2, 100000),
('HD007', 'SH010', 1, 120000),
('HD008', 'SH011', 2, 110000),
('HD008', 'SH012', 1, 110000),
('HD009', 'SH013', 1, 190000),
('HD010', 'SH014', 5, 70000),
('HD011', 'SH015', 3, 90000),
('HD012', 'SH016', 4, 125000),
('HD013', 'SH017', 1, 150000),
('HD014', 'SH018', 6, 75000),
('HD015', 'SH019', 8, 75000),
('HD016', 'SH020', 3, 75000),
('HD017', 'SH001', 1, 50000),
('HD018', 'SH002', 2, 200000),
('HD019', 'SH003', 4, 80000),
('HD020', 'SH004', 3, 90000),
('HD020', 'SH005', 2, 50000);

-- Thêm dữ liệu mẫu vào bảng PHIEUNHAP
INSERT INTO PHIEUNHAP (MAPN, NGAYLAP, TONGTIEN) VALUES
('PN001', '2024-11-01', 1500000),
('PN002', '2024-11-02', 1000000);

-- Thêm dữ liệu mẫu vào bảng CT_PHIEUNHAP
INSERT INTO CT_PHIEUNHAP (MAPN, MASH, SOLUONG, GIANHAP) VALUES
('PN001', 'SH001', 10, 50000),
('PN001', 'SH002', 5, 80000),
('PN002', 'SH003', 20, 20000);

select * 
from CT_HOADON 
where CT_HOADON.MAHD = 'HD001'

CREATE TRIGGER trg_UpdateSoLuongKhoKhiBan
ON CT_HOADON
AFTER delete
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật số lượng tồn kho trực tiếp
    UPDATE SACH
    SET TONKHO = s.TONKHO + d.SoLuong
    FROM SACH s, deleted d
    WHERE d.MASH = s.MASH
    -- Đảm bảo số lượng tồn kho không âm
    IF EXISTS (
        SELECT 1
        FROM SACH
        WHERE TONKHO < 0
    )
    BEGIN
        RAISERROR ('Số lượng tồn kho không hợp lệ sau khi bán!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO