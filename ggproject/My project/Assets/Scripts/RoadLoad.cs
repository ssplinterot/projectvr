using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class RoadLoad : MonoBehaviour
{
  public GameObject[] obj;
  public GameObject road;
  public int timer;
  public MeshRenderer rend;

    private async void Start()
    {
        await Task.Delay(timer); 
        road.SetActive(true);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        float a = 0;
        float maxA;
        Material material = rend.material;
        maxA = rend.material.color.a;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0);
        rend.material = material;
        while (a < maxA)
        {
            yield return new WaitForSeconds(0.05f);
            a += 0.03f;
            material.color = new Color(material.color.r, material.color.g, material.color.b, a);
            rend.material = material;
        }
    }
}

