using UnityEngine;
using System.Collections;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 50f; // Velocidade de subida
    public float fadeDuration = 1.5f; // Duração do fade
    private TextMeshProUGUI textComponent;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void ShowMessage(string message)
    {
        textComponent.text = message;
        StartCoroutine(FadeAndMove());
    }

    private IEnumerator FadeAndMove()
    {
        float elapsedTime = 0f;
        Color originalColor = textComponent.color;
        Vector3 originalPosition = transform.position;

        while (elapsedTime < fadeDuration)
        {
            // Movimento para cima
            transform.position = originalPosition + Vector3.up * (moveSpeed * elapsedTime);

            // Desvanecer o texto
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject); // Destrói o texto após o fade
    }
}
