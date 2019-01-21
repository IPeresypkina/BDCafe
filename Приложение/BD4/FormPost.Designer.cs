namespace BD4
{
    partial class FormPost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.postDGV = new System.Windows.Forms.DataGridView();
            this.idpost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idserve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postAddButton = new System.Windows.Forms.Button();
            this.postChangeButton = new System.Windows.Forms.Button();
            this.postDeleteButton = new System.Windows.Forms.Button();
            this.buttonClearDataPost = new System.Windows.Forms.Button();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            this.comboBoxServe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ErrorlabelPost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.postDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // postDGV
            // 
            this.postDGV.AllowUserToAddRows = false;
            this.postDGV.AllowUserToDeleteRows = false;
            this.postDGV.AllowUserToResizeColumns = false;
            this.postDGV.AllowUserToResizeRows = false;
            this.postDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.postDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.postDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpost,
            this.title,
            this.salary,
            this.idserve});
            this.postDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.postDGV.Location = new System.Drawing.Point(0, 0);
            this.postDGV.Name = "postDGV";
            this.postDGV.ReadOnly = true;
            this.postDGV.RowHeadersVisible = false;
            this.postDGV.Size = new System.Drawing.Size(415, 121);
            this.postDGV.TabIndex = 0;
            this.postDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.postDGV_CellClick);
            // 
            // idpost
            // 
            this.idpost.HeaderText = "idpost";
            this.idpost.Name = "idpost";
            this.idpost.ReadOnly = true;
            this.idpost.Visible = false;
            // 
            // title
            // 
            this.title.HeaderText = "Должность";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // salary
            // 
            this.salary.HeaderText = "Зарплата";
            this.salary.Name = "salary";
            this.salary.ReadOnly = true;
            // 
            // idserve
            // 
            this.idserve.HeaderText = "Сотрудник";
            this.idserve.Name = "idserve";
            this.idserve.ReadOnly = true;
            // 
            // postAddButton
            // 
            this.postAddButton.Location = new System.Drawing.Point(328, 134);
            this.postAddButton.Name = "postAddButton";
            this.postAddButton.Size = new System.Drawing.Size(75, 42);
            this.postAddButton.TabIndex = 1;
            this.postAddButton.Text = "Добавить запись";
            this.postAddButton.UseVisualStyleBackColor = true;
            this.postAddButton.Click += new System.EventHandler(this.postAddButton_Click);
            // 
            // postChangeButton
            // 
            this.postChangeButton.Location = new System.Drawing.Point(328, 181);
            this.postChangeButton.Name = "postChangeButton";
            this.postChangeButton.Size = new System.Drawing.Size(75, 46);
            this.postChangeButton.TabIndex = 2;
            this.postChangeButton.Text = "Изменить запись";
            this.postChangeButton.UseVisualStyleBackColor = true;
            this.postChangeButton.Click += new System.EventHandler(this.postChangeButton_Click);
            // 
            // postDeleteButton
            // 
            this.postDeleteButton.Location = new System.Drawing.Point(328, 233);
            this.postDeleteButton.Name = "postDeleteButton";
            this.postDeleteButton.Size = new System.Drawing.Size(75, 45);
            this.postDeleteButton.TabIndex = 3;
            this.postDeleteButton.Text = "Удалить запись";
            this.postDeleteButton.UseVisualStyleBackColor = true;
            this.postDeleteButton.Click += new System.EventHandler(this.postDeleteButton_Click);
            // 
            // buttonClearDataPost
            // 
            this.buttonClearDataPost.Location = new System.Drawing.Point(19, 166);
            this.buttonClearDataPost.Name = "buttonClearDataPost";
            this.buttonClearDataPost.Size = new System.Drawing.Size(94, 23);
            this.buttonClearDataPost.TabIndex = 4;
            this.buttonClearDataPost.Text = "Очистить поля ввода";
            this.buttonClearDataPost.UseVisualStyleBackColor = true;
            this.buttonClearDataPost.Click += new System.EventHandler(this.buttonClearDataPost_Click);
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(115, 226);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(192, 20);
            this.textBoxPost.TabIndex = 5;
            this.textBoxPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed1);
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.Location = new System.Drawing.Point(115, 258);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.Size = new System.Drawing.Size(192, 20);
            this.textBoxSalary.TabIndex = 6;
            this.textBoxSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed2);
            // 
            // comboBoxServe
            // 
            this.comboBoxServe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServe.FormattingEnabled = true;
            this.comboBoxServe.Location = new System.Drawing.Point(115, 195);
            this.comboBoxServe.Name = "comboBoxServe";
            this.comboBoxServe.Size = new System.Drawing.Size(192, 21);
            this.comboBoxServe.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Сотрудник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Должность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Зарплата";
            // 
            // ErrorlabelPost
            // 
            this.ErrorlabelPost.AutoSize = true;
            this.ErrorlabelPost.Location = new System.Drawing.Point(19, 128);
            this.ErrorlabelPost.Name = "ErrorlabelPost";
            this.ErrorlabelPost.Size = new System.Drawing.Size(0, 13);
            this.ErrorlabelPost.TabIndex = 11;
            // 
            // FormPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 290);
            this.Controls.Add(this.ErrorlabelPost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxServe);
            this.Controls.Add(this.textBoxSalary);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.buttonClearDataPost);
            this.Controls.Add(this.postDeleteButton);
            this.Controls.Add(this.postChangeButton);
            this.Controls.Add(this.postAddButton);
            this.Controls.Add(this.postDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPost";
            this.Text = "Должности";
            this.Load += new System.EventHandler(this.FormPost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView postDGV;
        private System.Windows.Forms.Button postAddButton;
        private System.Windows.Forms.Button postChangeButton;
        private System.Windows.Forms.Button postDeleteButton;
        private System.Windows.Forms.Button buttonClearDataPost;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.ComboBox comboBoxServe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ErrorlabelPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpost;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn idserve;
    }
}