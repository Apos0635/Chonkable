using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Chonkable
{
    // Initialisierung der DLL
    public static void Initialise()
    {
        GameObject runner = new GameObject("Chonkable_Runtime");

        UnityEngine.Object.DontDestroyOnLoad(runner);

        runner.AddComponent<ChonkableRunner>();

        UnityEngine.Debug.Log("[Chonkable] Initialised.");
    }
}

public class ChonkableRunner : MonoBehaviour
{
    private IEnumerator Start()
    {
        UnityEngine.Debug.Log("[Chonkable] Waiting for tabletop...");

        while (true)
        {
            // RectTransform aufspüren und belästigen
            GameObject tableObject =
                GameObject.Find("TabletopBackground");

            if (tableObject != null)
            {
                RectTransform table =
                    tableObject.GetComponent<RectTransform>();

                // Jetzt auch noch die Kinder ;-;
                Transform leatherObject =
                    tableObject.transform.Find("Leather");

                RectTransform leather = leatherObject != null
                    ? leatherObject.GetComponent<RectTransform>()
                    : null;

                // Beim Warten habe ich Lust erschlagen zu werden mit Spaten
                if (table != null && leather != null)
                {
                    ApplyTabletopSettings(table);
                    ApplyLeatherSettings(leather);

                    UnityEngine.Debug.Log(
                        "[Chonkable] Tabletop and Leather settings applied."
                    );

                    yield break;
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ApplyTabletopSettings(RectTransform rect)
    {
        // Transform / RectTransform 914

        rect.localRotation = Quaternion.identity;

        rect.localScale = new Vector3(
            1.95f,
            1.8f,
            1.95f
        );

        rect.anchorMin = new Vector2(0f, 0f);
        rect.anchorMax = new Vector2(1f, 1f);

        rect.pivot = new Vector2(0.5f, 0.5f);

        rect.sizeDelta = new Vector2(
            0f,
            -100f
        );

        rect.anchoredPosition = new Vector2(
            0f,
            600f
        );
    }

    private void ApplyLeatherSettings(RectTransform rect)
    {
        // Transform / RectTransform 919

        rect.localRotation = Quaternion.identity;

        rect.localScale = new Vector3(
            1f,
            1f,
            1f
        );

        rect.anchorMin = new Vector2(0f, 0f);
        rect.anchorMax = new Vector2(1f, 1f);

        rect.pivot = new Vector2(0.5f, 0.5f);

        rect.sizeDelta = new Vector2(
            -275f,
            -275f
        );

        rect.anchoredPosition = new Vector2(
            0f,
            0f
        );
    }
}
