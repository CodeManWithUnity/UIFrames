using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI框架中的方法库，用于为Ui系统提供各类方法
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
    /// 获得场景中的Canvas（目前没有考虑多画布的情况）
    /// </summary>
    /// <returns></returns>
    public GameObject FindCanvas() 
    {
        GameObject gameObject_canvas = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject_canvas == null)
        {
            Debug.LogError("当前场景当中没有Canvas,请添加！");
            return gameObject_canvas;
        }
        return gameObject_canvas;
    }
    /// <summary>
    /// 获得panel当中名为childname的子物体
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
        Debug.LogWarning($"在{panel.name}物体中没有找到{childname}物体！");
        return null;
    }

    /// <summary>
    /// 从目标对象的子物体中根据组件的名称获取对应的组件
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
        Debug.LogError($"没有在{panel.name}当中找到{ComponentName}组件");
        return null;
    }
    /// <summary>
    /// 从目标对象中获取对应的组件
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
        Debug.LogWarning($"无法在{gameObject}物体上获得目标组件！");
        return null;
    }
}
