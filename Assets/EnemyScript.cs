using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{

    public bool isAir;

    public float speedatYou = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAir == false)
        {
            transform.position -= transform.right * speedatYou * Time.deltaTime;
        }

        if (isAir == true)
        {
            transform.position += transform.right * speedatYou * Time.deltaTime;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("Pared"))
        {

            gameObject.SetActive(false);
        }


    }
}
