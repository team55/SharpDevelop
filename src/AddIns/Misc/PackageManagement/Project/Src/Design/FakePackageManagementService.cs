﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using ICSharpCode.Core;
using ICSharpCode.PackageManagement;
using ICSharpCode.SharpDevelop.Project;
using NuGet;

namespace ICSharpCode.PackageManagement.Design
{
	public class FakePackageManagementService : IPackageManagementService
	{
		public event EventHandler ParentPackageInstalled;
		
		PackageManagementOptions options = new PackageManagementOptions(new Properties());
		
		protected virtual void OnParentPackageInstalled()
		{
			if (ParentPackageInstalled != null) {
				ParentPackageInstalled(this, new EventArgs());
			}
		}
		
		public event EventHandler ParentPackageUninstalled;
		
		protected virtual void OnParentPackageUninstalled()
		{
			if (ParentPackageUninstalled != null) {
				ParentPackageUninstalled(this, new EventArgs());
			}
		}
		
		public FakeProjectManager FakeActiveProjectManager { get; set; }
		
		public FakePackageManagementService()
		{
			FakeActiveProjectManager = new FakeProjectManager();
		}
		
		public virtual IProjectManager ActiveProjectManager {
			get { return FakeActiveProjectManager; }
		}
		
		public FakeInstallPackageAction ActionToReturnFromCreateInstallPackageAction =
			new FakeInstallPackageAction();
		
		public virtual InstallPackageAction CreateInstallPackageAction()
		{
			return ActionToReturnFromCreateInstallPackageAction;
		}
		
		public FakeUninstallPackageAction ActionToReturnFromCreateUninstallPackageAction =
			new FakeUninstallPackageAction();		
		
		public virtual UninstallPackageAction CreateUninstallPackageAction()
		{
			return ActionToReturnFromCreateUninstallPackageAction;
		}
		
		public void FireParentPackageInstalled()
		{
			OnParentPackageInstalled();
		}
		
		public void FireParentPackageUninstalled()
		{
			OnParentPackageUninstalled();
		}
		
		public void AddPackageToProjectLocalRepository(FakePackage package)
		{
			FakeActiveProjectManager.FakeLocalRepository.FakePackages.Add(package);
		}
		
		public PackageManagementOptions Options {
			get { return options; }
		}
		
		public FakePackageManagementOutputMessagesView FakeOutputMessagesView = new FakePackageManagementOutputMessagesView();
		
		public IPackageManagementOutputMessagesView OutputMessagesView {
			get { return FakeOutputMessagesView; }
		}
		
		public FakeProjectManager FakeProjectManagerToReturnFromCreateProjectManager = new FakeProjectManager();
		public IPackageRepository PackageRepositoryPassedToCreateProjectManager;
		public MSBuildBasedProject ProjectPassedToCreateProjectManager;
		
		public ISharpDevelopProjectManager CreateProjectManager(IPackageRepository repository, MSBuildBasedProject project)
		{
			PackageRepositoryPassedToCreateProjectManager = repository;
			ProjectPassedToCreateProjectManager = project;
			
			return FakeProjectManagerToReturnFromCreateProjectManager;
		}
		
		public FakePackageManager FakePackageManagerToReturnFromCreatePackageManager =
			new FakePackageManager();
		
		public virtual ISharpDevelopPackageManager CreatePackageManagerForActiveProject()
		{
			return FakePackageManagerToReturnFromCreatePackageManager;
		}
		
		public IPackageRepository PackageRepositoryPassedToCreatePackageManager;
		
		public ISharpDevelopPackageManager CreatePackageManagerForActiveProject(IPackageRepository packageRepository)
		{
			PackageRepositoryPassedToCreatePackageManager = packageRepository;
			return FakePackageManagerToReturnFromCreatePackageManager;
		}
		
		public PackageSource PackageSourcePassedToCreatePackageManager;
		public MSBuildBasedProject ProjectPassedToCreatePackageManager;
		
		public ISharpDevelopPackageManager CreatePackageManager(PackageSource packageSource, MSBuildBasedProject project)
		{
			PackageSourcePassedToCreatePackageManager = packageSource;
			ProjectPassedToCreatePackageManager = project;
			return FakePackageManagerToReturnFromCreatePackageManager;
		}
		
		public FakeUpdatePackageAction ActionToReturnFromCreateUpdatePackageAction =
			new FakeUpdatePackageAction();
		
		public UpdatePackageAction CreateUpdatePackageAction()
		{
			return ActionToReturnFromCreateUpdatePackageAction;
		}
		
		public IPackage PackagePassedToOnParentPackageInstalled;
		
		public void OnParentPackageInstalled(IPackage package)
		{
			PackagePassedToOnParentPackageInstalled = package;
		}
		
		public IPackage PackagePassedToOnParentPackageUninstalled;
		
		public void OnParentPackageUninstalled(IPackage package)
		{
			PackagePassedToOnParentPackageUninstalled = package;
		}
	}
}
