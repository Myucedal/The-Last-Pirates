using UnityEngine;
using System.Collections.Generic;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [System.Serializable]
    public class ParticleEffect
    {
        public string name;
        public GameObject prefab;
    }

    [Header("Particle Effects List")]
    public List<ParticleEffect> particleEffects;

    private Dictionary<string, GameObject> particleDict;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeDictionary()
    {
        particleDict = new Dictionary<string, GameObject>();
        foreach (var effect in particleEffects)
        {
            if (!particleDict.ContainsKey(effect.name))
            {
                particleDict.Add(effect.name, effect.prefab);
            }
        }
    }

    /// <summary>
    /// Bir efekti world pozisyonunda çalıştır.
    /// </summary>
    public void Play(string effectName, Vector3 position, Quaternion rotation = default, float destroyAfter = 2f)
    {
        if (particleDict.ContainsKey(effectName))
        {
            GameObject effect = Instantiate(particleDict[effectName], position, rotation);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();

            if (ps != null)
                ps.Play();

            Destroy(effect, destroyAfter);
        }
        else
        {
            Debug.LogWarning("Effect not found: " + effectName);
        }
    }
}