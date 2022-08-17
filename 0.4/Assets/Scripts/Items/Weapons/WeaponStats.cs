using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/Item/Weapon")]
public class WeaponStats : ObjectData
{
    public float attackTime;
    public float damage;
    // ������ ��������, � ������� �������� �����
    // ����� ������, "������" �����
    public int hitboxX;
    // ������ ��������
    public int hitboxY;
    // ������� �����
    public int hitboxZ;
}
