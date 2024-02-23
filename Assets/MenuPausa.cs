using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour

{
    [SerializeField] private GameObject ObjetoMenuPausa;
    private bool Pausa = false;

    [SerializeField] private GameObject MenuSalir;

    [SerializeField] private AudioSource musicAtmosphere;
    void Start()
    {
        // Aqu� puedes inicializar variables si es necesario
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                musicAtmosphere.Pause();
                

            }

            else if (Pausa == true)
            {
                Resumir();
            }

        }


    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        MenuSalir.SetActive(false);
        Pausa = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        musicAtmosphere.UnPause();
    }

    public void IraAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
















//public class MenuPausa : MonoBehaviour
//{
//    public GameObject ObjetoMenuPausa;
//    public bool Pausa = false;
//    public AudioSource musicaMenuPausa; // Agrega una referencia al AudioSource para la m�sica del men� de pausa

//    void Start()
//    {
//        // Inicializa la m�sica del men� de pausa
//        musicaMenuPausa.Play(); // Puedes reproducir la m�sica autom�ticamente al iniciar el men� de pausa
//        musicaMenuPausa.Pause(); // Pausa la m�sica inicialmente para que solo se reproduzca cuando se pausa el juego
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (!Pausa)
//            {
//                ObjetoMenuPausa.SetActive(true);
//                Pausa = true;

//                Time.timeScale = 0;
//                Cursor.visible = true;
//                Cursor.lockState = CursorLockMode.None;

//                AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

//                for (int i = 0; i < sonidos.Length; i++)
//                {
//                    sonidos[i].Pause();
//                }
//            }
//            else
//            {
//                Resumir();
//            }
//        }
//    }

//    //public void Resumir()
//    //{
//    //    ObjetoMenuPausa.SetActive(false);
//    //    Pausa = false;
//    //    Time.timeScale = 1;
//    //    Cursor.visible = false;
//    //    Cursor.lockState = CursorLockMode.Locked;

//    //    AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

//    //    for (int i = 0; i < sonidos.Length; i++)
//    //    {
//    //        // Reanudar todos los AudioSource que se pausaron durante la pausa del juego
//    //        sonidos[i].UnPause();

//    //        // Si el AudioSource es la m�sica del men� de pausa, lo detiene solo si se sale del men� de pausa
//    //        if (sonidos[i] == musicaMenuPausa && !Pausa)
//    //        {
//    //            sonidos[i].Stop();
//    //        }
//    //        else // Si no es la m�sica del men� de pausa o si a�n estamos en el men� de pausa, reanuda la m�sica
//    //        {
//    //            sonidos[i].Play();
//    //        }
//    //    }
//    //}


//    public void Resumir()
//    {
//        ObjetoMenuPausa.SetActive(false);
//        Pausa = false;
//        Time.timeScale = 1;
//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;

//        AudioSource[] sonidos = FindObjectsOfType<AudioSource>();

//        for (int i = 0; i < sonidos.Length; i++)
//        {
//            sonidos[i].Play();
//        }
//    }

//    public void IraAlMenu(string NombreMenu)
//    {
//        SceneManager.LoadScene(NombreMenu);
//    }

//    public void SalirDelJuego()
//    {
//        Application.Quit();
//    }
//}