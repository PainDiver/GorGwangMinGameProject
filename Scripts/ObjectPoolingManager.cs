using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;

    public GameObject m_goPrefab = null;

    public Queue<GameObject> m_queue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for (int i = 0; i < 500; i++)
        {
            GameObject t_object = Instantiate(m_goPrefab, Vector3.zero, Quaternion.Euler(Random.Range(0, 45f), Random.Range(0, 45f), Random.Range(0, 45f)));
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject p_object)
    {
        Debug.Log("enque activated");
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }

}
