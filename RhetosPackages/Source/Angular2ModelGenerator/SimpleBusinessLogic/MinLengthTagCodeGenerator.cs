﻿/*
    Copyright (C) 2014 Omega software d.o.o.

    This file is part of Rhetos.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;
using Angular2ModelGenerator.Property;

namespace Angular2ModelGenerator.SimpleBusinessLogic
{
    [Export(typeof(IAngular2ModelGenratorPlugin))]
    [ExportMetadata(MefProvider.Implements, typeof(MinLengthInfo))]
    public class MinLengthTagCodeGenerator : IAngular2ModelGenratorPlugin
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (MinLengthInfo)conceptInfo;
            codeBuilder.InsertCode(ValidatorsCodeSnippet(info), PropertyCodeGeneratorHelper.ReturnTag, info.Property);

        }
        private static string ValidatorsCodeSnippet(MinLengthInfo info)
        {
            string result = string.Format(
                @"{{Validator :Validators.minLength({1}), ErrorCode: 'minlength', ErrorMessage: ""{0} has minimum length of {1} characters"" }},
                ",
                info.Property.Name,
                info.Length);
            return result;
        }
    }
}