using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Paint
{
    public partial class frmMain : Form
    {
        private QLHSDataContext db;
        private Timer timerClock = new Timer();
        private bool isLoggedIn = false;
        private string currentUser = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load()
        {
            timerClock.Interval = 1000;
            timerClock.Tick += (s, e) => lblStatusTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy  ");
            timerClock.Start();
            UpdateUI();
        }

        // ─── ĐĂNG NHẬP / ĐĂNG XUẤT (TÍCH HỢP TRÊN CÙNG FORM) ───────────
        private void HienThiFormDangNhap()
        {
            if (isLoggedIn) return;
            pnlLogin.Visible = true;
            pnlLogin.BringToFront();
            tabControl1.Visible = false;
            txtLoginPass.Clear();
            txtLoginUser.Focus();
        }

        private void ThucHienDangNhap()
        {
            string username = txtLoginUser.Text.Trim();
            string password = txtLoginPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đăng nhập hợp lệ (ví dụ: admin/123 hoặc bất kỳ tài khoản hợp lệ nào)
            if ((username == "admin" && password == "123") || username.Length > 0)
            {
                isLoggedIn = true;
                currentUser = username;
                db = new QLHSDataContext();

                pnlLogin.Visible = false;
                tabControl1.Visible = true;
                UpdateUI();

                LoadComboLops();
                LoadDSLop();
                LoadDSHocSinh();
                LoadDSDiem();

                MessageBox.Show("Đăng nhập thành công! Chào mừng " + username, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoginPass.SelectAll();
                txtLoginPass.Focus();
            }
        }

        private void DangXuat()
        {
            isLoggedIn = false;
            currentUser = "";
            db = null;

            lvLop.Items.Clear();
            dgvHS.DataSource = null;
            dgvDiem.DataSource = null;
            cboLopHS.DataSource = null;
            cboLopChon.DataSource = null;
            cboDiem.DataSource = null;

            pnlLogin.Visible = true;
            pnlLogin.BringToFront();
            tabControl1.Visible = false;
            txtLoginPass.Clear();
            txtLoginUser.Focus();

            UpdateUI();
        }

        private void UpdateUI()
        {
            tabControl1.Visible = isLoggedIn;
            pnlLogin.Visible = !isLoggedIn;
            if (!isLoggedIn) pnlLogin.BringToFront();

            mnuDangNhap.Enabled = !isLoggedIn;
            mnuDangXuat.Enabled = isLoggedIn;
            lblStatusUser.Text = isLoggedIn ? $"  Người dùng: {currentUser}" : "  Chưa đăng nhập";
        }

        // ─── LOAD COMBOBOX LỚP ─────────────────────────────────────────
        private void LoadComboLops()
        {
            try
            {
                var dsLop = db.Lops.OrderBy(l => l.MaLop).ToList();
                cboLopHS.DataSource = dsLop.ToList();
                cboLopHS.DisplayMember = "TenLop";
                cboLopHS.ValueMember = "MaLop";

                cboLopChon.DataSource = dsLop.ToList();
                cboLopChon.DisplayMember = "TenLop";
                cboLopChon.ValueMember = "MaLop";

                cboDiem.DataSource = dsLop.ToList();
                cboDiem.DisplayMember = "TenLop";
                cboDiem.ValueMember = "MaLop";
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  TAB LỚP
        // ════════════════════════════════════════════════════════════════
        private void LoadDSLop()
        {
            lvLop.Items.Clear();
            try
            {
                using (var con = DatabaseConfig.GetConnection())
                {
                    con.Open();
                    var cmd = new SqlCommand("SELECT MaLop, TenLop, SiSo FROM Lop ORDER BY MaLop", con);
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var item = new ListViewItem(dr[0].ToString());
                        item.Tag = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr.IsDBNull(2) ? "" : dr[2].ToString());
                        lvLop.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void LvLop_Select(ListViewItem item)
        {
            txtMaLop.Text = item.Text;
            txtTenLop.Text = item.SubItems.Count > 1 ? item.SubItems[1].Text : "";
            txtSiSo.Text = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            if (!ValidateLop()) return;
            try
            {
                using (var con = DatabaseConfig.GetConnection())
                {
                    con.Open();
                    var cmd = new SqlCommand("INSERT INTO Lop(MaLop,TenLop,SiSo) VALUES(@a,@b,@c)", con);
                    cmd.Parameters.AddWithValue("@a", txtMaLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@b", txtTenLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@c", int.TryParse(txtSiSo.Text, out int ss) ? ss : 0);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAll();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (!ValidateLop()) return;
            try
            {
                using (var con = DatabaseConfig.GetConnection())
                {
                    con.Open();
                    var cmd = new SqlCommand("UPDATE Lop SET TenLop=@b,SiSo=@c WHERE MaLop=@a", con);
                    cmd.Parameters.AddWithValue("@a", txtMaLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@b", txtTenLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@c", int.TryParse(txtSiSo.Text, out int ss) ? ss : 0);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAll();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Chọn lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp '{txtMaLop.Text}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (var con = DatabaseConfig.GetConnection())
                {
                    con.Open();
                    new SqlCommand($"DELETE FROM Lop WHERE MaLop='{txtMaLop.Text.Trim()}'", con).ExecuteNonQuery();
                }
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearLop();
                RefreshAll();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private bool ValidateLop()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Nhập đầy đủ Mã lớp và Tên lớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearLop()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSiSo.Clear();
        }

        // ════════════════════════════════════════════════════════════════
        //  TAB HỌC SINH
        // ════════════════════════════════════════════════════════════════
        private void LoadDSHocSinh()
        {
            if (db == null || cboLopHS.SelectedValue == null) return;
            try
            {
                string maLop = cboLopHS.SelectedValue.ToString();
                var ds = db.HocSinhs.Where(p => p.MaLop == maLop)
                    .Select(p => new { p.MaHS, p.TenHS, p.NgaySinh, p.DiaChi, p.DTB, p.MaLop }).ToList();
                dgvHS.DataSource = ds;
                FormatDgv(dgvHS);
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void LoadTatCaHS()
        {
            if (db == null) return;
            try
            {
                var ds = db.HocSinhs.Select(p => new { p.MaHS, p.TenHS, p.NgaySinh, p.DiaChi, p.DTB, p.MaLop }).ToList();
                dgvHS.DataSource = ds;
                FormatDgv(dgvHS);
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void DgvHS_CellClick(int row)
        {
            if (row < 0 || row >= dgvHS.Rows.Count) return;
            var r = dgvHS.Rows[row];
            txtMaHS.Text = r.Cells["MaHS"]?.Value?.ToString() ?? "";
            txtTenHS.Text = r.Cells["TenHS"]?.Value?.ToString() ?? "";
            txtDiaChi.Text = r.Cells["DiaChi"]?.Value?.ToString() ?? "";
            txtDTB.Text = r.Cells["DTB"]?.Value?.ToString() ?? "";
            if (r.Cells["NgaySinh"]?.Value != null && DateTime.TryParse(r.Cells["NgaySinh"].Value.ToString(), out DateTime dt))
                dtpNgaySinh.Value = dt;
            if (r.Cells["MaLop"]?.Value != null)
                cboLopChon.SelectedValue = r.Cells["MaLop"].Value.ToString();
        }

        private void btnThemHS_Click(object sender, EventArgs e)
        {
            if (!ValidateHS()) return;
            try
            {
                var existing = db.HocSinhs.SingleOrDefault(p => p.MaHS == txtMaHS.Text.Trim());
                if (existing != null)
                {
                    MessageBox.Show("Mã HS đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.HocSinhs.InsertOnSubmit(new HocSinh
                {
                    MaHS = txtMaHS.Text.Trim(),
                    TenHS = txtTenHS.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text.Trim(),
                    DTB = float.TryParse(txtDTB.Text, out float d) ? d : 0,
                    MaLop = cboLopChon.SelectedValue?.ToString()
                });
                db.SubmitChanges();
                MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSHocSinh();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
                db = new QLHSDataContext();
            }
        }

        private void btnSuaHS_Click(object sender, EventArgs e)
        {
            if (!ValidateHS()) return;
            try
            {
                var hs = db.HocSinhs.SingleOrDefault(p => p.MaHS == txtMaHS.Text.Trim());
                if (hs == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                hs.TenHS = txtTenHS.Text.Trim();
                hs.NgaySinh = dtpNgaySinh.Value;
                hs.DiaChi = txtDiaChi.Text.Trim();
                hs.DTB = float.TryParse(txtDTB.Text, out float d) ? d : 0;
                hs.MaLop = cboLopChon.SelectedValue?.ToString();
                db.SubmitChanges();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSHocSinh();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
                db = new QLHSDataContext();
            }
        }

        private void btnXoaHS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHS.Text))
            {
                MessageBox.Show("Chọn học sinh cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa học sinh '{txtTenHS.Text}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                var hs = db.HocSinhs.SingleOrDefault(p => p.MaHS == txtMaHS.Text.Trim());
                if (hs == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.HocSinhs.DeleteOnSubmit(hs);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearHS();
                LoadDSHocSinh();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
                db = new QLHSDataContext();
            }
        }

        private void btnTimHS_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            string ten = txtTenHS.Text.Trim();
            try
            {
                var ds = db.HocSinhs.Where(p => p.TenHS.Contains(ten))
                    .Select(p => new { p.MaHS, p.TenHS, p.NgaySinh, p.DiaChi, p.DTB, p.MaLop }).ToList();
                dgvHS.DataSource = ds;
                FormatDgv(dgvHS);
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private bool ValidateHS()
        {
            if (string.IsNullOrWhiteSpace(txtMaHS.Text) || string.IsNullOrWhiteSpace(txtTenHS.Text))
            {
                MessageBox.Show("Nhập đầy đủ Mã HS và Tên HS!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearHS()
        {
            txtMaHS.Clear();
            txtTenHS.Clear();
            txtDiaChi.Clear();
            txtDTB.Clear();
        }

        // ════════════════════════════════════════════════════════════════
        //  TAB NHẬP ĐIỂM
        // ════════════════════════════════════════════════════════════════
        private void LoadDSDiem()
        {
            if (db == null || cboDiem.SelectedValue == null) return;
            try
            {
                string maLop = cboDiem.SelectedValue.ToString();
                var ds = db.HocSinhs.Where(p => p.MaLop == maLop)
                    .Select(p => new { p.MaHS, p.TenHS, p.DTB, p.MaLop }).ToList();
                dgvDiem.DataSource = ds;
                if (dgvDiem.Columns["DTB"] != null)
                {
                    dgvDiem.Columns["DTB"].HeaderText = "Điểm TB";
                    dgvDiem.Columns["DTB"].DefaultCellStyle.Format = "N2";
                }
                if (dgvDiem.Columns["MaLop"] != null) dgvDiem.Columns["MaLop"].Visible = false;
            }
            catch (Exception ex)
            {
                ShowErr(ex);
            }
        }

        private void DgvDiem_CellClick(int row)
        {
            if (row < 0 || row >= dgvDiem.Rows.Count) return;
            var r = dgvDiem.Rows[row];
            txtMaHSDiem.Text = r.Cells["MaHS"]?.Value?.ToString() ?? "";
            txtTenHSDiem.Text = r.Cells["TenHS"]?.Value?.ToString() ?? "";
            txtDiemNhap.Text = r.Cells["DTB"]?.Value?.ToString() ?? "";
            CapNhatXepLoai();
        }

        private void CapNhatXepLoai()
        {
            if (float.TryParse(txtDiemNhap.Text, out float d))
            {
                if (d >= 9) txtXepLoai.Text = "Xuất sắc";
                else if (d >= 8) txtXepLoai.Text = "Giỏi";
                else if (d >= 6.5f) txtXepLoai.Text = "Khá";
                else if (d >= 5) txtXepLoai.Text = "Trung bình";
                else txtXepLoai.Text = "Yếu";
            }
            else
            {
                txtXepLoai.Text = "";
            }
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHSDiem.Text))
            {
                MessageBox.Show("Chọn học sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!float.TryParse(txtDiemNhap.Text, out float d) || d < 0 || d > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var hs = db.HocSinhs.SingleOrDefault(p => p.MaHS == txtMaHSDiem.Text.Trim());
                if (hs == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                hs.DTB = d;
                db.SubmitChanges();
                MessageBox.Show("Lưu điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSDiem();
            }
            catch (Exception ex)
            {
                ShowErr(ex);
                db = new QLHSDataContext();
            }
        }

        // ─── HELPERS ────────────────────────────────────────────────────
        private void RefreshAll()
        {
            db = new QLHSDataContext();
            LoadDSLop();
            LoadComboLops();
            LoadDSHocSinh();
            LoadDSDiem();
        }

        private void FormatDgv(DataGridView dgv)
        {
            if (dgv.Columns["MaHS"] != null) dgv.Columns["MaHS"].HeaderText = "Mã HS";
            if (dgv.Columns["TenHS"] != null) dgv.Columns["TenHS"].HeaderText = "Tên HS";
            if (dgv.Columns["NgaySinh"] != null)
            {
                dgv.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgv.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgv.Columns["DiaChi"] != null) dgv.Columns["DiaChi"].HeaderText = "Địa chỉ";
            if (dgv.Columns["DTB"] != null)
            {
                dgv.Columns["DTB"].HeaderText = "ĐTB";
                dgv.Columns["DTB"].DefaultCellStyle.Format = "N2";
            }
            if (dgv.Columns["MaLop"] != null) dgv.Columns["MaLop"].Visible = false;
        }

        private void ShowErr(Exception ex) =>
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
