using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Player reference - will refer to the player's position (oyuncu referansı - oyuncunun pozisyonuna referans verir)
    public float distance; // Default camera distance - controls the default distance between the camera and the target (varsayılan kamera mesafesi - kameranın hedefle arasındaki mesafeyi kontrol eder)
    public float height; // Camera height - sets how high the camera is above the target (kamera yüksekliği - kameranın hedefin üzerinde ne kadar yüksekte olduğunu belirler)
    public float zoomSpeed = 1f; // Speed of zooming - controls how fast the camera zooms in or out when the user presses the arrow keys (yakınlaştırma hızı - kullanıcı ok tuşlarına bastığında kameranın ne kadar hızlı yakınlaştığını veya uzaklaştığını kontrol eder)
    public Camera MainCamera; // Camera reference (attach the camera in the Inspector) (kamera referansı - Unity Inspector'da kamerayı ekleyin)

    void Start()
    {
        if (MainCamera == null)
            MainCamera = Camera.main; // If MainCamera is not assigned, set it to the main camera (MainCamera atanmadıysa, ana kameraya ayarla)
    }

    void Update()
    {
        if (target == null) return; // If there's no target, stop executing (hedef yoksa, işlem durur)

        // Zoom in with Up Arrow key (Yukarı ok tuşu ile yakınlaştır)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            distance -= zoomSpeed; // Zoom in (yakınlaştır)
            if (distance < 2f) distance = 0.5f; // Prevent the camera from getting too close (kameranın çok yakınlaşmasını engelle)
        }

        // Zoom out with Down Arrow key (Aşağı ok tuşu ile uzaklaştır)
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            distance += zoomSpeed; // Zoom out (uzaklaştır)
        }

        // Adjust camera position based on the target (hedefe göre kameranın pozisyonunu ayarla)
        transform.position = target.position + new Vector3(0, height, -distance);

        // Keep the camera looking at the player (kameranın oyuncuyu görmesini sağla)
        transform.LookAt(target);

        // Adjust field of view (FOV) to match the camera's distance for better visibility (görüş alanını (FOV) kameranın mesafesine göre ayarla, daha iyi görünürlük için)
        MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 60 + distance / 2, Time.deltaTime * 2);
    }
}