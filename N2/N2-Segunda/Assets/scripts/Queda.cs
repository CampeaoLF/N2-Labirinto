using UnityEngine;
using UnityEngine.SceneManagement;

public class Queda : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOver;
    void Start()
    {
        
    }

   
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("buraco"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void NextScene(string cena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(cena);
    }
}
