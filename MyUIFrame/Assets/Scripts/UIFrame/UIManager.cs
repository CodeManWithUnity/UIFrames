using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //UI框架中的首脑，负载Panel的入栈出栈以及从本地加载对应的Panel
    /// <summary>
    /// 用UIType.Name作为Key,存储Panel的名称和物体对应的关系
    /// </summary>
    public Dictionary<string, GameObject> dict_uiObject;
    //UI堆栈
    public Stack<BasePanel> stack_ui;
    private static UIManager instance;
    /// <summary>
    /// 当前场景下对应的Canvas
    /// </summary>
    public GameObject CanvasObj;

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.Log("UIManager 实体不存在");
            return instance;
        }
        else 
        {
            return instance;
        }
    }
    public UIManager() 
    {
        instance = this;
        dict_uiObject = new Dictionary<string, GameObject>();
        stack_ui = new Stack<BasePanel>();
    }
    //Stack.Peek()方法用于在不删除对象的情况下返回堆栈顶部的对象
    /// <summary>
    /// 将栈顶元素禁用，从本地加载Panel对应物体，将目标Panel推入栈中
    /// </summary>
    /// <param name="basePanel_push"></param>
    public void Push(BasePanel basePanel_push)
    {
        Debug.Log($"{basePanel_push.uiType.Name}入栈");
        if (stack_ui.Count > 0)
        {
            stack_ui.Peek().OnDisable();
        }
        //从本地加载GameObject
        GameObject BasePanel_pushObj = GetSingleObject(basePanel_push.uiType);
        dict_uiObject.Add(basePanel_push.uiType.Name, BasePanel_pushObj);
        //设置元素的GameObject是我们从本地加载的这个GameObject
        basePanel_push.ActiveObj = BasePanel_pushObj;
        if (stack_ui.Count == 0)
        {
            stack_ui.Push(basePanel_push);
        }
        else
        {
            //入栈
            if (stack_ui.Peek().uiType.Name != basePanel_push.uiType.Name)
            {
                stack_ui.Push(basePanel_push);
            }
        }
        basePanel_push.OnStart();
    }
    /// <summary>
    /// 将栈顶元素弹出，或者在加载场景的时候Pop所有的Panel,isLoad == true的时候将栈清空，isLoad==false弹出栈顶
    /// </summary>
    /// <param name="isload"></param>
    public void Pop(bool isload)
    {
        if (isload == true)
        {
            //清空栈顶所有元素
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestory();
                GameObject.Destroy(dict_uiObject[stack_ui.Peek().uiType.Name]);
                dict_uiObject.Remove(stack_ui.Peek().uiType.Name);
                stack_ui.Pop();
                //递归执行直至栈里面没有元素了
                Pop(true);
            }
        }
        if(isload == false) 
        {     
            //弹出栈顶一个元素
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestory();
                GameObject.Destroy(dict_uiObject[stack_ui.Peek().uiType.Name]);
                dict_uiObject.Remove(stack_ui.Peek().uiType.Name);
                stack_ui.Pop();
                if (stack_ui.Count > 0)
                {
                    stack_ui.Peek().OnEnable();
                }
            }
        }
    }
    private GameObject GetSingleObject(UIType uIType)
    {
        if (dict_uiObject.ContainsKey(uIType.Name))
        {
            return dict_uiObject[uIType.Name];
        }
        if (CanvasObj == null)
        {
            CanvasObj = UIMethods.GetInstance().FindCanvas();
        }
        GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uIType.Path),CanvasObj.transform);
        return obj;
    } 
}

