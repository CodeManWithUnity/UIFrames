using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����İְ��࣬��Ϊÿ��Scene�İְ�Ϊ���ṩ���󷽷����ڳ����л�ʱ�ǲ�������
public abstract class SceneBase : MonoBehaviour 
{
    //���볡��ʱִ�еķ���
    public abstract void EnterScene();
    //�˳�����ʱִ�еķ���
    public abstract void ExitScene();
}
