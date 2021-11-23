using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Job currentJob;

    public string getLanguage(){
      return currentJob.tasks[currentJob.taskNr].languageName;
    }
}
