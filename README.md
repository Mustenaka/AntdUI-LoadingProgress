# LoadingProgress

这是一个展示带进度条的任务加载功能的C#项目，用于处理和显示多任务执行过程中的进度。

## 项目概述

LoadingProgress是一个Windows窗体应用程序，它展示了如何在执行多个任务时，使用模态对话框显示任务进度。项目通过一个主窗体(MainForm)启动计算任务，并通过加载窗体(LoadingForm)显示任务执行进度。

相比直接使用.spin方案，其具备以下优势：

1. 具备进度条和加载参数化，更直观查看进度
2. .spin方案会造成更多的资源消耗，loadingForm的方案对原计算函数影响损失小
3. ShowDialog() 方案自动屏蔽前窗体的操作，避免误操作bug

你也可以把LoadingForm改成UserControl方案，但是这样会让3优势消失。

## 项目结构

项目主要包含以下组件：

- **MainForm**：主窗体，用于启动任务
- **LoadingForm**：进度显示窗体，用于展示任务执行进度
- **Jobs**：任务类，代表单个执行任务
- **JobMgr**：任务管理器类，管理多个任务的执行并报告进度

## 功能特点

- 使用事件机制报告任务执行进度
- 通过进度条直观显示执行进度
- 支持多任务批量执行
- 跨线程更新UI界面，保证界面响应性
- 模态对话框显示任务进度，阻止用户操作主界面

## 使用方法

1. 运行应用程序
2. 在主界面点击计算按钮开始执行任务
3. 任务执行过程中会显示进度窗口
4. 所有任务执行完成后，进度窗口自动关闭

## 代码示例

### 启动任务执行：

```csharp
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
}
```

### 更新进度：

```csharp
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
```

### 启动截图

点击主机界面的“执行运算”，弹出加载中窗体

![loading](Pic\loading.png)

## 注意事项

- 项目中使用了`CheckForIllegalCrossThreadCalls = false`来简化跨线程UI操作，在生产环境中应使用更安全的方法如`Invoke`来更新UI
- 进度百分比使用0-100的浮点数表示，在实际使用时注意数值范围的转换