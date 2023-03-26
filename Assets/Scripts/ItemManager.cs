using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;

    void Awake()
    {
        
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    public static ItemManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

  

    public IEnumerator Spawn(GameObject obj, float freq)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(freq);

        if (obj != null)
        {
            StartCoroutine(Spawn(obj, freq));
        }
        
    }

}