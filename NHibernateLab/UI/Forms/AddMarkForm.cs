using NHibernateLab.Entities;
using NHibernateLab.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class AddMarkForm : Form {
        private IList<Student> _students;
        private event Action _updateEvent;

        public AddMarkForm(Action updateEvent) {
            InitializeComponent();

            Load += InitialComboboxesAsync;

            _updateEvent = updateEvent;
        }

        public async void InitialComboboxesAsync(object sender, EventArgs e) {
            var studentService = new StudentService();

            _students = await studentService.GetAllAsync();
            foreach (var student in _students) {
                cbStudent.Items.Add($"{student.CreditBookNumber} {student.LastName} {student.FirstName} {student.Patronymic}");
            }

            cbStudent.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e) {
            try {
                var mark = new Mark() {
                    ExamMark = (int)numExamMark.Value,
                    DefendMark = (int)numDefendMark.Value,
                    Student = _students.SingleOrDefault(x => x.CreditBookNumber.ToString() == cbStudent.Text.Split(' ')[0]),
                };

                var markService = new MarkService();
                await markService.CreateAsync(mark);

                MessageBox.Show(MessagesConstants.MARK_SUCCESS_ADDED);
                _updateEvent.Invoke();
                Close();
                return;

            }
            catch (Exception ex) {
                MessageBox.Show($"{MessagesConstants.MARK_ADD_ERROR}");
            }
        }
    }
}
