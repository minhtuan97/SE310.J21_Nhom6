//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DTO.DB
//{
//    public class qlhkObject
//    {
//        protected static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DB\\quanlyhokhauDataContext.mdf;Integrated Security=True";
//        protected static SqlConnection connection = new SqlConnection(connString);


//        public List<CanBoDTO> canbodto;
//        public List<HocSinhSinhVienDTO> hocsinhsinhviendto;
//        public List<NhanKhau> nhankhaudto;
//        public List<NhanKhauTamTruDTO> nhankhautamtrudto;
//        public List<NhanKhauTamVangDTO> nhankhautamvangdto;
//        public List<NhanKhauThuongTruDTO> nhankhauthuongtrudto;
//        public List<QuanHuyenDTO> quanhuyendto;
//        public List<ReplacementGroup> relacememntgroupdto;
//        public List<SoHoKhauDTO> sohokhaudto;
//        public List<SoTamTruDTO> sotamtrudto;
//        public List<TienAnTienSuDTO> tienantiensudto;
//        public List<TieuSuDTO> tieusudto;
//        public List<TinhThanhPhoDTO> tinhthanhphodto;
//        public List<XaPhuongThiTranDTO> xaphuongthitrandto;


//    }
//    public static List getData()
//    {
//        quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();
//        var kq = from t in qlhk.CANBOs
//                 select new CanBoDTO
//                 {
//                     dbcb = t
//                 };
//    }


//    public class CanBoDTO : NhanKhauThuongTruDTO
//    {
//        public string MaCanBo { get; set; }
//        public string TenTaiKhoan { get; set; }
//        public string MatKhau { get; set; }
//        public string LoaiCanBo { get; set; }

//        public CanBoDTO() : base() { }

//        public CanBoDTO(string maCanBo, string tenTaiKhoan, string matKhau, string loaiCanBo, string str_manhankhauthuongtru)
//        {
//            MaCanBo = maCanBo;
//            TenTaiKhoan = tenTaiKhoan;
//            MatKhau = matKhau;
//            LoaiCanBo = loaiCanBo;
//            MaNhanKhauThuongTru = str_manhankhauthuongtru;
//        }
//    }

//    public class HocSinhSinhVienDTO
//    {
//        public string MaHSSV { get; set; }
//        public string MaDinhDanh { get; set; }
//        public string Truong { get; set; }
//        public string DiaChiThuongTru { get; set; }
//        public DateTime TGBDTTTT { get; set; }
//        public DateTime TGKTTTTT { get; set; }
//        public string ViPham { get; set; }

//        public HocSinhSinhVienDTO() : base() { }

//        public HocSinhSinhVienDTO(string maHSSV, string maDinhDanh, string truong, string diaChiThuongTru,
//            DateTime tGBDTTTT, DateTime tGKTTTTT, string viPham)
//        {
//            MaHSSV = maHSSV;
//            MaDinhDanh = maDinhDanh;
//            Truong = truong;
//            DiaChiThuongTru = diaChiThuongTru;
//            TGBDTTTT = tGBDTTTT;
//            TGKTTTTT = tGKTTTTT;
//            ViPham = viPham;
//        }
//    }

//    public class NhanKhau
//    {
//        public string MaDinhDanh { get; set; }
//        public string HoTen { get; set; }
//        public string TenKhac { get; set; }
//        public DateTime NgaySinh { get; set; }
//        public string GioiTinh { get; set; }
//        public string NoiSinh { get; set; }
//        public string NguyenQuan { get; set; }
//        public string DanToc { get; set; }
//        public string TonGiao { get; set; }
//        public string QuocTich { get; set; }
//        public string HoChieu { get; set; }
//        public string NoiThuongTru { get; set; }
//        public string DiaChiHienNay { get; set; }
//        public string SDT { get; set; }
//        public string TrinhDoHocVan { get; set; }
//        public string TrinhDoChuyenMon { get; set; }
//        public string BietTiengDanToc { get; set; }
//        public string TrinhDoNgoaiNgu { get; set; }
//        public string NgheNghiep { get; set; }

//        public NhanKhau() { }

//        public NhanKhau(string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
//            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
//            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
//            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
//            string trinhDoNgoaiNgu, string ngheNghiep)
//        {
//            MaDinhDanh = maDinhDanh;
//            HoTen = hoTen;
//            TenKhac = tenKhac;
//            NgaySinh = ngaySinh;
//            GioiTinh = gioiTinh;
//            NoiSinh = noiSinh;
//            NguyenQuan = nguyenQuan;
//            DanToc = danToc;
//            TonGiao = tonGiao;
//            QuocTich = quocTich;
//            HoChieu = hoChieu;
//            NoiThuongTru = noiThuongTru;
//            DiaChiHienNay = diaChiHienNay;
//            SDT = sDT;
//            TrinhDoHocVan = trinhDoHocVan;
//            TrinhDoChuyenMon = trinhDoChuyenMon;
//            BietTiengDanToc = bietTiengDanToc;
//            TrinhDoNgoaiNgu = trinhDoNgoaiNgu;
//            NgheNghiep = ngheNghiep;
//        }
//    }

