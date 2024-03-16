using UnityEngine;

public class MinecraftCharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform _leftLegTransform;
    [SerializeField] private Transform _rightLegTransform;
    [SerializeField] private Transform _leftArmTransform;
    [SerializeField] private Transform _rightArmTransform;

    private float _rightLegRotation = 0f;
    private float _leftArmRotation = 0f;
    private float _rightArmRotation = 0f;
    private float _leftLegRotation = 0f;

    private float rotationSpeed = 100f;
    private float rotationSpeed2 = 50f;
    private bool rotateBack;
    private bool isSecondPhase;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject _character;
    private void Start()
    {
        // Karaktere ait Rigidbody bileşenini al
        _rb = GetComponent<Rigidbody>();
        // Eğer Rigidbody bileşeni yoksa, bir tane oluştur ve hizalamayı düzelt
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    void Update()
    {
        // WASD tuşları ile hareket
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        // Karakterin hareketini Rigidbody kullanarak yap
        _rb.MovePosition(transform.position + movement);

        // Sağa dönme kontrolü
        if (Input.GetKey(KeyCode.D))
        {
            // Sağa dönme
            _character.transform.Rotate(Vector3.up, rotationSpeed2 * Time.deltaTime);
        }
        // Sola dönme kontrolü
        if (Input.GetKey(KeyCode.A))
        {
            // Sola dönme
            _character.transform.Rotate(Vector3.up, -rotationSpeed2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!rotateBack && !isSecondPhase)
            {
                // İlk aşama: Sol kol ve sağ bacak döner
                if (_leftArmRotation < 45f)
                {
                    _leftArmRotation += rotationSpeed * Time.deltaTime;
                    _rightLegRotation += rotationSpeed * Time.deltaTime;
                }
                else
                {
                    rotateBack = true;
                }
            }
            else if (rotateBack && !isSecondPhase)
            {
                // İlk aşamanın geri dönüşü
                if (_leftArmRotation > 0f)
                {
                    _leftArmRotation -= rotationSpeed * Time.deltaTime;
                    _rightLegRotation -= rotationSpeed * Time.deltaTime;
                }
                else
                {
                    rotateBack = false;
                    isSecondPhase = true;
                }
            }
            else if (!rotateBack && isSecondPhase)
            {
                // İkinci aşama: Sağ kol ve sol bacak döner
                if (_rightArmRotation < 45f)
                {
                    _rightArmRotation += rotationSpeed * Time.deltaTime;
                    _leftLegRotation += rotationSpeed * Time.deltaTime;
                }
                else
                {
                    rotateBack = true;
                }
            }
            else if (rotateBack && isSecondPhase)
            {
                // İkinci aşamanın geri dönüşü
                if (_rightArmRotation > 0f)
                {
                    _rightArmRotation -= rotationSpeed * Time.deltaTime;
                    _leftLegRotation -= rotationSpeed * Time.deltaTime;
                }
                else
                {
                    rotateBack = false;
                    isSecondPhase = false; // İşlemi sıfırlayıp tekrar başlatmak için
                }
            }
        }
        // Uygulanan dönüşleri transforma aktar
        _leftArmTransform.localRotation = Quaternion.Euler(0f, 0f, _leftArmRotation);
        _rightLegTransform.localRotation = Quaternion.Euler(0f, 0f, _rightLegRotation);
        _rightArmTransform.localRotation = Quaternion.Euler(0f, 0f, _rightArmRotation);
        _leftLegTransform.localRotation = Quaternion.Euler(0f, 0f, _leftLegRotation);
    }
}