using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] Job currentJob;

    public string getLanguage(){
      if (currentJob == null) return "None";
      
      return currentJob.tasks[currentJob.taskNr].languageName;
    }

    public void onClick(){
      if (currentJob == null){
        return ;
      }

      currentJob.tasks[currentJob.taskNr].lines++;
      if (currentJob.tasks[currentJob.taskNr].lines >= currentJob.tasks[currentJob.taskNr].requiredLines) {
        Debug.Log("Task Compleate");

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
              Debug.LogError($"Invalid value: {name}. Expected: work or learn");
              break;
          }
          return;
        }
        currentJob = null;
        currentJob.taskNr++;
      }
    }

    void addSkill(string name){
      Debug.LogWarning($"addSkill called name: {name}");
    }

    void addMoney(int count){
      Debug.LogWarning($"addMoney called count: {count}");
    }
}
