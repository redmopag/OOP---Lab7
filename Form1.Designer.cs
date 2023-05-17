namespace Project
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxDrawFigure = new System.Windows.Forms.PictureBox();
            this.checkBoxMultiSelection = new System.Windows.Forms.CheckBox();
            this.checkBoxCtrl = new System.Windows.Forms.CheckBox();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonSquare = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialogShapes = new System.Windows.Forms.ColorDialog();
            this.buttonGroup = new System.Windows.Forms.Button();
            this.buttonUngroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawFigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDrawFigure
            // 
            this.pictureBoxDrawFigure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDrawFigure.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxDrawFigure.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDrawFigure.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxDrawFigure.Name = "pictureBoxDrawFigure";
            this.pictureBoxDrawFigure.Size = new System.Drawing.Size(483, 426);
            this.pictureBoxDrawFigure.TabIndex = 0;
            this.pictureBoxDrawFigure.TabStop = false;
            this.pictureBoxDrawFigure.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDrawFigure_Paint);
            this.pictureBoxDrawFigure.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDrawFigure_MouseDown);
            // 
            // checkBoxMultiSelection
            // 
            this.checkBoxMultiSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMultiSelection.Location = new System.Drawing.Point(497, 31);
            this.checkBoxMultiSelection.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMultiSelection.Name = "checkBoxMultiSelection";
            this.checkBoxMultiSelection.Size = new System.Drawing.Size(86, 16);
            this.checkBoxMultiSelection.TabIndex = 2;
            this.checkBoxMultiSelection.Text = "Multi-selection";
            this.checkBoxMultiSelection.UseVisualStyleBackColor = true;
            this.checkBoxMultiSelection.Click += new System.EventHandler(this.checkBoxMultiSelection_Click);
            // 
            // checkBoxCtrl
            // 
            this.checkBoxCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCtrl.Location = new System.Drawing.Point(497, 10);
            this.checkBoxCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCtrl.Name = "checkBoxCtrl";
            this.checkBoxCtrl.Size = new System.Drawing.Size(86, 16);
            this.checkBoxCtrl.TabIndex = 1;
            this.checkBoxCtrl.Text = "Ctrl";
            this.checkBoxCtrl.UseVisualStyleBackColor = true;
            this.checkBoxCtrl.Click += new System.EventHandler(this.checkBoxCtrl_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.AllowDrop = true;
            this.buttonCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCircle.Location = new System.Drawing.Point(497, 53);
            this.buttonCircle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(56, 19);
            this.buttonCircle.TabIndex = 3;
            this.buttonCircle.Text = "Circle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonSquare
            // 
            this.buttonSquare.AllowDrop = true;
            this.buttonSquare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSquare.Location = new System.Drawing.Point(497, 76);
            this.buttonSquare.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSquare.Name = "buttonSquare";
            this.buttonSquare.Size = new System.Drawing.Size(56, 19);
            this.buttonSquare.TabIndex = 4;
            this.buttonSquare.Text = "Square";
            this.buttonSquare.UseVisualStyleBackColor = true;
            this.buttonSquare.Click += new System.EventHandler(this.buttonSquare_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.AllowDrop = true;
            this.buttonTriangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTriangle.Location = new System.Drawing.Point(497, 100);
            this.buttonTriangle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(56, 19);
            this.buttonTriangle.TabIndex = 5;
            this.buttonTriangle.Text = "Triangle";
            this.buttonTriangle.UseVisualStyleBackColor = true;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxColor.Location = new System.Drawing.Point(583, 53);
            this.pictureBoxColor.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(75, 19);
            this.pictureBoxColor.TabIndex = 6;
            this.pictureBoxColor.TabStop = false;
            // 
            // buttonColor
            // 
            this.buttonColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColor.Location = new System.Drawing.Point(592, 76);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(56, 19);
            this.buttonColor.TabIndex = 7;
            this.buttonColor.Text = "Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonGroup
            // 
            this.buttonGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGroup.Location = new System.Drawing.Point(497, 138);
            this.buttonGroup.Name = "buttonGroup";
            this.buttonGroup.Size = new System.Drawing.Size(71, 23);
            this.buttonGroup.TabIndex = 8;
            this.buttonGroup.Text = "Group";
            this.buttonGroup.UseVisualStyleBackColor = true;
            this.buttonGroup.Click += new System.EventHandler(this.buttonGroup_Click);
            // 
            // buttonUngroup
            // 
            this.buttonUngroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUngroup.Location = new System.Drawing.Point(574, 138);
            this.buttonUngroup.Name = "buttonUngroup";
            this.buttonUngroup.Size = new System.Drawing.Size(75, 23);
            this.buttonUngroup.TabIndex = 9;
            this.buttonUngroup.Text = "Ungroup";
            this.buttonUngroup.UseVisualStyleBackColor = true;
            this.buttonUngroup.Click += new System.EventHandler(this.buttonUngroup_Click);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 445);
            this.Controls.Add(this.buttonUngroup);
            this.Controls.Add(this.buttonGroup);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.pictureBoxColor);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonSquare);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.checkBoxMultiSelection);
            this.Controls.Add(this.checkBoxCtrl);
            this.Controls.Add(this.pictureBoxDrawFigure);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawFigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDrawFigure;
        private System.Windows.Forms.CheckBox checkBoxMultiSelection;
        private System.Windows.Forms.CheckBox checkBoxCtrl;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonSquare;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.PictureBox pictureBoxColor;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialogShapes;
        private System.Windows.Forms.Button buttonGroup;
        private System.Windows.Forms.Button buttonUngroup;
    }
}

