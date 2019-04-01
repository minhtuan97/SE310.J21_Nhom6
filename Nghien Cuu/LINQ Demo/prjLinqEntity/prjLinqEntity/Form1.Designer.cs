namespace prjLinqEntity
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.LINQENTITY = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(-1, -2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(363, 285);
            this.dataGridView.TabIndex = 0;
            // 
            // LINQENTITY
            // 
            this.LINQENTITY.Location = new System.Drawing.Point(389, 59);
            this.LINQENTITY.Name = "LINQENTITY";
            this.LINQENTITY.Size = new System.Drawing.Size(145, 48);
            this.LINQENTITY.TabIndex = 1;
            this.LINQENTITY.Text = "LINQ to Entity";
            this.LINQENTITY.UseVisualStyleBackColor = true;
            this.LINQENTITY.Click += new System.EventHandler(this.LINQENTITY_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(389, 153);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 48);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 284);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.LINQENTITY);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "LINQ to SQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button LINQENTITY;
        private System.Windows.Forms.Button btnReset;
    }
}

