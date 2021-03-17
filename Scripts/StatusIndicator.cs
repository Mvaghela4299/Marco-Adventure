using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{
    [SerializeField]
    private RectTransform HealthBarRect;        //Position, size, anchor and pivot information for a rectangle
    [SerializeField]
    private Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        if (HealthBarRect == null)
        {
            Debug.Log("STATUS INDICATOR: No health bar object reference");
            Debug.Log("1");
        }
        if (HealthText == null)
        {
            Debug.Log("STATUS INDICATOR: No health text object reference");
        }
    }
    //set health for enemy
    public void setHealth(int _cur, int _max)
    {
        Debug.Log("2");
        float _value = (float)_cur / _max;
        HealthBarRect.localScale = new Vector3(_value, HealthBarRect.localScale.y, HealthBarRect.localScale.z);
        HealthText.text = _cur + "/" + _max + "HP";
    }
}
