using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WLButton : MonoBehaviour
{
    public Image img;
    public Sprite[] spr;

    public void YouWinLose(int i)
    {
        img.sprite = spr[i];
    }
}
