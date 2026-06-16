namespace PhysicsTesting.Forms
{
    partial class TestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbAnswer1 = new System.Windows.Forms.RadioButton();
            this.rbAnswer2 = new System.Windows.Forms.RadioButton();
            this.rbAnswer3 = new System.Windows.Forms.RadioButton();
            this.rbAnswer4 = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            
            // lblQuestionNumber
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuestionNumber.Location = new System.Drawing.Point(20, 20);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(124, 21);
            this.lblQuestionNumber.TabIndex = 0;
            this.lblQuestionNumber.Text = "Вопрос: 1 из 10";
            
            // lblQuestion
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuestion.Location = new System.Drawing.Point(20, 60);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(50, 21);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Label";
            this.lblQuestion.AutoSize = false;
            this.lblQuestion.Width = 560;
            this.lblQuestion.Height = 80;
            
            // rbAnswer1
            this.rbAnswer1.AutoSize = true;
            this.rbAnswer1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbAnswer1.Location = new System.Drawing.Point(40, 160);
            this.rbAnswer1.Name = "rbAnswer1";
            this.rbAnswer1.Size = new System.Drawing.Size(103, 24);
            this.rbAnswer1.TabIndex = 2;
            this.rbAnswer1.TabStop = true;
            this.rbAnswer1.Text = "radioButton1";
            this.rbAnswer1.UseVisualStyleBackColor = true;
            
            // rbAnswer2
            this.rbAnswer2.AutoSize = true;
            this.rbAnswer2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbAnswer2.Location = new System.Drawing.Point(40, 200);
            this.rbAnswer2.Name = "rbAnswer2";
            this.rbAnswer2.Size = new System.Drawing.Size(103, 24);
            this.rbAnswer2.TabIndex = 3;
            this.rbAnswer2.TabStop = true;
            this.rbAnswer2.Text = "radioButton2";
            this.rbAnswer2.UseVisualStyleBackColor = true;
            
            // rbAnswer3
            this.rbAnswer3.AutoSize = true;
            this.rbAnswer3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbAnswer3.Location = new System.Drawing.Point(40, 240);
            this.rbAnswer3.Name = "rbAnswer3";
            this.rbAnswer3.Size = new System.Drawing.Size(103, 24);
            this.rbAnswer3.TabIndex = 4;
            this.rbAnswer3.TabStop = true;
            this.rbAnswer3.Text = "radioButton3";
            this.rbAnswer3.UseVisualStyleBackColor = true;
            
            // rbAnswer4
            this.rbAnswer4.AutoSize = true;
            this.rbAnswer4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbAnswer4.Location = new System.Drawing.Point(40, 280);
            this.rbAnswer4.Name = "rbAnswer4";
            this.rbAnswer4.Size = new System.Drawing.Size(103, 24);
            this.rbAnswer4.TabIndex = 5;
            this.rbAnswer4.TabStop = true;
            this.rbAnswer4.Text = "radioButton4";
            this.rbAnswer4.UseVisualStyleBackColor = true;
            
            // btnNext
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(76)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(450, 330);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(130, 40);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(20, 390);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 30);
            this.progressBar.TabIndex = 7;
            
            // lblProgress
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(20, 425);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(70, 15);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "Прогресс:";
            
            // lblTimer
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.Location = new System.Drawing.Point(500, 20);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(80, 20);
            this.lblTimer.TabIndex = 9;
            this.lblTimer.Text = "Время: 0:00";
            
            // panel1
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 460);
            this.panel1.TabIndex = 10;
            this.panel1.SendToBack();
            
            // TestForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.lblQuestionNumber);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.rbAnswer1);
            this.Controls.Add(this.rbAnswer2);
            this.Controls.Add(this.rbAnswer3);
            this.Controls.Add(this.rbAnswer4);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbAnswer1;
        private System.Windows.Forms.RadioButton rbAnswer2;
        private System.Windows.Forms.RadioButton rbAnswer3;
        private System.Windows.Forms.RadioButton rbAnswer4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel panel1;
    }
}
