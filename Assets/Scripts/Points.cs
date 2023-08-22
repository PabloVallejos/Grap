using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text[] txt;
    public int points = 0;
    float timer;

    private void Update()
    {
        txt[0].text = points.ToString();
        timer += Time.deltaTime;
        txt[1].text = timer.ToString("0");
    }
}
