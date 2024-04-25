using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformConfig", menuName = "Craete Platform Config")]
public class PlatformConfig : ScriptableObject
{
    public float platformsSpeedMin;
    public float platformsSpeed;
    public float posXmax;
    public float posXmin;
}
