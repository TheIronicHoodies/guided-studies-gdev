using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Day_Cycle_Script : MonoBehaviour
{
    public Light2D lightSource;
    private Color32 day = new Color32(255, 255, 255, 255);
    private Color32 night = new Color32(35, 36, 58, 255);
    private float scale, duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightSource = GetComponent<Light2D>();
        duration = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        scale = Mathf.PingPong(Time.time, duration) / duration;
        lightSource.color = Color.Lerp(day, night, scale);
    }
}
