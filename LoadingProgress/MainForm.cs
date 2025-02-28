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
                _jobMgr.jobs.Add(new Jobs() { Name = $"����{i + 1}" });
            }
        }

        // ִ��������ӵļ�������
        private void Btn_Calc_Click(object sender, EventArgs e)
        {
            var loadingForm = new LoadingForm();

            // ���Ľ����¼�
            _jobMgr.ProgressChanged += (s, args) =>
            {
                loadingForm.UpdateProgress(args.Percentage, args.Message);
            };

            Task.Run(() =>
            {
                try
                {
                    _jobMgr.InvokerAll();
                    // ��ɺ�رմ���
                    loadingForm.Invoke((Action)(() =>
                    {
                        if (!loadingForm.IsDisposed && loadingForm.Visible)
                            loadingForm.CloseForm();
                    }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($@"ִ�г���: {ex.Message}");
                }
            });

            // ��ʾģ̬�Ի���
            loadingForm.ShowDialog(this);

            Console.WriteLine($@"����������Ŀ");
        }
    }
}
