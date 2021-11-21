using System.Collections;
using UnityEngine;
using TMPro;

public class ProgrammingParticle : MonoBehaviour
{
  [SerializeField] GameObject textParticle;
  [SerializeField] Camera cam;
  [SerializeField] TextAsset targetFile
    void OnMouseDown()
    {
      Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
      pos.z = 0;
      GameObject particle = Instantiate(textParticle, pos, Quaternion.identity);
      Debug.Log(LanguageKeywords.load("json/html.json").keywords[4]);
    }
}

// 6 * 5 pompek
[System.Serializable]
public class LanguageKeywords
{
    public string link;
    public int keywords;

    public static LanguageKeywords load(string patch)
    {
      TextAsset targetFile = Resources.Load<TextAsset>(patch);
      return JsonUtility.FromJson<LanguageKeywords>(targetFile.text);
    }
}
