using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKTX
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            SetupButtonLayout();


        }
        private void SetupButtonLayout()
        { 
            // nút Quản lý sinh viên
            bQuanLySinhVien.TextImageRelation = TextImageRelation.ImageBeforeText; // Đặt hình ảnh trước văn bản
            bQuanLySinhVien.ImageAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của hình ảnh ở giữa
            bQuanLySinhVien.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của văn bản ở giữa
            bQuanLySinhVien.Padding = new Padding(3); // Xóa bỏ Padding để hình ảnh và văn bản nằm ở giữa của nút


            // nút Quản lý phòng
            bQuanLyPhong.TextImageRelation = TextImageRelation.ImageBeforeText; // Đặt hình ảnh trước văn bản
            bQuanLyPhong.ImageAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của hình ảnh ở giữa
            bQuanLyPhong.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của văn bản ở giữa
            bQuanLyPhong.Padding = new Padding(0); // Xóa bỏ Padding để hình ảnh và văn bản nằm ở giữa của nút


            // nút Quản lý hóa đơn
            bQuanLyHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText; // Đặt hình ảnh trước văn bản
            bQuanLyHoaDon.ImageAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của hình ảnh ở giữa
            bQuanLyHoaDon.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của văn bản ở giữa
            bQuanLyHoaDon.Padding = new Padding(3); // Xóa bỏ Padding để hình ảnh và văn bản nằm ở giữa của nút


            // nút Quản lý thiết bị
            bQuanLyThietBi.TextImageRelation = TextImageRelation.ImageBeforeText; // Đặt hình ảnh trước văn bản
            bQuanLyThietBi.ImageAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của hình ảnh ở giữa
            bQuanLyThietBi.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của văn bản ở giữa
            bQuanLyThietBi.Padding = new Padding(3); // Xóa bỏ Padding để hình ảnh và văn bản nằm ở giữa của nút


            // nút Quản lý nhân viên
            bQuanLyNhanVien.TextImageRelation = TextImageRelation.ImageBeforeText; // Đặt hình ảnh trước văn bản
            bQuanLyNhanVien.ImageAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của hình ảnh ở giữa
            bQuanLyNhanVien.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của văn bản ở giữa
            bQuanLyNhanVien.Padding = new Padding(3); // Xóa bỏ Padding để hình ảnh và văn bản nằm ở giữa của nút


            // nút Báo cáo thống kê
            bBaoCaoThongKe.TextImageRelation = TextImageRelation.ImageBeforeText; // Đặt hình ảnh trước văn bản
            bBaoCaoThongKe.ImageAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của hình ảnh ở giữa
            bBaoCaoThongKe.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí của văn bản ở giữa
            bBaoCaoThongKe.Padding = new Padding(3); // Xóa bỏ Padding để hình ảnh và văn bản nằm ở giữa của nút
        }
    }
}
