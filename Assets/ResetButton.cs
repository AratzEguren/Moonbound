using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void ResetScene()
    {
        // Carga la escena llamada "SampleScene"
        SceneManager.LoadScene("interfaz");
    }
}
