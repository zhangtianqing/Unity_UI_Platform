using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Script.UI.Message;

public class CJ_Model :  BaseUI
{
    #region Universal
    public override bool SetData(object[] o)
    {
        content.text = (string)o[0];
        bg.color = (Color)o[1];
        return true;
    }

    protected override void ShowSelf(int i)
    {
        content.text = "活动" + i+"-"+ UnityEngine.Random.Range(0,10);
        //Debug.Log(content.text);
        switch ((ShowModel)i)
        {
            case ShowModel.Normal:
                bg.color = Color.white;
                
                break;
            case ShowModel.Activitie_1:
                bg.color = Color.green;
                break;
            case ShowModel.Activitie_2:
                bg.color = Color.red;
                break;
            case ShowModel.Activitie_3:
                bg.color = Color.cyan;
                break;
            case ShowModel.Activitie_4:
                bg.color = Color.blue;
                break;
            case ShowModel.Activitie_5:
                bg.color = Color.gray;
                break;
            default:
                bg.color = Color.black;
                break;
        }
        CallCallBack("Result",
                     new Universal() { messageType = MessageType.CallBack, message = "显示完成", result = $"{transform.name}_Show_{content.text}" });
    }

    protected override bool HideSelf()
    {
        bg.color = Color.black;
        content.text = "无活动" ;
        return true;
    }

    #endregion

    public Text content;
    public RawImage bg;

    public enum ShowModel { 
        Normal=0,
        Activitie_1=1,
        Activitie_2=2,
        Activitie_3=3,
        Activitie_4=4,
        Activitie_5=5,
    }
}
