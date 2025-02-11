using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IniciarJuego()
    {
    // Cargar la escena principal del juego
        SceneManager.LoadScene("MoonBound_level1");
    }
}