//    public class NhanKhauTamTruDTO : NhanKhau
//    {
//        public string MaNhanKhauTamTru { get; set; }
//        public string NoiTamTru { get; set; }
//        public DateTime TuNgay { get; set; }
//        public DateTime DenNgay { get; set; }
//        public string LyDo { get; set; }
//        public string SoSoTamTru { get; set; }

//        public NhanKhauTamTruDTO() : base() { }

//        public NhanKhauTamTruDTO(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, string str_MaDinhDanh)
//        {
//            MaNhanKhauTamTru = maNhanKhauTamTru;
//            NoiTamTru = noiTamTru;
//            TuNgay = tuNgay;
//            DenNgay = denNgay;
//            LyDo = lyDo;
//            SoSoTamTru = soSoTamTru;
//            MaDinhDanh = str_MaDinhDanh;
//        }

//        public NhanKhauTamTruDTO(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru,
//            string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
//            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
//            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
//            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
//            string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
//                noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
//                trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
//        {
//            MaNhanKhauTamTru = maNhanKhauTamTru;
//            NoiTamTru = noiTamTru;
//            TuNgay = tuNgay;
//            DenNgay = denNgay;
//            LyDo = lyDo;
//            SoSoTamTru = soSoTamTru;
//        }
//    }

//    public class NhanKhauTamVangDTO : NhanKhau
//    {
//        public string MaNhanKhauTamVang { get; set; }
//        public DateTime NgayBatDauTamVang { get; set; }
//        public DateTime NgayKetThucTamVang { get; set; }
//        public string LyDo { get; set; }
//        public string NoiDen { get; set; }

//        public NhanKhauTamVangDTO() { }

//        public NhanKhauTamVangDTO(string maNhanKhauTamVang, DateTime ngayBatDauTamVang, DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhdDanh)
//        {
//            MaNhanKhauTamVang = maNhanKhauTamVang;
//            MaDinhDanh = maDinhdDanh;
//            NgayBatDauTamVang = ngayBatDauTamVang;
//            NgayKetThucTamVang = ngayKetThucTamVang;
//            LyDo = lyDo;
//            NoiDen = noiDen;
//        }
//        public NhanKhauTamVangDTO(string maNhanKhauTamVang, DateTime ngayBatDauTamVang,
//            DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhDanh, string hoTen, string tenKhac,
//            DateTime ngaySinh, string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
//             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
//             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
//             string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
//                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
//                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
//        {
//            MaNhanKhauTamVang = maNhanKhauTamVang;
//            NgayBatDauTamVang = ngayBatDauTamVang;
//            NgayKetThucTamVang = ngayKetThucTamVang;
//            LyDo = lyDo;
//            NoiDen = noiDen;
//        }
//    }

//    public class NhanKhauThuongTruDTO : NhanKhau
//    {
//        public string MaNhanKhauThuongTru { get; set; }
//        public string DiaChiThuongTru { get; set; }
//        public string QuanHeVoiChuHo { get; set; }
//        public string SoSoHoKhau { get; set; }

//        public NhanKhauThuongTruDTO() { }

//        public NhanKhauThuongTruDTO(string maNhanKhauThuongTru, string diaChiThuongTru,
//            string quanHeVoiChuHo, string soSoHoKhau, string maDinhDanh)
//        {
//            MaNhanKhauThuongTru = maNhanKhauThuongTru;
//            DiaChiThuongTru = diaChiThuongTru;
//            QuanHeVoiChuHo = quanHeVoiChuHo;
//            SoSoHoKhau = soSoHoKhau;
//            MaDinhDanh = maDinhDanh;
//        }

//        public NhanKhauThuongTruDTO(string maNhanKhauThuongTru, string diaChiThuongTru,
//            string quanHeVoiChuHo, string soSoHoKhau,
//             string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
//             string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
//             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
//             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
//             string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
//                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
//                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
//        {
//            MaNhanKhauThuongTru = maNhanKhauThuongTru;
//            DiaChiThuongTru = diaChiThuongTru;
//            QuanHeVoiChuHo = quanHeVoiChuHo;
//            SoSoHoKhau = soSoHoKhau;
//        }
//    }

//    public class QuanHuyenDTO
//    {
//        public string MaQH { get; set; }
//        public string Ten { get; set; }
//        public string Kieu { get; set; }
//        public string MaTP { get; set; }

//        public QuanHuyenDTO() { }

//        public QuanHuyenDTO(string maqh, string ten, string kieu, string matp)
//        {
//            this.MaQH = maqh;
//            this.Ten = ten;
//            this.Kieu = kieu;
//            this.MaTP = matp;
//        }
//    }

//    public class ReplacementGroup
//    {
//        public string text { get; set; }
//        public string replacement { get; set; }

