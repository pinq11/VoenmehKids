using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType
{
    Helmet,
    Armor,
    Boots,
    LeftRing,
    RightRing,
}

public class Equipment : MonoBehaviour
{
    public EquipmentSlot helmetUI;
    private ObjectData helmet;

    public EquipmentSlot armorUI;
    private ObjectData armor;

    public EquipmentSlot bootsUI;
    private ObjectData boots;

    public EquipmentSlot leftRingUI;
    private ObjectData leftRing;

    public EquipmentSlot rightRingUI;
    private ObjectData rightRing;

    // ставит новый шлем, возвращает старый
    /*public Helmet ReplaceHelmet(Helmet helmet)
    {
        Helmet old = this.helmet;
        this.helmet = helmet;
        helmetUI.icon.sprite = helmet.sprite;

        return old;
    }*/

    public ObjectData RemoveArmor(ArmorType armorType)
    {
        ObjectData removed = null;

        switch (armorType)
        {
            case ArmorType.Helmet:
                helmetUI.icon.sprite = null;
                removed = helmet;
                helmet = null;
                break;
            case ArmorType.Armor:
                armorUI.icon.sprite = null;
                removed = armor;
                armor = null;
                break;
            case ArmorType.Boots:
                bootsUI.icon.sprite = null;
                removed = boots;
                boots = null;
                break;
            case ArmorType.LeftRing:
                leftRingUI.icon.sprite = null;
                removed = leftRing;
                leftRing = null;
                break;
            case ArmorType.RightRing:
                rightRingUI.icon.sprite = null;
                removed = rightRing;
                rightRing = null;
                break;
        }

        return removed;
    }

    public void PutOnArmor(ObjectData armor, ArmorType armorType)
    {
        switch (armorType)
        {
            case ArmorType.Helmet:
                helmet = armor;
                helmetUI.icon.sprite = armor.sprite;
                break;
            case ArmorType.Armor:
                this.armor = armor;
                armorUI.icon.sprite = armor.sprite;
                break;
            case ArmorType.Boots:
                boots = armor;
                bootsUI.icon.sprite = armor.sprite;
                break;
            case ArmorType.LeftRing:
                leftRing = armor;
                leftRingUI.icon.sprite = armor.sprite;
                break;
            case ArmorType.RightRing:
                rightRing = armor;
                rightRingUI.icon.sprite = armor.sprite;
                break;
        }
    }
}
