using NHibernateLab.Entities;
using NHibernateLab.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class UpdateStudentForm : Form {
        public Student Student { get; private set; }
        public IList<Faculty> Faculties { get; private set; }
        public IList<Group> Groups { get; private set; }
        public StudentService StudentService { get; private set; }
        private event Action _updateEvent;

        public UpdateStudentForm(Student student, IList<Faculty> faculties, IList<Group> groups, Action updateEvent) {
            InitializeComponent();
            Student = student;
            Faculties = faculties;
            Groups = groups;
            _updateEvent = updateEvent;
            StudentService = new StudentService();

            tbFirstName.Text = student.FirstName;
            tbLastName.Text = student.LastName;
            tbPatronymic.Text = student.Patronymic;

            foreach (var faculty in Faculties) {
                cbFaculty.Items.Add(faculty.Name);
            }

            foreach (var group in Groups) {
                cbGroup.Items.Add(group.Name);
            }

            cbFaculty.SelectedItem = Student.Faculty.Name;
            cbGroup.SelectedItem = Student.Group.Name;
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            Student.FirstName = tbFirstName.Text;
            Student.LastName = tbLastName.Text;
            Student.Patronymic = tbPatronymic.Text;
            Student.Group = Groups.SingleOrDefault(x => x.Name == cbGroup.Text);
            Student.Faculty = Faculties.SingleOrDefault(x => x.Name == cbFaculty.Text);

            await StudentService.UpdateAsync(Student);
            _updateEvent.Invoke();

            MessageBox.Show(MessagesConstants.STUDENT_SUCCESS_UPDATED);
            Close();
        }
    }
}
