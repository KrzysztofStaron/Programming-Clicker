using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    public Job currentJob;

    [Header("Slider: ")]
    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderObj;
    [SerializeField] int maxValue = 0;
    [SerializeField] int value = 1;

    public string getLanguage(){
      if (currentJob.type == "" || currentJob == null){
        return "None";
      } else {
        try {
          return currentJob.tasks[currentJob.taskNr].languageName;
        } catch {
          return "None";
        }
      }
    }

    void updateSlider(){
      sliderObj.SetActive(true);
      if (currentJob == null) {
        sliderObj.SetActive(false);
        return ;
      }

      maxValue = 0;
      foreach (Task task in currentJob.tasks) {
        maxValue += task.requiredLines;
      }

      slider.maxValue = maxValue;

      value = 1;
      foreach (Task task in currentJob.tasks) {
        value += task.lines;
      }
      slider.value = value;
    }

    public void onClick(){
      if (currentJob.type == "") return ;
      updateSlider();

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
          updateSlider();
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
