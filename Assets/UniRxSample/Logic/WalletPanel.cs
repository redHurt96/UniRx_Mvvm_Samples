using UniRx;
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
            _model.Wallet.Subscribe(UpdateView);
        }

        private void UpdateView(int value) => 
            _label.text = value.ToString();
    }
}