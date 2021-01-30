using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIController : MonoBehaviour
{
    public Sprite[] activeSprites;

    public Sprite[] inactiveSprites;

    public abstract void SetInactiveHealth(int childIndex, int baseHealth);
    
    public abstract void ArrangeHealthSprites(int count);
    
}
