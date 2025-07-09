using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Config", menuName = "MyData/Config", order = 0)]
public class Config : ScriptableObject
{
    [field: SerializeField] public float[] PaddleBorders { get; private set; }
    [field: SerializeField] public float PaddleSpeed = 10f;
    [field: SerializeField] public float BallSpeed = 5f;
    [field: SerializeField] public List<BricksSetup> BricksLevelsSetup { get; private set; }
}