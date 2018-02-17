namespace DevExpressExcelDashboard
{
	partial class ExcelGenerator
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
			this.CreateExcelBtn = new System.Windows.Forms.Button();
			this.chartCB = new System.Windows.Forms.CheckBox();
			this.tableCB = new System.Windows.Forms.CheckBox();
			this.pivotCB = new System.Windows.Forms.CheckBox();
			this.openBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CreateExcelBtn
			// 
			this.CreateExcelBtn.Location = new System.Drawing.Point(71, 108);
			this.CreateExcelBtn.Name = "CreateExcelBtn";
			this.CreateExcelBtn.Size = new System.Drawing.Size(106, 38);
			this.CreateExcelBtn.TabIndex = 0;
			this.CreateExcelBtn.Text = "Create Excel";
			this.CreateExcelBtn.UseVisualStyleBackColor = true;
			this.CreateExcelBtn.Click += new System.EventHandler(this.CreateExcelBtn_Click);
			// 
			// chartCB
			// 
			this.chartCB.AutoSize = true;
			this.chartCB.Location = new System.Drawing.Point(35, 38);
			this.chartCB.Name = "chartCB";
			this.chartCB.Size = new System.Drawing.Size(71, 21);
			this.chartCB.TabIndex = 1;
			this.chartCB.Text = "Charts";
			this.chartCB.UseVisualStyleBackColor = true;
			// 
			// tableCB
			// 
			this.tableCB.AutoSize = true;
			this.tableCB.Location = new System.Drawing.Point(159, 38);
			this.tableCB.Name = "tableCB";
			this.tableCB.Size = new System.Drawing.Size(66, 21);
			this.tableCB.TabIndex = 2;
			this.tableCB.Text = "Table";
			this.tableCB.UseVisualStyleBackColor = true;
			// 
			// pivotCB
			// 
			this.pivotCB.AutoSize = true;
			this.pivotCB.Location = new System.Drawing.Point(279, 38);
			this.pivotCB.Name = "pivotCB";
			this.pivotCB.Size = new System.Drawing.Size(61, 21);
			this.pivotCB.TabIndex = 3;
			this.pivotCB.Text = "Pivot";
			this.pivotCB.UseVisualStyleBackColor = true;
			// 
			// openBtn
			// 
			this.openBtn.Location = new System.Drawing.Point(197, 108);
			this.openBtn.Name = "openBtn";
			this.openBtn.Size = new System.Drawing.Size(111, 38);
			this.openBtn.TabIndex = 4;
			this.openBtn.Text = "Open Existing";
			this.openBtn.UseVisualStyleBackColor = true;
			this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
			// 
			// ExcelGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 192);
			this.Controls.Add(this.openBtn);
			this.Controls.Add(this.pivotCB);
			this.Controls.Add(this.tableCB);
			this.Controls.Add(this.chartCB);
			this.Controls.Add(this.CreateExcelBtn);
			this.Name = "ExcelGenerator";
			this.Text = "Excel Generator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CreateExcelBtn;
		private System.Windows.Forms.CheckBox chartCB;
		private System.Windows.Forms.CheckBox tableCB;
		private System.Windows.Forms.CheckBox pivotCB;
		private System.Windows.Forms.Button openBtn;
	}
}

