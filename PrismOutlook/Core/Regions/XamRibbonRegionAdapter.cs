﻿using Infragistics.Windows.Ribbon;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Core.Regions
{
	public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
	{
		public XamRibbonRegionAdapter(IRegionBehaviorFactory factory)
			: base(factory) { }
		protected override void Adapt(IRegion region, XamRibbon regionTarget)
		{
			if (region == null) throw new ArgumentNullException(nameof(region));
			if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

			region.Views.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Add)
				{
					foreach (var view in e.NewItems)
					{
						AddViewToRegion(view, regionTarget);
					}
				}
				else if (e.Action == NotifyCollectionChangedAction.Remove)
				{
					foreach (var view in e.OldItems)
					{
						RemoveViewFromRegion(view, regionTarget);
					}
				}
			};
		}

		static void RemoveViewFromRegion(object view, XamRibbon xamRibbon)
		{
			if (view is RibbonTabItem ribbonTabItem) xamRibbon.Tabs.Remove(ribbonTabItem);
		}

		static void AddViewToRegion(object view, XamRibbon xamRibbon)
		{
			if (view is RibbonTabItem ribbonTabItem) xamRibbon.Tabs.Add(ribbonTabItem);
		}

		protected override IRegion CreateRegion()
		{
			return new SingleActiveRegion();
		}
	}
}
