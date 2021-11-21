using System.Collections;
using UnityEngine;
using TMPro;

public class ProgrammingParticle : MonoBehaviour
{
  [SerializeField] GameObject textParticle;
  [SerializeField] Camera cam;
  [SerializeField] Transform parent;

    void OnMouseDown()
    {
      Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
      GameObject particle = Instantiate(textParticle, pos, Quaternion.identity);
      particle.transform.SetParent(parent);
      particle.transform.position = pos;
      particle.transform.localScale = new Vector3(1, 1, 1);
      TMP_Text text = particle.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
      text.text = LanguageKeywords.get("html");
    }
}

// 16 * 5 pompek
[System.Serializable]
public class LanguageKeywords
{
    public string link;
    public string[] keywords;

    public static string get(string lan)
    {
      TextAsset targetFile = Resources.Load<TextAsset>("json/"+lan);
      LanguageKeywords lk = JsonUtility.FromJson<LanguageKeywords>(targetFile.text);
      return lk.keywords[Random.Range(0, lk.keywords.Length)];
    }
}
