using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Script.UI.Message;

public class TestEvent : MonoBehaviour
{
    public Dictionary<string, Func<CallBackDataBase, bool>> CallBackMethod
        =new Dictionary<string, Func<CallBackDataBase, bool>>();
    CJ_Model cj;
    void Start()
    {
        CallBackMethod.Add("Result", Result);
        cj = FindObjectOfType<CJ_Model>();
        cj.SetCallBack(CallBackMethod);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            cj?.Show(UnityEngine.Random.Range(-1, 6));
            Debug.Log("ShowF");
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            cj?.Hide();
            Debug.Log("HideF");
        }
    }

    public bool Result(CallBackDataBase callBackDataBase) {
        Debug.Log(callBackDataBase.ToString());
        return true;
    }
}
