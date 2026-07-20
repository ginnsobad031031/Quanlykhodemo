USE QuanlyKho;
GO

-- Thêm dữ liệu mẫu vào Danh Mục Hàng Hóa
INSERT INTO [dbo].[DanhMucHangHoa] ([MaDanhMuc], [TenDanhMuc], [MoTa])
VALUES 
    ('DM001', 'Điện tử', 'Các sản phẩm điện tử'),
    ('DM002', 'Quần áo', 'Các loại quần áo'),
    ('DM003', 'Giày dép', 'Các loại giày dép'),
    ('DM004', 'Phụ kiện', 'Các loại phụ kiện');

-- Thêm dữ liệu mẫu vào Hàng Hóa
INSERT INTO [dbo].[HangHoa] ([MaHangHoa], [TenHangHoa], [MaDanhMuc], [KichThuoc], [Mau], [KhoiLuong], [GiaNhap], [GiaBan], [MoTa])
VALUES 
    ('A', 'Điện Thoại iPhone 13', 'DM001', '6.1 inch', 'Đen', 0.17, 15000000, 16000000, 'iPhone 13 64GB'),
    ('A1', 'Điện Thoại Samsung S21', 'DM001', '6.2 inch', 'Trắng', 0.17, 12000000, 13000000, 'Samsung Galaxy S21'),
    ('A2', 'Laptop Dell XPS 13', 'DM001', '13.3 inch', 'Bạc', 1.20, 20000000, 22000000, 'Laptop Dell XPS 13'),
    ('A3', 'Tai nghe Sony WH-1000', 'DM001', 'M', 'Đen', 0.25, 5000000, 5500000, 'Tai nghe chống ồn'),
    ('A4', 'Smartwatch Apple Watch 7', 'DM001', '41mm', 'Đỏ', 0.04, 8000000, 8500000, 'Apple Watch Series 7'),
    ('B', 'Áo phông Nam', 'DM002', 'M', 'Trắng', 0.15, 50000, 100000, 'Áo phông 100% cotton'),
    ('C', 'Quần jeans Nam', 'DM002', '32', 'Xanh đậm', 0.60, 200000, 350000, 'Quần jeans Levi'),
    ('D', 'Giày thể thao', 'DM003', '42', 'Trắng', 0.40, 500000, 800000, 'Giày Nike Air Max'),
    ('D1', 'Dép quai hông', 'DM003', '40', 'Xanh', 0.20, 100000, 150000, 'Dép xỏ ngón');

-- Thêm dữ liệu mẫu vào Kho
INSERT INTO [dbo].[Kho] ([MaKho], [TenKho], [DiaChi], [SDT], [MoTa])
VALUES 
    ('K001', 'Kho Chính Hà Nội', '123 Đường Láng, Hà Nội', '0243123456', 'Kho chính tại Hà Nội'),
    ('K002', 'Kho Hồ Chí Minh', '456 Đinh Bộ Lĩnh, TP.HCM', '0283456789', 'Kho tại TP.HCM'),
    ('K003', 'Kho Đà Nẵng', '789 Nguyễn Hữu Thọ, Đà Nẵng', '0236123789', 'Kho tại Đà Nẵng');

-- Thêm dữ liệu mẫu vào Chi Tiết Kho
INSERT INTO [dbo].[ChiTietKho] ([MaKho], [MaHangHoa], [SoLuong], [SoLuongToiThieu], [SoLuongToiDa])
VALUES 
    ('K001', 'A', 15, 5, 50),
    ('K001', 'A1', 20, 5, 50),
    ('K001', 'A2', 8, 2, 20),
    ('K001', 'B', 100, 20, 500),
    ('K001', 'C', 50, 10, 200),
    ('K002', 'A', 12, 5, 50),
    ('K002', 'A3', 25, 10, 100),
    ('K002', 'D', 30, 10, 100),
    ('K003', 'A4', 18, 5, 50),
    ('K003', 'D1', 40, 15, 200);

-- Thêm dữ liệu mẫu vào Người Dùng
INSERT INTO [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [TenNguoiDung], [Email], [SDT], [VaiTro])
VALUES 
    ('ND001', 'admin', 'admin123', 'Quản trị viên', 'admin@quanlykho.com', '0901234567', 'Quản trị viên'),
    ('ND002', 'nhvien1', 'pass123', 'Nguyễn Văn A', 'nvana@quanlykho.com', '0912345678', 'Nhân viên'),
    ('ND003', 'nhvien2', 'pass123', 'Trần Thị B', 'tranb@quanlykho.com', '0923456789', 'Nhân viên'),
    ('ND004', 'qlkho', 'pass123', 'Lê Văn C', 'levanc@quanlykho.com', '0934567890', 'Quản lý kho');

GO
