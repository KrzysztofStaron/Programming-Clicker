using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Job currentJob;

    public string getLanguage(){
      return currentJob.tasks[currentJob.taskNr].languageName;
    }

    public void onClick(){
      currentJob.tasks[currentJob.taskNr].lines++;
      if (currentJob.tasks[currentJob.taskNr].lines >= currentJob.tasks[currentJob.taskNr].requiredLines) {
        Debug.Log("Task Compleate");
        if (currentJob.taskNr < currentJob.tasks.Length) {
          currentJob.taskNr++;
        }
      }
    }
}
