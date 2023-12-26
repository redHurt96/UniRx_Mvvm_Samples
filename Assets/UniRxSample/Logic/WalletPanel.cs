using UnityEngine;
using UnityEngine.UI;

namespace UniRxSample
{
    public class WalletPanel : MonoBehaviour, IModelHandler
    {
        [SerializeField] private Text _label;
        
        private Model _model;

        public void SetupModel(Model model)
        {
            _model = model;
            _model.Updated += UpdateView;
        }

        private void OnDestroy() => 
            _model.Updated -= UpdateView;

        private void UpdateView() => 
            _label.text = _model.Wallet.ToString();
    }
}