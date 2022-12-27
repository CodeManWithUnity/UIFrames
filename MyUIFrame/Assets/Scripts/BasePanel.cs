using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    //������Ϊÿ��Panel�ĸ���Ϊ���ṩvirtual������ActiveObj
    
    public UIType uiType;
    //��Panel�ڳ������Ӧ�ľ����һ������
    public GameObject ActiveObj;
    
    public BasePanel(UIType uitype)
    {
        uiType = uitype;
    }
    public virtual void OnStart() 
    {
        Debug.Log($"{uiType.Name}��ʼʹ�ã�");
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
