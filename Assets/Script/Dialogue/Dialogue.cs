using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class Dialogue : ScriptableObject
{
    public string text;
    public float speed;
    public bool choose;

    public Dialogue nextOption_1;
    public Dialogue nextOption_2;

}
