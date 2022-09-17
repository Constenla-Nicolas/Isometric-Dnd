using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Custom/New item")]
public class ScriptableItem : ScriptableObject
{
    new public string name="new item";
    public Sprite icon=null;
    public bool isDefaultItem=false;
}
