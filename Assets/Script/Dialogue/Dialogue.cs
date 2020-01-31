using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea]public string text;
    [Range(0,1)]public float speed;
    public bool choose;

    public Dialogue nextOption_1;
    public string textChoix1;
    public Dialogue nextOption_2;
    public string textChoix2;

}
