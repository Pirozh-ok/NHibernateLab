using NHibernateLab.Entities;
using NHibernateLab.Helpers;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class AddTopicForm : Form {
        private IList<Student> _students;
        private IList<Teacher> _teachers;
        private event Action _updateEvent;
        private IValidator<Topic> _validator;

        public AddTopicForm(Action updateEvent) {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            Load += InitialComboboxesAsync;

            _updateEvent = updateEvent;
            _validator = new TopicValidator();
        }

        public async void InitialComboboxesAsync(object sender, EventArgs e) {
            var studentService = new StudentService();
            var teacherService = new TeacherService();

            _students = await studentService.GetAllAsync();
            foreach (var student in _students) {
                cbStudent.Items.Add($"{student.CreditBookNumber} {student.LastName} {student.FirstName} {student.Patronymic}");
            }

            _teachers = await teacherService.GetAllAsync();
            foreach (var teacher in _teachers) {
                cbTeacher.Items.Add($"{teacher.LastName} {teacher.FirstName} {teacher.Patronymic}");
            }

            cbStudent.SelectedIndex = 0;
            cbTeacher.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e) {
            try {
                var topic = new Topic() {
                    Name = tbTopicName.Text,
                    Student = _students.SingleOrDefault(x => x.CreditBookNumber.ToString() == cbStudent.Text.Split(' ')[0]),
                    Teacher = _teachers.SingleOrDefault(x => $"{x.LastName} {x.FirstName} {x.Patronymic}" == cbTeacher.Text)
                };

                var validateResult = _validator.Validate(topic);

                if (validateResult.IsValid) {
                    var topicService = new TopicService();
                    await topicService.CreateAsync(topic);

                    MessageBox.Show(MessagesConstants.TOPIC_SUCCESS_ADDED);
                    _updateEvent.Invoke();
                    Close();
                    return;
                }

                MessageBox.Show($"{MessagesConstants.TOPIC_ADD_ERROR}. {validateResult.Error}");
            }
            catch (Exception ex) {
                MessageBox.Show($"{MessagesConstants.TOPIC_ADD_ERROR}");
            }
        }
    }
}
