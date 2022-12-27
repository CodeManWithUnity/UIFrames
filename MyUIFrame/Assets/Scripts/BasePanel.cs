using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    //用于作为每个Panel的父类为其提供virtual方法和ActiveObj
    
    public UIType uiType;
    //此Panel在场景里对应的具体的一个物体
    public GameObject ActiveObj;
    
    public BasePanel(UIType uitype)
    {
        uiType = uitype;
    }
    public virtual void OnStart() 
    {
        Debug.Log($"{uiType.Name}开始使用！");
        UIMethods.GetInstance().GetorAddComponent<CanvasGroup>(ActiveObj).interactable = true;

    }
    public virtual void OnEnable() 
    {
        UIMethods.GetInstance().GetorAddComponent<CanvasGroup>(ActiveObj).interactable = true;
    }
    public virtual void OnDisable() 
    {
        UIMethods.GetInstance().GetorAddComponent<CanvasGroup>(ActiveObj).interactable = false;
    }
    public virtual void OnDestory() 
    {
        UIMethods.GetInstance().GetorAddComponent<CanvasGroup>(ActiveObj).interactable = false;
    }
}
