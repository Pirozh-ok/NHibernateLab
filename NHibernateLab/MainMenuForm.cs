using NHibernateLab.Services.Implementations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            Load += MyForm_Load;
        }

        private async void MyForm_Load(object sender, EventArgs e) {
            var service = new DegreeService();
            var result = await service.GetAll();

            var r = result.Select((x, i) => new { Номер = i + 1, Название = x.Name }).ToList();

            dgvStudents.DataSource = r;
        }

        //private void ContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            
        //}

        //private void ToolStripItem_Click(object sender, System.EventArgs e) {
        //    var point = dgvStudents.PointToClient(cmStudent.Bounds.Location);
        //    var info = dgvStudents.HitTest(point.X, point.Y);

        //    // Работаем с ячейкой
        //    var value = dgvStudents[info.ColumnIndex, info.RowIndex].Value;
        //}

        private void cmStudent_Opening(object sender, CancelEventArgs e) {
            //var point = dgvStudents.PointToClient(cmStudent.Bounds.Location);
            //var info = dgvStudents.HitTest(point.X, point.Y);

            //// Отменяем показ контекстного меню, если клик был не на ячейке
            //if (info.RowIndex == -1 || info.ColumnIndex == -1) {
            //    e.Cancel = true;
            //}
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e) {
            var point = dgvStudents.PointToClient(cmStudent.Bounds.Location);
            var info = dgvStudents.HitTest(point.X, point.Y);

            MessageBox.Show("Изменить");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) {
            var point = dgvStudents.PointToClient(cmStudent.Bounds.Location);
            var info = dgvStudents.HitTest(point.X, point.Y);

            MessageBox.Show("Удалить");
        }

        private void dgvStudents_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) { 
                return; 
            }

            DataGridView dgv = (DataGridView)sender;

            int rowIndex = dgv.HitTest(e.X, e.Y).RowIndex;

            if (rowIndex == -1) { 
                return; 
            }

            dgv.ClearSelection();

            dgv.Rows[rowIndex].Selected = true;

            cmStudent.Show(dgvStudents, new Point(e.Y, e.Y));
        }
    }
}
