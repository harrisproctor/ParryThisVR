using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitProps : MonoBehaviour
{
    // 0 = none, er, 1 = rock, air = 2, fire = 3, 4 = water : tier 1 elements
    public int element;
    
    // 0 = none, 1 = shooting, 2 = beam, 3 = grenade
    public int shape;
}
