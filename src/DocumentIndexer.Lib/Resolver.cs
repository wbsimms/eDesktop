﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DocumentIndexer.Lib
{
	public class Resolver
	{
		private static Resolver INSTANCE = new Resolver();
		private IUnityContainer unityContainer;

		private Resolver()
		{
			Init();
		}

		private void Init()
		{
			this.unityContainer = new UnityContainer();
			Register(unityContainer);
		}

		public void Register(IUnityContainer container)
		{
			container.RegisterType<ISearcher, Searcher>();
			container.RegisterType<ISearchFolders, SearchFolders>();
			container.RegisterType<ISearchFoldersLoader, SearchFoldersesLoader>();
			container.RegisterType<ISearchFoldersValidator, SearchFoldersValidator>();
		}

		public IUnityContainer Container
		{
			get { return this.unityContainer; }
		}

		public static Resolver Instance
		{
			get { return INSTANCE; }
		}

		public void Reset()
		{
			this.Init();
		}
	}
}