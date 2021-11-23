using UnityEngine;
using System;

[Serializable]
public class Job
{
  public Task[] tasks;
  public string type; // work / learn

  public string salary;

  public Job(string jobType, string revard){
    switch (jobType){
      case "work":
        salary = ""+revard;
        break;
      case "learn":
        salary = revard;
        break;
      default:
        Debug.LogError($"Invalid value: {jobType}. Expected: work or learn");
        break;
      }
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
  }
}
