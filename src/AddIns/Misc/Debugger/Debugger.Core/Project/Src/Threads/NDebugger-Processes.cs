﻿// <file>
//     <copyright see="prj:///doc/copyright.txt">2002-2005 AlphaSierraPapa</copyright>
//     <license see="prj:///doc/license.txt">GNU General Public License</license>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Debugger.Interop.CorDebug;

namespace Debugger
{
	public partial class NDebugger
	{
		List<Process> processCollection = new List<Process>();
		
		// Is set as long as the process count is zero
		ManualResetEvent noProcessesHandle = new ManualResetEvent(true);

		public event EventHandler<ProcessEventArgs> ProcessStarted;
		public event EventHandler<ProcessEventArgs> ProcessExited;
		
		public IList<Process> Processes {
			get {
				return processCollection.AsReadOnly();
			}
		}

		internal Process GetProcess(ICorDebugProcess corProcess)
		{
			foreach (Process process in Processes) {
				if (process.CorProcess == corProcess) {
					return process;
				}
			}
			throw new DebuggerException("Process is not in collection");
		}

		internal void AddProcess(Process process)
		{
			processCollection.Add(process);
			OnProcessStarted(process);
			noProcessesHandle.Reset();
		}

		internal void RemoveProcess(Process process)
		{
			processCollection.Remove(process);
			OnProcessExited(process);
			if (processCollection.Count == 0) {
				noProcessesHandle.Set();
			}
		}

		protected virtual void OnProcessStarted(Process process)
		{
			if (ProcessStarted != null) {
				ProcessStarted(this, new ProcessEventArgs(process));
			}
		}

		protected virtual void OnProcessExited(Process process)
		{
			if (ProcessExited != null) {
				ProcessExited(this, new ProcessEventArgs(process));
			}
		}
	}
}
