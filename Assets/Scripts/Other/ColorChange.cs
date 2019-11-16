using System.Collections;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private float _timeDelay;

    void OnEnable() => 
        StartCoroutine(Run(_timeDelay, GetComponent<SpriteRenderer>()));

    private IEnumerator Run(float timeDelay, SpriteRenderer sRender)
    {
        var nextColor = new Color();
        
        while (true)
        {
            nextColor = Random.ColorHSV();
            
            for (float t = 0; t < timeDelay; t += Time.deltaTime)
            {
                sRender.color = Color.Lerp(sRender.color, nextColor, t / timeDelay);
                yield return null;
            }
        }
    }

}
