using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControl
{
    //���ڳ����л���������UIManager,ʹ��SceneLoad���������س���
    private static SceneControl instance;
    public static SceneControl GetInstacne()
    {
        if (instance == null)
        {
            Debug.Log("��ǰ��SceneControl��һ���յ�");
            return instance;
        }
        return instance;
    }
    //Ĭ�ϵĳ���
    public SceneType default_sceneNumber = SceneType.Scene1;
    public string[] string_scene;
    public Dictionary<string, SceneBase> dict_scene;

    public SceneControl()
    {
        instance = this;
        dict_scene = new Dictionary<string, SceneBase>(); ;
    }

    /// <summary>
    /// ����һ������
    /// </summary>
    /// <param name="SceneName">Ŀǰ����������</param>
    /// <param name="sceneBase">Ŀ�곡����SceneBase</param>
    public void LoadScene(string SceneName,SceneBase sceneBase) 
    {
        if (!dict_scene.ContainsKey(SceneName)) 
        {
            dict_scene.Add(SceneName, sceneBase);
        }
        if (dict_scene.ContainsKey(SceneManager.GetActiveScene().name))
        {
            dict_scene[SceneManager.GetActiveScene().name].ExitScene();
        }
        else 
        {
            Debug.LogWarning($"SceneControl���ֵ��в�����{SceneManager.GetActiveScene().name}");
        }
        //�Ȱѵ�ǰ�����е�����Ԫ�ض�Pop��
        //TODO Pop
        GameRoot.GetInstance().UIManager_Root.Pop(true);
        SceneManager.LoadScene(SceneName);
        sceneBase.EnterScene();
    }
}
