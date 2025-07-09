using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BricksSetup : MonoBehaviour
{
    public List<BrickViewBase> AllBricks { get; private set; }
    
    public void Init()
    {
        BrickViewBase[] bricks = transform.GetComponentsInChildren<BrickViewBase>();
        AllBricks = bricks.ToList();
    }
}
