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
        private string _activeDataGridType;
        private Dictionary<string, Func<Task<List<object>>>> updateGridMethods;

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

            updateGridMethods = new Dictionary<string, Func<Task<List<object>>>> {
                { Constants.StudentType, GetAllStudentForGrid },
                { Constants.TeacherType, GetAllTeacherForGrid },
                { Constants.TopicType, GetAllTopicForGrid },
                { Constants.MarkType, GetAllMarksForGrid },
                { Constants.DegreeType, GetAllDegreesForGrid},
                { Constants.RankType, GetAllRanksForGrid},
                { Constants.DepartmentType, GetAllDepartmentsForGrid},
                { Constants.FacultyType, GetAllFacultyForGrid},
                { Constants.GroupType, GetAllGroupsForGrid}
            };

            Load += Form_Load;
        }

        private async void Form_Load(object sender, EventArgs e) {
            dgvStudents.DataSource = await GetAllStudentForGrid();
            _activeDataGrid = dgvStudents;
            _activeDataGridType = Constants.StudentType;

            _updateForm += UpdateForm;
        }

        private async void updateRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            //TODO: add dictionary<TypeEntity, FuncUpdateEntity>
            var point = dgvStudents.PointToClient(cmTableAction.Bounds.Location);
            var info = dgvStudents.HitTest(point.X, point.Y);

            _faculties = _faculties ?? await GetFacultiesAsync();
            _groups = _groups ?? await GetGroupsAsync();

            var updateStudentForm = new UpdateStudentForm(_students[info.RowIndex], _faculties, _groups, _updateForm);
            updateStudentForm.ShowDialog();
        }

        private async void removeRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            //TODO: add dictionary<TypeEntity, FuncDeleteEntity>
            var point = dgvStudents.PointToClient(cmTableAction.Bounds.Location);
            var info = dgvStudents.HitTest(point.X, point.Y).RowIndex;

            if (int.TryParse(dgvStudents.Rows[info].Cells[4].Value.ToString(), out int deleteStudentId)) {
                var studentService = new StudentService();
                await studentService.DeleteAsync(deleteStudentId);
                MessageBox.Show("Удаление студента прошло успешно!");
                _updateForm?.Invoke();
            }
            else {
                MessageBox.Show("В процессе удаления произошла ошибка");
            }
        }

        private void dgvStudents_MouseDown(object sender, MouseEventArgs e) {
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

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            //TODO: add dictionary<TypeEntity, FuncCreateEntity>
            var createNewStudentForm = new AddStudentForm(_updateForm);
            createNewStudentForm.ShowDialog();
        }

        private async void UpdateForm() {
            switch (_activeDataGridType) {
                case Constants.TeacherType:
                    _activeDataGrid = dgvTeachers;
                    break;
                case Constants.MarkType:
                    _activeDataGrid = dgvMarks;
                    break;
                case Constants.TopicType:
                    _activeDataGrid = dgvTopics;
                    break;
                case Constants.GroupType:
                    _activeDataGrid = dgvGroups;
                    break;
                case Constants.FacultyType:
                    _activeDataGrid = dgvFaculties;
                    break;
                case Constants.DepartmentType:
                    _activeDataGrid = dgvDepartments;
                    break;
                case Constants.DegreeType:
                    _activeDataGrid = dgvDegrees;
                    break;
                case Constants.RankType:
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
                Кафедра = x.Department.Name,
                Степень = x.Degree.Name,
                Звание = x.Rank.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllTopicForGrid() {
            //var service = new TopicService();
            //_topics = await service.GetAllAsync();

            //return _topics.Select((x, i) => (object)new {
            //    Номер = i + 1,
            //    Фамилия = x.LastName,
            //    Имя = x.FirstName,
            //    Отчество = x.Patronymic,
            //    Номер_зачётной_книжки = x.CreditBookNumber,
            //    Група = x.Group.Name,
            //    Факультет = x.Faculty.Name
            //}).ToList();
            return null;
        }

        public async Task<List<object>> GetAllMarksForGrid() {
            //var service = new MarkService();
            //_marks = await service.GetAllAsync();

            //return _marks.Select((x, i) => (object)new {
            //    Номер = i + 1,
            //    Фамилия = x.LastName,
            //    Имя = x.FirstName,
            //    Отчество = x.Patronymic,
            //    Номер_зачётной_книжки = x.CreditBookNumber,
            //    Група = x.Group.Name,
            //    Факультет = x.Faculty.Name
            //}).ToList();
            return null;
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

        //public async Task<IList<Mark>> GetMarksAsync() {
        //    var service = new MarkService();
        //    return await service.GetAllAsync();
        //}

        //public async Task<IList<Topic>> GetTopicsAsync() {
        //    var service = new TopicService();
        //    return await service.GetAllAsync();
        //}

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

        #region Delete entity methods

        #endregion

        #region Create entity methods

        #endregion

        #region Update entity methods

        public async Task UpdateStudent() {

        }

        #endregion

        #region TabViewer tab changed events

        private void studentsPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.StudentType;
            _updateForm?.Invoke();
        }

        private void teachersPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.TeacherType;
            _updateForm?.Invoke();
        }

        private void topicsPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.TopicType;
            _updateForm?.Invoke();
        }


        private void groupPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.GroupType;
            _updateForm?.Invoke();
        }

        private void facultyPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.FacultyType;
            _updateForm?.Invoke();
        }

        private void departmentPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.DepartmentType;
            _updateForm?.Invoke();
        }

        private void degreePage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.DegreeType;
            _updateForm?.Invoke();
        }

        private void rankPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.RankType;
            _updateForm?.Invoke();
        }

        private void marksPage_Enter(object sender, EventArgs e) {
            _activeDataGridType = Constants.MarkType;
            _updateForm?.Invoke();
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e) {
            var filter = txtFilter.Text;

            if (string.IsNullOrEmpty(filter)) {
                MessageBox.Show("Фильтр пустой");
            }
        }
    }
}