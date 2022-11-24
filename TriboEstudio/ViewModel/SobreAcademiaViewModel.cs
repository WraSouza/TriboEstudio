using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriboEstudio.ViewModel
{
    internal class SobreAcademiaViewModel : BaseViewModel
    {
        public Command AbrirInstagramView { get; set; }

        public INavigation navigation { get; set; }

        public SobreAcademiaViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            AbrirInstagramView = new Command( () =>  IrParaInstagram());
        }

        void IrParaInstagram()
        {
            navigation.PushAsync(new View.InstagramView());
        }
    }
}
