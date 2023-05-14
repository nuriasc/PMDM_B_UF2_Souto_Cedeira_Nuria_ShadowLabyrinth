using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoorController : MonoBehaviour
{
    [SerializeField] float sensorDistance;
    [SerializeField] float openTime;
    AudioSource sfx;
    Vector3 openedPosition;
    Vector3 closedPosition;
    GameObject player;
    
    const float CHECK_PERIOD = 0.5f;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
        closedPosition = transform.position;
        openedPosition = closedPosition + new Vector3(4.1f, 0f, 0f);
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("DoCheck");
    }

    void Update()
    {
        
    }

    bool ProximityCheck()
    {
        if (Vector3.Distance(closedPosition, player.transform.position) < sensorDistance)
            return true;

        return false;
    }

    IEnumerator DoCheck()
    {
        float t;
        while(true)
        {
            if (ProximityCheck())
            {
                t = 0;
                sfx.Play();
                while (t < openTime)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(closedPosition, openedPosition, t/openTime);
                    yield return null;
                }
                while (ProximityCheck())
                    yield return new WaitForSeconds(2f);
                t = 0;
                sfx.Stop();
                sfx.Play();
                while (t < openTime)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(openedPosition, closedPosition, t/openTime);
                    yield return null;
                }
            }
            yield return new WaitForSeconds(CHECK_PERIOD);
        }
    }
}
