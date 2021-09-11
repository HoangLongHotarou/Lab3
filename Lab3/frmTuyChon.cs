using Lab3.Class;
using Lab3.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class frmTuyChon : Form
    {
        private int i;
        public StudentManager sm;
        public List<Student> s;
        private TypeOfSortOrSearch type;

        public frmTuyChon(StudentManager sm, int i)
        {
            InitializeComponent();
            this.i = i;
            this.sm = sm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (label1.Text == null)
            {
                MessageBox.Show("Dien thieu", "Error");
            }
            else
            {
                s = sm.Search(type, txtSearch.Text);
                if (s.Count==0)
                {
                    MessageBox.Show("Ko tim thay", "infor");
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }


        private void frmTuyChon_Load(object sender, EventArgs e)
        {
            this.rbnID.Checked = true;
            label1.Text = rbnID.Text;
            if (i == 0)
            {
                groupBox2.Enabled = false;
                btnSort.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = true;
                btnSort.Enabled = false;
            }
        }

        private void rbnID_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (radioButton.Checked)
                {
                    label1.Text = rbnID.Text;
                    type = TypeOfSortOrSearch.MaSV;
                }
            }
        }

        private void rbnName_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (radioButton.Checked)
                {
                    label1.Text = rbnName.Text;
                    type = TypeOfSortOrSearch.HoTem;

                }
            }
        }

        private void rbnDate_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (radioButton.Checked)
                {
                    label1.Text = rbnDate.Text;
                    type = TypeOfSortOrSearch.NgaySinh;
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sm.Sort(type);
            DialogResult = DialogResult.OK;
        }
    }
}
