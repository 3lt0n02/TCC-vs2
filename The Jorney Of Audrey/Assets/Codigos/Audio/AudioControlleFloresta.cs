using UnityEngine;

namespace Codigos.Audio
{
    public class AudioControlleFloresta : MonoBehaviour
    {
        public AudioSource audiosorcesMusicasDeFundo;
        public AudioClip[] MusicasDefundo;
        
        void Start()
        {
            AudioClip musicaDeFundoDessaFase = MusicasDefundo[0];
            audiosorcesMusicasDeFundo.clip = musicaDeFundoDessaFase;
            audiosorcesMusicasDeFundo.loop = true;
            audiosorcesMusicasDeFundo.Play();

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
