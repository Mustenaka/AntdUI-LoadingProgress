namespace LoadingProgress
{
    partial class LoadingForm
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
            LoadingProgress = new AntdUI.Progress();
            LoadingSpin = new AntdUI.Spin();
            SuspendLayout();
            // 
            // LoadingProgress
            // 
            LoadingProgress.ContainerControl = this;
            LoadingProgress.Location = new Point(12, 198);
            LoadingProgress.Name = "LoadingProgress";
            LoadingProgress.Size = new Size(454, 34);
            LoadingProgress.TabIndex = 0;
            LoadingProgress.Text = "progress1";
            // 
            // LoadingSpin
            // 
            LoadingSpin.Location = new Point(12, 12);
            LoadingSpin.Name = "LoadingSpin";
            LoadingSpin.Size = new Size(454, 180);
            LoadingSpin.TabIndex = 1;
            LoadingSpin.Text = "加载中";
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 244);
            Controls.Add(LoadingSpin);
            Controls.Add(LoadingProgress);
            Name = "LoadingForm";
            Text = "加载中";
            Load += LoadingForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Progress LoadingProgress;
        private AntdUI.Spin LoadingSpin;
    }
}