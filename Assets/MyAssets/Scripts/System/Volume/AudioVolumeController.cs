using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public enum VolumeType
    {
        BGM,
        SE
    }
    /*
     * オプションの音量を設定するUIにアタッチしているクラス
     * ボリュームを変更した時にその変更内容を反映するためのクラス
     */
    public class AudioVolumeController : MonoBehaviour
    {
        [SerializeField]
        private Slider[]        volumeSliders;
        [SerializeField]
        private InputField[]    inputFields;

        private void Awake()
        {
            volumeSliders = GetComponentsInChildren<Slider>();

            inputFields = GetComponentsInChildren<InputField>();
        }

        private void Start()
        {
            volumeSliders[(int)VolumeType.BGM].value = SystemManager.BGMVolume;
            inputFields[(int)VolumeType.BGM].text = SystemManager.BGMVolume.ToString();

            volumeSliders[(int)VolumeType.SE].value = SystemManager.SEVolume;
            inputFields[(int)VolumeType.SE].text = SystemManager.SEVolume.ToString();
        }

        private void OnEnable()
        {
            volumeSliders[(int)VolumeType.BGM].onValueChanged.AddListener(SetBGMVolume);
            inputFields[(int)VolumeType.BGM].onEndEdit.AddListener(SetStringFormatBGMVolume);

            volumeSliders[(int)VolumeType.SE].onValueChanged.AddListener(SetSEVolume);
            inputFields[(int)VolumeType.SE].onEndEdit.AddListener(SetStringFormatSEVolume);
        }

        private void OnDisable()
        {
            volumeSliders[(int)VolumeType.BGM].onValueChanged.RemoveListener(SetBGMVolume);
            inputFields[(int)VolumeType.BGM].onEndEdit.RemoveListener(SetStringFormatBGMVolume);

            volumeSliders[(int)VolumeType.SE].onValueChanged.RemoveListener(SetSEVolume);
            inputFields[(int)VolumeType.SE].onEndEdit.RemoveListener(SetStringFormatSEVolume);
        }
        //以下はSliderやInputFieldのコールバックで呼び出している

        //Sliderで変更した値を反映させる(BGM)
        public void SetBGMVolume(float value)
        {
            SystemManager.SetBGMVolume(value);
            inputFields[(int)VolumeType.BGM].text = value.ToString();
        }
        //入力で変更した値を反映させる(BGM)
        public void SetStringFormatBGMVolume(string value)
        {
            SystemManager.SetBGMVolume(float.Parse(value));
            volumeSliders[(int)VolumeType.BGM].value = float.Parse(value);
        }
        //Sliderで変更した値を反映させる(SE)
        private void SetSEVolume(float value)
        {
            SystemManager.SetSEVolume(value);
            inputFields[(int)VolumeType.SE].text = value.ToString();
        }
        //入力で変更した値を反映させる(SE)
        public void SetStringFormatSEVolume(string value)
        {
            SystemManager.SetSEVolume(float.Parse(value));
            volumeSliders[(int)VolumeType.SE].value = float.Parse(value);
        }
    }
}
