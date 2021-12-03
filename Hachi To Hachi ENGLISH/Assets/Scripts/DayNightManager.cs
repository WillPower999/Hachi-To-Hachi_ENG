using UnityEngine;
using System.Collections;

[ExecuteAlways]
public class DayNightManager : MonoBehaviour
{
    public Gradient AmbientColor;
    [SerializeField] public Skybox Day;
    [SerializeField] public Skybox Night;
    [SerializeField] public Skybox Awnusk;
    [SerializeField] private Light DirectionalLight;
    [SerializeField, Range(0, 24)] private float TimeOfDay;
    [SerializeField] public float slownessMultiplier;
    [SerializeField] private float Daytime;
    [SerializeField] private float Dawn;
    [SerializeField] private float Dusk;
    [SerializeField] private float NightFastForwardInSeconds;

    private void Update()
    {
        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime * (1/slownessMultiplier);
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }

        if (TimeOfDay < Dawn || TimeOfDay > Dusk)
        {
            StartCoroutine(NightSkip());
            //Global.Skybox.material = Night;

        }
        else if (TimeOfDay < Daytime || TimeOfDay > Daytime && TimeOfDay > Dawn || TimeOfDay < Dusk)
        {
            //Skybox.material = Awnusk;
        }
        else;
        {
            //Skybox.material = Day;
        }
        
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = AmbientColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 80f, 0));
        }
    }

    private IEnumerator NightSkip()
    {
        yield return new WaitForSeconds(NightFastForwardInSeconds);
        TimeOfDay = Dawn;
    }
}