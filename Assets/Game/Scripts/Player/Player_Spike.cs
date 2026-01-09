using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpike : MonoBehaviour
{
    [Header("Settings - Tamanho")]
    [SerializeField] private float growthMultiplier = 2.5f;
    [SerializeField] private float actionDuration = 1f;

    [Header("Settings - Movimento")]
    [SerializeField] private Vector3 moveOffset = new Vector3(0f, 1f, 0f);
    
    [Header("References")]
    [SerializeField] private PlayerController playerController;

    private SpriteRenderer spriteRenderer;
    private bool isActing;
    
    private Vector3 originalScale;
    private Vector3 targetScale;
    
    private Vector3 startPos;
    private Vector3 targetPos;

    private float progress;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController ??= GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !isActing)
        {
            StartAction();
        }

        if (isActing)
        {
            progress += Time.deltaTime / actionDuration;

            if (progress < 0.5f)
            {
                float t = progress / 0.5f;
                
                transform.position = Vector3.Lerp(startPos, targetPos, t);
                transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            }
            else
            {
                float t = (progress - 0.5f) / 0.5f;
                
                transform.position = Vector3.Lerp(targetPos, startPos, t);
                transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
                
                if (progress >= 1f)
                {
                    EndAction();
                }
            }
        }
    }

    private void StartAction()
    {
        isActing = true;
        progress = 0f;
        
        originalScale = transform.localScale;
        targetScale = originalScale * growthMultiplier;

        startPos = transform.position;
        targetPos = startPos + moveOffset;

        if(playerController != null) playerController.enabled = false;
    }

    private void EndAction()
    {
        isActing = false;
        
        transform.localScale = originalScale;
        transform.position = startPos;
        
        if(playerController != null) playerController.enabled = true;
    }
}