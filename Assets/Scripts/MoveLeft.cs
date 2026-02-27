using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    public GameObject player;
    public PlayerController playerSet;
    bool isOver;
    void Awake()
    {
        isOver = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isOver==false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if(transform.position.x <= -3.5)
            {
                if (gameObject.CompareTag("Obstacle"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnEnable()
    {
        PlayerController.Overnow += Spanwer;
    }
    void Spanwer()
    {
        isOver = true;
    }
}
