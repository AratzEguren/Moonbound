using UnityEngine;

public class PlataformaUpFinal : MonoBehaviour
{
    public Vector3 puntoA;
    public Vector3 puntoB;
    public float velocidad = 2f;
    private bool moviendoHaciaB = true;
    private bool isPlayerOnPlataform = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = puntoA;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOnPlataform){
            if(moviendoHaciaB){
                transform.position = Vector3.MoveTowards(transform.position,puntoB,velocidad*Time.deltaTime);
                if(transform.position == puntoB){
                    moviendoHaciaB = false;
                }
            }
        /* else
            {
                transform.position = Vector3.MoveTowards(transform.position,puntoA,velocidad*Time.deltaTime);
                if(transform.position == puntoA){
                    moviendoHaciaB = true;
                }
            }*/
        }

    }
           private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // Make the player a child of the platform
            collision.transform.SetParent(transform,true);
            isPlayerOnPlataform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player left the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detach the player from the platform
            collision.transform.SetParent(null);
            isPlayerOnPlataform = false;
        }
    }
}
