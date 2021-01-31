using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingUI : UIController
{
    private Transform currentSlot;

    private Image currentSlotImage;

    private int slotIndex = 0;

    private int slotState = 0;

    void Awake()
    {
        currentSlot = transform.GetChild(0);
        currentSlotImage = currentSlot.GetComponent<Image>();
    }

    public override void SetInactiveHealth(int childIndex, int baseHealth)
    {
        throw new System.NotImplementedException();
    }

    public override void ArrangeHealthSprites(int count)
    {
        currentSlotImage.sprite = activeSprites[slotState];
    }

    public void UseHealOrb()
    {
        if(slotState < 8 && slotIndex < 1) return; // We can add a sound

        slotIndex -= 1;

        if(slotIndex <= 0) 
        {
            slotState = 0;
            currentSlot = transform.GetChild(slotIndex);
            currentSlotImage = currentSlot.GetComponent<Image>();
            currentSlotImage.sprite = activeSprites[slotState];
            return;
        }

        currentSlot.gameObject.SetActive(false);
        currentSlot = transform.GetChild(slotIndex);
        currentSlotImage = currentSlot.GetComponent<Image>();
        currentSlotImage.sprite = activeSprites[slotState];
    }

    public void UpdateCurrentSlot()
    {
        if(slotState == 8)
        {
            slotIndex += 1;
            slotState = 0;
            currentSlot = transform.GetChild(slotIndex);
            currentSlotImage = currentSlot.GetComponent<Image>();
            currentSlot.gameObject.SetActive(true);
        }

        slotState += 1;
        currentSlotImage.sprite = activeSprites[slotState];
    }
}
