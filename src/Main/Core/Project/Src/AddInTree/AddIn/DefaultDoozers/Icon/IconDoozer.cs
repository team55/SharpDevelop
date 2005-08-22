﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace ICSharpCode.Core
{
	/// <summary>
	/// Creates associations between file types or node types in the project browser and
	/// icons in the resource service.
	/// </summary>
	/// <attribute name="resource">
	/// This attribute must be specified. It is the name of a bitmap resource
	/// in the resource service.
	/// </attribute>
	/// <attribute name="language">
	/// This attribute is specified when a project icon association should be created.
	/// It specifies the language of the project types that use the icon.
	/// </attribute>
	/// <attribute name="extensions">
	/// This attribute is specified when a file icon association should be created.
	/// It specifies the semicolon-separated list of file types that use the icon.
	/// </attribute>
	/// <returns>
	/// An IconDescriptor object that exposes the attributes.
	/// </returns>
	public class IconDoozer : IDoozer
	{
		/// <summary>
		/// Gets if the doozer handles codon conditions on its own.
		/// If this property return false, the item is excluded when the condition is not met.
		/// </summary>
		public bool HandleConditions {
			get {
				return false;
			}
		}
		
		public object BuildItem(object caller, Codon codon, ArrayList subItems)
		{
			return new IconDescriptor(codon);
		}
	}
}
