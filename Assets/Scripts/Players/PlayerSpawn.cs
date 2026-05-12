using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static Vector2 nextSpawnPosition;
    public static bool isSpawning = false;

    void Start()
    {
       
        if (isSpawning)
        {
            transform.position = nextSpawnPosition;
            isSpawning = false;
        }
    }
}