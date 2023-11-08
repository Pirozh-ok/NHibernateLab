using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using NHibernateLab.Services.Implementations;
using NHibernateLab.UI;
using NHibernateLab.UI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHibernateLab {
    public partial class MainForm : Form {
        private event Action _updateForm;
        private DataGridView _activeDataGrid;
        private EntityType _activeDataGridType;
        private Dictionary<EntityType, Func<Task<List<object>>>> updateGridMethods;
        private Dictionary<EntityType, Action> createEntityMethods;
        private Dictionary<EntityType, Func<int, Task>> updateEntityMethods;
        private Dictionary<EntityType, Func<int, Task>> deleteEntityMethods;
        private Dictionary<EntityType, Func<string, Task>> searchEntityMethods;

        private IList<Student> _students;
        private IList<Teacher> _teachers;
        private IList<Topic> _topics;
        private IList<Mark> _marks;
        private IList<Group> _groups;
        private IList<Faculty> _faculties;
        private IList<Department> _departments;
        private IList<Degree> _degrees;
        private IList<Rank> _ranks;

        public MainForm() {
            InitializeComponent();

            updateGridMethods = new Dictionary<EntityType, Func<Task<List<object>>>> {
                { EntityType.Student, GetAllStudentForGrid },
                { EntityType.Teacher, GetAllTeacherForGrid },
                { EntityType.Topic, GetAllTopicForGrid },
                { EntityType.Mark, GetAllMarksForGrid },
                { EntityType.Degree, GetAllDegreesForGrid},
                { EntityType.Rank, GetAllRanksForGrid},
                { EntityType.Department, GetAllDepartmentsForGrid},
                { EntityType.Faculty, GetAllFacultyForGrid},
                { EntityType.Group, GetAllGroupsForGrid}
            };

            createEntityMethods = new Dictionary<EntityType, Action> {
                { EntityType.Student, CreateStudent },
                { EntityType.Teacher, CreateTeacher },
                { EntityType.Topic, CreateTopic },
                { EntityType.Mark, CreateMark },
                { EntityType.Degree, CreateDegree},
                { EntityType.Rank, CreateRank},
                { EntityType.Department, CreateDepartment},
                { EntityType.Faculty, CreateFaculty},
                { EntityType.Group, CreateGroup}
            };

            deleteEntityMethods = new Dictionary<EntityType, Func<int, Task>> {
                { EntityType.Student, DeleteStudent },
                { EntityType.Teacher, DeleteTeacher },
                { EntityType.Topic, DeleteTopic },
                { EntityType.Mark, DeleteMark },
                { EntityType.Degree, DeleteDegree},
                { EntityType.Rank, DeleteRank},
                { EntityType.Department, DeleteDepartment},
                { EntityType.Faculty, DeleteFaculty},
                { EntityType.Group, DeleteGroup}
            };

            updateEntityMethods = new Dictionary<EntityType, Func<int, Task>> {
                { EntityType.Student, UpdateStudent },
                { EntityType.Teacher, UpdateTeacher },
                { EntityType.Topic, UpdateTopic },
                { EntityType.Mark, UpdateMark },
                { EntityType.Degree, UpdateDegree},
                { EntityType.Rank, UpdateRank},
                { EntityType.Department, UpdateDepartment},
                { EntityType.Faculty, UpdateFaculty},
                { EntityType.Group, UpdateGroup}
            };

            searchEntityMethods = new Dictionary<EntityType, Func<string, Task>> {
                { EntityType.Student, SearchStudent },
                { EntityType.Teacher, SearchTeacher },
                { EntityType.Topic, SearchTopic },
                { EntityType.Mark, SearchMark },
                { EntityType.Degree, SearchDegree},
                { EntityType.Rank, SearchRank},
                { EntityType.Department, SearchDepartment},
                { EntityType.Faculty, SearchFaculty},
                { EntityType.Group, SearchGroup}
            };

            Load += Form_Load;
        }

        private async void Form_Load(object sender, EventArgs e) {
            dgvStudents.DataSource = await GetAllStudentForGrid();
            _activeDataGrid = dgvStudents;
            _activeDataGridType = EntityType.Student;

            _updateForm += UpdateForm;
        }

        private async void updateRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            var clickedPoint = _activeDataGrid.PointToClient(cmTableAction.Bounds.Location);
            var rowIndex = _activeDataGrid.HitTest(clickedPoint.X, clickedPoint.Y).RowIndex;

            updateEntityMethods[_activeDataGridType](rowIndex);
        }

        private async void removeRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            var clickedPoint = _activeDataGrid.PointToClient(cmTableAction.Bounds.Location);
            var rowIndex = _activeDataGrid.HitTest(clickedPoint.X, clickedPoint.Y).RowIndex;

            await deleteEntityMethods[_activeDataGridType](rowIndex);
        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            createEntityMethods[_activeDataGridType]();
        }

        private async void UpdateForm() {
            switch (_activeDataGridType) {
                case EntityType.Teacher:
                    _activeDataGrid = dgvTeachers;
                    break;
                case EntityType.Mark:
                    _activeDataGrid = dgvMarks;
                    break;
                case EntityType.Topic:
                    _activeDataGrid = dgvTopics;
                    break;
                case EntityType.Group:
                    _activeDataGrid = dgvGroups;
                    break;
                case EntityType.Faculty:
                    _activeDataGrid = dgvFaculties;
                    break;
                case EntityType.Department:
                    _activeDataGrid = dgvDepartments;
                    break;
                case EntityType.Degree:
                    _activeDataGrid = dgvDegrees;
                    break;
                case EntityType.Rank:
                    _activeDataGrid = dgvRanks;
                    break;
                default: {
                        _activeDataGrid = dgvStudents;
                        break;
                    }
            }

            _activeDataGrid.DataSource = await updateGridMethods[_activeDataGridType]();
        }

        #region Get entity methods

        public async Task<List<object>> GetAllStudentForGrid() {
            _students = await GetStudentsAsync();

            return _students.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Номер_зачётной_книжки = x.CreditBookNumber,
                Группа = x.Group.Name,
                Факультет = x.Faculty.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllTeacherForGrid() {
            _teachers = await GetTeachersAsync();

            return _teachers.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Почта = x.Email,
                Телефон = x.Phone,
                Кафедра = x.Department.Name,
                Степень = x.Degree.Name,
                Звание = x.Rank.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllTopicForGrid() {
            var service = new TopicService();
            _topics = await service.GetAllAsync();

            return _topics.Select((x, i) => (object)new {
                Номер = i + 1,
                Название_темы = x.Name,
                Номер_зачётной_книжки_студента = x.Student.CreditBookNumber,
                ФИО_студента = $"{x.Student.LastName} {x.Student.FirstName} {x.Student.Patronymic}",
                ФИО_преподавателя = $"{x.Teacher.LastName} {x.Teacher.FirstName} {x.Teacher.Patronymic}"           
            }).ToList();
        }

        public async Task<List<object>> GetAllMarksForGrid() {
            var service = new MarkService();
            _marks = await service.GetAllAsync();

            return _marks.Select((x, i) => (object)new {
                Номер = i + 1,
                Оценка_за_экзамен = x.ExamMark,
                Оценка_за_защиту = x.DefendMark,
                Номер_зачётной_книжки_студента = x.Student.CreditBookNumber,
                ФИО_студента = $"{x.Student.LastName} {x.Student.FirstName} {x.Student.Patronymic}"
            }).ToList();
        }

        public async Task<List<object>> GetAllGroupsForGrid() {
            _groups = await GetGroupsAsync();

            return _groups.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllFacultyForGrid() {
            _faculties = await GetFacultiesAsync();

            return _faculties.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllDepartmentsForGrid() {
            _departments = await GetDepartmentsAsync();

            return _departments.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllRanksForGrid() {
            _ranks = await GetRanksAsync();

            return _ranks.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllDegreesForGrid() {
            _degrees = await GetDegreesAsync();

            return _degrees.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<IList<Student>> GetStudentsAsync() {
            var service = new StudentService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Teacher>> GetTeachersAsync() {
            var service = new TeacherService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Mark>> GetMarksAsync() {
            var service = new MarkService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Topic>> GetTopicsAsync() {
            var service = new TopicService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Faculty>> GetFacultiesAsync() {
            var service = new FacultyService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Group>> GetGroupsAsync() {
            var service = new GroupService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Department>> GetDepartmentsAsync() {
            var service = new DepartmentService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Degree>> GetDegreesAsync() {
            var service = new DegreeService();
            return await service.GetAllAsync();
        }

        public async Task<IList<Rank>> GetRanksAsync() {
            var service = new RankService();
            return await service.GetAllAsync();
        }

        #endregion

        #region Create entity methods

        private void CreateStudent() {
            var createNewStudentForm = new AddStudentForm(_updateForm);
            createNewStudentForm.ShowDialog();
        }

        private void CreateTeacher() {
            var createNewTeacherForm = new AddTeacherForm(_updateForm);
            createNewTeacherForm.ShowDialog();
        }

        private void CreateTopic() {
            var createNewTopicForm = new AddTopicForm(_updateForm);
            createNewTopicForm.ShowDialog();
        }

        private void CreateMark() {
            var createNewMarkForm = new AddMarkForm(_updateForm);
            createNewMarkForm.ShowDialog();
        }

        private void CreateFaculty() {
            var form = new AddDictionaryEntityForm(EntityType.Faculty, _updateForm);
            form.ShowDialog();
        }

        private void CreateGroup() {
            var form = new AddDictionaryEntityForm(EntityType.Group, _updateForm);
            form.ShowDialog();
        }

        private void CreateDepartment() {
            var form = new AddDictionaryEntityForm(EntityType.Department, _updateForm);
            form.ShowDialog();
        }

        private void CreateDegree() {
            var form = new AddDictionaryEntityForm(EntityType.Degree, _updateForm);
            form.ShowDialog();
        }

        private void CreateRank() {
            var form = new AddDictionaryEntityForm(EntityType.Rank, _updateForm);
            form.ShowDialog();
        }

        #endregion

        #region Delete entity methods

        private async Task DeleteStudent(int deleteRowIndex) {
            try {
                var studentService = new StudentService();
                await studentService.DeleteAsync(_students[deleteRowIndex].CreditBookNumber);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteTeacher(int deleteRowIndex) {
            try {
                var teacherService = new TeacherService();
                await teacherService.DeleteAsync(_teachers[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteTopic(int deleteRowIndex) {
            try {
                var topicService = new TopicService();
                await topicService.DeleteAsync(_topics[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteMark(int deleteRowIndex) {
            try {
                var markService = new MarkService();
                await markService.DeleteAsync(_marks[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteGroup(int deleteRowIndex) {
            try {
                var groupService = new GroupService();
                await groupService.DeleteAsync(_groups[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteFaculty(int deleteRowIndex) {
            try {
                var facultyService = new FacultyService();
                await facultyService.DeleteAsync(_faculties[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteDepartment(int deleteRowIndex) {
            try {
                var departmentService = new DepartmentService();
                await departmentService.DeleteAsync(_departments[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteDegree(int deleteRowIndex) {
            try {
                var degreeService = new DegreeService();
                await degreeService.DeleteAsync(_degrees[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        private async Task DeleteRank(int deleteRowIndex) {
            try {
                var rankService = new RankService();
                await rankService.DeleteAsync(_ranks[deleteRowIndex].Id);
                _updateForm?.Invoke();
                MessageBox.Show(MessagesConstants.DELETE_SUCCESS);
            }
            catch {
                MessageBox.Show(MessagesConstants.DELETE_ERROR);
            }
        }

        #endregion

        #region Update entity methods

        private async Task UpdateStudent(int rowForUpdateIndex) {
            _faculties = _faculties ?? await GetFacultiesAsync();
            _groups = _groups ?? await GetGroupsAsync();

            var updateStudentForm = new UpdateStudentForm(_students[rowForUpdateIndex], _faculties, _groups, _updateForm);
            updateStudentForm.ShowDialog();
        }

        private async Task UpdateTeacher(int rowForUpdateIndex) {
            var updateTeacherForm = new UpdateTeacherForm(_teachers[rowForUpdateIndex], _updateForm);
            updateTeacherForm.ShowDialog();
        }

        private async Task UpdateTopic(int rowForUpdateIndex) {
            var updateNewTopicForm = new UpdateTopicForm(_topics[rowForUpdateIndex],_updateForm);
            updateNewTopicForm.ShowDialog();
        }

        private async Task UpdateMark(int rowForUpdateIndex) {
            var updateNewMarkForm = new UpdateMarkForm(_marks[rowForUpdateIndex], _updateForm);
            updateNewMarkForm.ShowDialog();
        }

        private async Task UpdateFaculty(int rowForUpdateIndex) {
            var form = new UpdateDictionaryEntityForm(_faculties[rowForUpdateIndex].Id, _faculties[rowForUpdateIndex].Name, EntityType.Faculty, _updateForm);
            form.ShowDialog();
        }

        private async Task UpdateGroup(int rowForUpdateIndex) {
            var form = new UpdateDictionaryEntityForm(_groups[rowForUpdateIndex].Id, _groups[rowForUpdateIndex].Name, EntityType.Group, _updateForm);
            form.ShowDialog();
        }

        private async Task UpdateDepartment(int rowForUpdateIndex) {
            var form = new UpdateDictionaryEntityForm(_departments[rowForUpdateIndex].Id, _departments[rowForUpdateIndex].Name, EntityType.Department, _updateForm);
            form.ShowDialog();
        }

        private async Task UpdateDegree(int rowForUpdateIndex) {
            var form = new UpdateDictionaryEntityForm(_degrees[rowForUpdateIndex].Id, _degrees[rowForUpdateIndex].Name, EntityType.Degree, _updateForm);
            form.ShowDialog();
        }

        private async Task UpdateRank(int rowForUpdateIndex) {
            var form = new UpdateDictionaryEntityForm(_ranks[rowForUpdateIndex].Id, _ranks[rowForUpdateIndex].Name, EntityType.Rank, _updateForm);
            form.Name = MessagesConstants.UPDATE_DEPARTMENT_FORM_TITLE;
            form.ShowDialog();
        }

        #endregion

        #region TabViewer tab changed events

        private void studentsPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Student;
            _updateForm?.Invoke();
        }

        private void teachersPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Teacher;
            _updateForm?.Invoke();
        }

        private void topicsPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Topic;
            _updateForm?.Invoke();
        }


        private void groupPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Group;
            _updateForm?.Invoke();
        }

        private void facultyPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Faculty;
            _updateForm?.Invoke();
        }

        private void departmentPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Department;
            _updateForm?.Invoke();
        }

        private void degreePage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Degree;
            _updateForm?.Invoke();
        }

        private void rankPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Rank;
            _updateForm?.Invoke();
        }

        private void marksPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = EntityType.Mark;
            _updateForm?.Invoke();
        }

        #endregion

        #region Search methods

        private async void btnSearch_Click(object sender, EventArgs e) {
            var filter = txtFilter.Text;

            await searchEntityMethods[_activeDataGridType](filter);
        }

        private async Task SearchStudent(string filter) {
            var studentService = new StudentService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllStudentForGrid();
            }

            var result = await studentService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Номер_зачётной_книжки = x.CreditBookNumber,
                Группа = x.Group.Name,
                Факультет = x.Faculty.Name
            }).ToList();
        }

        private async Task SearchTeacher(string filter) {
            var teacherService = new TeacherService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllTeacherForGrid();
            }

            var result = await teacherService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Почта = x.Email,
                Телефон = x.Phone,
                Кафедра = x.Department.Name,
                Степень = x.Degree.Name,
                Звание = x.Rank.Name
            }).ToList();
        }

        private async Task SearchTopic(string filter) {
            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllTopicForGrid();
            }

            var topicService = new TopicService();
            var result = await topicService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название_темы = x.Name,
                Номер_зачётной_книжки_студента = x.Student.CreditBookNumber,
                ФИО_студента = $"{x.Student.LastName} {x.Student.FirstName} {x.Student.Patronymic}",
                ФИО_преподавателя = $"{x.Teacher.LastName} {x.Teacher.FirstName} {x.Teacher.Patronymic}"
            }).ToList();
        }

        private async Task SearchMark(string filter) {
            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllMarksForGrid();
            }

            var marksService = new MarkService();
            var result = await marksService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Оценка_за_экзамен = x.ExamMark,
                Оценка_за_защиту = x.DefendMark,
                Номер_зачётной_книжки_студента = x.Student.CreditBookNumber,
                ФИО_студента = $"{x.Student.LastName} {x.Student.FirstName} {x.Student.Patronymic}"
            }).ToList();
        }

        private async Task SearchGroup(string filter) {
            var groupService = new GroupService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllGroupsForGrid();
            }

            var result = await groupService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        private async Task SearchFaculty(string filter) {
            var facultyService = new FacultyService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllFacultyForGrid();
            }

            var result = await facultyService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        private async Task SearchDepartment(string filter) {
            var departmentService = new DepartmentService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllDepartmentsForGrid();
            }

            var result = await departmentService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        private async Task SearchRank(string filter) {
            var rankService = new RankService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllRanksForGrid();
            }

            var result = await rankService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        private async Task SearchDegree(string filter) {
            var degreeService = new DegreeService();

            if (string.IsNullOrEmpty(filter)) {
                _activeDataGrid.DataSource = GetAllDegreesForGrid();
            }

            var result = await degreeService.SearchAsync(filter);
            _activeDataGrid.DataSource = result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        #endregion

        #region Handlers for grid click event

        private void dgvStudents_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvTeachers_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvTopics_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvMarks_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvGroups_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvFaculties_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvDepartments_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvDegrees_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void dgvRanks_MouseDown(object sender, MouseEventArgs e) {
            ShowContextMenuStrip(sender, e);
        }

        private void ShowContextMenuStrip(object sender, MouseEventArgs e) {
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

            cmTableAction.Show(dgvStudents, new Point(e.Y, e.Y));
        }

        #endregion
    }
}