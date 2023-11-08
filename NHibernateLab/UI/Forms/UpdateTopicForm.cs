using NHibernateLab.Entities;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class UpdateTopicForm : Form {
        private IList<Student> _students;
        private IList<Teacher> _teachers;
        private event Action _updateEvent;
        private IValidator<Topic> _validator;
        private Topic _topic;

        public UpdateTopicForm(Topic topic, Action updateEvent) {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            _topic = topic;
            tbTopicName.Text = topic.Name;

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

            cbStudent.SelectedItem = $"{_topic.Student.CreditBookNumber} {_topic.Student.LastName} {_topic.Student.FirstName} {_topic.Student.Patronymic}";
            cbTeacher.SelectedItem = $"{_topic.Teacher.LastName} {_topic.Teacher.FirstName} {_topic.Teacher.Patronymic}";
        }

        private async void btnUpdate_Click(object sender, EventArgs e) {
            try {
                var topic = new Topic() {
                    Id = _topic.Id,
                    Name = tbTopicName.Text,
                    Student = _students.SingleOrDefault(x => x.CreditBookNumber.ToString() == cbStudent.Text.Split(' ')[0]),
                    Teacher = _teachers.SingleOrDefault(x => $"{x.LastName} {x.FirstName} {x.Patronymic}" == cbTeacher.Text)
                };

                var validateResult = _validator.Validate(topic);

                if (validateResult.IsValid) {
                    var topicService = new TopicService();
                    await topicService.UpdateAsync(topic);

                    MessageBox.Show(MessagesConstants.TOPIC_SUCCESS_UPDATED);
                    _updateEvent.Invoke();
                    Close();
                    return;
                }

                MessageBox.Show($"{MessagesConstants.TOPIC_UPDATE_ERROR}. {validateResult.Error}");
            }
            catch (Exception ex) {
                MessageBox.Show($"{MessagesConstants.TOPIC_UPDATE_ERROR}");
            }
        }
    }
}
