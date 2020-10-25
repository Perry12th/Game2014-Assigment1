using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButtonBehaviour : MonoBehaviour
{
    public void OnClicked()
    {
        Debug.Log("Clicked Start");
        FindObjectOfType<AudioManager>().StopPlaying("EndMusic");
        SceneManager.LoadScene("Play");
    }
}
