using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadContoller : MonoBehaviour
{
    public Transform _spawn;
    public GameObject _row;
    public List<RowController> _rows = new List<RowController>();
    public static RoadContoller Instance;
    public float minTime;
    public float maxTime;
    private float time;
    [SerializeField] private GameObject _particles;
    [SerializeField] private Texture[] _sprites;


    private void Awake() => Instance = this;

    private void Update()
    {
        if (time <= 0)
        {
            var row = Instantiate(_row, _spawn.position, Quaternion.identity, transform).GetComponent<RowController>();
            row._road = this;
            row.sprite = _sprites;
            time = Random.Range(minTime, maxTime);
        }
        time -= Time.deltaTime;

        if (_rows.Count > 0)
            print(_rows[0]._swape);
    }

    public void OnSwape(RowController.Swape swape)
    {
        if (_rows.Count > 0 && swape == _rows[0]._swape)
        {
            Instantiate(_particles, _rows[0].transform.position, Quaternion.identity);
            var row = _rows[0];
            _rows.Remove(row);
            Destroy(row.gameObject);
        }
    }
}
