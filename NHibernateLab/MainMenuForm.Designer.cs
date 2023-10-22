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
            this.cmStudent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTeacher = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTopic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовуюТемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовогоПреподавателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовогоСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmMark = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовуюОценкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDataViews.SuspendLayout();
            this.studentsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.teachersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.topicsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            this.marksPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.cmStudent.SuspendLayout();
            this.cmTeacher.SuspendLayout();
            this.cmTopic.SuspendLayout();
            this.cmMark.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcDataViews
            // 
            this.tbcDataViews.Controls.Add(this.studentsPage);
            this.tbcDataViews.Controls.Add(this.teachersPage);
            this.tbcDataViews.Controls.Add(this.topicsPage);
            this.tbcDataViews.Controls.Add(this.marksPage);
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
            // cmStudent
            // 
            this.cmStudent.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmStudent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.добавитьНовогоСтудентаToolStripMenuItem});
            this.cmStudent.Name = "cmStudent";
            this.cmStudent.Size = new System.Drawing.Size(263, 76);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(262, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(262, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // cmTeacher
            // 
            this.cmTeacher.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmTeacher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem1,
            this.добавитьНовогоПреподавателяToolStripMenuItem});
            this.cmTeacher.Name = "cmTeacher";
            this.cmTeacher.Size = new System.Drawing.Size(310, 76);
            // 
            // изменитьToolStripMenuItem1
            // 
            this.изменитьToolStripMenuItem1.Name = "изменитьToolStripMenuItem1";
            this.изменитьToolStripMenuItem1.Size = new System.Drawing.Size(309, 24);
            this.изменитьToolStripMenuItem1.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(309, 24);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            // 
            // cmTopic
            // 
            this.cmTopic.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmTopic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem2,
            this.удалитьToolStripMenuItem2,
            this.добавитьНовуюТемуToolStripMenuItem});
            this.cmTopic.Name = "cmTopic";
            this.cmTopic.Size = new System.Drawing.Size(231, 76);
            // 
            // изменитьToolStripMenuItem2
            // 
            this.изменитьToolStripMenuItem2.Name = "изменитьToolStripMenuItem2";
            this.изменитьToolStripMenuItem2.Size = new System.Drawing.Size(230, 24);
            this.изменитьToolStripMenuItem2.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem2
            // 
            this.удалитьToolStripMenuItem2.Name = "удалитьToolStripMenuItem2";
            this.удалитьToolStripMenuItem2.Size = new System.Drawing.Size(230, 24);
            this.удалитьToolStripMenuItem2.Text = "Удалить";
            // 
            // добавитьНовуюТемуToolStripMenuItem
            // 
            this.добавитьНовуюТемуToolStripMenuItem.Name = "добавитьНовуюТемуToolStripMenuItem";
            this.добавитьНовуюТемуToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.добавитьНовуюТемуToolStripMenuItem.Text = "Добавить новую тему";
            // 
            // добавитьНовогоПреподавателяToolStripMenuItem
            // 
            this.добавитьНовогоПреподавателяToolStripMenuItem.Name = "добавитьНовогоПреподавателяToolStripMenuItem";
            this.добавитьНовогоПреподавателяToolStripMenuItem.Size = new System.Drawing.Size(309, 24);
            this.добавитьНовогоПреподавателяToolStripMenuItem.Text = "Добавить нового преподавателя";
            // 
            // добавитьНовогоСтудентаToolStripMenuItem
            // 
            this.добавитьНовогоСтудентаToolStripMenuItem.Name = "добавитьНовогоСтудентаToolStripMenuItem";
            this.добавитьНовогоСтудентаToolStripMenuItem.Size = new System.Drawing.Size(262, 24);
            this.добавитьНовогоСтудентаToolStripMenuItem.Text = "Добавить нового студента";
            // 
            // cmMark
            // 
            this.cmMark.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmMark.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem3,
            this.удалитьToolStripMenuItem3,
            this.добавитьНовуюОценкуToolStripMenuItem});
            this.cmMark.Name = "cmMark";
            this.cmMark.Size = new System.Drawing.Size(248, 76);
            // 
            // изменитьToolStripMenuItem3
            // 
            this.изменитьToolStripMenuItem3.Name = "изменитьToolStripMenuItem3";
            this.изменитьToolStripMenuItem3.Size = new System.Drawing.Size(247, 24);
            this.изменитьToolStripMenuItem3.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem3
            // 
            this.удалитьToolStripMenuItem3.Name = "удалитьToolStripMenuItem3";
            this.удалитьToolStripMenuItem3.Size = new System.Drawing.Size(247, 24);
            this.удалитьToolStripMenuItem3.Text = "Удалить";
            // 
            // добавитьНовуюОценкуToolStripMenuItem
            // 
            this.добавитьНовуюОценкуToolStripMenuItem.Name = "добавитьНовуюОценкуToolStripMenuItem";
            this.добавитьНовуюОценкуToolStripMenuItem.Size = new System.Drawing.Size(247, 24);
            this.добавитьНовуюОценкуToolStripMenuItem.Text = "Добавить новую оценку";
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
            this.cmStudent.ResumeLayout(false);
            this.cmTeacher.ResumeLayout(false);
            this.cmTopic.ResumeLayout(false);
            this.cmMark.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDataViews;
        private System.Windows.Forms.TabPage teachersPage;
        private System.Windows.Forms.TabPage studentsPage;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ContextMenuStrip cmStudent;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.TabPage topicsPage;
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.TabPage marksPage;
        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовогоСтудентаToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmTeacher;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовогоПреподавателяToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmTopic;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовуюТемуToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmMark;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовуюОценкуToolStripMenuItem;
    }
}

