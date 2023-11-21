using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(1,3)]
    public string[] names;

    [TextArea(4, 11)]
    public string[] sentences;

}
