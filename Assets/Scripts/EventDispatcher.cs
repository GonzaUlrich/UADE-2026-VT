using UnityEngine;
using UnityEngine.Events;

// Eventos personalizados que pasan información del Collider/Collision al inspector
[System.Serializable] public class Collision2DEvent : UnityEvent<Collision2D> { }
[System.Serializable] public class Collider2DEvent : UnityEvent<Collider2D> { }

public class EventDispatcher : MonoBehaviour
{
    [Header("Filtro opcional por Tag (dejar vacío para no filtrar)")]
    public string filterTag = "";


    // ---------------- COLISIONES 2D ----------------
    [Header("Colisiones 2D")]
    public Collision2DEvent onCollisionEnter2D;
    public Collision2DEvent onCollisionStay2D;
    public Collision2DEvent onCollisionExit2D;

    // ---------------- TRIGGERS 2D ----------------
    [Header("Triggers 2D")]
    public Collider2DEvent onTriggerEnter2D;
    public Collider2DEvent onTriggerStay2D;
    public Collider2DEvent onTriggerExit2D;

    // ---------------- CICLO DE VIDA ----------------
    [Header("Ciclo de Vida")]
    public UnityEvent onAwake;
    public UnityEvent onStart;
    public UnityEvent onEnableEvent;
    public UnityEvent onDisableEvent;
    public UnityEvent onDestroyEvent;

    // =========================================================
    // CICLO DE VIDA
    // =========================================================
    private void Awake() => onAwake?.Invoke();
    private void Start() => onStart?.Invoke();
    private void OnEnable() => onEnableEvent?.Invoke();
    private void OnDisable() => onDisableEvent?.Invoke();
    private void OnDestroy() => onDestroyEvent?.Invoke();



    // =========================================================
    // COLISIONES 2D
    // =========================================================
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (PassesFilter(c.gameObject)) onCollisionEnter2D?.Invoke(c);
    }
    private void OnCollisionStay2D(Collision2D c)
    {
        if (PassesFilter(c.gameObject)) onCollisionStay2D?.Invoke(c);
    }
    private void OnCollisionExit2D(Collision2D c)
    {
        if (PassesFilter(c.gameObject)) onCollisionExit2D?.Invoke(c);
    }

    // =========================================================
    // TRIGGERS 2D
    // =========================================================
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (PassesFilter(c.gameObject)) onTriggerEnter2D?.Invoke(c);
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        if (PassesFilter(c.gameObject)) onTriggerStay2D?.Invoke(c);
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (PassesFilter(c.gameObject)) onTriggerExit2D?.Invoke(c);
    }

    // =========================================================
    // FILTRO POR TAG
    // =========================================================
    private bool PassesFilter(GameObject other)
    {
        if (string.IsNullOrEmpty(filterTag)) return true;
        return other.CompareTag(filterTag);
    }
}