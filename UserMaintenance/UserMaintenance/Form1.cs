using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;
using System.IO;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFirstName.Text = Resource1.FirstName;
            lblLastName.Text = Resource1.LastName;
            btnAdd.Text = Resource1.Add;
            btnWrite.Text = Resource1.Write;
            btnDel.Text = Resource1.Delete;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User() 
            {
                FullName = string.Format("{0} {1}", txtLastName.Text, txtFirstName.Text)
            };
        users.Add(u);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var u in users)
                {
                    sw.Write(u.ID);
                    sw.WriteLine(u.FullName);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                users.RemoveAt(listUsers.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
            
            
        }
    }
}
