using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Soul Card", fileName = "New Soul Card")]

public class CardScriptableObject : ScriptableObject
{
    public Texture SoulIcon;
    public int custo;
    public float cooldown;
    
}
