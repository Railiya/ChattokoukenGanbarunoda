using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CKG.Forms;

namespace CKG.Controls
{
    public partial class OverlayPanel : SettingPanel
    {
        public static event Action OnOverlaySettingChanged = null;

        public event Action<bool> OnOverlayToggleChanged = null;

        private List<Control> _overlayActiveGroup = null;
        

        public OverlayPanel()
        {
            InitializeComponent();

            _overlayActiveGroup =
            [
                _overlayAnchorSelector,
                _overlayOffsetXField,
                _overlayOffsetYField,
                _overlayFontSizeField,
                _overlayOpacitySlider,
            ];

            _overlayAnchorSelector.OnAnchorChanged += _overlayAnchorSelector_AnchorChanged;
        }

        public override void UpdateProfile(UserProfile profile)
        {
            _overlayEnabledToggle.Checked = profile.OverlayEnabled;
            _overlayAnchorSelector.SelectedAnchor = (ContentAlignment)profile.OverlayAnchorIndex;
            _overlayOffsetXField.Value = profile.OverlayOffsetX;
            _overlayOffsetYField.Value = profile.OverlayOffsetY;
            _overlayFontSizeField.Value = profile.OverlayFontSize;
            _overlayOpacitySlider.Value = profile.OverlayOpacity;
            _overlayOpacityField.Text = profile.OverlayOpacity.ToString();

            _overlayActiveGroup.SetControlGroupActive(profile.OverlayEnabled);
        }

        private void _overlayEnabledToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            bool toggle = _overlayEnabledToggle.Checked;
            UserProfile.Current.OverlayEnabled = toggle;
            _overlayActiveGroup.SetControlGroupActive(toggle);

            ProfileManager.SaveCurrentProfile();

            OnOverlayToggleChanged?.Invoke(toggle);
            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayAnchorSelector_AnchorChanged(ContentAlignment alignment)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.OverlayAnchorIndex = (int)_overlayAnchorSelector.SelectedAnchor;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOffsetXField_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.OverlayOffsetX = (int)_overlayOffsetXField.Value;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOffsetYField_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.OverlayOffsetY = (int)_overlayOffsetYField.Value;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayFontSizeField_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            UserProfile.Current.OverlayFontSize = (int)_overlayFontSizeField.Value;
            ProfileManager.SaveCurrentProfile();

            OnOverlaySettingChanged?.Invoke();
        }

        private void _overlayOpacitySlider_ValueChanged(object sender, EventArgs e)
        {
            if (MainForm.LockControlEvents)
            {
                return;
            }

            int value = _overlayOpacitySlider.Value;
            UserProfile.Current.OverlayOpacity = value;
            _overlayOpacityField.Text = value.ToString();

            ProfileManager.SaveCurrentProfile();
            OnOverlaySettingChanged?.Invoke();
        }
    }
}
