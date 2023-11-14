using UnityEngine;
using UnityEngine.Serialization;

namespace Codigos.Audio
{
    public class AudioControlleFloresta : MonoBehaviour
    {
        public AudioSource audiosorcesMusicasDeFundo;
        [FormerlySerializedAs("MusicasDefundo")] public AudioClip[] musicasDefundo;
        public int _NumeroDAMusica;
        
        void Start()
        {
            AudioClip musicaDeFundoDessaFase = musicasDefundo[_NumeroDAMusica];
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
