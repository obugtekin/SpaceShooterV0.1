using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] RectTransform barRectTransform;
    float maxWidth;

    private void Awake()
    {
        maxWidth=barRectTransform.rect.width;
    }

    private void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldDisplay;
    }
    private void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateShieldDisplay;
    }


    void UpdateShieldDisplay(float percantage)
    {
         barRectTransform.sizeDelta=new Vector2(maxWidth*percantage,10f);
    }

}
