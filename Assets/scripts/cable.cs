using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable : MonoBehaviour
{
  private LineRenderer rl;
  [SerializeField] Transform[] points;

    void Awake()
    {
      rl = gameObject.GetComponent<LineRenderer>();
      rl.positionCount = 2;

      if (points.Length < 2) {
        Debug.LogError("Points Aren't Set Up!, cable.cs");
      }
    }

    void Update()
    {
      rl.SetPosition(0, points[0].position);
      rl.SetPosition(1, points[1].position);
    }
}
