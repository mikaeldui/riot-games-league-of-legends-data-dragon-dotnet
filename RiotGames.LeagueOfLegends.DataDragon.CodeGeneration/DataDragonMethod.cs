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
    internal static class DataDragonMethod
    {
        public static MethodDeclarationSyntax GetStringAsync(string identifier, string path) =>
            MethodDeclaration(ParseTypeName("Task<string>"), Identifier(identifier))
                .WithModifiers(SyntaxKind.AsyncKeyword, SyntaxKind.PublicKeyword)
                .WithBody($"return await _requestHandler.GetStringAsync(\"{path}\");".ToBlock());

        public static MethodDeclarationSyntax GetStreamAsync(string identifier, string path) =>
            MethodDeclaration(ParseTypeName("Task<Stream>"), Identifier(identifier))
                .WithModifiers(SyntaxKind.AsyncKeyword, SyntaxKind.PublicKeyword)
                .WithBody($"return await _requestHandler.GetStreamAsync(\"{path}\");".ToBlock());

        public static MethodDeclarationSyntax GetFromJsonAsync(string typeName, string identifier, string path) =>
            MethodDeclaration(ParseTypeName($"Task<{typeName}>"), Identifier(identifier))
                .WithModifiers(SyntaxKind.AsyncKeyword, SyntaxKind.PublicKeyword)
                .WithBody($"return await _requestHandler.GetFromJsonAsync<{typeName}>(\"{path}\");".ToBlock());
    }
}
