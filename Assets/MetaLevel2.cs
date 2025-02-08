using UnityEngine;
public class MetaLevel2 : MonoBehaviour
{
void OnTriggerEnter(Collider other)
{
if (other.CompareTag("Player"))
{
Debug.Log("¡Has llegado a la meta! ¡Felicidades!");
}
}
}