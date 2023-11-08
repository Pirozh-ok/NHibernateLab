using NHibernateLab.Entities;
using NHibernateLab.NHibernate;
using NHibernateLab.Services.Implementations;
using NHibernateLab.Validators;
using System;
using System.Windows.Forms;

namespace NHibernateLab.UI.Forms {
    public partial class UpdateDictionaryEntityForm : Form {
        private Action _updateEvent;
        private EntityType _entityType;
        private IValidator<BaseDictionaryEntity> _validator;
        private int updatedEntityId;

        public UpdateDictionaryEntityForm(int entityId, string name, EntityType entityType, Action updateEvent) {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            _entityType = entityType;
            _updateEvent = updateEvent;
            updatedEntityId = entityId;

            tbName.Text = name;

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
                        Name = MessagesConstants.UPDATE_DEPARTMENT_FORM_TITLE;
                        break;
                    }
            }
        }

        private async void btnUpdateRecord_Click(object sender, EventArgs e) {
            _validator = new DictionaryEntityValidator();

            switch (_entityType) {
                case EntityType.Group:
                    try {
                        var group = new Group() {
                            Id = updatedEntityId,
                            Name = tbName.Text,
                        };

                        var validateResult = _validator.Validate(group);

                        if (!validateResult.IsValid) {
                            MessageBox.Show($"{MessagesConstants.GROUP_UPDATE_ERROR} {validateResult.Error}");
                            return;
                        }

                        var service = new GroupService();
                        await service.UpdateAsync(group);

                        MessageBox.Show(MessagesConstants.GROUP_UPDATE_ERROR);
                        _updateEvent.Invoke();
                        Close();
                        return;
                    }
                    catch {
                        MessageBox.Show(MessagesConstants.GROUP_UPDATE_ERROR);
                        _updateEvent.Invoke();
                        Close();
                        return;
                    }
                case EntityType.Faculty: {
                        try {
                            var faculty = new Faculty() {
                                Id = updatedEntityId,
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(faculty);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.FACULTY_UPDATE_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new FacultyService();
                            await service.UpdateAsync(faculty);

                            MessageBox.Show(MessagesConstants.FACULTY_SUCCESS_UPDATED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.FACULTY_UPDATE_ERROR);
                            return;
                        }
                    }
                case EntityType.Rank: {
                        try {
                            var rank = new Rank() {
                                Id = updatedEntityId,
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(rank);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.RANK_UPDATE_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new RankService();
                            await service.UpdateAsync(rank);

                            MessageBox.Show(MessagesConstants.RANK_SUCCESS_UPDATED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.RANK_UPDATE_ERROR);
                            return;
                        }
                    }
                case EntityType.Degree: {
                        try {
                            var degree = new Degree() {
                                Id = updatedEntityId,
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(degree);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.DEGREE_UPDATE_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new DegreeService();
                            await service.UpdateAsync(degree);

                            MessageBox.Show(MessagesConstants.DEGREE_SUCCESS_UPDATED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.DEGREE_UPDATE_ERROR);
                            return;
                        }
                    }
                case EntityType.Department: {
                        try {
                            var department = new Department() {
                                Id = updatedEntityId,
                                Name = tbName.Text,
                            };

                            var validateResult = _validator.Validate(department);

                            if (!validateResult.IsValid) {
                                MessageBox.Show($"{MessagesConstants.DEPARTMENT_UPDATE_ERROR} {validateResult.Error}");
                                return;
                            }

                            var service = new DepartmentService();
                            await service.UpdateAsync(department);

                            MessageBox.Show(MessagesConstants.DEPARTMENT_SUCCESS_UPDATED);
                            _updateEvent.Invoke();
                            Close();
                            return;
                        }
                        catch {
                            MessageBox.Show(MessagesConstants.DEPARTMENT_UPDATE_ERROR);
                            return;
                        }
                    }
            }
        }
    }
}
