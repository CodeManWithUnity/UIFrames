using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI����еķ����⣬����ΪUiϵͳ�ṩ���෽��
public class UIMethods
{
    private static UIMethods instance;
    public static UIMethods GetInstance()
    {
        if (instance == null)
        {
            instance = new UIMethods();
        }
        return instance;

    }
    public UIMethods(){ instance = this;}

    /// <summary>
    /// ��ó����е�Canvas��Ŀǰû�п��Ƕ໭���������
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas() 
    {
        GameObject gameObject_canvas = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject_canvas == null)
        {
            Debug.LogError("��ǰ��������û��Canvas,����ӣ�");
            return gameObject_canvas;
        }
        return gameObject_canvas;
    }
    /// <summary>
    /// ���panel������Ϊchildname��������
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="childname"></param>
    /// <returns></returns>
    public GameObject FindObjectInChild(GameObject panel,string childname) 
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();
        foreach (var item in transforms) 
        {
            if (item.gameObject.name == childname) 
            {
                return item.gameObject;
            }
        }
        Debug.LogWarning($"��{panel.name}������û���ҵ�{childname}���壡");
        return null;
    }

    /// <summary>
    /// ��Ŀ�������������и�����������ƻ�ȡ��Ӧ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="panel"></param>
    /// <param name="ComponentName"></param>
    /// <returns></returns>
    public T GetOrAddSingleComponentInChild<T>(GameObject panel,string ComponentName) where T : Component
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();
        foreach (var item in transforms)
        {
            if (item.gameObject.name == ComponentName)
            {
                return item.gameObject.GetComponent<T>();
            }
        }
        Debug.LogError($"û����{panel.name}�����ҵ�{ComponentName}���");
        return null;
    }
    /// <summary>
    /// ��Ŀ������л�ȡ��Ӧ�����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public T GetorAddComponent<T>(GameObject gameObject) where T : Component 
    {
        if (gameObject.GetComponent<T>() != null)
        {
            return gameObject.GetComponent<T>();
        }
        Debug.LogWarning($"�޷���{gameObject}�����ϻ��Ŀ�������");
        return null;
    }
}
