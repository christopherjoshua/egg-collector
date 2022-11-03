using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;
using Collector.InputsEditor;

namespace Collector.Home
{
    public class HomeView : BaseView
    {
        public InputsEditorView InputsEditorView;

        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _settingButton;
        [SerializeField]
        private Button _creditsButton;
        [SerializeField]
        private Button _closeCreditsButton;
        [SerializeField]
        private GameObject _creditsPanel;
        [SerializeField]
        private GameObject _settingsPanel;
        [SerializeField]
        private Button _closeSettingButton;

        public void SetButtonsCallback(UnityAction onClickPlayButton, UnityAction onCloseSettingsButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
            _creditsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.AddListener(() => _creditsPanel.SetActive(true));
            _closeCreditsButton.onClick.RemoveAllListeners();
            _closeCreditsButton.onClick.AddListener(() => _creditsPanel.SetActive(false));
            _settingButton.onClick.RemoveAllListeners();
            _settingButton.onClick.AddListener(() => _settingsPanel.SetActive(true));
            _closeSettingButton.onClick.RemoveAllListeners();
            _closeSettingButton.onClick.AddListener(() => { _settingsPanel.SetActive(false); onCloseSettingsButton.Invoke(); });
        }
    }
}
