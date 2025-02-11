using UnityEngine;
public class RespawnLevel2 : MonoBehaviour
{
    public float caidaLimite = 4f;
    public Vector3 respawnPlace;

    void Start()
    {
        if(respawnPlace == Vector3.zero)
        {
            respawnPlace = transform.position;
        }
    }

    void Update()
    {
        if(transform.position.y < caidaLimite)
        {
            respawn();
        }
    }

    void respawn()
    {
        transform.position = respawnPlace;
    }
}