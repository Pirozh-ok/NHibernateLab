namespace NHibernateLab {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tbcDataViews = new System.Windows.Forms.TabControl();
            this.studentsPage = new System.Windows.Forms.TabPage();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.teachersPage = new System.Windows.Forms.TabPage();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.topicsPage = new System.Windows.Forms.TabPage();
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            this.marksPage = new System.Windows.Forms.TabPage();
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.groupPage = new System.Windows.Forms.TabPage();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.facultyPage = new System.Windows.Forms.TabPage();
            this.dgvFaculties = new System.Windows.Forms.DataGridView();
            this.departmentPage = new System.Windows.Forms.TabPage();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.degreePage = new System.Windows.Forms.TabPage();
            this.dgvDegrees = new System.Windows.Forms.DataGridView();
            this.rankPage = new System.Windows.Forms.TabPage();
            this.dgvRanks = new System.Windows.Forms.DataGridView();
            this.cmTableAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiUpdateRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRemoveRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiAddRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDataViews.SuspendLayout();
            this.studentsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.teachersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.topicsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            this.marksPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.groupPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.facultyPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculties)).BeginInit();
            this.departmentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.degreePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDegrees)).BeginInit();
            this.rankPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanks)).BeginInit();
            this.cmTableAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcDataViews
            // 
            this.tbcDataViews.Controls.Add(this.studentsPage);
            this.tbcDataViews.Controls.Add(this.teachersPage);
            this.tbcDataViews.Controls.Add(this.topicsPage);
            this.tbcDataViews.Controls.Add(this.marksPage);
            this.tbcDataViews.Controls.Add(this.groupPage);
            this.tbcDataViews.Controls.Add(this.facultyPage);
            this.tbcDataViews.Controls.Add(this.departmentPage);
            this.tbcDataViews.Controls.Add(this.degreePage);
            this.tbcDataViews.Controls.Add(this.rankPage);
            this.tbcDataViews.Location = new System.Drawing.Point(12, 12);
            this.tbcDataViews.Name = "tbcDataViews";
            this.tbcDataViews.SelectedIndex = 0;
            this.tbcDataViews.Size = new System.Drawing.Size(776, 426);
            this.tbcDataViews.TabIndex = 0;
            // 
            // studentsPage
            // 
            this.studentsPage.Controls.Add(this.dgvStudents);
            this.studentsPage.Location = new System.Drawing.Point(4, 25);
            this.studentsPage.Name = "studentsPage";
            this.studentsPage.Padding = new System.Windows.Forms.Padding(3);
            this.studentsPage.Size = new System.Drawing.Size(768, 397);
            this.studentsPage.TabIndex = 0;
            this.studentsPage.Text = "Студенты";
            this.studentsPage.UseVisualStyleBackColor = true;
            this.studentsPage.Enter += new System.EventHandler(this.studentsPage_Enter);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(35, 20);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(700, 350);
            this.dgvStudents.TabIndex = 1;
            this.dgvStudents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStudents_MouseDown);
            // 
            // teachersPage
            // 
            this.teachersPage.Controls.Add(this.dgvTeachers);
            this.teachersPage.Location = new System.Drawing.Point(4, 25);
            this.teachersPage.Name = "teachersPage";
            this.teachersPage.Padding = new System.Windows.Forms.Padding(3);
            this.teachersPage.Size = new System.Drawing.Size(768, 397);
            this.teachersPage.TabIndex = 1;
            this.teachersPage.Text = "Преподаватели";
            this.teachersPage.UseVisualStyleBackColor = true;
            this.teachersPage.Enter += new System.EventHandler(this.teachersPage_Enter);
            // 
            // dgvTeachers
            // 
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachers.Location = new System.Drawing.Point(35, 20);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.RowHeadersWidth = 51;
            this.dgvTeachers.RowTemplate.Height = 24;
            this.dgvTeachers.Size = new System.Drawing.Size(700, 350);
            this.dgvTeachers.TabIndex = 0;
            // 
            // topicsPage
            // 
            this.topicsPage.Controls.Add(this.dgvTopics);
            this.topicsPage.Location = new System.Drawing.Point(4, 25);
            this.topicsPage.Name = "topicsPage";
            this.topicsPage.Size = new System.Drawing.Size(768, 397);
            this.topicsPage.TabIndex = 2;
            this.topicsPage.Text = "Темы";
            this.topicsPage.UseVisualStyleBackColor = true;
            this.topicsPage.Enter += new System.EventHandler(this.topicsPage_Enter);
            // 
            // dgvTopics
            // 
            this.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopics.Location = new System.Drawing.Point(35, 20);
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.RowHeadersWidth = 51;
            this.dgvTopics.RowTemplate.Height = 24;
            this.dgvTopics.Size = new System.Drawing.Size(700, 350);
            this.dgvTopics.TabIndex = 0;
            // 
            // marksPage
            // 
            this.marksPage.Controls.Add(this.dgvMarks);
            this.marksPage.Location = new System.Drawing.Point(4, 25);
            this.marksPage.Name = "marksPage";
            this.marksPage.Size = new System.Drawing.Size(768, 397);
            this.marksPage.TabIndex = 3;
            this.marksPage.Text = "Оценки";
            this.marksPage.UseVisualStyleBackColor = true;
            this.marksPage.Enter += new System.EventHandler(this.marksPage_Enter);
            // 
            // dgvMarks
            // 
            this.dgvMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarks.Location = new System.Drawing.Point(35, 20);
            this.dgvMarks.Name = "dgvMarks";
            this.dgvMarks.RowHeadersWidth = 51;
            this.dgvMarks.RowTemplate.Height = 24;
            this.dgvMarks.Size = new System.Drawing.Size(700, 350);
            this.dgvMarks.TabIndex = 0;
            // 
            // groupPage
            // 
            this.groupPage.Controls.Add(this.dgvGroups);
            this.groupPage.Location = new System.Drawing.Point(4, 25);
            this.groupPage.Name = "groupPage";
            this.groupPage.Padding = new System.Windows.Forms.Padding(3);
            this.groupPage.Size = new System.Drawing.Size(768, 397);
            this.groupPage.TabIndex = 4;
            this.groupPage.Text = "Группы";
            this.groupPage.UseVisualStyleBackColor = true;
            this.groupPage.Enter += new System.EventHandler(this.groupPage_Enter);
            // 
            // dgvGroups
            // 
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(34, 23);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.RowHeadersWidth = 51;
            this.dgvGroups.RowTemplate.Height = 24;
            this.dgvGroups.Size = new System.Drawing.Size(700, 350);
            this.dgvGroups.TabIndex = 1;
            // 
            // facultyPage
            // 
            this.facultyPage.Controls.Add(this.dgvFaculties);
            this.facultyPage.Location = new System.Drawing.Point(4, 25);
            this.facultyPage.Name = "facultyPage";
            this.facultyPage.Padding = new System.Windows.Forms.Padding(3);
            this.facultyPage.Size = new System.Drawing.Size(768, 397);
            this.facultyPage.TabIndex = 5;
            this.facultyPage.Text = "Факультеты";
            this.facultyPage.UseVisualStyleBackColor = true;
            this.facultyPage.Enter += new System.EventHandler(this.facultyPage_Enter);
            // 
            // dgvFaculties
            // 
            this.dgvFaculties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculties.Location = new System.Drawing.Point(34, 23);
            this.dgvFaculties.Name = "dgvFaculties";
            this.dgvFaculties.RowHeadersWidth = 51;
            this.dgvFaculties.RowTemplate.Height = 24;
            this.dgvFaculties.Size = new System.Drawing.Size(700, 350);
            this.dgvFaculties.TabIndex = 1;
            // 
            // departmentPage
            // 
            this.departmentPage.Controls.Add(this.dgvDepartments);
            this.departmentPage.Location = new System.Drawing.Point(4, 25);
            this.departmentPage.Name = "departmentPage";
            this.departmentPage.Padding = new System.Windows.Forms.Padding(3);
            this.departmentPage.Size = new System.Drawing.Size(768, 397);
            this.departmentPage.TabIndex = 6;
            this.departmentPage.Text = "Кафедры";
            this.departmentPage.UseVisualStyleBackColor = true;
            this.departmentPage.Enter += new System.EventHandler(this.departmentPage_Enter);
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Location = new System.Drawing.Point(34, 23);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowHeadersWidth = 51;
            this.dgvDepartments.RowTemplate.Height = 24;
            this.dgvDepartments.Size = new System.Drawing.Size(700, 350);
            this.dgvDepartments.TabIndex = 1;
            // 
            // degreePage
            // 
            this.degreePage.Controls.Add(this.dgvDegrees);
            this.degreePage.Location = new System.Drawing.Point(4, 25);
            this.degreePage.Name = "degreePage";
            this.degreePage.Padding = new System.Windows.Forms.Padding(3);
            this.degreePage.Size = new System.Drawing.Size(768, 397);
            this.degreePage.TabIndex = 7;
            this.degreePage.Text = "Степени";
            this.degreePage.UseVisualStyleBackColor = true;
            this.degreePage.Enter += new System.EventHandler(this.degreePage_Enter);
            // 
            // dgvDegrees
            // 
            this.dgvDegrees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDegrees.Location = new System.Drawing.Point(34, 23);
            this.dgvDegrees.Name = "dgvDegrees";
            this.dgvDegrees.RowHeadersWidth = 51;
            this.dgvDegrees.RowTemplate.Height = 24;
            this.dgvDegrees.Size = new System.Drawing.Size(700, 350);
            this.dgvDegrees.TabIndex = 1;
            // 
            // rankPage
            // 
            this.rankPage.Controls.Add(this.dgvRanks);
            this.rankPage.Location = new System.Drawing.Point(4, 25);
            this.rankPage.Name = "rankPage";
            this.rankPage.Padding = new System.Windows.Forms.Padding(3);
            this.rankPage.Size = new System.Drawing.Size(768, 397);
            this.rankPage.TabIndex = 8;
            this.rankPage.Text = "Звания";
            this.rankPage.UseVisualStyleBackColor = true;
            this.rankPage.Enter += new System.EventHandler(this.rankPage_Enter);
            // 
            // dgvRanks
            // 
            this.dgvRanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanks.Location = new System.Drawing.Point(34, 23);
            this.dgvRanks.Name = "dgvRanks";
            this.dgvRanks.RowHeadersWidth = 51;
            this.dgvRanks.RowTemplate.Height = 24;
            this.dgvRanks.Size = new System.Drawing.Size(700, 350);
            this.dgvRanks.TabIndex = 1;
            // 
            // cmTableAction
            // 
            this.cmTableAction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmTableAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiUpdateRecord,
            this.cmiRemoveRecord,
            this.cmiAddRecord});
            this.cmTableAction.Name = "cmStudent";
            this.cmTableAction.Size = new System.Drawing.Size(247, 76);
            // 
            // cmiUpdateRecord
            // 
            this.cmiUpdateRecord.Name = "cmiUpdateRecord";
            this.cmiUpdateRecord.Size = new System.Drawing.Size(246, 24);
            this.cmiUpdateRecord.Text = "Изменить";
            this.cmiUpdateRecord.Click += new System.EventHandler(this.updateRecordToolStripMenuItem_Click);
            // 
            // cmiRemoveRecord
            // 
            this.cmiRemoveRecord.Name = "cmiRemoveRecord";
            this.cmiRemoveRecord.Size = new System.Drawing.Size(246, 24);
            this.cmiRemoveRecord.Text = "Удалить";
            this.cmiRemoveRecord.Click += new System.EventHandler(this.removeRecordToolStripMenuItem_Click);
            // 
            // cmiAddRecord
            // 
            this.cmiAddRecord.Name = "cmiAddRecord";
            this.cmiAddRecord.Size = new System.Drawing.Size(246, 24);
            this.cmiAddRecord.Text = "Добавить новую запись";
            this.cmiAddRecord.Click += new System.EventHandler(this.addRecordToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbcDataViews);
            this.Name = "MainForm";
            this.Text = "Lab 2";
            this.tbcDataViews.ResumeLayout(false);
            this.studentsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.teachersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.topicsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            this.marksPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).EndInit();
            this.groupPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.facultyPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculties)).EndInit();
            this.departmentPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.degreePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDegrees)).EndInit();
            this.rankPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanks)).EndInit();
            this.cmTableAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDataViews;
        private System.Windows.Forms.TabPage teachersPage;
        private System.Windows.Forms.TabPage studentsPage;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ContextMenuStrip cmTableAction;
        private System.Windows.Forms.ToolStripMenuItem cmiUpdateRecord;
        private System.Windows.Forms.ToolStripMenuItem cmiRemoveRecord;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.TabPage topicsPage;
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.TabPage marksPage;
        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.ToolStripMenuItem cmiAddRecord;
        private System.Windows.Forms.TabPage groupPage;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.TabPage facultyPage;
        private System.Windows.Forms.DataGridView dgvFaculties;
        private System.Windows.Forms.TabPage departmentPage;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.TabPage degreePage;
        private System.Windows.Forms.DataGridView dgvDegrees;
        private System.Windows.Forms.TabPage rankPage;
        private System.Windows.Forms.DataGridView dgvRanks;
    }
}

