using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    //UI����е����ԣ�����Panel����ջ��ջ�Լ��ӱ��ؼ��ض�Ӧ��Panel
    /// <summary>
    /// ��UIType.Name��ΪKey,�洢Panel�����ƺ������Ӧ�Ĺ�ϵ
    /// </summary>
    public Dictionary<string, GameObject> dict_uiObject;
    //UI��ջ
    public Stack<BasePanel> stack_ui;
    private static UIManager instance;
    /// <summary>
    /// ��ǰ�����¶�Ӧ��Canvas
    /// </summary>
    public GameObject CanvasObj;

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.Log("UIManager ʵ�岻����");
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
    //Stack.Peek()���������ڲ�ɾ�����������·��ض�ջ�����Ķ���
    /// <summary>
    /// ��ջ��Ԫ�ؽ��ã��ӱ��ؼ���Panel��Ӧ���壬��Ŀ��Panel����ջ��
    /// </summary>
    /// <param name="basePanel_push"></param>
    public void Push(BasePanel basePanel_push)
    {
        Debug.Log($"{basePanel_push.uiType.Name}��ջ");
        if (stack_ui.Count > 0)
        {
            stack_ui.Peek().OnDisable();
        }
        //�ӱ��ؼ���GameObject
        GameObject BasePanel_pushObj = GetSingleObject(basePanel_push.uiType);
        dict_uiObject.Add(basePanel_push.uiType.Name, BasePanel_pushObj);
        //����Ԫ�ص�GameObject�����Ǵӱ��ؼ��ص����GameObject
        basePanel_push.ActiveObj = BasePanel_pushObj;
        if (stack_ui.Count == 0)
        {
            stack_ui.Push(basePanel_push);
        }
        else
        {
            //��ջ
            if (stack_ui.Peek().uiType.Name != basePanel_push.uiType.Name)
            {
                stack_ui.Push(basePanel_push);
            }
        }
        basePanel_push.OnStart();
    }
    /// <summary>
    /// ��ջ��Ԫ�ص����������ڼ��س�����ʱ��Pop���е�Panel,isLoad == true��ʱ��ջ��գ�isLoad==false����ջ��
    /// </summary>
    /// <param name="isload"></param>
    public void Pop(bool isload)
    {
        if (isload == true)
        {
            //���ջ������Ԫ��
            if (stack_ui.Count > 0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestory();
                GameObject.Destroy(dict_uiObject[stack_ui.Peek().uiType.Name]);
                dict_uiObject.Remove(stack_ui.Peek().uiType.Name);
                stack_ui.Pop();
                //�ݹ�ִ��ֱ��ջ����û��Ԫ����
                Pop(true);
            }
        }
        if(isload == false) 
        {     
            //����ջ��һ��Ԫ��
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

