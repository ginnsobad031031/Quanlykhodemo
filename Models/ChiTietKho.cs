using System;

namespace QuanlyKhodemo.Models
{
    public class ChiTietKho
    {
        public int MaChiTietKho { get; set; }
        public string MaKho { get; set; }
        public string MaHangHoa { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongToiThieu { get; set; }
        public int SoLuongToiDa { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public ChiTietKho()
        {
        }

        public ChiTietKho(string maKho, string maHangHoa, int soLuong, int soLuongToiThieu, int soLuongToiDa)
        {
            MaKho = maKho;
            MaHangHoa = maHangHoa;
            SoLuong = soLuong;
            SoLuongToiThieu = soLuongToiThieu;
            SoLuongToiDa = soLuongToiDa;
        }
    }
}
