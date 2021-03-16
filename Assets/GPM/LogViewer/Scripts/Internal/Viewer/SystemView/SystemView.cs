namespace Gpm.LogViewer.Internal
{
    using Gpm.Ui;
    using System.Text;
    using UnityEngine;
    using UnityEngine.UI;

    public class SystemView : ViewBase
    {
        public Text                             systemInfoHeading   = null;
        public Text                             systemInfoDetail    = null;
        public Text                             appInfoHeading      = null;
        public Text                             appInfoDetail       = null;
        public Text                             displayInfoHeading  = null;
        public Text                             displayInfoDetail   = null;
        public Text                             playInfoHeading     = null;
        public Text                             playInfoDetail      = null;
        public Text                             featureInfoHeading  = null;
        public Text                             featureInfoDetail   = null;
        public Text                             graphicsInfoHeading = null;
        public Text                             graphicsInfoDetail  = null;

        private MultiLayout                     multiLayout         = null;
        private SystemInformation.Information   information         = null;

        public override void SetOrientation(ScreenOrientation orientation)
        {
            if (orientation == ScreenOrientation.Portrait || orientation == ScreenOrientation.PortraitUpsideDown)
            {
                multiLayout.SelectLayout(1);
            }
            else
            {
                multiLayout.SelectLayout(0);
            }

            Refresh();
        }

        public override void InitializeView()
        {
            multiLayout = GetComponent<MultiLayout>();
            information = SystemInformation.Instance.GetInformation();
            
            SetSystemInfo();
            SetAppInfo();
            SetDisplayInfo();
            SetPlayInfo();
            SetFeatureInfo();
            SetGraphicsInfo();
        }

        public void Refresh()
        {
            SystemInformation.Instance.RefreshInformation();

            UpdateRefresh();
        }

        private void UpdateRefresh()
        {
            SetSystemInfo();
            SetDisplayInfo();
            SetPlayInfo();
        }

        private void SetSystemInfo()
        {
            StringBuilder heading   = new StringBuilder();
            StringBuilder detail    = new StringBuilder();

            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_OS);               detail.AppendLine(information.system.operatingSystem);
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_DEVICE_MODEL);     detail.AppendLine(information.system.deviceModel);
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_PROCESSOR_TYPE);   detail.AppendLine(information.system.processorType);
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_PROCESSOR_COUNT);  detail.AppendLine(information.system.processorCount.ToString());
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_MEMORY_SIZE);      detail.AppendLine(string.Format(SystemViewConst.MEMORY_SIZE_GB_FORMAT, information.system.memorySize.ToString()));
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_GC_MEMORY);        detail.AppendLine(string.Format(SystemViewConst.MEMORY_SIZE_MB_FORMAT, information.system.gcTotalMemory.ToString()));


            systemInfoHeading.text  = heading.ToString();
            systemInfoDetail.text   = detail.ToString();
        }
        
        private void SetAppInfo()
        {
            StringBuilder heading   = new StringBuilder();
            StringBuilder detail    = new StringBuilder();

            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_PLATFORM);         detail.AppendLine(information.app.platform.ToString());
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_VERSION);          detail.AppendLine(information.app.applicationVersion.ToString());
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_SYSTEMLANGUAGE);   detail.AppendLine(information.app.systemLanguage.ToString());

            appInfoHeading.text     = heading.ToString();
            appInfoDetail.text      = detail.ToString();
        }

        private void SetDisplayInfo()
        {
            information = SystemInformation.Instance.GetInformation();
            StringBuilder heading   = new StringBuilder();
            StringBuilder detail    = new StringBuilder();

            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_RESOLUTION);     detail.AppendLine(string.Format(SystemViewConst.RESOLUTION_FORMAT, information.display.width, information.display.height));
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_ORIENTATION);    detail.AppendLine(information.display.GetOrientationToString());

            displayInfoHeading.text = heading.ToString();
            displayInfoDetail.text  = detail.ToString();
        }
        
        private void SetPlayInfo()
        {
            StringBuilder heading   = new StringBuilder();
            StringBuilder detail    = new StringBuilder();

            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_PLAYTIME);       detail.AppendLine(information.play.playTime.ToString("F"));
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_LEVELPLAYTIME);  detail.AppendLine(information.play.levelPlayTime.ToString("F"));
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_LEVELNAME);      detail.AppendLine(information.play.levelName);

            playInfoHeading.text    = heading.ToString();
            playInfoDetail.text     = detail.ToString();
        }
        
        private void SetFeatureInfo()
        {
            StringBuilder heading   = new StringBuilder();
            StringBuilder detail    = new StringBuilder();

            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_LOCATION);       detail.AppendLine(information.features.supportsLocationService == true ? "✓" : "✗");
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_ACCELEROMETER);  detail.AppendLine(information.features.supportsAccelerometer == true ? "✓" : "✗");
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_GYROSCOPE);      detail.AppendLine(information.features.supportsGyroscope == true ? "✓" : "✗");
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_VIBRATION);      detail.AppendLine(information.features.supportsVibration == true ? "✓" : "✗");
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_AUDIO);          detail.AppendLine(information.features.supportsAudio == true ? "✓" : "✗");

            featureInfoHeading.text = heading.ToString();
            featureInfoDetail.text  = detail.ToString();
        }
        
        private void SetGraphicsInfo()
        {
            StringBuilder heading   = new StringBuilder();
            StringBuilder detail    = new StringBuilder();

            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_DEVICE_NAME);        detail.AppendLine(information.graphics.deviceName);
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_DEVICE_VENDOR);      detail.AppendLine(information.graphics.deviceVendor);
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_DEVICE_VERSION);     detail.AppendLine(information.graphics.deviceVersion);
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_MEMORY_SIZE);        detail.AppendLine(string.Format(SystemViewConst.MEMORY_SIZE_GB_FORMAT, information.graphics.memorySize.ToString()));
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_MAX_TEXTURE);        detail.AppendLine(information.graphics.maxTextureSize.ToString());
            heading.AppendLine(SystemViewConst.INFROMATION_HEADING_NPOT);               detail.AppendLine(information.graphics.npotSupport.ToString());

            graphicsInfoHeading.text = heading.ToString();
            graphicsInfoDetail.text  = detail.ToString();
        }
    }
}