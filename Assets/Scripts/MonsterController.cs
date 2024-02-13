using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player; // Asigna el objeto del jugador en el Inspector
    public float detectionRange = 10f;
    public float minDetectionDistance = 2f; // Distancia m�nima para detenerse
    public float speed = 3f;
    public Animator monsterAnimator; // Asigna el componente Animator en el Inspector

    void Update()
    {
        // Calcula la distancia entre el monstruo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador est� dentro del rango de visi�n
        if (distanceToPlayer <= detectionRange)
        {
            // Si la distancia es mayor que la distancia m�nima de detecci�n
            if (distanceToPlayer > minDetectionDistance)
            {
                // Orienta al monstruo hacia el jugador
                transform.LookAt(player);

                // Activa la animaci�n de caminar (Walk)
                monsterAnimator.SetBool("Walk", true);

                // Mueve al monstruo hacia el jugador
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                // Si la distancia es menor que la distancia m�nima, detiene al monstruo
                monsterAnimator.SetBool("Walk", false);
            }
        }
        else
        {
            // Si el jugador est� fuera del rango, detiene al monstruo
            monsterAnimator.SetBool("Walk", false);
        }
    }
}
