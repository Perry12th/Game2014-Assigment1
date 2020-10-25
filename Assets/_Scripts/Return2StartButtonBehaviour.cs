
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return2StartButtonBehaviour : MonoBehaviour
{
    public void OnClicked()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSelect");
        SceneManager.LoadScene("Start");
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSelect");
    }
}
