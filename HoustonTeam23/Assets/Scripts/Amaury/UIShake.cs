using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShake : MonoBehaviour
{
    public static UIShake instance;
    public RectTransform rectTransform;

    public void Awake()
    {
        instance = this;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {

        Vector3 originalPos = rectTransform.anchoredPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            rectTransform.anchoredPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;
            // before we continue on the next iteration of the coroutine we wait until the next frame is drawn
            yield return null;
        }

        rectTransform.anchoredPosition = originalPos;
    }
}
