using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("GorGwangmin"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
            
    }

}
