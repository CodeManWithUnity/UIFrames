using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "Panel/StartPanel";
    public static readonly UIType uIType = new UIType(path, name);
    private Button BackButton;
    private Button LoadButton;
    public StartPanel() : base(uIType)
    {

    }


    public override void OnDestory()
    {
        base.OnDestory();
    }

    public override void OnDisable()
    {
        Debug.Log("StartPanel is back");
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnStart()
    {
        base.OnStart();
        BackButton =  UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back");
        BackButton.onClick.AddListener(OnBack);
        LoadButton = UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Load");
        LoadButton.onClick.AddListener(OnLoad);
    }
    public void OnLoad() 
    {
        Debug.Log("OnLoad");
        Scene2 scene2 = new Scene2();
        GameRoot.GetInstance().SceneControl_Root.LoadScene(scene2.SceneName, scene2);
    }
    public void OnBack() 
    {
        Debug.Log("OnBack");
        GameRoot.GetInstance().UIManager_Root.Pop(false);
        //Debug.Log("点击当前事件");
    }
}
