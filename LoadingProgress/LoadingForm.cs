namespace LoadingProgress
{
    /// <summary>
    /// 加载窗体
    /// </summary>
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

            // 确保在非创建线程上调用控件
            CheckForIllegalCrossThreadCalls = false;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(@"创建计算加载中");
        }

        // 更新进度的公共方法
        public void UpdateProgress(float percentage, string statusText = null)
        {
            // 确保在UI线程上更新控件
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<float, string>(UpdateProgress), percentage, statusText);
                return;
            }

            // 更新进度条
            LoadingProgress.Value = percentage;

            // 如果提供了状态文本，则更新状态标签
            if (!string.IsNullOrEmpty(statusText))
            {
                LoadingSpin.Text = statusText;
            }
        }

        // 用于模态对话框关闭的方法
        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseForm));
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
