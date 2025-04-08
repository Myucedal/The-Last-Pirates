using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance;

    public Vector3 WindDirection { get; private set; }
    public float WindStrength { get; private set; }

    [Header("Rüzgar Ayarları")]
    public float windChangeInterval = 20f;
    public float maxWindStrength = 20f;

    private float timer;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateNewWind();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= windChangeInterval)
        {
            GenerateNewWind();
            timer = 0;
        }
    }

    void GenerateNewWind()
    {
        WindDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        WindStrength = Random.Range(5f, maxWindStrength);
        Debug.Log($"Yeni Rüzgar: Yön {WindDirection}, Şiddet: {WindStrength}");
    }
}