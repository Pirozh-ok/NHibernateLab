using NHibernateLab.Entities;
using NHibernateLab.Helpers;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class AddStudentForm : Form, ICreateUpdateForm {
        private IList<Faculty> _faculties;
        private IList<Group> _groups;
        private event Action _updateEvent;
        private IValidator<Student> _validator;

        public AddStudentForm(Action updateEvent) {
            InitializeComponent();
            Load += InitialComboboxesAsync;

            _updateEvent = updateEvent;
            _validator = new StudentValidator();
        }

        public async void InitialComboboxesAsync(object sender, EventArgs e) {
            var facultyService = new FacultyService();
            var groupService = new GroupService();

            _faculties = await facultyService.GetAllAsync();
            foreach( var faculty in _faculties) {
                cbFaculty.Items.Add(faculty.Name);
            }

            _groups = await groupService.GetAllAsync();
            foreach (var group in _groups) {
                cbGroup.Items.Add(group.Name);
            }

            cbFaculty.SelectedIndex = 0;
            cbGroup.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e) {
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
                    await studentService.CreateAsync(student);

                    MessageBox.Show(MessagesConstants.STUDENT_SUCCESS_ADDED);
                    _updateEvent.Invoke();
                    Close();
                    return;
                }

                MessageBox.Show($"{MessagesConstants.STUDENT_ADD_ERROR}. {validateResult.Error}");
            }
            catch(Exception ex) {
                MessageBox.Show($"{MessagesConstants.STUDENT_ADD_ERROR}");
            }
        }
    }
}
