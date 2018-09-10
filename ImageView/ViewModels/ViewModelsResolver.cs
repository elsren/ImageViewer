using EventBinding.MVVM;
using ImageView.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ImageView.ViewModels
{
    public class ViewModelsResolver : IViewModelsResolver
    {
        private static ViewModelsResolver _instance;

        public static ViewModelsResolver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewModelsResolver();
                }

                return _instance;
            }
        }

        private readonly Dictionary<string, Func<ViewModelBase>> _vmResolvers = new Dictionary<string, Func<ViewModelBase>>();

        private ViewModelsResolver()
        {
            _vmResolvers.Add(MainWindowViewModel.GridImageViewModelAlias, () => new GridImageViewModel());
            _vmResolvers.Add(MainWindowViewModel.SingleImageViewModelAlias, () => new SingleImageViewModel());
        }

        public INotifyPropertyChanged GetViewModelInstance(string alias)
        {
            if (_vmResolvers.ContainsKey(alias))
            {
                return _vmResolvers[alias]();
            }

            return _vmResolvers[MainWindowViewModel.GridImageViewModelAlias]();
        }
    }
}
