# Bài tập Quản lý trang thiết bị (ASP net.core MVC)
- Câu 1: Script tạo bảng và thêm dữ liệu cho CSDL: `Create_QLTB_db.sql`
- Câu 2: Controller và view được đặt tên `Qltb`
- Câu 3: Code bài tập jquery nằm trong `QLTB\Views\Qltb\Edit.cshtml`

# Bài tập SQL Quản lý karaoke
- Script tạo bảng và thêm dữ liệu cho CSDL: `TaoCSDLchoBT_SQL.sql`
- Script trả lời 11 câu hỏi: `LamBT_SQL_karaoke.sql`

# Use user-secret to manage settings
- On windows, use below commands to override `appsettings.json`:
```
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:QLTBContext" "Data Source=(localdb)\mssqllocaldb;Database=QLTB;Trusted_Connection=True;MultipleActiveResultSets=true;" --project .\HD.Station.Qltb.Demoo\
```