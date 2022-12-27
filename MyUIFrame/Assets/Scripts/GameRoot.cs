using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    //��ܵ�ʹ��: Push һ��Panel�½��̳���BasePanel��XXXPanel
    //��XXXPanel��ʵ��������Name��Path��������UIType
    //��GameRoot �����¼��н���ʵ������ʹ��UIManager����Push��ջ��

    //GameRoot����������Ϸ��֧�ܣ��ڳ����л�ʱ�������٣�����ʵ����UIManager��SceneControl������Push��һ��Panel
    //ͬʱ��һ�³�ʼ���Ĳ�������Ҫ���ص���Ϸ�е�һ��������
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
        //�ô������ڳ������ٵ�ʱ�򲻽�������
        DontDestroyOnLoad(this.gameObject);
        UIManager_Root.CanvasObj = UIMethods.GetInstance().FindCanvas();
        Scene1 scene1 = new Scene1();
        SceneControl_Root.dict_scene.Add(scene1.SceneName, scene1);
        #region �����һ�����
        UIManager_Root.Push(new StartPanel());
        #endregion
    }
}
