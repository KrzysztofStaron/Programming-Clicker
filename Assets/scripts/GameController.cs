using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] Job currentJob;
    [SerializeField] Slider slider;

    public string getLanguage(){
      if (currentJob.type == "") return "None";

      return currentJob.tasks[currentJob.taskNr].languageName;
    }

    public void onClick(){
      if (currentJob.type == "") return ;

      //  setup slider
      int maxValue = 0;
      foreach (Task task in currentJob.tasks) {
        maxValue += task.requiredLines;
      }
      slider.maxValue = maxValue;

      int value = 0;
      foreach (Task task in currentJob.tasks) {
        value += task.lines;
      }
      slider.value = value;

      currentJob.tasks[currentJob.taskNr].lines++;

      if (currentJob.tasks[currentJob.taskNr].lines >= currentJob.tasks[currentJob.taskNr].requiredLines) {
        Debug.Log($"Task Compleate nr: {currentJob.taskNr}");
        currentJob.taskNr++;

        //if last task
        if (currentJob.taskNr >= currentJob.tasks.Length) {
          switch (currentJob.type){
            case "work":
              addMoney(Int32.Parse(currentJob.salary));
              break;
            case "learn":
              addSkill(currentJob.salary);
              break;
            default:
              Debug.LogError($"Invalid value: {currentJob.type}. Expected: work or learn");
              break;
          }
          currentJob = null;
          return;
        }
      }
    }

    void addSkill(string name){
      Debug.LogWarning($"addSkill called name: {name}");
    }

    void addMoney(int count){
      Debug.LogWarning($"addMoney called count: {count}");
    }
}
