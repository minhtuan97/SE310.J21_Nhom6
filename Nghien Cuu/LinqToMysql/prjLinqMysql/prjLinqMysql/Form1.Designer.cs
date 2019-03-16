namespace prjLinqMysql
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LinqSql = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(331, 269);
            this.dataGridView1.TabIndex = 0;
            // 
            // LinqSql
            // 
            this.LinqSql.Location = new System.Drawing.Point(337, 38);
            this.LinqSql.Name = "LinqSql";
            this.LinqSql.Size = new System.Drawing.Size(130, 46);
            this.LinqSql.TabIndex = 1;
            this.LinqSql.Text = "LINQ to Mysql";
            this.LinqSql.UseVisualStyleBackColor = true;
            this.LinqSql.Click += new System.EventHandler(this.LinqSql_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(337, 115);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 54);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 269);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.LinqSql);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "LINQ to Mysql";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button LinqSql;
        private System.Windows.Forms.Button btnReset;
    }
}

