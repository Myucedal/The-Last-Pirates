using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    public Material GloriousPink,BlueSunset,ColdSunset,DeepDusk, ColdNight, NightMoonBrust, OvercastLow, Space;

    private int currentSkyboxIndex = 0;
    private Material[] skyboxMaterials;
    private Dictionary<Material, float> skyboxDurations;

    void Start()
    {
        // Skybox materyallerini diziye ekleyelim
        skyboxMaterials = new Material[] { GloriousPink, BlueSunset, ColdSunset, DeepDusk, ColdNight, NightMoonBrust, OvercastLow, Space };

        // Her skybox materyali i�in s�releri belirleyelim
        skyboxDurations = new Dictionary<Material, float>
        {
            { GloriousPink, 5f },
            { ColdNight, 5f },
            { ColdSunset, 5f },
            { DeepDusk, 5f },
            { BlueSunset, 5f },
            { NightMoonBrust, 5f },
            { OvercastLow, 5f },
            { Space, 5f  }
        };

        // Coroutine'i ba�latal�m
        StartCoroutine(ChangeSkyboxRoutine());
    }

    private IEnumerator ChangeSkyboxRoutine()
    {
        while (true)
        {
            // Ge�erli skybox materyali i�in bekleme s�resini alal�m
            float waitTime = skyboxDurations[skyboxMaterials[currentSkyboxIndex]];

            // Belirli bir s�re bekle
            yield return new WaitForSeconds(waitTime);

            // Skybox materyalini de�i�tir
            ChangeSkybox();
        }
    }

    private void ChangeSkybox()
    {
        // Skybox materyalini de�i�tir
        RenderSettings.skybox = skyboxMaterials[currentSkyboxIndex];

        // Sonraki skybox materyaline ge�
        currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxMaterials.Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Manuel olarak skybox materyalini de�i�tir
            ChangeSkybox();
        }
    }
}
