using NHibernateLab.Entities;
using NHibernateLab.Services.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class UpdateMarkForm : Form {
        private IList<Student> _students;
        private event Action _updateEvent;
        private Mark _mark;

        public UpdateMarkForm(Mark mark, Action updateEvent) {
            InitializeComponent();
            Load += InitialComboboxesAsync;

            numExamMark.Value = mark.ExamMark;
            numDefendMark.Value = mark.DefendMark;

            _updateEvent = updateEvent;
            _mark = mark;
        }

        public async void InitialComboboxesAsync(object sender, EventArgs e) {
            var studentService = new StudentService();

            _students = await studentService.GetAllAsync();
            foreach (var student in _students) {
                cbStudent.Items.Add($"{student.CreditBookNumber} {student.LastName} {student.FirstName} {student.Patronymic}");
            }

            cbStudent.SelectedItem = $"{_mark.Student.CreditBookNumber} {_mark.Student.LastName} {_mark.Student.FirstName} {_mark.Student.Patronymic}";
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            try {
                var mark = new Mark() {
                    Id = _mark.Id,
                    ExamMark = (int)numExamMark.Value,
                    DefendMark = (int)numDefendMark.Value,
                    Student = _students.SingleOrDefault(x => x.CreditBookNumber.ToString() == cbStudent.Text.Split(' ')[0]),
                };

                var markService = new MarkService();
                await markService.UpdateAsync(mark);

                MessageBox.Show(MessagesConstants.MARK_SUCCESS_UPDATED);
                _updateEvent.Invoke();
                Close();
                return;

            }
            catch (Exception ex) {
                MessageBox.Show($"{MessagesConstants.MARK_UPDATE_ERROR}");
            }
        }
    }
}
