using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class AddDictionaryEntityForm : Form {
        private Action _updateEvent;
        private EntityType _entityType;
        private IValidator<BaseDictionaryEntity> _validator;

        public AddDictionaryEntityForm(EntityType entityType, Action updateEvent) {
            InitializeComponent();

            _entityType = entityType;
            _updateEvent = updateEvent;

            switch (entityType) {
                case EntityType.Group: {
                        Name = MessagesConstants.ADD_GROUP_FORM_TITLE;
                        break;
                    }
                case EntityType.Faculty: {
                        Name = MessagesConstants.ADD_FACULTY_FORM_TITLE;
                        break;
                    }
                case EntityType.Rank: {
                        Name = MessagesConstants.ADD_RANK_FORM_TITLE;
                        break;
                    }
                case EntityType.Degree: {
                        Name = MessagesConstants.ADD_DEGREE_FORM_TITLE;
                        break;
                    }
                case EntityType.Department: {
                        Name = MessagesConstants.ADD_DEPARTMENT_FORM_TITLE;
                        break;
                    }
            }
        }

        private async void btnAddRecord_Click(object sender, System.EventArgs e) {
            _validator = new DictionaryEntityValidator();

            switch (_entityType) {
                case EntityType.Group:
                    try {
                        var group = new Group() {
                            Name = tbName.Text,
                        };

                        var validateResult = _validator.Validate(group);

                        if (!validateResult.IsValid) {
                            MessageBox.Show($"{MessagesConstants.GROUP_ADD_ERROR} {validateResult.Error}");
                            return;
                        }

                        var service = new GroupService();
                        await service.CreateAsync(group);

                        MessageBox.Show(MessagesConstants.GROUP_SUCCESS_ADDED);
                        _updateEvent.Invoke();
                        Close();
                        return;
                    }
                    catch {
                        MessageBox.Show(MessagesConstants.GROUP_ADD_ERROR);
                        _updateEvent.Invoke();
                        Close();
                        return;
                    }
                case EntityType.Faculty: {
                        try {
                            var faculty = new Faculty() {
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(faculty);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.FACULTY_ADD_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new FacultyService();
                            await service.CreateAsync(faculty);

                            MessageBox.Show(MessagesConstants.FACULTY_SUCCESS_ADDED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.FACULTY_ADD_ERROR);
                            return;
                        }
                    }
                case EntityType.Rank: {
                        try {
                            var rank = new Rank() {
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(rank);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.RANK_ADD_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new RankService();
                            await service.CreateAsync(rank);

                            MessageBox.Show(MessagesConstants.RANK_SUCCESS_ADDED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.RANK_ADD_ERROR);
                            return;
                        }
                    }
                case EntityType.Degree: {
                        try {
                            var degree = new Degree() {
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(degree);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.DEGREE_ADD_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new DegreeService();
                            await service.CreateAsync(degree);

                            MessageBox.Show(MessagesConstants.DEGREE_SUCCESS_ADDED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.DEGREE_ADD_ERROR);
                            return;
                        }
                    }
                case EntityType.Department: {
                        try {
                            var department = new Department() {
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(department);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.DEPARTMENT_ADD_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new DepartmentService();
                            await service.CreateAsync(department);

                            MessageBox.Show(MessagesConstants.DEPARTMENT_SUCCESS_ADDED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.DEPARTMENT_ADD_ERROR);
                            return;
                        }
                    }
            }
        }
    }
}
