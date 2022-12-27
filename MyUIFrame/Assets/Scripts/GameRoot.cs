using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    //框架的使用: Push 一个Panel新建继承自BasePanel的XXXPanel
    //在XXXPanel中实例化创建Name与Path并将其存进UIType
    //在GameRoot 或者事件中将其实例化并使用UIManager将其Push进栈中

    //GameRoot类是整个游戏的支架，在场景切换时不会销毁，用于实例化UIManager和SceneControl，用于Push第一个Panel
    //同时做一下初始化的操作，需要挂载到游戏中的一个物体上
    private static GameRoot instance;
    public static GameRoot GetInstance() 
    {
        if (instance == null) 
        {
            Debug.LogError("GameRoot Ins is false");
            return instance;
        }
        return instance;
    }

    private UIManager UIManager;

    public UIManager UIManager_Root { get => UIManager; }
    
    private SceneControl SceneControl;
    public SceneControl SceneControl_Root { get => SceneControl; }    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        UIManager = new UIManager();
        SceneControl = new SceneControl();
    }
    private void Start()
    {
        //让此物体在场景销毁的时候不进行销毁
        DontDestroyOnLoad(this.gameObject);
        UIManager_Root.CanvasObj = UIMethods.GetInstance().FindCanvas();
        Scene1 scene1 = new Scene1();
        SceneControl_Root.dict_scene.Add(scene1.SceneName, scene1);
        #region 推入第一个面板
        UIManager_Root.Push(new StartPanel());
        #endregion
    }
}
