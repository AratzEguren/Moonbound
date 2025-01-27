using UnityEngine;

public class PlataformaUp : MonoBehaviour
{
    public Vector3 puntoA;
    public Vector3 puntoB;
    public float velocidad = 2f;
    private bool moviendoHaciaB = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = puntoA;
    }

    // Update is called once per frame
    void Update()
    {
        if(moviendoHaciaB){
            transform.position = Vector3.MoveTowards(transform.position,puntoB,velocidad*Time.deltaTime);
            if(transform.position == puntoB){
                moviendoHaciaB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,puntoA,velocidad*Time.deltaTime);
            if(transform.position == puntoA){
                moviendoHaciaB = true;
            }
        }
    }
}
