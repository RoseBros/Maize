using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    //call any of these settings with PlayerSettings.setting
    [SerializeField] private float playerSpeed = 10f;
    public static float PlayerSpeed => Instance.playerSpeed;

    [SerializeField] private float lookSensitivity = 20f;
    public static float LookSensitivity => Instance.lookSensitivity;
    public static PlayerSettings Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
}
