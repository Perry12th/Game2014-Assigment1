using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("EndMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnDestory()
    {
        FindObjectOfType<AudioManager>().StopPlaying("EndMusic");
    }
}
