using UnityEngine;

public class giroscopio : MonoBehaviour
{
    Gyroscope gyro;

    void Start()
    {
       gyro = Input.gyro;
       gyro.enabled = true;

       
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 200;

        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.2f, Screen.width * 0.8f, Screen.height * 0.1f), "Gyro rotation rate" + gyro.rotationRate);
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.1f), "Gyro Attitude: " + gyro.attitude);
        GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0f, Screen.width * 0.8f, Screen.height * 0.1f), "Gyro enabled: " + gyro.enabled);
    }

}
