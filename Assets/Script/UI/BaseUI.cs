using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using static Assets.Script.UI.Message;

public abstract class BaseUI : MonoBehaviour
{
    public Dictionary<string, Func<CallBackDataBase, bool>> ResponseCall;
    
    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public abstract bool SetData(object[] o);
    /// <summary>
    /// 隐藏方法
    /// </summary>
    /// <returns></returns>
    protected abstract bool HideSelf();
    /// <summary>
    /// 显示方法
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    protected abstract void ShowSelf(int i);

    /// <summary>
    /// 设置事件回调，同时需要回调方法标注为async,同时需要调用处前缀 await
    /// </summary>
    /// <param name="unityEvent"></param>
    /// <returns></returns>
    public  bool SetCallBack(Dictionary<string, Func<CallBackDataBase, bool>> unityEvent)
    {
        if (unityEvent != null)
        {
            ResponseCall = unityEvent;
            return true;
        }

        return false;
    }

    /// <summary>
    /// 隐藏
    /// </summary>
    /// <returns></returns>
    public void Hide()
    {
        ContinueWithOnMainThread(() => { HideSelf(); });
    }

    /// <summary>
    /// 显示 -  比如进入一个内容列表，左侧为列表，右侧为内容，默认进入列表第二项时就需要此参数 
    /// </summary>
    /// <returns></returns>
    public void Show(int model)
    {
        ContinueWithOnMainThread(() => {
            ////await Task.Delay(3000);
            ShowSelf(model); 
        });
    }
    /// <summary>
    /// 确保操作在主线程上面，避免更新了UI却没有刷新
    /// </summary>
    /// <param name="action"></param>
    private void ContinueWithOnMainThread(Action action) {
        Task task=new Task(action);
        task.Start(TaskScheduler.FromCurrentSynchronizationContext());

    }
    /// <summary>
    /// 回调调用机制
    /// </summary>
    /// <param name="methodName"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    public bool CallCallBack(string methodName, CallBackDataBase callBack) {
        if (ResponseCall.TryGetValue(methodName,out Func<CallBackDataBase,bool> call))
        {
            return (bool)(call?.Invoke(callBack));
        }
        return false;
    }
    public void Show()
    {
        Show(0);
    }
}
public enum MessageType { 
      Normal=0,
      CallBack=1
}