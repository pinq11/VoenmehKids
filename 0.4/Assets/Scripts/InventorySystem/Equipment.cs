using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipmentSlot helmetUI;
    private Helmet helmet;

    public EquipmentSlot armorUI;
    private ObjectData armor;

    public EquipmentSlot bootsUI;
    private ObjectData boots;

    public EquipmentSlot leftRingUI;
    private ObjectData leftRing;

    public EquipmentSlot rightRingUI;
    private ObjectData rightRing;

    public void ReplaceHelmet(Helmet helmet)
    {
        this.helmet = helmet;
    }


}
