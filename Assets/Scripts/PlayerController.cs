using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 5f;
    private GameObject vfxGround;
    private GameObject vfxObstacle;
    private Rigidbody rb;
    private InputAction jumpAction;
    [SerializeField]private GameObject hitVfxGround;
    [SerializeField]private GameObject hitVfxObstacle;
    private bool isGrouned;
    public bool isGameOver;
    public static Action Overnow;

    void Awake()
    {
        isGameOver = false;
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && isGrouned && isGameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrouned = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Overnow?.Invoke();
            Debug.Log("Game Over");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrouned = false;
        }
    }
}
