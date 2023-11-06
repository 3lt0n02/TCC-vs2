using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject objetoParaInstanciar;
    private float proximoTempoDeInstanciacao;
    [SerializeField] private float tempoMinimo = 1.0f; // Tempo mínimo de instanciação
    [SerializeField] private float tempoMaximo = 3.0f; // Tempo máximo de instanciação
    public Animator ani;
    private float tempoParaDesativarAttack = 0.5f; // Tempo para desativar o ataque (exemplo: 2 segundos)

    // ponto de Criação
    public Transform pontoDeInstancia;

    void Start()
    {
        // Defina o próximo tempo de instanciação para o início.
        proximoTempoDeInstanciacao = Time.time + Random.Range(tempoMinimo, tempoMaximo);
    }

    void Update()
    {
        // Verifique se o tempo atual é maior ou igual ao próximo tempo de instanciação.
        if (Time.time >= proximoTempoDeInstanciacao)
        {
            // Use a função Instantiate para criar uma cópia do objeto desejado.
            ani.SetBool("IsAttack", true);
            
            Instantiate(objetoParaInstanciar, pontoDeInstancia.position, pontoDeInstancia.rotation);
            
            StartCoroutine(DesativarAtaque(tempoParaDesativarAttack));

            // Atualize o próximo tempo de instanciação com base no intervalo definido.
            proximoTempoDeInstanciacao = Time.time + Random.Range(tempoMinimo, tempoMaximo);
        }
        
    }

    IEnumerator DesativarAtaque(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        ani.SetBool("IsAttack", false);
    }
}