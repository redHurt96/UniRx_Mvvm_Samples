using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxSample
{
    public class CoinsPanel : MonoBehaviour, IModelHandler
    {
        [SerializeField] private Text _label;
        
        private CharacterModel _characterModel;

        public void SetupModel(CharacterModel characterModel)
        {
            _characterModel = characterModel;
            _characterModel.Coins.Subscribe(UpdateView);
        }

        private void UpdateView(int value) => 
            _label.text = value.ToString();
    }
}