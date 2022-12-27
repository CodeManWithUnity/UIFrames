using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景的爸爸类，作为每个Scene的爸爸为其提供抽象方法，在场景切换时们不会销毁
public abstract class SceneBase : MonoBehaviour 
{
    //进入场景时执行的方法
    public abstract void EnterScene();
    //退出场景时执行的方法
    public abstract void ExitScene();
}
