using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using Collector.Boot;
using UnityEngine.Events;
using Collector.Inputs;
using Collector.InputsEditor;

namespace Collector.Home
{
    public class HomeLauncher : BaseLauncher<HomeLauncher, HomeView>
    {
        public override string SceneName => "Home";

        private InputsEditorController _inputsEditor;

        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new InputsEditorController(),
            };
        }

        protected override ISplash GetSplash()
        {
            return SplashScreen.Instance;
        }

        protected override IEnumerator InitSceneObject()
        {
            SetViewButtonsCallback(OnClickPlayButton, OnCloseSettingsButton);
            _inputsEditor.SetView(_view.InputsEditorView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        private void SetViewButtonsCallback(UnityAction onClickPlayButton, UnityAction onCloseSettingsButton)
        {
            _view.SetButtonsCallback(onClickPlayButton, onCloseSettingsButton);
        }

        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        private void OnCloseSettingsButton()
        {
            _inputsEditor.DisableRemap();
        }
    }
}
