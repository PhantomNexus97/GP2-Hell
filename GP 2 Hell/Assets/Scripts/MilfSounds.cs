using UnityEngine;

public class MilfSounds : MonoBehaviour
{
    [SerializeField] public float _timePassed = 30f;
    [SerializeField] public bool _chasing = false;
    

    // Update is called once per frame
    void Update()
    {
        _timePassed= Time.deltaTime;

        if(_timePassed == 1f)
        {
            PlayRandomEnemySound();
            _timePassed = 0f;
        }
    }

    public void PlayRandomEnemySound()
    {
        int randomIndex = Random.Range(0, AudioManager.instance._enemySounds.Length);
        AudioManager.instance.Play(AudioManager.instance._enemySounds[randomIndex].Name);
        _timePassed = 30f;
    }


}
