using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIType
{
    //用于存储Panel信息的最基本的结构
    private string path;
    public string Path { get => path; }
    private string name;
    public string Name { get => name; }
    /// <summary>
    /// 获得UI信息
    /// </summary>
    /// <param name="ui_path">路径</param>
    /// <param name="ui_name">名称</param>
    public UIType(string ui_path, string ui_name)
    {
        path = ui_path;
        name = ui_name;
    }
}
