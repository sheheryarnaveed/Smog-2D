using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_shake : MonoBehaviour {

    public static float shakeTimer;
    public float shakeAmount;
    public Light Thunder_Light;
    /* 

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 OriginalPos = transform.localPosition;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, OriginalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = OriginalPos;

    }*/

    private void Start()
    {
        ShakeCamera(0.3f, 5);
        Thunder_Light.enabled = true;
        StartCoroutine(LateCall_T());
    }

    void Update()
    {
        if(shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCamera(float shakePwr, float shakeDuration)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDuration;
    }

    IEnumerator LateCall_T()
    {
        yield return new WaitForSeconds(0.6F);
        Thunder_Light.enabled = false;
        yield return new WaitForSeconds(0.6F);
        Thunder_Light.enabled = true;
        yield return new WaitForSeconds(0.6F);
        Thunder_Light.enabled = false;
    }
}
