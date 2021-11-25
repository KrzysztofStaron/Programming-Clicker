using System.Collections.Generic;
using UnityEngine;
using System;
/*
[SerializeField]
[Header("text")]
[Range()]
[Tooltip("text")]
[RequireComponent(typeof(Tilemap))]
[TextArea(minLines: 0, maxLines: 5)]
*/
[Serializable]
public class Job
{
  public List<Task> tasks;
  public int taskNr = 0;
  public bool active = true;

  public string type; // work / learn

  public string salary;

  public Job(string jobType="", string revard="", List<Task> newTasks = null){
    tasks = newTasks;
    type = jobType;
    salary = ""+revard;
  }
}

[Serializable]
public class Task
{
  public string languageName = "";
  public int lines = 0;
  public int requiredLines = 500;

  public Task(string name = "", int lines = 500){
    languageName = name;
    requiredLines = lines;
    Debug.Log("Task created");
  }
}
