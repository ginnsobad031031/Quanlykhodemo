# 📦 Phần mềm Quản lý Kho - QuanlyKhodemo

Ứng dụng quản lý kho hàng được phát triển bằng **C# WinForms** và **SQL Server**.

## 🎯 Tính năng chính

✅ **Quản lý Hàng Hóa**
- Thêm, sửa, xóa hàng hóa
- Quản lý giá nhập, giá bán
- Phân loại theo danh mục

✅ **Quản lý Kho**
- Quản lý thông tin kho
- Theo dõi địa chỉ, số điện thoại

✅ **Quản lý Danh Mục**
- Tổ chức hàng hóa theo danh mục
- Dễ dàng tìm kiếm

✅ **Giao diện thân thiện**
- Dễ sử dụng
- Responsive design

## 📋 Yêu cầu hệ thống

- **Visual Studio 2019** trở lên
- **.NET Framework 4.7.2** trở lên
- **SQL Server 2012** trở lên (hoặc SQL Server Express)

## 🚀 Hướng dẫn cài đặt

### Bước 1: Clone Repository
```bash
git clone https://github.com/ginnsobad031031/QuanlyKhodemo.git
cd QuanlyKhodemo
```

### Bước 2: Tạo Database
1. Mở **SQL Server Management Studio**
2. Chạy script: `Database/CreateDatabase.sql`
3. Chạy script: `Database/InsertSampleData.sql`

### Bước 3: Cấu hình Connection String
Mở file `App.config` và cập nhật connection string:

```xml
<connectionStrings>
    <add name="QuanlyKhoConnection" 
         connectionString="Server=YOUR_SERVER_NAME;Database=QuanlyKho;Uid=sa;Pwd=YOUR_PASSWORD;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Thay đổi:**
- `YOUR_SERVER_NAME` - Tên server SQL (ví dụ: `localhost`, `PC-NAME\SQLEXPRESS`)
- `YOUR_PASSWORD` - Mật khẩu của user `sa`

### Bước 4: Mở Solution và Build
1. Mở file `QuanlyKhodemo.sln` bằng Visual Studio
2. **Build Solution** (Ctrl + Shift + B)
3. **Run** (F5)

## 📂 Cấu trúc thư mục

```
QuanlyKhodemo/
├── Database/
│   ├── CreateDatabase.sql          # Script tạo database
│   └── InsertSampleData.sql        # Script dữ liệu mẫu
├── Models/
│   ├── HangHoa.cs                  # Model hàng hóa
│   ├── Kho.cs                      # Model kho
│   ├── DanhMuc.cs                  # Model danh mục
│   └── ...
├── DAL/                            # Data Access Layer
│   ├── DatabaseConnection.cs
│   ├── HangHoaDAL.cs
│   ├── KhoDAL.cs
│   └── ...
├── BLL/                            # Business Logic Layer
│   ├── HangHoaBLL.cs
│   ├── KhoBLL.cs
│   └── ...
├── Forms/                          # User Interface
│   ├── frmMain.cs                  # Form chính
│   ├── frmHangHoa.cs               # Form quản lý hàng hóa
│   ├── frmKho.cs                   # Form quản lý kho
│   └── ...
├── App.config                      # Cấu hình ứng dụng
├── Program.cs                      # Entry point
└── README.md
```

## 🔐 Tài khoản mẫu

| Tên đăng nhập | Mật khẩu | Vai trò |
|---|---|---|
| admin | admin123 | Quản trị viên |
| nhvien1 | pass123 | Nhân viên |
| nhvien2 | pass123 | Nhân viên |

## 🛠️ Công nghệ sử dụng

- **C# .NET Framework 4.7.2**
- **Windows Forms (WinForms)**
- **SQL Server**
- **ADO.NET**

## 📝 Các bảng chính trong Database

### HangHoa
- MaHangHoa (Primary Key)
- TenHangHoa
- MaDanhMuc (Foreign Key)
- GiaNhap, GiaBan
- Mô tả

### Kho
- MaKho (Primary Key)
- TenKho
- DiaChi
- SDT

### DanhMucHangHoa
- MaDanhMuc (Primary Key)
- TenDanhMuc
- Mô tả

### ChiTietKho
- MaChiTietKho (Primary Key)
- MaKho (Foreign Key)
- MaHangHoa (Foreign Key)
- SoLuong

## 🐛 Xử lý lỗi

### Lỗi: "Connection string not found"
- ✅ Kiểm tra lại `App.config`
- ✅ Đảm bảo connection string đúng

### Lỗi: "Cannot connect to server"
- ✅ Kiểm tra SQL Server đã bật chưa
- ✅ Kiểm tra tên server có đúng không

### Lỗi: "Database does not exist"
- ✅ Chạy lại script `CreateDatabase.sql`

## 📧 Hỗ trợ

Nếu bạn gặp bất kỳ vấn đề nào, vui lòng:
1. Kiểm tra lại các bước cài đặt
2. Đảm bảo SQL Server và Visual Studio đã cài đặt đúng
3. Tạo Issue trên GitHub

## 📄 Giấy phép

Dự án này được phát hành dưới giấy phép MIT.

---

**Version:** 1.0.0  
**Author:** ginnsobad031031  
**Ngày tạo:** 2026-07-20
