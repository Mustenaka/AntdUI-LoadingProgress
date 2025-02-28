namespace LoadingProgress.Mission
{
    public class JobMgr
    {
        public List<Jobs> jobs = new();

        // 进度报告事件
        public event EventHandler<ProgressEventArgs> ProgressChanged;

        // 进度事件参数类
        public class ProgressEventArgs : EventArgs
        {
            public float Percentage { get; set; }
            public string Message { get; set; }

            /// <summary>
            /// 进度事件参数
            /// </summary>
            /// <param name="percentage">百分比，一个[0,1]的数字</param>
            /// <param name="message">传递信息，spin的text的显示结果</param>
            public ProgressEventArgs(float percentage, string message)
            {
                Percentage = percentage;
                Message = message;
            }
        }

        // 触发进度事件的方法
        protected virtual void OnProgressChanged(ProgressEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        public void InvokerAll()
        {
            for (var index = 0; index < jobs.Count; index++)
            {
                var job = jobs[index];

                // 报告进度
                var percentage = (index + 1) / (float)jobs.Count;
                OnProgressChanged(new ProgressEventArgs(percentage, $"正在执行项目: {job.GetType()}:{job.Name}"));


                job.Invoker();
            }

            OnProgressChanged(new ProgressEventArgs(100, "所有项目执行完成!"));
        }
    }
}
