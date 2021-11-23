using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable : MonoBehaviour
{
  private LineRenderer rl;
  [SerializeField] Transform point;
  [SerializeField] Vector3 upAnchor;

    void Awake()
    {
      rl = gameObject.GetComponent<LineRenderer>();
      rl.positionCount = 2;
    }

    void Update()
    {
      rl.SetPosition(0, point.position);
      rl.SetPosition(1, upAnchor);
    }
}
