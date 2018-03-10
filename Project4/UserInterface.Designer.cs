namespace Project4
{
    partial class uxUserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uxUserInterface));
            this.uxInitExpLabel = new System.Windows.Forms.Label();
            this.uxInitTypeLabel = new System.Windows.Forms.Label();
            this.uxResultTypeLabel = new System.Windows.Forms.Label();
            this.uxResultLabel = new System.Windows.Forms.Label();
            this.uxInitialExpressionTextBox = new System.Windows.Forms.TextBox();
            this.uxInitialTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uxResultTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uxResultTextBox = new System.Windows.Forms.TextBox();
            this.uxConvertExpButton = new System.Windows.Forms.Button();
            this.uxEvaluateButton = new System.Windows.Forms.Button();
            this.uxBuildTreeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxInitExpLabel
            // 
            this.uxInitExpLabel.AutoSize = true;
            this.uxInitExpLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInitExpLabel.Location = new System.Drawing.Point(13, 9);
            this.uxInitExpLabel.Name = "uxInitExpLabel";
            this.uxInitExpLabel.Size = new System.Drawing.Size(133, 18);
            this.uxInitExpLabel.TabIndex = 0;
            this.uxInitExpLabel.Text = "Initial Expression: ";
            // 
            // uxInitTypeLabel
            // 
            this.uxInitTypeLabel.AutoSize = true;
            this.uxInitTypeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInitTypeLabel.Location = new System.Drawing.Point(17, 46);
            this.uxInitTypeLabel.Name = "uxInitTypeLabel";
            this.uxInitTypeLabel.Size = new System.Drawing.Size(88, 18);
            this.uxInitTypeLabel.TabIndex = 1;
            this.uxInitTypeLabel.Text = "Initial Type: ";
            // 
            // uxResultTypeLabel
            // 
            this.uxResultTypeLabel.AutoSize = true;
            this.uxResultTypeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxResultTypeLabel.Location = new System.Drawing.Point(17, 88);
            this.uxResultTypeLabel.Name = "uxResultTypeLabel";
            this.uxResultTypeLabel.Size = new System.Drawing.Size(92, 18);
            this.uxResultTypeLabel.TabIndex = 2;
            this.uxResultTypeLabel.Text = "Result type: ";
            // 
            // uxResultLabel
            // 
            this.uxResultLabel.AutoSize = true;
            this.uxResultLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxResultLabel.Location = new System.Drawing.Point(12, 149);
            this.uxResultLabel.Name = "uxResultLabel";
            this.uxResultLabel.Size = new System.Drawing.Size(162, 18);
            this.uxResultLabel.TabIndex = 3;
            this.uxResultLabel.Text = "Resulting Expression: ";
            // 
            // uxInitialExpressionTextBox
            // 
            this.uxInitialExpressionTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInitialExpressionTextBox.Location = new System.Drawing.Point(143, 6);
            this.uxInitialExpressionTextBox.Name = "uxInitialExpressionTextBox";
            this.uxInitialExpressionTextBox.Size = new System.Drawing.Size(334, 26);
            this.uxInitialExpressionTextBox.TabIndex = 4;
            // 
            // uxInitialTypeComboBox
            // 
            this.uxInitialTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxInitialTypeComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInitialTypeComboBox.FormattingEnabled = true;
            this.uxInitialTypeComboBox.Location = new System.Drawing.Point(116, 43);
            this.uxInitialTypeComboBox.Name = "uxInitialTypeComboBox";
            this.uxInitialTypeComboBox.Size = new System.Drawing.Size(121, 26);
            this.uxInitialTypeComboBox.TabIndex = 5;
            // 
            // uxResultTypeComboBox
            // 
            this.uxResultTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxResultTypeComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxResultTypeComboBox.FormattingEnabled = true;
            this.uxResultTypeComboBox.Location = new System.Drawing.Point(116, 84);
            this.uxResultTypeComboBox.Name = "uxResultTypeComboBox";
            this.uxResultTypeComboBox.Size = new System.Drawing.Size(121, 26);
            this.uxResultTypeComboBox.TabIndex = 6;
            // 
            // uxResultTextBox
            // 
            this.uxResultTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxResultTextBox.Location = new System.Drawing.Point(167, 146);
            this.uxResultTextBox.Name = "uxResultTextBox";
            this.uxResultTextBox.Size = new System.Drawing.Size(310, 26);
            this.uxResultTextBox.TabIndex = 7;
            // 
            // uxConvertExpButton
            // 
            this.uxConvertExpButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxConvertExpButton.Location = new System.Drawing.Point(12, 208);
            this.uxConvertExpButton.Name = "uxConvertExpButton";
            this.uxConvertExpButton.Size = new System.Drawing.Size(169, 33);
            this.uxConvertExpButton.TabIndex = 8;
            this.uxConvertExpButton.Text = "Convert Expression";
            this.uxConvertExpButton.UseVisualStyleBackColor = true;
            this.uxConvertExpButton.Click += new System.EventHandler(this.ConvertExpressionClick);
            // 
            // uxEvaluateButton
            // 
            this.uxEvaluateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxEvaluateButton.Location = new System.Drawing.Point(377, 208);
            this.uxEvaluateButton.Name = "uxEvaluateButton";
            this.uxEvaluateButton.Size = new System.Drawing.Size(89, 33);
            this.uxEvaluateButton.TabIndex = 10;
            this.uxEvaluateButton.Text = "Evaluate";
            this.uxEvaluateButton.UseVisualStyleBackColor = true;
            this.uxEvaluateButton.Click += new System.EventHandler(this.EvaluateClick);
            // 
            // uxBuildTreeButton
            // 
            this.uxBuildTreeButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxBuildTreeButton.Location = new System.Drawing.Point(225, 208);
            this.uxBuildTreeButton.Name = "uxBuildTreeButton";
            this.uxBuildTreeButton.Size = new System.Drawing.Size(109, 33);
            this.uxBuildTreeButton.TabIndex = 11;
            this.uxBuildTreeButton.Text = "Build Tree";
            this.uxBuildTreeButton.UseVisualStyleBackColor = true;
            this.uxBuildTreeButton.Click += new System.EventHandler(this.BuildTreeClick);
            // 
            // uxUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 267);
            this.Controls.Add(this.uxBuildTreeButton);
            this.Controls.Add(this.uxEvaluateButton);
            this.Controls.Add(this.uxConvertExpButton);
            this.Controls.Add(this.uxResultTextBox);
            this.Controls.Add(this.uxResultTypeComboBox);
            this.Controls.Add(this.uxInitialTypeComboBox);
            this.Controls.Add(this.uxInitialExpressionTextBox);
            this.Controls.Add(this.uxResultLabel);
            this.Controls.Add(this.uxResultTypeLabel);
            this.Controls.Add(this.uxInitTypeLabel);
            this.Controls.Add(this.uxInitExpLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "uxUserInterface";
            this.Text = "Expression Tree Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxInitExpLabel;
        private System.Windows.Forms.Label uxInitTypeLabel;
        private System.Windows.Forms.Label uxResultTypeLabel;
        private System.Windows.Forms.Label uxResultLabel;
        private System.Windows.Forms.TextBox uxInitialExpressionTextBox;
        private System.Windows.Forms.ComboBox uxInitialTypeComboBox;
        private System.Windows.Forms.ComboBox uxResultTypeComboBox;
        private System.Windows.Forms.TextBox uxResultTextBox;
        private System.Windows.Forms.Button uxConvertExpButton;
        private System.Windows.Forms.Button uxEvaluateButton;
        private System.Windows.Forms.Button uxBuildTreeButton;
    }
}

