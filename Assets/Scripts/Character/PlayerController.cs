using Character.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    [RequireComponent(typeof(PlayerHealthComponent))]

    public class PlayerController : MonoBehaviour, IPauseable
    {
        public CrossHairScript CrossHair => CrossHairComponent;
        [SerializeField] private CrossHairScript CrossHairComponent;

        public HealthComponent health => healthComponent;
        private HealthComponent healthComponent;

        public WeaponHolder weaponHolder => weaponHolderComponent;
        private WeaponHolder weaponHolderComponent;
        
        public bool IsFiring;
        public bool IsReloading;
        public bool IsJumping;
        public bool IsRunning;


        private GameUIController UIController;
        private PlayerInput playerInput;

        private void Awake()
        {
            UIController = FindObjectOfType<GameUIController>();
            playerInput = GetComponent<PlayerInput>();

            if (health == null) healthComponent = GetComponent<HealthComponent>();
            if (weaponHolder == null) weaponHolderComponent = GetComponent<WeaponHolder>();
        }

        public void OnPauseGame(InputValue value)
        {
            PauseManager.Instance.PauseGame();
        }
        public void OnUnPauseGame(InputValue value)
        {
            PauseManager.Instance.UnPauseGame();

        }

        public void PauseMenu()
        {
            UIController.EnablePauseMenu();
            playerInput.SwitchCurrentActionMap("PauseActionMap");
        }

        public void UnPauseMenu()
        {
            UIController.EnableGameMenu();
            playerInput.SwitchCurrentActionMap("PlayerActionMap");

        }
    }
}
