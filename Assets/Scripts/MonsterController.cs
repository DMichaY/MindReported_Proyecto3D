using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 120f; // Velocidad de rotaci�n
    public float idleTimeMin = 2f; // Tiempo m�nimo en segundos para estar quieto
    public float idleTimeMax = 5f; // Tiempo m�ximo en segundos para estar quieto
    public Animator monsterAnimator; // Asigna el componente Animator en el Inspector

    private float idleTimer; // Temporizador para estar quieto
    private bool isWalking; // Variable para rastrear si el monstruo est� caminando

    void Start()
    {
        // Inicializa el temporizador
        ResetIdleTimer();
    }

    void Update()
    {
        // Si el monstruo no est� caminando, decrementa el temporizador y decide caminar si llega a cero
        if (!isWalking)
        {
            idleTimer -= Time.deltaTime;

            if (idleTimer <= 0f)
            {
                DecideToWalk();
            }
        }
        else
        {
            // Si el monstruo est� caminando, mueve y rota el monstruo en una direcci�n aleatoria
            MoveAndRotateRandomly();

            // Decrementa el temporizador de caminar y decide quedarse quieto si llega a cero
            idleTimer -= Time.deltaTime;

            if (idleTimer <= 0f)
            {
                DecideToIdle();
            }
        }
    }

    void DecideToWalk()
    {
        // Decide aleatoriamente si el monstruo debe caminar
        isWalking = Random.Range(0f, 1f) > 0.5f;

        if (isWalking)
        {
            // Inicializa el temporizador de caminar
            ResetIdleTimer();

            // Activa la animaci�n de caminar (Walk)
            monsterAnimator.SetBool("Walk", true);
        }
        else
        {
            // Inicializa el temporizador de estar quieto (Idle)
            ResetIdleTimer();
        }
    }

    void DecideToIdle()
    {
        // Decide aleatoriamente si el monstruo debe estar quieto
        isWalking = Random.Range(0f, 1f) > 0.5f;

        if (!isWalking)
        {
            // Inicializa el temporizador de estar quieto (Idle)
            ResetIdleTimer();

            // Desactiva la animaci�n de caminar (Walk)
            monsterAnimator.SetBool("Walk", false);
        }
        else
        {
            // Inicializa el temporizador de caminar
            ResetIdleTimer();

            // Activa la animaci�n de caminar (Walk)
            monsterAnimator.SetBool("Walk", true);
        }
    }

    void MoveAndRotateRandomly()
    {
        // Mueve al monstruo en una direcci�n aleatoria
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rota el monstruo en una direcci�n aleatoria
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void ResetIdleTimer()
    {
        // Reinicia el temporizador de estar quieto (Idle) con un tiempo aleatorio
        idleTimer = Random.Range(idleTimeMin, idleTimeMax);
    }
}
