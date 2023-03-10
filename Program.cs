
//Enter 216 character length identifier

using DokkanIdentifierConvertor;

Console.WriteLine("Enter identifier :");
string ident_216 = Console.ReadLine();

Security security = new Security();

string ident_152 = security.DecryptIdentifier(ident_216);

Console.WriteLine("Converted identifier:\n" + ident_152);


