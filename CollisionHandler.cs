using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float finishDelayTime = 1f;
    [SerializeField] float crashDelayTime = 1f;
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip crashSound;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

   void OnCollisionEnter(Collision other)
   { 
       if (isTransitioning) {return;}
       
       switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Remember, you are humanity's last hope");
                break;
            case "Finish":
                Debug.Log("Keep up the good work. Perhaps humanity stands a chance after all.");
                FinishingSequence();
                break;
            default:
                Debug.Log("BOOOOM! You blew up");
                StartCrashSequence();
                break;
        }
    }

    void FinishingSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        //might want to work on volume and sounds
        audioSource.PlayOneShot(finishSound);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", finishDelayTime);
    }

    void LoadNextLevel()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        //might want to work on volume and sounds
        audioSource.PlayOneShot(crashSound);
        //todo add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", crashDelayTime);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}