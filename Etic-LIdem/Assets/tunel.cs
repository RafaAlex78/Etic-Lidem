using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunel : MonoBehaviour
{
    [SerializeField] Vector3 _initialScale;
    [SerializeField] Vector3 _finalScale;
    [SerializeField] float _duration = 2.0f;
    float _startTime;
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        transform.localScale = _initialScale;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - _startTime) / _duration;
        transform.localScale = Vector3.Lerp(_initialScale, _finalScale, t);
        
    }

    private void ChangeScale()
    {
    }
}
