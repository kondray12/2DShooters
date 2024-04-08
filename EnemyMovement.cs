using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // —корость движени€ врага
    public float moveDistance = 4.0f; // –ассто€ние, на которое враг будет двигатьс€ вперед и назад

    private Vector3 originalPosition;
    private bool moveForward = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (moveForward)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // ѕроверка на достижение максимального рассто€ни€
        if (Vector3.Distance(originalPosition, transform.position) >= moveDistance)
        {
            // ѕомен€ть направление движени€
            moveForward = !moveForward;
        }
    }
}
