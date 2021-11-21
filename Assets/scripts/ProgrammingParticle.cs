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


[System.Serializable]
public class LanguageKeywords
{
    public string link;
    public int keywords;

    public static LanguageKeywords load(string patch)
    {
      TextAsset targetFile = Resources.Load<TextAsset>(path);
      return JsonUtility.FromJson<LanguageKeywords>(targetFile.text);
    }
}
