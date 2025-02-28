using System.Diagnostics;
using LoadingProgress.Mission;

namespace LoadingProgress
{
    public partial class MainForm : Form
    {
        private readonly JobMgr _jobMgr;

        public MainForm()
        {
            InitializeComponent();

            _jobMgr = new JobMgr();
            for (int i = 0; i < 5; i++)
            {
                _jobMgr.jobs.Add(new Jobs() { Name = $"任务{i + 1}" });
            }
        }

        // 执行这个复杂的计算任务
        private void Btn_Calc_Click(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();

            // 订阅进度事件
            _jobMgr.ProgressChanged += (s, args) =>
            {
                loadingForm.UpdateProgress(args.Percentage, args.Message);
            };

            Task.Run(() =>
            {
                try
                {
                    _jobMgr.InvokerAll();
                    // 完成后关闭窗口
                    loadingForm.Invoke((Action)(() =>
                    {
                        if (!loadingForm.IsDisposed && loadingForm.Visible)
                            loadingForm.CloseForm();
                    }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"执行出错: {ex.Message}");
                }
            });

            // 显示模态对话框
            loadingForm.ShowDialog(this);

            Console.WriteLine($@"批量运行项目");
        }
    }
}
