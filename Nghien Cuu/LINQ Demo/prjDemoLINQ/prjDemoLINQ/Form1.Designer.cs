namespace prjDemoLINQ
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
            this.LINQObject = new System.Windows.Forms.Button();
            this.LINQXML = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(372, 310);
            this.dataGridView.TabIndex = 0;
            // 
            // LINQObject
            // 
            this.LINQObject.Location = new System.Drawing.Point(400, 34);
            this.LINQObject.Name = "LINQObject";
            this.LINQObject.Size = new System.Drawing.Size(177, 59);
            this.LINQObject.TabIndex = 1;
            this.LINQObject.Text = "LINQ to Object";
            this.LINQObject.UseVisualStyleBackColor = true;
            this.LINQObject.Click += new System.EventHandler(this.LINQObject_Click);
            // 
            // LINQXML
            // 
            this.LINQXML.Location = new System.Drawing.Point(400, 124);
            this.LINQXML.Name = "LINQXML";
            this.LINQXML.Size = new System.Drawing.Size(174, 59);
            this.LINQXML.TabIndex = 2;
            this.LINQXML.Text = "LINQ to XML";
            this.LINQXML.UseVisualStyleBackColor = true;
            this.LINQXML.Click += new System.EventHandler(this.LINQXML_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(400, 213);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(174, 59);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 311);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.LINQXML);
            this.Controls.Add(this.LINQObject);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Object XML";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button LINQObject;
        private System.Windows.Forms.Button LINQXML;
        private System.Windows.Forms.Button btnReset;
    }
}

