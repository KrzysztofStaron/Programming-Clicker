using UnityEngine;
using UnityEngine.UI;

public class WorkAndLearnMenu : MonoBehaviour
{
  [SerializeField] GameObject menu;
  [SerializeField] GameObject WorkMenu;
  [SerializeField] GameObject LearnMenu;

  void start(){
    MenuState(false);
  }

  public void MenuState(bool state){
    menu.SetActive(state);
  }

  public void OpenTab(string name){
    /*
     name can be:
      -work
      -learn
    */
    switch (name){
      case "work":
        WorkMenu.SetActive(true);
        LearnMenu.SetActive(false);
        break;
      case "learn":
        WorkMenu.SetActive(false);
        LearnMenu.SetActive(true);
        break;
      default:
        Debug.LogError($"Invalid value: {name}. Expected: work or learn");
        break;
    }
  }
}
