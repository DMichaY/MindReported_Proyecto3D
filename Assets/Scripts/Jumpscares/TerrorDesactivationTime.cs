using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorDesactivationTime : MonoBehaviour
{
    public GameObject objetoParaActivar;
    public AudioClip sonidoActivacion;
    public float tiempoDeVida = 5f; // Tiempo en segundos antes de que el objeto desaparezca

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el objeto
            if (objetoParaActivar != null)
            {
                objetoParaActivar.SetActive(true);
            }

            // Reproducir el sonido
            if (sonidoActivacion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoActivacion, transform.position);
            }

            // Desactivar el collider para evitar activaciones m�ltiples
            GetComponent<BoxCollider>().enabled = false;

            // Programar la desactivaci�n despu�s de cierto tiempo
            Invoke("DesactivarObjeto", tiempoDeVida);
        }
    }

    // M�todo para desactivar el objeto
    private void DesactivarObjeto()
    {
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(false);
        }
    }
}