-- Tạo Database QuanlyKho
CREATE DATABASE QuanlyKho;
GO

USE QuanlyKho;
GO

-- Bảng Danh Mục Hàng Hóa
CREATE TABLE [dbo].[DanhMucHangHoa]
(
    [MaDanhMuc] NVARCHAR(50) PRIMARY KEY NOT NULL,
    [TenDanhMuc] NVARCHAR(255) NOT NULL,
    [MoTa] NVARCHAR(MAX),
    [NgayTao] DATETIME DEFAULT GETDATE(),
    [NgayCapNhat] DATETIME DEFAULT GETDATE()
);

-- Bảng Hàng Hóa
CREATE TABLE [dbo].[HangHoa]
(
    [MaHangHoa] NVARCHAR(50) PRIMARY KEY NOT NULL,
    [TenHangHoa] NVARCHAR(255) NOT NULL,
    [MaDanhMuc] NVARCHAR(50) NOT NULL,
    [KichThuoc] NVARCHAR(100),
    [Mau] NVARCHAR(100),
    [KhoiLuong] DECIMAL(10, 2),
    [GiaNhap] DECIMAL(18, 2) NOT NULL,
    [GiaBan] DECIMAL(18, 2) NOT NULL,
    [MoTa] NVARCHAR(MAX),
    [HinhAnh] NVARCHAR(MAX),
    [NgayTao] DATETIME DEFAULT GETDATE(),
    [NgayCapNhat] DATETIME DEFAULT GETDATE(),
    FOREIGN KEY ([MaDanhMuc]) REFERENCES [dbo].[DanhMucHangHoa]([MaDanhMuc])
);

-- Bảng Kho
CREATE TABLE [dbo].[Kho]
(
    [MaKho] NVARCHAR(50) PRIMARY KEY NOT NULL,
    [TenKho] NVARCHAR(255) NOT NULL,
    [DiaChi] NVARCHAR(MAX),
    [SDT] NVARCHAR(20),
    [MoTa] NVARCHAR(MAX),
    [NgayTao] DATETIME DEFAULT GETDATE(),
    [NgayCapNhat] DATETIME DEFAULT GETDATE()
);

-- Bảng Chi Tiết Kho
CREATE TABLE [dbo].[ChiTietKho]
(
    [MaChiTietKho] INT PRIMARY KEY IDENTITY(1,1),
    [MaKho] NVARCHAR(50) NOT NULL,
    [MaHangHoa] NVARCHAR(50) NOT NULL,
    [SoLuong] INT DEFAULT 0,
    [SoLuongToiThieu] INT DEFAULT 0,
    [SoLuongToiDa] INT DEFAULT 1000,
    [NgayCapNhat] DATETIME DEFAULT GETDATE(),
    FOREIGN KEY ([MaKho]) REFERENCES [dbo].[Kho]([MaKho]),
    FOREIGN KEY ([MaHangHoa]) REFERENCES [dbo].[HangHoa]([MaHangHoa])
);

-- Bảng Phiếu Nhập
CREATE TABLE [dbo].[PhieuNhap]
(
    [MaPhieuNhap] NVARCHAR(50) PRIMARY KEY NOT NULL,
    [MaKho] NVARCHAR(50) NOT NULL,
    [NgayNhap] DATETIME DEFAULT GETDATE(),
    [NguonNhap] NVARCHAR(255),
    [GhiChu] NVARCHAR(MAX),
    [TrangThai] NVARCHAR(50) DEFAULT 'Chưa xử lý',
    [NgayTao] DATETIME DEFAULT GETDATE(),
    [NgayCapNhat] DATETIME DEFAULT GETDATE(),
    FOREIGN KEY ([MaKho]) REFERENCES [dbo].[Kho]([MaKho])
);

-- Bảng Chi Tiết Phiếu Nhập
CREATE TABLE [dbo].[ChiTietPhieuNhap]
(
    [MaChiTietPhieuNhap] INT PRIMARY KEY IDENTITY(1,1),
    [MaPhieuNhap] NVARCHAR(50) NOT NULL,
    [MaHangHoa] NVARCHAR(50) NOT NULL,
    [SoLuong] INT NOT NULL,
    [GiaNhap] DECIMAL(18, 2) NOT NULL,
    [ThanhTien] DECIMAL(18, 2),
    [GhiChu] NVARCHAR(MAX),
    FOREIGN KEY ([MaPhieuNhap]) REFERENCES [dbo].[PhieuNhap]([MaPhieuNhap]),
    FOREIGN KEY ([MaHangHoa]) REFERENCES [dbo].[HangHoa]([MaHangHoa])
);

-- Bảng Phiếu Xuất
CREATE TABLE [dbo].[PhieuXuat]
(
    [MaPhieuXuat] NVARCHAR(50) PRIMARY KEY NOT NULL,
    [MaKho] NVARCHAR(50) NOT NULL,
    [NgayXuat] DATETIME DEFAULT GETDATE(),
    [NguoiNhan] NVARCHAR(255),
    [GhiChu] NVARCHAR(MAX),
    [TrangThai] NVARCHAR(50) DEFAULT 'Chưa xử lý',
    [NgayTao] DATETIME DEFAULT GETDATE(),
    [NgayCapNhat] DATETIME DEFAULT GETDATE(),
    FOREIGN KEY ([MaKho]) REFERENCES [dbo].[Kho]([MaKho])
);

-- Bảng Chi Tiết Phiếu Xuất
CREATE TABLE [dbo].[ChiTietPhieuXuat]
(
    [MaChiTietPhieuXuat] INT PRIMARY KEY IDENTITY(1,1),
    [MaPhieuXuat] NVARCHAR(50) NOT NULL,
    [MaHangHoa] NVARCHAR(50) NOT NULL,
    [SoLuong] INT NOT NULL,
    [GiaBan] DECIMAL(18, 2) NOT NULL,
    [ThanhTien] DECIMAL(18, 2),
    [GhiChu] NVARCHAR(MAX),
    FOREIGN KEY ([MaPhieuXuat]) REFERENCES [dbo].[PhieuXuat]([MaPhieuXuat]),
    FOREIGN KEY ([MaHangHoa]) REFERENCES [dbo].[HangHoa]([MaHangHoa])
);

-- Bảng Người Dùng
CREATE TABLE [dbo].[NguoiDung]
(
    [MaNguoiDung] NVARCHAR(50) PRIMARY KEY NOT NULL,
    [TenDangNhap] NVARCHAR(100) UNIQUE NOT NULL,
    [MatKhau] NVARCHAR(255) NOT NULL,
    [TenNguoiDung] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255),
    [SDT] NVARCHAR(20),
    [VaiTro] NVARCHAR(50) DEFAULT 'Nhân viên',
    [TrangThai] BIT DEFAULT 1,
    [NgayTao] DATETIME DEFAULT GETDATE(),
    [NgayCapNhat] DATETIME DEFAULT GETDATE()
);

-- Tạo Index
CREATE INDEX [IX_HangHoa_MaDanhMuc] ON [dbo].[HangHoa]([MaDanhMuc]);
CREATE INDEX [IX_ChiTietKho_MaKho] ON [dbo].[ChiTietKho]([MaKho]);
CREATE INDEX [IX_ChiTietKho_MaHangHoa] ON [dbo].[ChiTietKho]([MaHangHoa]);
CREATE INDEX [IX_PhieuNhap_MaKho] ON [dbo].[PhieuNhap]([MaKho]);
CREATE INDEX [IX_PhieuXuat_MaKho] ON [dbo].[PhieuXuat]([MaKho]);

GO
