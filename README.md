# 👗 HỆ THỐNG BÁN QUẦN ÁO (QLBanQuanAo)

> **Báo cáo kết thúc học phần Lập trình trên Windows** – Mã lớp học phần `2611COMP1019`
> Trường Đại học Sư phạm TP. Hồ Chí Minh – Khoa Công nghệ Thông tin
> Giảng viên hướng dẫn: **ThS. Lương Trần Ngọc Khiết** – Nhóm **NTD**

Ứng dụng desktop **bán hàng và quản lý cửa hàng thời trang**, xây dựng bằng **C# Windows Forms** và **SQL Server**, gồm hai phân hệ: **khách hàng** (mua sắm) và **quản trị viên** (quản lý cửa hàng).

---

## ✨ Chức năng chính

**🔐 Tài khoản**
- Đăng ký, đăng nhập, đổi mật khẩu, đăng xuất
- Quên mật khẩu bằng **OTP qua email**
- Phân quyền theo vai trò (khách hàng / quản trị viên)

**🛠️ Phân hệ quản trị**
- Quản lý sản phẩm (màu sắc, kích thước, biến thể, hình ảnh, tồn kho)
- Quản lý danh mục sản phẩm
- Quản lý đơn hàng và cập nhật trạng thái xử lý
- Quản lý tài khoản khách hàng (khóa / mở khóa)
- In hóa đơn bằng **RDLC ReportViewer**

**🛍️ Phân hệ khách hàng**
- Xem, tìm kiếm và lọc sản phẩm
- Xem chi tiết sản phẩm
- Giỏ hàng, thanh toán và đặt hàng
- Theo dõi lịch sử và trạng thái đơn hàng

## 🛠️ Công nghệ sử dụng

| Công nghệ | Vai trò |
|---|---|
| C# | Ngôn ngữ lập trình chính |
| Windows Forms | Xây dựng giao diện người dùng |
| SQL Server | Lưu trữ dữ liệu tập trung |
| LINQ / LINQ to SQL | Truy vấn và ánh xạ dữ liệu |
| BCrypt.Net | Băm mật khẩu và mã OTP |
| RDLC / ReportViewer | Thiết kế và hiển thị báo cáo, hóa đơn |
| SMTP (Gmail) | Gửi email OTP |

## 📸 Giao diện

### Xác thực

| Đăng nhập | Đăng ký | Đổi mật khẩu |
|:---:|:---:|:---:|
| <img src="docs/login.png" width="250"> | <img src="docs/register.png" width="250"> | <img src="docs/change-password.png" width="250"> |

### Phân hệ khách hàng

**Trang chủ**

![Trang chủ khách hàng](docs/customer-home.png)

| Chi tiết sản phẩm | Giỏ hàng |
|:---:|:---:|
| <img src="docs/product-detail.png" width="420"> | <img src="docs/cart.png" width="420"> |

| Thanh toán & đặt hàng | Lịch sử đơn hàng |
|:---:|:---:|
| <img src="docs/checkout.png" width="420"> | <img src="docs/order-history.png" width="420"> |

### Phân hệ quản trị

**Quản lý sản phẩm**

![Quản lý sản phẩm](docs/admin-products.png)

**Quản lý danh mục**

![Quản lý danh mục](docs/admin-categories.png)

**Quản lý đơn hàng**

![Quản lý đơn hàng](docs/admin-orders.png)

**Quản lý tài khoản khách hàng**

![Quản lý tài khoản](docs/admin-accounts.png)

**In hóa đơn (RDLC)**

![Hóa đơn](docs/invoice.png)

## 🗄️ Cơ sở dữ liệu

Sơ đồ quan hệ thực thể (ERD):

![ERD](docs/erd.png)

## 🚀 Hướng dẫn cài đặt & chạy

### 1. Yêu cầu
- Windows 10 trở lên
- Visual Studio 2019/2022 (workload **.NET desktop development**)
- SQL Server (bản Express trở lên) và SQL Server Management Studio (SSMS)

### 2. Clone project
```bash
git clone https://github.com/ntkt28122006-web/QLBanQuanAo.git
```

### 3. Tạo cơ sở dữ liệu
1. Mở **SSMS**, kết nối tới SQL Server.
2. Chạy file `Database/QLBanHang.sql` để tạo database và dữ liệu mẫu.
3. Đảm bảo bảng `users` có các cột phục vụ quên mật khẩu:

```sql
ALTER TABLE users ADD password_reset_otp_hash NVARCHAR(255) NULL;
ALTER TABLE users ADD password_reset_otp_expires_at DATETIME NULL;
ALTER TABLE users ADD password_reset_attempts INT NOT NULL DEFAULT 0;
```
> Bỏ qua câu lệnh nào nếu cột đã tồn tại.

### 4. Cấu hình chuỗi kết nối
Mở `App.config` và sửa `connectionString` cho đúng tên SQL Server trên máy bạn (ví dụ `Data Source=.\SQLEXPRESS`).


### 5. Build & chạy
Mở `QLBanQuanAo.sln` → Restore NuGet Packages → nhấn **F5**.

### 🔑 Tài khoản demo
| Vai trò | Email / Tên đăng nhập | Mật khẩu |
|---|---|---|
| Quản trị viên | admin123@gmail.com | 00000000 |
| Khách hàng | ntkt.28122006@gmail.com | 00000000 |

## 🔒 Bảo mật

- Mật khẩu người dùng và mã OTP được **băm bằng BCrypt** trước khi lưu
- OTP 6 chữ số sinh bằng bộ sinh số ngẫu nhiên an toàn mật mã, hiệu lực **3 phút**, dùng **một lần**
- Giới hạn **5 lần** nhập sai OTP và giãn cách **60 giây** giữa các lần gửi mã
- Xác minh lại OTP ở bước đặt mật khẩu mới
- Thông báo chung chung, không làm lộ email nào tồn tại trong hệ thống
- Phân quyền theo vai trò (RBAC)

## 👨‍💻 Thành viên nhóm NTD

| STT | Họ và tên | MSSV | Vai trò |
|---|---|---|---|
| 1 | Nguyễn Thị Kim Thoa | 50.01.104.154 | Nền tảng, Database và giao diện xác thực |
| 2 | Nguyễn Huỳnh Ngọc Nhân | 50.01.104.106 | Phân hệ quản trị |
| 3 | Thạch Minh Dũng | 50.01.104.033 | Phân hệ khách hàng |

## 📄 Giấy phép

Dự án được thực hiện cho mục đích học tập.
