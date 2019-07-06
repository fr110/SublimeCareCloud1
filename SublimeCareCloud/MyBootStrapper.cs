using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SublimeCareCloud
{
    public class MyBootStrapper : BootstrapperBase
    {
        private CompositionContainer container;
        protected override void Configure()
        {

            //Set up MEF
            container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));
            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);

            container.Compose(batch);
        }
        protected override object GetInstance(Type service, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Any())
            {
                return exports.First();
            }

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }
        protected override IEnumerable<object> GetAllInstances(Type service) 
         {
             return container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
         }
        protected override void BuildUp(object instance)
         {
             container.SatisfyImportsOnce(instance);
         }

        public MyBootStrapper()
        {
            Initialize();
        }

        protected override void OnExit(object sender, EventArgs e) {
            container.Dispose();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ViewModels.MainViewModel>();
        }
    }
}
