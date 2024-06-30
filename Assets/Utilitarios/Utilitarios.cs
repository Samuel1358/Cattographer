using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public static class Utilitarios
{
    static public Vector3 IgnoreY(Vector3 vector)
    => Vector3.Scale(vector, Vector3.one - Vector3.up);

    static public IEnumerator Parabola(GameObject gameObject, Vector3 target, float height, float time)
    {
        float distance;
        Vector3 movement;
        {
            float heightDifference = gameObject.transform.position.y - target.y;
            if (heightDifference > height) height = heightDifference;

            distance = height + heightDifference;

            heightDifference = height - heightDifference;
            movement = Vector3.up * heightDifference;

            movement += (IgnoreY(target) - IgnoreY(gameObject.transform.position)) / 4;
        }

        Vector3 newPosition = gameObject.transform.position;
        while (movement.y > 0 || newPosition.y - target.y > 0)
        {
            movement += Vector3.down * (distance * 2 / time * Time.deltaTime);
            newPosition = gameObject.transform.position + (movement * 4 / time * Time.deltaTime);
            gameObject.transform.position = newPosition;

            yield return null;
        }

        gameObject.transform.position = target;
    }
}