//        public ReplacementGroup() { }

//        public ReplacementGroup(string text, string replacement)
//        {
//            this.text = text;
//            this.replacement = replacement;
//        }
//    }

//    public class SoHoKhauDTO
//    {
//        public string SoSoHoKhau { get; set; }
//        public string MaChuHoThuongTru { get; set; }
//        public string DiaChi { get; set; }
//        public DateTime NgayCap { get; set; }
//        public string SoDangKy { get; set; }
//        public List<NhanKhauThuongTruDTO> NhanKhau { get; set; }

//        public SoHoKhauDTO()
//        {
//            NhanKhau = new List<NhanKhauThuongTruDTO>();
//        }

//        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi,
//            DateTime ngayCap, string soDangKy, List<NhanKhauThuongTruDTO> nhanKhau)
//        {
//            SoSoHoKhau = soSoHoKhau;
//            MaChuHoThuongTru = maChuHoThuongTru;
//            DiaChi = diaChi;
//            NgayCap = ngayCap;
//            SoDangKy = soDangKy;
//            NhanKhau = nhanKhau;
//        }

//        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi,
//            DateTime ngayCap, string soDangKy)
//        {
//            SoSoHoKhau = soSoHoKhau;
//            MaChuHoThuongTru = maChuHoThuongTru;
//            DiaChi = diaChi;
//            NgayCap = ngayCap;
//            SoDangKy = soDangKy;
//            NhanKhau = new List<NhanKhauThuongTruDTO>();
//        }
//    }

//    public class SoTamTruDTO
//    {
//        public string SoSoTamTru { get; set; }
//        public string MaChuHoTamTru { get; set; }
//        public string NoiTamTru { get; set; }
//        public DateTime NgayCap { get; set; }
//        public DateTime DenNgay { get; set; }

//        public SoTamTruDTO() { }

//        public SoTamTruDTO(string soSoTamTru, string maChuHoTamTru, string noiTamTru,
//            DateTime ngayCap, DateTime denNgay)
//        {
//            SoSoTamTru = soSoTamTru;
//            MaChuHoTamTru = maChuHoTamTru;
//            NoiTamTru = noiTamTru;
//            NgayCap = ngayCap;
//            DenNgay = denNgay;
//        }
//    }

//    public class TienAnTienSuDTO
//    {
//        public string MaTienAnTienSu { get; set; }
//        public string MaDinhDanh { get; set; }
//        public string ToiDanh { get; set; }
//        public string HinhPhat { get; set; }
//        public string BanAn { get; set; }
//        public DateTime NgayPhat { get; set; }

//        public TienAnTienSuDTO() { }

//        public TienAnTienSuDTO(string maTienAnTienSu, string maDinhDanh, string banAn, string toiDanh, string hinhPhat, DateTime ngayPhat)
//        {
//            MaTienAnTienSu = maTienAnTienSu;
//            MaDinhDanh = maDinhDanh;
//            BanAn = banAn;
//            ToiDanh = toiDanh;
//            HinhPhat = hinhPhat;
//            NgayPhat = ngayPhat;
//        }
//    }

//    public class TieuSuDTO
//    {
//        public string MaTieuSu { get; set; }
//        public string MaDinhDanh { get; set; }
//        public DateTime ThoiGianBatDau { get; set; }
//        public DateTime ThoiGianKetThuc { get; set; }
//        public string ChoO { get; set; }
//        public string NgheNghiep { get; set; }
//        public string NoiLamViec { get; set; }

//        public TieuSuDTO() { }

//        public TieuSuDTO(string maTieuSu, string maDinhDanh, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string choO, string ngheNghiep, string noiLamViec)
//        {
//            MaTieuSu = maTieuSu;
//            MaDinhDanh = maDinhDanh;
//            ThoiGianBatDau = thoiGianBatDau;
//            ThoiGianKetThuc = thoiGianKetThuc;
//            ChoO = choO;
//            NgheNghiep = ngheNghiep;
//            NoiLamViec = noiLamViec;
//        }
//    }

//    public class TinhThanhPhoDTO
//    {
//        public string MaTP { get; set; }
//        public string Ten { get; set; }
//        public string Kieu { get; set; }

//        public TinhThanhPhoDTO() { }

//        public TinhThanhPhoDTO(string matp, string ten, string kieu)
//        {
//            this.MaTP = matp;
//            this.Ten = ten;
//            this.Kieu = kieu;
//        }
//    }

//    public class XaPhuongThiTranDTO
//    {
//        public string MaXP { get; set; }
//        public string Ten { get; set; }
//        public string Kieu { get; set; }
//        public string MaQH { get; set; }

//        public XaPhuongThiTranDTO() { }

//        public XaPhuongThiTranDTO(string maxp, string ten, string kieu, string maqh)
//        {
//            this.MaXP = maxp;
//            this.Ten = ten;
//            this.Kieu = kieu;
//            this.MaQH = maqh;
//        }
//    }
//}
