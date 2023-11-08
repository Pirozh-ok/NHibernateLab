using NHibernateLab.Entities;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class AddTeacherForm : Form {
        private IList<Department> _departments;
        private IList<Degree> _degrees;
        private IList<Rank> _ranks;
        private event Action _updateEvent;
        private IValidator<Teacher> _validator;

        public AddTeacherForm(Action updateEvent) {
            InitializeComponent();

            Load += InitialComboboxesAsync;

            _updateEvent = updateEvent;
            _validator = new TeacherValidator();
        }

        public async void InitialComboboxesAsync(object sender, EventArgs e) {
            var departmentService = new DepartmentService();
            var rankService = new RankService();
            var degreeService = new DegreeService();

            _departments = await departmentService.GetAllAsync();
            foreach (var dep in _departments) {
                cbDepartment.Items.Add(dep.Name);
            }

            _degrees = await degreeService.GetAllAsync();
            foreach (var degree in _degrees) {
                cbDegree.Items.Add(degree.Name);
            }

            _ranks = await rankService.GetAllAsync();
            foreach (var rank in _ranks) {
                cbRank.Items.Add(rank.Name);
            }

            cbDepartment.SelectedIndex = 0;
            cbRank.SelectedIndex = 0;
            cbDegree.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e) {
            try {
                var teacher = new Teacher() {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Patronymic = tbPatronymic.Text,
                    Email = tbEmail.Text,
                    Phone = tbPhone.Text,
                    Department = _departments.SingleOrDefault(x => x.Name == cbDepartment.Text),
                    Degree = _degrees.SingleOrDefault(x => x.Name == cbDegree.Text),
                    Rank = _ranks.SingleOrDefault(x => x.Name == cbRank.Text)
                };

                var validateResult = _validator.Validate(teacher);

                if (validateResult.IsValid) {
                    var teacherService = new TeacherService();
                    await teacherService.CreateAsync(teacher);

                    MessageBox.Show(MessagesConstants.TEACHER_SUCCESS_ADDED);
                    _updateEvent.Invoke();
                    Close();
                    return;
                }

                MessageBox.Show($"{MessagesConstants.TEACHER_ADD_ERROR} {validateResult.Error}");
            }
            catch (Exception ex) {
                MessageBox.Show($"{MessagesConstants.TEACHER_ADD_ERROR}");
            }
        }
    }
}
