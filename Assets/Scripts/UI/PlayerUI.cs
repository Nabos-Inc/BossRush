using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : UIController
{
    public void GenerateHealth(int baseHealth)
    {
        int childCount = transform.childCount;
        if(baseHealth > childCount) return;

        foreach(Transform child in transform)
        {
            if(!child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(true);
                break;
            }
        }

        ArrangeHealthSprites(baseHealth);
    }

    public override void SetInactiveHealth(int childIndex, int baseHealth)
    {
        Transform child = transform.GetChild(childIndex);

        if(childIndex == 0)
        {
            child.gameObject.GetComponent<Image>().sprite = inactiveSprites[0];
        }
        else if(childIndex == (baseHealth - 1))
        {
            child.gameObject.GetComponent<Image>().sprite = inactiveSprites[2];
        }
        else
        {
            child.gameObject.GetComponent<Image>().sprite = inactiveSprites[1];
        }
    }
    
    public override void ArrangeHealthSprites(int count)
    {
        int it = 0;

        foreach(Transform child in transform)
        {
            if(it == 0)
            {
                child.gameObject.GetComponent<Image>().sprite = activeSprites[0];
            }
            else if(it == (count - 1))
            {
                child.gameObject.GetComponent<Image>().sprite = activeSprites[2];
            }
            else
            {
                child.gameObject.GetComponent<Image>().sprite = activeSprites[1];
            }

            it++;
        }
    }
}
