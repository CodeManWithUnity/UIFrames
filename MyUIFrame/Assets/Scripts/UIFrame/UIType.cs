using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIType
{
    //���ڴ洢Panel��Ϣ��������Ľṹ
    private string path;
    public string Path { get => path; }
    private string name;
    public string Name { get => name; }
    /// <summary>
    /// ���UI��Ϣ
    /// </summary>
    /// <param name="ui_path">·��</param>
    /// <param name="ui_name">����</param>
    public UIType(string ui_path, string ui_name)
    {
        path = ui_path;
        name = ui_name;
    }
}
