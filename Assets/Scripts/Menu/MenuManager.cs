using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles / Canvases")]
    public GameObject Inicio;
    public GameObject Pausa;
    public GameObject SelectorNiveles;

    void Start()
    {
        Time.timeScale = 1f;

        if (Inicio != null) Inicio.SetActive(true);
        if (Pausa != null) Pausa.SetActive(false);
        if (SelectorNiveles != null) SelectorNiveles.SetActive(false);
    }

    public void Jugar()
    {
        if (Inicio != null) Inicio.SetActive(false);
        if (Pausa != null) Pausa.SetActive(false);
        if (SelectorNiveles != null) SelectorNiveles.SetActive(true);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrAOpciones()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Opciones");
    }

    public void Pausar()
    {
        if (Pausa != null) Pausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        if (Pausa != null) Pausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IrANiveles()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void CargarNivel(string nombreNivel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreNivel);
    }

    public void CargarNivel1() { Time.timeScale = 1f; SceneManager.LoadScene("Juego"); }
    public void CargarNivel2() { Time.timeScale = 1f; SceneManager.LoadScene("JuegoNivel2"); }
    public void CargarNivel3() { Time.timeScale = 1f; SceneManager.LoadScene("JuegoNivel3"); }
    public void CargarNivel4() { Time.timeScale = 1f; SceneManager.LoadScene("JuegoNivel4"); }
    public void CargarNivel5() { Time.timeScale = 1f; SceneManager.LoadScene("JuegoNivel5"); }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}