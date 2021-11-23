using UnityEngine;

public class coin : MonoBehaviour
{
    public void interact()
    {
      GetComponent<Animator>().SetTrigger("interact");
    }
}
