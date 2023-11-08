namespace NHibernateLab.UI.Forms {
    partial class UpdateMarkForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStudent = new System.Windows.Forms.ComboBox();
            this.numDefendMark = new System.Windows.Forms.NumericUpDown();
            this.numExamMark = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numDefendMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExamMark)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(64, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 27);
            this.label2.TabIndex = 39;
            this.label2.Text = "Оценка за защиту";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.Location = new System.Drawing.Point(459, 169);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(176, 62);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Сохранить изменения";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(64, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 37;
            this.label1.Text = "Оценка за экзамен";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(308, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(428, 27);
            this.label4.TabIndex = 36;
            this.label4.Text = "Номер зачётной книжки и ФИО Студента";
            // 
            // cbStudent
            // 
            this.cbStudent.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStudent.FormattingEnabled = true;
            this.cbStudent.Location = new System.Drawing.Point(344, 67);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(376, 35);
            this.cbStudent.TabIndex = 35;
            // 
            // numDefendMark
            // 
            this.numDefendMark.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.numDefendMark.Location = new System.Drawing.Point(69, 198);
            this.numDefendMark.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDefendMark.Name = "numDefendMark";
            this.numDefendMark.Size = new System.Drawing.Size(120, 33);
            this.numDefendMark.TabIndex = 34;
            this.numDefendMark.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // numExamMark
            // 
            this.numExamMark.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.numExamMark.Location = new System.Drawing.Point(69, 80);
            this.numExamMark.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numExamMark.Name = "numExamMark";
            this.numExamMark.Size = new System.Drawing.Size(120, 33);
            this.numExamMark.TabIndex = 33;
            this.numExamMark.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // UpdateMarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStudent);
            this.Controls.Add(this.numDefendMark);
            this.Controls.Add(this.numExamMark);
            this.Name = "UpdateMarkForm";
            this.Text = "Изменение оценки";
            ((System.ComponentModel.ISupportInitialize)(this.numDefendMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExamMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbStudent;
        private System.Windows.Forms.NumericUpDown numDefendMark;
        private System.Windows.Forms.NumericUpDown numExamMark;
    }
}