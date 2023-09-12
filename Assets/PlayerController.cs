using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb2d;

    private bool IsinGround;
    public bool OpenPanel;

    private float speedPlayer = 7;
    private float jumpForce = 70;

    public GameObject panel;

    [SerializeField] private FMODUnity.StudioEventEmitter audioEmitter1;
    [SerializeField] private FMODUnity.StudioEventEmitter audioEmitter2;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        IsinGround = false;
        OpenPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsinGround == false)
        {
            jumpForce = 0;
            

        }

        if (IsinGround == true)
        {
            jumpForce = 70;
            
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(input.x, input.y = 0);
        transform.Translate(speedPlayer * Time.deltaTime * velocity);
    }

    private void OnEnable()
    {
        InputManager.OnMovement += Move;
        InputManager.OnJump += Jump;
        InputManager.onPause += Pause;
    }

    private void OnDisable()
    {
        InputManager.OnMovement -= Move;
        InputManager.OnJump -= Jump;
        InputManager.onPause -= Pause;


    }

    private void Move(Vector2 input)
    {
        this.input = input;
        if (IsinGround == true)
        {
            audioEmitter2.Play();
        }
        
    }

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("salto");
        

        if (IsinGround == true)
        {
            audioEmitter1.Play();
        }
    }

    private void Pause()
    {

        if (OpenPanel == false)
        {
            panel.SetActive(true);
            OpenPanel = true;
            Time.timeScale = 0f;
            
        }
        else
        {
            panel.SetActive(false);
            OpenPanel = false;
            Time.timeScale = 1f;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            IsinGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            IsinGround = false;
        }
    }
}
