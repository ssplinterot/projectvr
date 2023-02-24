using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class RowController : MonoBehaviour
{
    [SerializeField] private int timer;
    [SerializeField] private Texture sprite;
    public int _angle;
    public float _speed;
    private MeshRenderer _renderer;
    public enum Swape
    {
        right,
        left,
        up,
        down
    }
    public Swape _swape;


    private void Start()
    {
        _angle = Random.Range(0,4) * 90;
        _swape = _angle switch
        {
            0 => Swape.right,
            90 => Swape.up,
            180 => Swape.left,
            270 => Swape.down,
            _ => Swape.right
        };
        transform.localRotation = Quaternion.Euler(_angle,-90,90);
        _renderer = GetComponent<MeshRenderer>();
        StartCoroutine("FadeIn");
    }

    private void Update()
    {
        transform.localPosition += new Vector3(-1,0,0) * _speed * Time.deltaTime;
    }

    private async void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RoadPreEnd")
        {
            transform.GetComponent<MeshRenderer>().material.mainTexture = sprite;
          
        }
        
        if(other.tag == "RoadEnd")
        {
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeIn()
    {
        float a = 0;
        float maxA;
        Material material = _renderer.material;
        maxA = _renderer.material.color.a;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0);
        _renderer.material = material;
        while (a < maxA)
        {
            yield return new WaitForSeconds(0.02f);
            a += 0.03f;
            material.color = new Color(material.color.r, material.color.g, material.color.b, a);
            _renderer.material = material;
        }
    }
    IEnumerator FadeOut()
    {
        float a = _renderer.material.color.a;
        Material material = _renderer.material;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
        _renderer.material = material;
        while (a > 0)
        {
            yield return new WaitForSeconds(0.02f);
            a -= 0.1f;
            material.color = new Color(material.color.r, material.color.g, material.color.b, a);
            _renderer.material = material;
        }

        RoadContoller.Instance._rows.Remove(this);
        Destroy(gameObject);
    }
}
