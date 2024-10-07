using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller; // Componente para controlar o movimento do personagem
    private Transform myCamera; // Referência à transformação da câmera principal
    private Animator animator; // Componente para controlar as animações do personagem
    private Vector3 initialPosition;
    // Inicialização de componentes
    private void Start()
    {
        controller = GetComponent<CharacterController>(); // Obtém o componente CharacterController do GameObject
        myCamera = Camera.main.transform; // Atribui a transformação da câmera principal
        animator = GetComponent<Animator>(); // Obtém o componente Animator do GameObject
        initialPosition = transform.position; // Armazena a posição inicial do Player
    }


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Obtém o input horizontal (A, D, esquerda, direita)
        float vertical = Input.GetAxis("Vertical"); // Obtém o input vertical (W, S, cima, baixo)
        Vector3 movimento = new Vector3(horizontal, 0, vertical); // Cria um vetor de movimento baseado nos inputs

        movimento = myCamera.TransformDirection(movimento); // Ajusta o vetor de movimento para corresponder à orientação da câmera
        movimento.y = 0; // Garante que não há movimento no eixo Y (vertical)

        controller.Move(movimento * Time.deltaTime * 5f); // Aplica o movimento ao personagem
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime); // Aplica gravidade ao personagem

        // Rotação do personagem para enfrentar a direção do movimento
        if (movimento != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        }

        animator.SetBool("isRunning", movimento != Vector3.zero); // Ativa a animação de movimento se houver deslocamento
    }
}