using UnityEngine;

public class Alvo : MonoBehaviour
{
    // Referência ao componente Rigidbody2D do objeto para aplicar uma força
    public Rigidbody2D MeuRigidBody;

    // Vector 2 para definir a Força mínima e máxima no eixo X aplicada quando o objeto é criado
    public Vector2 VariacaoDeForca_X;

    // Vector 2 para definir a Força mínima e máxima no eixo Y aplicada quando o objeto é criado
    public Vector2 VariacaoDeForca_Y;

    // Booleana para definir se o alvo é um alvo ruim ou não
    public GameObject BalaoCaveira;

    // Referência ao script Cronometro para aumentar o tempo do cronômetro
    public contagemR1 cronometro;  // A referência ao script Cronometro

    // Quantos segundos serão adicionados ao cronômetro quando o jogador clicar no alvo
    public float tempoParaAdicionar = 5f;

    // Função chamada quando o objeto é inicializado na cena
    void Start()
    {
        // Adicionar força ao objeto quando ele é criado
        AdicionarForcaAoRigidBody();
    }

    // Função que adiciona uma força ao objeto
    void AdicionarForcaAoRigidBody()
    {
        // Declaração de uma variável local para definir a força aplicada no objeto
        Vector2 variacaoDeForca = new Vector2();

        // Randomização dos valores de força utilizando as variáveis VariacaoDeForca_X e VariacaoDeForca_Y
        variacaoDeForca.x = Random.Range(VariacaoDeForca_X.x, VariacaoDeForca_X.y);
        variacaoDeForca.y = Random.Range(VariacaoDeForca_Y.x, VariacaoDeForca_Y.y);

        // Aplicar força definida nas linhas anteriores ao RigidBody2D do objeto
        MeuRigidBody.AddForce(variacaoDeForca, ForceMode2D.Impulse);
    }

    // Identifica se o jogador clicou com o mouse no objeto
    void OnMouseDown()
    {
        // Se o script Cronometro está configurado corretamente
        if (cronometro != null)
        {
            // Aumenta o tempo do cronômetro (você pode ajustar o valor de "tempoParaAdicionar")
            cronometro.AdicionarTempo(tempoParaAdicionar);
        }

        // Checa a variável BalaoCaveira para saber se este objeto é um alvo ruim
        if (BalaoCaveira)
        {
            // Remove pontos do jogador se for um alvo ruim
            ContadorDePonto.Instance.AdicionarPontos(-3);
        }
        else
        {
            // Adiciona pontos ao jogador caso contrário
            ContadorDePonto.Instance.AdicionarPontos(1);
        }

        // Independente se é ou não um alvo ruim, destrói o objeto
        Destroy(gameObject);
    }
}