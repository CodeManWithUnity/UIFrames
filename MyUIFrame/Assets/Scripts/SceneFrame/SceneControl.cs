using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneControl
{
    //用于场景切换，类似于UIManager,使用SceneLoad方法来加载场景
    private static SceneControl instance;
    public static SceneControl GetInstacne()
    {
        if (instance == null)
        {
            Debug.Log("当前的SceneControl是一个空的");
            return instance;
        }
        return instance;
    }
    //默认的场景
    public SceneType default_sceneNumber = SceneType.Scene1;
    public string[] string_scene;
    public Dictionary<string, SceneBase> dict_scene;

    public SceneControl()
    {
        instance = this;
        dict_scene = new Dictionary<string, SceneBase>(); ;
    }

    /// <summary>
    /// 加载一个场景
    /// </summary>
    /// <param name="SceneName">目前场景的名称</param>
    /// <param name="sceneBase">目标场景的SceneBase</param>
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
            Debug.LogWarning($"SceneControl的字典中不包含{SceneManager.GetActiveScene().name}");
        }
        //先把当前场景中的所有元素都Pop掉
        //TODO Pop
        GameRoot.GetInstance().UIManager_Root.Pop(true);
        SceneManager.LoadScene(SceneName);
        sceneBase.EnterScene();
    }
}
