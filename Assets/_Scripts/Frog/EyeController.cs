using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Eye
{
    public SpriteRenderer outerEye;
    public SpriteRenderer innerEye;

    [HideInInspector] public Vector3 center;
    [HideInInspector] public float maxRadius;
}

public class EyeController : MonoBehaviour
{
    [SerializeField] private List<Eye> eyes = new List<Eye>();

    void Start()
    {
        foreach (var eye in eyes)
        {
            eye.center = eye.outerEye.transform.position;
            eye.maxRadius = eye.outerEye.bounds.size.x * 0.25f; // Ajustable
        }
    }

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        foreach (var eye in eyes)
        {
            Vector3 direction = mouseWorldPos - eye.center;

            if (direction.magnitude > eye.maxRadius)
                direction = direction.normalized * eye.maxRadius;

            eye.innerEye.transform.position = eye.center + direction;
        }
    }
}
