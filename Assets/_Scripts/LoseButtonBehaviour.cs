using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("EndMusic");
    }

    public void OnClicked()
    {
        FindObjectOfType<AudioManager>().StopPlaying("EndMusic");
        SceneManager.LoadScene("Start");
    }

   
}
