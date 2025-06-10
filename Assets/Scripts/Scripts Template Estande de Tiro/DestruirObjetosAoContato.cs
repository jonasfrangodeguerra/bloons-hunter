using UnityEngine;

public class DestruirObjetosAoContato : MonoBehaviour
{
    // Método que identifica quando outro objeto entra no collisor deste objeto 
    // (Este colisor precisa estar configurado como 'Trigger')
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Destrói o objeto que colidiu com este colisor
        Destroy(collision.gameObject);
    }
}
