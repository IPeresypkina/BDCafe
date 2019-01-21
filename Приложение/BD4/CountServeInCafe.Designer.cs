namespace BD4
{
    partial class CountServeInCafe
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
            this.DGVCount = new System.Windows.Forms.DataGridView();
            this.idcafe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countServe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCount)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCount
            // 
            this.DGVCount.AllowUserToAddRows = false;
            this.DGVCount.AllowUserToDeleteRows = false;
            this.DGVCount.AllowUserToResizeColumns = false;
            this.DGVCount.AllowUserToResizeRows = false;
            this.DGVCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcafe,
            this.adress,
            this.countServe,
            this.salary});
            this.DGVCount.Location = new System.Drawing.Point(3, 4);
            this.DGVCount.MultiSelect = false;
            this.DGVCount.Name = "DGVCount";
            this.DGVCount.ReadOnly = true;
            this.DGVCount.RowHeadersVisible = false;
            this.DGVCount.Size = new System.Drawing.Size(283, 187);
            this.DGVCount.TabIndex = 0;
            // 
            // idcafe
            // 
            this.idcafe.HeaderText = "idcafe";
            this.idcafe.Name = "idcafe";
            this.idcafe.Visible = false;
            // 
            // adress
            // 
            this.adress.HeaderText = "Адрес кафе ";
            this.adress.Name = "adress";
            // 
            // countServe
            // 
            this.countServe.HeaderText = "Количество сотрудников";
            this.countServe.Name = "countServe";
            // 
            // salary
            // 
            this.salary.HeaderText = "Средняя зарплата";
            this.salary.Name = "salary";
            // 
            // CountServeInCafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 193);
            this.Controls.Add(this.DGVCount);
            this.Name = "CountServeInCafe";
            this.Text = "Информация о кофейнях";
            this.Load += new System.EventHandler(this.CountServeInCafe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcafe;
        private System.Windows.Forms.DataGridViewTextBoxColumn adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn countServe;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
    }
}