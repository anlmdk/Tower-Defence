using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filler : MonoBehaviour
{
    public Image myImage;
    public float originalAmount;

    public void UpdateAmount(float _amount)
    {
        myImage.fillAmount = _amount / originalAmount;
    }
}
