namespace LoadingProgress
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Btn_Calc = new AntdUI.Button();
            SuspendLayout();
            // 
            // Btn_Calc
            // 
            Btn_Calc.Font = new Font("Microsoft YaHei UI", 18F);
            Btn_Calc.Location = new Point(275, 225);
            Btn_Calc.Name = "Btn_Calc";
            Btn_Calc.Size = new Size(250, 150);
            Btn_Calc.TabIndex = 0;
            Btn_Calc.Text = "执行运算";
            Btn_Calc.Click += Btn_Calc_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 544);
            Controls.Add(Btn_Calc);
            Name = "MainForm";
            Text = "主窗体 —— 测试";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button Btn_Calc;
    }
}
