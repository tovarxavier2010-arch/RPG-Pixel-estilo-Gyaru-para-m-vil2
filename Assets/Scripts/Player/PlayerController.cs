using UnityEngine;

/// <summary>
/// Controlador del jugador - Movimiento en grid y acciones
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int gridSize = 1;
    
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Vector2 lastInputDirection = Vector2.zero;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        HandleInput();
        MoveTowardsTarget();
    }

    private void HandleInput()
    {
        // Entrada táctil para móvil
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HandleTouchInput(touch.position);
            }
        }

        // Entrada de teclado (para desarrollo)
        #if UNITY_EDITOR
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        if ((horizontal != 0 || vertical != 0) && !isMoving)
        {
            MoveInDirection(new Vector2(horizontal, vertical));
        }
        #endif
    }

    private void HandleTouchInput(Vector2 touchPos)
    {
        // Convertir posición táctil a dirección relativa
        Ray ray = Camera.main.ScreenPointToRay(touchPos);
        
        // Raycast para detectar dirección
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 touchDelta = touchPos - screenCenter;
        
        if (Mathf.Abs(touchDelta.x) > Mathf.Abs(touchDelta.y))
        {
            MoveInDirection(touchDelta.x > 0 ? Vector2.right : Vector2.left);
        }
        else
        {
            MoveInDirection(touchDelta.y > 0 ? Vector2.up : Vector2.down);
        }
    }

    private void MoveInDirection(Vector2 direction)
    {
        if (!isMoving)
        {
            targetPosition = transform.position + new Vector3(direction.x, direction.y, 0) * gridSize;
            isMoving = true;
        }
    }

    private void MoveTowardsTarget()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}