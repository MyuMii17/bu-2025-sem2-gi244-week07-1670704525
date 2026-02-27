using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject obstaclePrefab;
    public PlayerController player;
    private bool isSpawn = true;
    void Awake()
    {
    }
    void Start()
    {
        GameObject go = GameObject.Find("Player");
        player = go.GetComponent<PlayerController>();
        StartCoroutine(Spawner());  
    }
    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            StartCoroutine(Spawner());
            // InvokeRepeating(nameof(Spawn),1,Random.Range(1,3));
        }
        else if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            isSpawn = !isSpawn;
        }
    }

    // void Spawn()
    // {
    //     Instantiate(
    //         obstaclePrefab,
    //         spawnPoint.position,
    //         obstaclePrefab.transform.rotation
    //     );
    // }
    IEnumerator Spawner()
    {
        while (player.isGameOver == false)
        {
            Instantiate(
                obstaclePrefab,
                spawnPoint.position,
                obstaclePrefab.transform.rotation
            );
            yield return new WaitForSeconds(Random.Range(4,8));
        }
    }
}
