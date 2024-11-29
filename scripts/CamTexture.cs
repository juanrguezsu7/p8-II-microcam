using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTexture : MonoBehaviour
{
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string savePath = "Assets/Snapshots/";
    private int captureCounter = 1;

    void Start()
    {
        if (WebCamTexture.devices.Length > 0) {
            WebCamDevice device = WebCamTexture.devices[0]; // Selecciona la primera cámara
            webcamTexture = new WebCamTexture(device.name, 640, 480, 30);
            Debug.Log("Cámara seleccionada: " + device.name);
        }
        else {
            Debug.LogWarning("No se encontró ninguna cámara web.");
            webcamTexture = new WebCamTexture(640, 480, 30);
        }
        tvMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.S)) {
            tvMaterial.mainTexture = webcamTexture;
            webcamTexture.Play();
         }
          if (Input.GetKeyDown(KeyCode.P)) {
              tvMaterial.mainTexture = null;
              webcamTexture.Stop();
          }
          if (Input.GetKeyDown(KeyCode.X)) {
              Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
              snapshot.SetPixels(webcamTexture.GetPixels());
              snapshot.Apply();
              System.IO.File.WriteAllBytes(savePath + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
              captureCounter++;
          }
    }
}
