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
            this.studentPage = new System.Windows.Forms.TabPage();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmStudent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDataViews.SuspendLayout();
            this.studentPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.cmStudent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcDataViews
            // 
            this.tbcDataViews.Controls.Add(this.studentPage);
            this.tbcDataViews.Controls.Add(this.tabPage2);
            this.tbcDataViews.Location = new System.Drawing.Point(42, 12);
            this.tbcDataViews.Name = "tbcDataViews";
            this.tbcDataViews.SelectedIndex = 0;
            this.tbcDataViews.Size = new System.Drawing.Size(718, 363);
            this.tbcDataViews.TabIndex = 0;
            // 
            // studentPage
            // 
            this.studentPage.Controls.Add(this.dgvStudents);
            this.studentPage.Location = new System.Drawing.Point(4, 25);
            this.studentPage.Name = "studentPage";
            this.studentPage.Padding = new System.Windows.Forms.Padding(3);
            this.studentPage.Size = new System.Drawing.Size(710, 334);
            this.studentPage.TabIndex = 0;
            this.studentPage.Text = "Студенты";
            this.studentPage.UseVisualStyleBackColor = true;
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(25, 24);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.Size = new System.Drawing.Size(661, 287);
            this.dgvStudents.TabIndex = 1;
            this.dgvStudents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStudents_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(710, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmStudent
            // 
            this.cmStudent.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmStudent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.cmStudent.Name = "cmStudent";
            this.cmStudent.Size = new System.Drawing.Size(148, 52);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
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
            this.studentPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.cmStudent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDataViews;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage studentPage;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ContextMenuStrip cmStudent;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}

