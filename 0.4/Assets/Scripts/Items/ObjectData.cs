using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// возможно, от этого будут наследоваться другие айтемы типа мечи, щиты и тд
[CreateAssetMenu(menuName = "Object/Item")]
public class ObjectData : ScriptableObject
{
    public Sprite sprite;
}
