using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.ComponentModel;
using ImageView;
using ImageView.Views;
using Navigation.Interfaces;

namespace Navigation
{
    public class PagesResolver : IPageResolver
    {
        private static PagesResolver _instance;

        public static PagesResolver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PagesResolver();
                }

                return _instance;
            }
        }

        private readonly Dictionary<string, Func<Page>> _pagesResolvers = new Dictionary<string, Func<Page>>();

        private PagesResolver()
        {
            _pagesResolvers.Add(ImageView.Navigation.GridViewAlias, () => new GridImagesView());
            _pagesResolvers.Add(ImageView.Navigation.SingleViewAlias, () => new SingleImagesView());
        }

        public Page GetPageInstance(string alias)
        {
            if (_pagesResolvers.ContainsKey(alias))
            {
                return _pagesResolvers[alias]();
            }

            return _pagesResolvers[ImageView.Navigation.GridViewAlias]();
        }
    }
}
