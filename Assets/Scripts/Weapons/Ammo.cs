using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    [SerializeField] Slider ammoSlider;
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }


    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
        
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
        UpdateAmmoUI(ammoType);
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount)
    {
        if ((GetCurrentAmmo(ammoType) + amount) > 30)
        {
            GetAmmoSlot(ammoType).ammoAmount = 30;
        }
        else
        {
            GetAmmoSlot(ammoType).ammoAmount += amount;
        }
        UpdateAmmoUI(ammoType);
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

    public void Reload(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = 30;
        UpdateAmmoUI(ammoType);
    }

    public void UpdateAmmoUI(AmmoType ammoType)
    {
        ammoSlider.value = GetAmmoSlot(ammoType).ammoAmount / 30f;
    }
}
