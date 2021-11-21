using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingParticle : MonoBehaviour
{
  [SerializeField] GameObject textParticle;
  [SerializeField] Camera cam;
    void OnMouseDown()
    {
      Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
      pos.z = 0;
      GameObject particle = Instantiate(textParticle, pos, Quaternion.identity);
    }
}
