using System.Collections;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    [SerializeField] private Transform tongue; // La boca de la rana
    [SerializeField] private Transform tip;
    [SerializeField] private float tongueSpeed = 10f;
    [SerializeField] private float maxTongueLength = 5f;

    private Vector3 direction;
    private float currentLength = 0f;
    private bool isShooting = false;

    private void Awake()
    {
        tongue.gameObject.SetActive(false);
        tip.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            tongue.gameObject.SetActive(true);
            tip.gameObject.SetActive(true);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            direction = (mousePos - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            tongue.rotation = Quaternion.Euler(0, 0, angle);

            StartCoroutine(ExtendAndRetractTongue());
        }
    }

    IEnumerator ExtendAndRetractTongue()
    {
        isShooting = true;

        currentLength = 0f;

        while (currentLength < maxTongueLength)
        {
            currentLength += tongueSpeed * Time.deltaTime;
            UpdateTongueVisual(currentLength);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); // pausa opcional

        // Retractar
        while (currentLength > 0f)
        {
            currentLength -= tongueSpeed * Time.deltaTime;
            UpdateTongueVisual(currentLength);
            yield return null;
        }

        tongue.gameObject.SetActive(false);
        tip.gameObject.SetActive(false);
        isShooting = false;
    }

    void UpdateTongueVisual(float length)
    {
        tongue.localScale = new Vector3(length, tongue.localScale.y, tongue.localScale.z); // Suponiendo que tu sprite se estira en X
        tongue.localPosition = direction * (length / 2f);

        tip.position = tongue.position + tongue.right * (length / 2f);
    }
}