using UnityEngine;

public class MilfSounds : MonoBehaviour
{
    [SerializeField] public float _timePassed = 30f;
    [SerializeField] public bool _chasing = false;

    // Update is called once per frame
    void Update()
    {
        _timePassed= Time.deltaTime;

        if(_timePassed >= 30f && _chasing == false)
        {
            System.Action[] functions = { BansheeScream_01, BansheeScream_02, BansheeScream_03 };
            int randomIndex = Random.Range(0, functions.Length);
            functions[randomIndex].Invoke();
            _timePassed = 0f;
        }
    }

    void BansheeScream_01()
    {
        FindObjectOfType<AudioManager>().Play("Banshee_03");
    }

    void BansheeScream_02()
    {
        FindObjectOfType<AudioManager>().Play("Banshee_05");
    }

    void BansheeScream_03()
    {
        FindObjectOfType<AudioManager>().Play("Banshee_04");
    }


}
