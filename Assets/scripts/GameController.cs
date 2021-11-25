using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using TMPro;

public class GameController : MonoBehaviour
{
    public Job currentJob;

    [Header("Slider: ")]
    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderObj;
    [SerializeField] int maxValue = 0;
    [SerializeField] int value = 0;

    [Header("Coins: ")]
    [SerializeField] int coins = 0;
    [SerializeField] List<Task> newTasks;
    [SerializeField] TMP_Text coinsCointer;

    public string getLanguage(){
      if (currentJob.type == ""){
        return "None";
      } else {
        try {
          return currentJob.tasks[currentJob.taskNr].languageName;
        } catch {
          return "None";
        }
      }
    }

    void Update(){
      updateSlider();
      coinsCointer.text = ""+coins;
    }

    void updateSlider(){
      sliderObj.SetActive(true);
      if (currentJob.type == "") {
        sliderObj.SetActive(false);
        return ;
      }

      maxValue = 0;
      foreach (Task task in currentJob.tasks) {
        maxValue += task.requiredLines;
      }

      slider.maxValue = maxValue - 1;

      value = 0;
      foreach (Task task in currentJob.tasks) {
        value += task.lines;
      }
      slider.value = value;
    }

    public void onClick(){
      if (currentJob.type == "") return ;

      currentJob.tasks[currentJob.taskNr].lines++;

      if (currentJob.tasks[currentJob.taskNr].lines >= currentJob.tasks[currentJob.taskNr].requiredLines) {
        Debug.Log($"Task Compleate nr: {currentJob.taskNr}");
        currentJob.taskNr++;

        //if last task
        if (currentJob.taskNr >= currentJob.tasks.Count) {
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
          currentJob = new Job();
          return;
        }
      }
    }

    public void newJob(string lan){
      newTasks[0] = new Task(lan, 100);

      currentJob = new Job("work", "100", newTasks);
    }

    void addSkill(string name){
      Debug.LogWarning($"addSkill ({name})");
    }

    void addMoney(int count){
      Debug.Log($"addMoney ({count})");
      coins += count;
    }
}
