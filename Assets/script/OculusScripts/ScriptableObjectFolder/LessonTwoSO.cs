using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "NewStuff", menuName = "Lesson2SO")]
public class LessonTwoSO : ScriptableObject
{
    public Sprite artWork;
    public string title;
    public string description;
    public int indexObject; // indexObject���Ʀr�ǵ�HideObjectInInvantory��indexObject_Cache
}
