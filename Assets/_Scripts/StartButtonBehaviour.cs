using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("StartMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        Debug.Log("Clicked Start");
        FindObjectOfType<AudioManager>().StopPlaying("StartMusic");
        SceneManager.LoadScene("Play");
    }
}
