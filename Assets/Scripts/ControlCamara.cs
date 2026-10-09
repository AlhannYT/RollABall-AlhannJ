using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public GameObject Bola;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Bola.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Bola.transform.position + offset;
    }
}