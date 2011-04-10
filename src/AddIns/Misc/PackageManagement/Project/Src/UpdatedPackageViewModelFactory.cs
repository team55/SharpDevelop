﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using NuGet;

namespace ICSharpCode.PackageManagement
{
	public class UpdatedPackageViewModelFactory : PackageViewModelFactory
	{
		public UpdatedPackageViewModelFactory(IPackageViewModelFactory packageViewModelFactory)
			: base(packageViewModelFactory)
		{
		}
		
		public override PackageViewModel CreatePackageViewModel(IPackage package)
		{
			return new UpdatedPackageViewModel(
				package,
				RegisteredPackageRepositories.ActiveRepository,
				PackageManagementService,
				LicenseAcceptanceService,
				MessageReporter);
		}
	}
}
