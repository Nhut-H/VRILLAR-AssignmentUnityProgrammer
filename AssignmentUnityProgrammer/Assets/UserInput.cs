using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{
    [Header("GENERAL")]
    public string checkNull = "";
    [Header("FOR AUTO MANUAL TIME CALCULATE")]
    public string hourInput;
    public string minInput;
    private float hour, min, timeCal;
    public InputField InputHour;
    public InputField InputMin;
    private int startHour = 6;
    private int currentHour;
    public GameObject Sun;

    [Header("FOR AUTO TIME CALCULATE")]
    public Toggle auto;
    public float autoHour = 6, autoMin = 15, autoSec = 0;
    public bool isAuto = false;
    public GameObject autoPanel, mainBackground;
    public Text autoTime;
    public float YRotate;

    [Header("FOR COORDINATES")]
    public string lattitude;
    public string longitude;
    public float lattitude_Cal, longitude_Cal;
    public InputField InputLat, InputLon;
    public float angleY;
    private void Awake()
    {
        InputLat.text = "180";
        InputLon.text = "-30";
        InputHour.text = "6";
        InputMin.text = "15";
        ReadInputHour();
        ReadInputMinutes();
        ReadInputLattitude();
        ReadInputLongitude();
    }
    private void Update()
    {
        CheckNullInput();
        isAuto = auto.isOn;
        autoPanel.SetActive(isAuto);
        mainBackground.SetActive(!isAuto);
        InputTime();
        InputCoordinates();
    }
    public void ResetTimeAuto()
    {
        autoHour = 6;
        autoMin = 15;
    }
    public void ReadInputHour()
    {
        hour = 0;
        hourInput = InputHour.textComponent.text;
        hour = float.Parse(hourInput);
        if (hour >= 24 || hour <= 0)
        {
            hour = 0;
            InputHour.text = "0";
        }
        timeCal = hour + min;
        //Debug.Log(timeCal);
    }
    public void ReadInputMinutes()
    {
        min = 0;
        minInput = InputMin.textComponent.text;
        min = float.Parse(minInput);
        if (min >= 60 || min <= 0)
        {
            min = 0;
            InputMin.text = "0";
        }
        min = min/60;
        timeCal = hour + min;
        Debug.Log("H: "+timeCal);
    }
    public void ReadInputLattitude()
    {
        lattitude = InputLat.textComponent.text;
        lattitude_Cal = float.Parse(lattitude);
        if(lattitude_Cal < -180)
        {
            lattitude_Cal = -180;
            InputLat.text = lattitude_Cal.ToString();
        }
        if (lattitude_Cal > 180)
        {
            lattitude_Cal = 180;
            InputLat.text = lattitude_Cal.ToString();
        }
        angleY = Mathf.Atan2(longitude_Cal, lattitude_Cal) * Mathf.Rad2Deg;
        //Debug.Log("GOC Y"+angleY);
    }
    public void ReadInputLongitude()
    {
        longitude = InputLon.textComponent.text;
        longitude_Cal = float.Parse(longitude);
        if (longitude_Cal < -180)
        {
            longitude_Cal = -180;
            InputLon.text = longitude_Cal.ToString();
        }
        if (longitude_Cal > 180)
        {
            longitude_Cal = 180;
            InputLon.text = longitude_Cal.ToString();
        }
        angleY = Mathf.Atan2(longitude_Cal, lattitude_Cal) * Mathf.Rad2Deg;
        Debug.Log("GOC Y"+angleY);
    }
    public void InputTime()
    {
        if(isAuto == false)
        {
            Quaternion target = Quaternion.Euler(0, angleY, 0);
            Sun.transform.rotation = Quaternion.Slerp(transform.rotation, target, 1f);
            Sun.transform.Rotate(Vector3.right, (float)(timeCal - startHour) * 15f);
        }
        if(isAuto == true)
        {
            Time.timeScale = 100;
            autoSec += Time.deltaTime * 5;
            if(autoSec >= 60)
            {
                autoMin += 1;
                autoSec = 0;
            }
            if(autoMin >= 60)
            {
                autoHour += 1;
                autoMin = 0;
            }
            if (autoHour >= 24) autoHour = 0;
            autoTime.text = "Time(Giờ):      " + autoHour + " : " + autoMin;
            
            float autoHourCal = autoHour + (float)(autoMin / 60);
            Debug.Log(autoHourCal);
            Quaternion target = Quaternion.Euler(0, -20f, 0);
            Sun.transform.rotation = Quaternion.Slerp(transform.rotation, target, 100f);
            Sun.transform.Rotate(Vector3.right, (float)(autoHourCal - startHour) * 15f);
        }
    }
    public void InputCoordinates()
    {
        if(isAuto == false)
        {
            Quaternion target = Quaternion.Euler(0, angleY, 0);
            Sun.transform.rotation = Quaternion.Slerp(transform.rotation, target, 1f);
            Sun.transform.Rotate(Vector3.right, (float)(timeCal - startHour) * 15f);
        }
        else if(isAuto == true)
        {
            angleY = -20f;
        }
    }
    public void CheckNullInput()
    {
        if(InputHour.text == checkNull)
        {
            InputHour.text = "6";
        }
        if (InputMin.text == checkNull)
        {
            InputMin.text = "15";
        }
        if (InputLat.text == checkNull)
        {
            InputLat.text = "0";
        }
        if (InputLon.text == checkNull)
        {
            InputLon.text = "0";
        }

    }
    public void ResetApp()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void QuitApp()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
