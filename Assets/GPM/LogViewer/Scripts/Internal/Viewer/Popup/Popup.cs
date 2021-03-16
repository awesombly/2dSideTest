namespace Gpm.LogViewer.Internal
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Popup : MonoBehaviour
    {
        public Text             title       = null;
        public Text             message     = null;

        private static Popup    instance    = null;

        public static Popup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<Popup>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Show(false);
        }

        public void ShowPopup(string message, string title = "")
        {
            this.message.text   = message;
            this.title.text     = title;
            Show(true);
        }

        public void OnClickCloseButton()
        {
            Show(false);
        }

        private void Show(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}
