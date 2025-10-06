using UnityEngine;
using TMPro;

public class BotonEspaciador : MonoBehaviour
{
    public Esfera sp; // Script que maneja las esferas
    public float timeLimit = 10f; // Tiempo total del juego

    public GameObject canvasJuego;   // Canvas activo durante el juego
    public GameObject canvasFinal;   // Canvas que se muestra al terminar
    public TMP_Text textoCuentaAtras; // Texto para mostrar la cuenta regresiva
    public TMP_Text textoContador;    // Texto que mostrará solo el número
    public TMP_Text textoFinal;       // Texto específico para el canvas final

    private float timer;
    private bool gameActive = true;
    private int contador = 0;

    void Start() //Qué vemos nada más printear la pantalla
    {
        timer = timeLimit;

        // Si el canvas no está activo y tiene una variable, se activa, de ahí el != null
        if (canvasJuego != null) canvasJuego.SetActive(true);
        if (canvasFinal != null) canvasFinal.SetActive(false);

        // Mostrar el tiempo inicial en pantalla
        if (textoCuentaAtras != null)
            textoCuentaAtras.text = Mathf.CeilToInt(timer).ToString();

        // Inicializar contador
        if (textoContador != null)
            textoContador.text = contador.ToString();
    }

    void Update()
    {
        if (!gameActive) return; //Si el juego no está activo, no se hace nada

        // Reducir el timer cada frame, es decir, aplicar el contador
        timer -= Time.deltaTime;

        // Evitar que timer sea negativo
        if (timer <= 0)
            timer = 0;

        // Actualizar el texto de cuenta regresiva
        if (textoCuentaAtras != null)
            textoCuentaAtras.text = Mathf.CeilToInt(timer).ToString();

        // Detectar pulsación de la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sp.SpawnSphere(); //Ponemos sp. ya que es un Spawner
            contador++;

            // Actualizar contador en pantalla
            if (textoContador != null)
                textoContador.text = contador.ToString();
        }

        // Cuando se acabe el tiempo, finalizar juego
        if (timer <= 0)
        {
            gameActive = false;
            ActivarCanvasFinal();
        }
    }

    void ActivarCanvasFinal()
    {
        if (canvasJuego != null) canvasJuego.SetActive(false);
        if (canvasFinal != null)
        {
            canvasFinal.SetActive(true);

            // Mostrar el contador final en el texto específico del canvas final
            if (textoFinal != null)
                textoFinal.text = contador.ToString();
        }
    }
}


