using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float brilloMinimo = 0.5f; // Ajusta este valor seg�n tu preferencia
    public float brilloMaximo = 0.8f; // Ajusta este valor seg�n tu preferencia
    public Image panelBrillo;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", brilloMaximo); // Establece el valor predeterminado en el brillo m�ximo permitido
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        // Aqu� no hay c�digo en el m�todo Update. Si necesitas algo que se actualice cada frame, agr�galo aqu�.
    }

    // Este m�todo se llama cuando se cambia el valor del slider
    public void ChangeSlider(float valor)
    {
        slider.value = Mathf.Clamp(valor, brilloMinimo, brilloMaximo); // Limita el valor entre brilloMinimo y brilloMaximo
        PlayerPrefs.SetFloat("brillo", slider.value);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
    }
}
