using NHibernateLab.Entities;
using NHibernateLab.Helpers;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class UpdateStudentForm : Form {
        private IList<Faculty> _faculties;
        private IList<Group> _groups;

        private event Action _updateEvent;
        private IValidator<Student> _validator;

        public UpdateStudentForm(Student student, IList<Faculty> faculties, IList<Group> groups, Action updateEvent) {
            InitializeComponent();
            _faculties = faculties;
            _groups = groups;
            _updateEvent = updateEvent;
            _validator = new StudentValidator();

            tbFirstName.Text = student.FirstName;
            tbLastName.Text = student.LastName;
            tbPatronymic.Text = student.Patronymic;

            foreach (var faculty in _faculties) {
                cbFaculty.Items.Add(faculty.Name);
            }

            foreach (var group in _groups) {
                cbGroup.Items.Add(group.Name);
            }

            cbFaculty.SelectedItem = student.Faculty.Name;
            cbGroup.SelectedItem = student.Group.Name;
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            try {
                var student = new Student() {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Patronymic = tbPatronymic.Text,
                    Faculty = _faculties.SingleOrDefault(x => x.Name == cbFaculty.Text),
                    Group = _groups.SingleOrDefault(x => x.Name == cbGroup.Text)
                };

                var validateResult = _validator.Validate(student);

                if (validateResult.IsValid) {
                    var studentService = new StudentService();
                    await studentService.UpdateAsync(student);

                    _updateEvent.Invoke();
                    MessageBox.Show(MessagesConstants.STUDENT_SUCCESS_UPDATED);
                    Close();
                    return;
                }

                MessageBox.Show($"{MessagesConstants.STUDENT_UPDATE_ERROR}. {validateResult.Error}");
            }
            catch (Exception ex) {
                MessageBox.Show($"{MessagesConstants.STUDENT_UPDATE_ERROR}");
            }
        }
    }
}
