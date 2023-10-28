using NHibernateLab.Entities;
using NHibernateLab.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class AddStudentForm : Form {
        private IList<Faculty> _faculties;
        private IList<Group> _groups;
        private event Action _updateEvent;

        public AddStudentForm(Action updateEvent) {
            InitializeComponent();
            Load += InitialComboboxesAsync;

            _updateEvent = updateEvent;
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
            //ValidateStudentData();
            try {
                var studentService = new StudentService();
                var student = new Student() {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Patronymic = tbPatronymic.Text,
                    Faculty = _faculties.SingleOrDefault(x => x.Name == cbFaculty.Text),
                    Group = _groups.SingleOrDefault(x => x.Name == cbGroup.Text)
                };

                await studentService.CreateAsync(student);

                MessageBox.Show(MessagesConstants.StudentSucessAdded);
                _updateEvent.Invoke();
                Close();
            }
            catch(Exception ex) {

            }
        }
    }
}
