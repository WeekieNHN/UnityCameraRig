using UnityEngine;
using System.Collections;

public class CameraItemSwitcher : MonoBehaviour
{
    public GameObject[] objects;
    public float activationDuration = 2.0f;

    private int currentIndex = 0;

    void Start()
    {
        if (objects.Length > 0)
        {
            StartCoroutine(ActivateObjects());
        }
    }

    IEnumerator ActivateObjects()
    {
        while (true)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == currentIndex);
            }

            yield return new WaitForSeconds(activationDuration);

            currentIndex = (currentIndex + 1) % objects.Length;
        }
    }
}

