using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitória : MonoBehaviour
{
    public GameObject bola;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider b)
    {
       
        if (b.gameObject.CompareTag("Chegada"))
        {
            SceneManager.LoadScene("Vitoria");
        }
    }

}
