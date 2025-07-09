using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpaceObjectsHolder : MonoBehaviour
{
    [field: SerializeField] public Camera MainCamera { private set; get; }
    [field: SerializeField] public Transform PaddleStartPoint { private set; get; }
    [field: SerializeField] public Transform BricksHolder { private set; get; }
    [field: SerializeField] public BallView BallPrefab { get; private set; }
    [field: SerializeField] public PaddleView PuddlePrefab { get; private set; }
}
