﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Regions;

namespace HardwareCheckoutSystemAdmin.Common.Prism
{
    public class RegionManagerAwareBehavior : RegionBehavior
    {
        public const string BehaviorKey = "RegionManagerAwareBehavior";

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        void ActiveViews_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    IRegionManager regionManager = Region.RegionManager;

                    FrameworkElement element = item as FrameworkElement;
                    if (element != null)
                    {
                        IRegionManager scopedRegionManager =
                            element.GetValue(RegionManager.RegionManagerProperty) as IRegionManager;
                        if (scopedRegionManager != null)
                            regionManager = scopedRegionManager;
                    }

                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = regionManager);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = null);
                }
            }
        }

        static void InvokeOnRegionManagerAwareElement(object item, Action<IRegionManagerAware> invocation)
        {
            if (item is IRegionManagerAware rmAwareItem)
                invocation(rmAwareItem);

            if (item is FrameworkElement frameworkElement)
            {
                if (frameworkElement.DataContext is IRegionManagerAware rmAwareDataContext)
                {
                    if (frameworkElement.Parent is FrameworkElement frameworkElementParent)
                    {
                        if (frameworkElementParent.DataContext is IRegionManagerAware rmAwareDataContextParent)
                        {
                            if (rmAwareDataContext == rmAwareDataContextParent)
                            {
                                return;
                            }
                        }
                    }

                    invocation(rmAwareDataContext);
                }
            }
        }
    }
}
