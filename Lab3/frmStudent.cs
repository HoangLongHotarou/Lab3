using Lab3.Class;
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
    public partial class frmStudent : Form
    {
        StudentManager sm;

        public frmStudent()
        {
            InitializeComponent();
        }

        private Student GetStudent()
        {
            Student st = new Student();
            bool sex = true;
            List<string> majors = new List<string>();
            st.ID = this.mtbID.Text;
            st.Name = this.txtName.Text;
            st.DateOfBirth = this.dtpDateOfBirth.Value.Date;
            st.Address = this.txtAddress.Text;
            st.Class = this.cbClass.Text;
            st.Picture = this.txtPath.Text;

            if (rbFermale.Checked)
            {
                sex = false;
            }

            st.Sex = sex;

            for (int i = 0; i < this.chklistMajor.Items.Count; i++)
            {
                if (chklistMajor.GetItemChecked(i))
                    majors.Add(chklistMajor.Items[i].ToString());
            }

            st.Major = majors;
            return st;
        }


        private Student GetStudentList(ListViewItem lvItem)
        {
            Student st = new Student();
            bool sex = true;
            List<string> majors = new List<string>();
            st.ID = lvItem.SubItems[0].Text;
            st.Name = lvItem.SubItems[1].Text;
            st.DateOfBirth = DateTime.Parse(lvItem.SubItems[2].Text);
            st.Address = lvItem.SubItems[3].Text;
            st.Class = lvItem.SubItems[4].Text;
            st.Picture = lvItem.SubItems[7].Text;
            st.Sex = false;
            if(lvItem.SubItems[5].Text=="Nam")
                st.Sex = true;
            List<string> mj = new List<string>();
            string[] s = lvItem.SubItems[6].Text.Split(',');

            foreach (string item in s)
            {
                mj.Add(item);
            }

            st.Major = mj;
            return st;
        }

        private void Establish(Student st)
        {
            this.mtbID.Text = st.ID;
            this.txtName.Text = st.Name;
            this.dtpDateOfBirth.Value = st.DateOfBirth;
            this.txtAddress.Text = st.Address;
            this.cbClass.Text = st.Class;
            this.txtPath.Text = st.Picture;
            try
            {
                pbxCharacter.Load(txtPath.Text);
            }
            catch (Exception)
            {
            }
            if (st.Sex)
                this.rbMale.Checked = true;
            else
                this.rbFermale.Checked = true;
            for (int i = 0; i < this.chklistMajor.Items.Count; i++)
            {
                this.chklistMajor.SetItemChecked(i, false);
            }

            foreach (string s in st.Major)
            {
                for (int i = 0; i < this.chklistMajor.Items.Count; i++)
                {
                    if (s.CompareTo(this.chklistMajor.Items[i]) == 0)
                        this.chklistMajor.SetItemChecked(i, true);
                }
            }
        }

        // add student to listview
        private void AddStudent(Student st)
        {
            ListViewItem lvItem = new ListViewItem(st.ID);
            lvItem.SubItems.Add(st.Name);
            lvItem.SubItems.Add(st.DateOfBirth.ToShortDateString());
            lvItem.SubItems.Add(st.Address);
            lvItem.SubItems.Add(st.Class);
            string sx = "Nữ";
            if (st.Sex)
            {
                sx = "Nam";
            }
            lvItem.SubItems.Add(sx);
            string mj = "";
            foreach (string s in st.Major)
            {
                mj += s + ",";
            }
            mj = mj.Substring(0, mj.Length - 1);
            lvItem.SubItems.Add(mj);
            lvItem.SubItems.Add(st.Picture);
            this.lvStudentList.Items.Add(lvItem);
        }

        // Show student list in listview
        private void LoadListView()
        {
            this.lvStudentList.Items.Clear();
            toolStripStatusLabel1.Text = "Tổng số sinh viên: ";
            foreach (var item in sm.ls)
            {
                AddStudent(item);
            }
            toolStripStatusLabel1.Text = $"Tổng số sinh viên: {sm.ls.Count}";
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            sm = new StudentManager();
            sm.ReadFile();
            LoadListView();
        }

        private void lvStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvStudentList.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvItem = this.lvStudentList.SelectedItems[0];
                Student st = GetStudentList(lvItem);
                Establish(st);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student st = GetStudent();
            Student asw = sm.Find(st.ID, delegate (object obj1, object obj2)
            {
                return (obj2 as Student).ID.CompareTo(obj1.ToString());
            });
            if (asw != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sm.ls.Add(st);
                LoadListView();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student st = GetStudent();
            bool a;
            a = sm.Update(st, st.ID, delegate (object obj1, object obj2)
            {
                return (obj2 as Student).ID.CompareTo(obj1.ToString());
            });
            LoadListView();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int count;
            ListViewItem lvItem;
            count = lvStudentList.Items.Count - 1;
            while (count >= 0)
            {
                lvItem = this.lvStudentList.Items[count];
                if (lvItem.Checked)
                {
                    sm.Delete(lvItem.SubItems[0].Text, delegate (object obj1, object obj2)
                    {
                        return (obj2 as Student).ID.CompareTo(obj1.ToString());
                    });
                }
                count--;
            }
            this.LoadListView();
            btnDefault.PerformClick();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.mtbID.Text = "";
            this.txtName.Text = "";
            this.dtpDateOfBirth.Value = DateTime.Now;
            this.txtAddress.Text = "";
            this.cbClass.Text = "";
            this.txtPath.Text = "";
            this.rbMale.Checked = true;
            for (int i = 0; i < this.chklistMajor.Items.Count; i++)
            {
                this.chklistMajor.SetItemChecked(i, false);
            }
            pbxCharacter.Image = null;
            LoadListView();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Picture";// "Add Photos";
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                          + "*.jpg;*.jpeg;*.gif;*.bmp;"
                          + "*.tif;*.tiff;*.png|"
                        + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                        + "GIF files (*.gif)|*.gif|"
                        + "BMP files (*.bmp)|*.bmp|"
                        + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
                        + "PNG files (*.png)|*.png|"
                        + "All files (*.*)|*.*";

            dlg.InitialDirectory = Environment.CurrentDirectory;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                txtPath.Text = fileName;
                pbxCharacter.Load(fileName);
            }
        }

        private void SortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon tc = new frmTuyChon(sm,0);
            tc.ShowDialog();
            if (tc.DialogResult == DialogResult.OK)
            {
                LoadListView();
            }
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon tc = new frmTuyChon(sm, 1);
            tc.ShowDialog();
            if(tc.DialogResult == DialogResult.OK)
            {
                this.lvStudentList.Items.Clear();
                toolStripStatusLabel1.Text = "Tổng số sinh viên: ";
                foreach (var item in tc.s)
                {
                    AddStudent(item);
                    Establish(item);
                }
                toolStripStatusLabel1.Text += $"{sm.ls.Count}";
            }

        }
    }
}
