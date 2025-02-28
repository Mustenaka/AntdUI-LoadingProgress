namespace LoadingProgress.Mission;

public class Jobs
{
    public string Name { get; set; }

    public void Invoker()
    {
        Console.WriteLine(@$"{this.GetType()}:{Name} 准备执行任务");
        Thread.Sleep(2000);
        Console.WriteLine($@"{this.GetType()}:{Name} 完成任务执行");
    }
}