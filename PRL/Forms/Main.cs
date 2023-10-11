using BUS.Services;
using DAL.Models;
using DAL.ViewModels;

namespace PRL.Forms
{
    public partial class Main : Form
    {
        SinhvienServices _sinhvienServices = new();
        List<SinhvienVM> _listSV = new();
        int _idCellClick;

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show
            LoadGrid(null, null);
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(SearchType.All);
            comboBox1.Items.Add(SearchType.Sdt);
            comboBox1.Items.Add(SearchType.Diachi);
            comboBox1.Items.Add(SearchType.TenPH);
            comboBox1.Items.Add(SearchType.NgheNghiepPH);

            comboBox1.SelectedIndex = 0;
        }

        private void LoadGrid(string searchText, string searchType)
        {
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "TEN";
            dataGridView1.Columns[2].Name = "EMAIL";
            dataGridView1.Columns[3].Name = "SDT";
            dataGridView1.Columns[4].Name = "DIA CHI";
            dataGridView1.Columns[5].Name = "TenPH";
            dataGridView1.Columns[6].Name = "NgheNghiepPH";

            _listSV = _sinhvienServices.GetAll(searchText, searchType);

            foreach (var sv in _listSV)
            {
                int stt = _listSV.IndexOf(sv) + 1;

                dataGridView1.Rows.Add(stt, sv.Sinhvien.Ten, sv.Sinhvien.Email, sv.Sinhvien.Sdt, sv.Sinhvien.Diachi, sv.TenPH, sv.NgheNghiepPH);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Them
            var confirmResult = MessageBox.Show("Xac nhan them sinh vien", "Xac nhan", MessageBoxButtons.OKCancel);

            if (confirmResult == DialogResult.OK)
            {
                var result = _sinhvienServices.Add(new Sinhvien()
                {
                    Ten = textBox1.Text,
                    Email = textBox2.Text,
                    Sdt = textBox3.Text,
                    Diachi = textBox4.Text
                });

                if (result)
                {
                    MessageBox.Show("Them thanh cong");

                    LoadGrid(null, null);
                }
                else
                {
                    MessageBox.Show("Them that bai");
                }
            }
            else
            {
                MessageBox.Show("Xac nhan KHONG them sinh vien");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sua
            var confirmResult = MessageBox.Show("Xac nhan sua sinh vien", "Xac nhan", MessageBoxButtons.OKCancel);

            if (confirmResult == DialogResult.OK)
            {
                var result = _sinhvienServices.Update(_idCellClick, new Sinhvien()
                {
                    Ten = textBox1.Text,
                    Email = textBox2.Text,
                    Sdt = textBox3.Text,
                    Diachi = textBox4.Text
                });

                if (result)
                {
                    MessageBox.Show("Sua thanh cong");

                    LoadGrid(null, null);
                }
                else
                {
                    MessageBox.Show("Sua that bai");
                }
            }
            else
            {
                MessageBox.Show("Xac nhan KHONG sua sinh vien");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Xoa
            var confirmResult = MessageBox.Show("Xac nhan xoa sinh vien", "Xac nhan", MessageBoxButtons.OKCancel);

            if (confirmResult == DialogResult.OK)
            {
                var result = _sinhvienServices.Remove(_idCellClick);

                if (result)
                {
                    MessageBox.Show("Xoa thanh cong");

                    LoadGrid(null, null);
                }
                else
                {
                    MessageBox.Show("Xoa that bai");
                }
            }
            else
            {
                MessageBox.Show("Xac nhan KHONG xoa sinh vien");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= _listSV.Count)
            {
                return;
            }

            var objCellClick = _listSV[index];

            _idCellClick = objCellClick.Sinhvien.Id;

            textBox1.Text = objCellClick.Sinhvien.Ten;
            textBox2.Text = objCellClick.Sinhvien.Email;
            textBox3.Text = objCellClick.Sinhvien.Sdt;
            textBox4.Text = objCellClick.Sinhvien.Diachi;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LoadGrid(textBox5.Text, comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid(textBox5.Text, comboBox1.Text);
        }
    }
}
