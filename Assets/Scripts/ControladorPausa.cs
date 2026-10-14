using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPausa : MonoBehaviour
{
    [Header("Referencia al contenedor visual")]
    public GameObject panelVisualPausa;

    void Start()
    {
        Time.timeScale = 1f;
        if (panelVisualPausa != null)
        {
            panelVisualPausa.SetActive(false);
        }
    }

    public void Pausar()
    {
        if (panelVisualPausa != null) panelVisualPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        if (panelVisualPausa != null) panelVisualPausa.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrAOpciones()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Opciones");
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}