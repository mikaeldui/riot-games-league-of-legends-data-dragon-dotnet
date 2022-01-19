using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace RiotGames.LeagueOfLegends.DataDragon.CodeGeneration
{
    internal class DataDragonClass
    {
        private readonly ClassDeclarationSyntax _class;

        public DataDragonClass()
        {
            _class = ClassDeclaration("DataDragon").WithModifiers(SyntaxKind.PublicKeyword, SyntaxKind.PartialKeyword);
        }

        public void AddMethodForFile(string file)
        {
            var extension = file.Split('.').Last();

            MethodDeclarationSyntax method;

            switch (extension)
            {
                case "json":
                    {
                        method = DataDragonMethod.GetFromJsonAsync(file.Split('.').First(), file.Split('.').First(), file);
                    }
                case "js":
                    {
                        method = DataDragonMethod.GetStringAsync(file.Split('.').First().FirstCharToUpper(), file);
                    }
            }

            _class.AddMembers(method);
        }

        public void AddMethodsForFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                AddMethodForFile(file);
            }
        }

        public string GenerateCode()
        {
            var @namespace = SyntaxFactory.NamespaceDeclaration(ParseName("RiotGames.LeagueOfLegends.DataDragon"));

        }
    }
}
