using NHibernateLab.NHibernate;
using NHibernateLab.Services.Implementations;
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

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e) {
            //TODO: add dictionary<TypeEntity, FuncUpdateEntity>
            var point = dgvStudents.PointToClient(cmTableAction.Bounds.Location);
            var info = dgvStudents.HitTest(point.X, point.Y);

            MessageBox.Show("Изменить");
        }

        private async void удалитьToolStripMenuItem_Click(object sender, EventArgs e) {
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

        private void добавитьНовогоСтудентаToolStripMenuItem_Click(object sender, EventArgs e) {
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
            }

            _activeDataGrid.DataSource = await updateGridMethods[_activeDataGridType]();
        }

        public async Task<List<object>> GetAllStudentForGrid() {
            var service = new StudentService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Номер_зачётной_книжки = x.CreditBookNumber,
                Група = x.Group.Name,
                Факультет = x.Faculty.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllTeacherForGrid() {
            var service = new StudentService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Номер_зачётной_книжки = x.CreditBookNumber,
                Група = x.Group.Name,
                Факультет = x.Faculty.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllTopicForGrid() {
            var service = new StudentService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Номер_зачётной_книжки = x.CreditBookNumber,
                Група = x.Group.Name,
                Факультет = x.Faculty.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllMarksForGrid() {
            var service = new StudentService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Фамилия = x.LastName,
                Имя = x.FirstName,
                Отчество = x.Patronymic,
                Номер_зачётной_книжки = x.CreditBookNumber,
                Група = x.Group.Name,
                Факультет = x.Faculty.Name
            }).ToList();
        }

        public async Task<List<object>> GetAllGroupsForGrid() {
            var service = new GroupService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllFacultyForGrid() {
            var service = new FacultyService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllDepartmentsForGrid() {
            var service = new DepartmentService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllRanksForGrid() {
            var service = new RankService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

        public async Task<List<object>> GetAllDegreesForGrid() {
            var service = new DegreeService();
            var result = await service.GetAllAsync();

            return result.Select((x, i) => (object)new {
                Номер = i + 1,
                Название = x.Name,
            }).ToList();
        }

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
    }
}
