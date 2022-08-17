using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������, �� ����� ����� ������������� ������ ������ ���� ����, ���� � ��
[CreateAssetMenu(menuName = "Object/Item")]
public class ObjectData : ScriptableObject
{
    public Sprite sprite;
    public GameObject prefab;
    public GameObject groundItem;
}
