using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/Item/Weapon")]
public class WeaponStats : ObjectData
{
    public float attackTime;
    public float damage;
    // ширина хитбокса, в который попадают враги
    // проще говоря, "размах" удара
    public int hitboxX;
    // высота хитбокса
    public int hitboxY;
    // глубина удара
    public int hitboxZ;
}
