﻿/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections;
using System.Text;
using System.Reflection;
using Microsoft.VsSDK.UnitTestLibrary;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackMarble.ParametersXmlAddin;

namespace ParametersXmlAddin_UnitTests
{
    [TestClass()]
    public class PackageTest
    {
        [TestMethod()]
        public void CreateInstance()
        {
            ParametersXmlAddinPackage package = new ParametersXmlAddinPackage();
        }

        [TestMethod()]
        public void IsIVsPackage()
        {
            ParametersXmlAddinPackage package = new ParametersXmlAddinPackage();
            Assert.IsNotNull(package as IVsPackage, "The object does not implement IVsPackage");
        }

        [TestMethod()]
        [Ignore]  // commented out see https://social.msdn.microsoft.com/Forums/vstudio/en-US/4400c6bc-c7d8-4004-9834-f5b765d25b17/vspackage-automatically-generated-test-fails-with-systeminvalidoperationexception-the-service?forum=vsx
        public void SetSite()
        {
            // Create the package
            IVsPackage package = new ParametersXmlAddinPackage() as IVsPackage;
            Assert.IsNotNull(package, "The object does not implement IVsPackage");

            // Create a basic service provider
            OleServiceProvider serviceProvider = OleServiceProvider.CreateOleServiceProviderWithBasicServices();

            // Site the package
            Assert.AreEqual(0, package.SetSite(serviceProvider), "SetSite did not return S_OK");

            // Unsite the package
            Assert.AreEqual(0, package.SetSite(null), "SetSite(null) did not return S_OK");
        }
    }
}
