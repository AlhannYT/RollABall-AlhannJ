using System.Collections; // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class BolaScript : MonoBehaviour
{
    public float velocidad = 7f;
    private Rigidbody rb;

    [Header("UI - TextMeshPro")]
    public TextMeshProUGUI textoCantidad;
    public TextMeshProUGUI textoGanar;
    public TextMeshProUGUI textoTimer;

    [Header("Configuración")]
    public int totalColeccionables = 18;
    private int contador = 0;
    public float tiempoRestante = 60f;

    private bool juegoTerminado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        contador = 0;
        ActualizarTextoContador();

        if (textoGanar != null)
            textoGanar.text = "";
    }

    void Update()
    {
        if (juegoTerminado) return;

        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (textoTimer != null)
                textoTimer.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }
        else
        {
            tiempoRestante = 0;
            if (textoTimer != null)
                textoTimer.text = "Tiempo: 0s";
            Derrota();
        }
    }

    private void FixedUpdate()
    {
        if (juegoTerminado) return;

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        rb.AddForce(movimiento * velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (juegoTerminado) return;

        if (other.gameObject.CompareTag("Recolectable") || other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);

            contador = contador +1;
            ActualizarTextoContador();

            if (contador >= totalColeccionables)
            {
                Victoria();
            }
        }
    } 

    void ActualizarTextoContador()
    {
        if (textoCantidad != null)
            textoCantidad.text = "Puntos: " + contador.ToString();
    }

    void Victoria()
    {
        juegoTerminado = true;
        DetenerFisicas();
        if (textoGanar != null)
            textoGanar.text = "¡HAS GANADO!";
        StartCoroutine(VolverAlMenuTrasEspera());
    }

    void Derrota()
    {
        juegoTerminado = true;
        DetenerFisicas();
        if (textoGanar != null)
            textoGanar.text = "¡TIEMPO AGOTADO!\nHAS PERDIDO";
        StartCoroutine(VolverAlMenuTrasEspera());
    }

    void DetenerFisicas()
    {
        // En Unity 6 se usa linearVelocity; en versiones previas se usa velocity
        #if UNITY_6000_0_OR_NEWER
                rb.linearVelocity = Vector3.zero;
        #else
                rb.velocity = Vector3.zero;
        #endif
                rb.angularVelocity = Vector3.zero;
    }

    IEnumerator VolverAlMenuTrasEspera()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MenuPrincipal");
    }
}