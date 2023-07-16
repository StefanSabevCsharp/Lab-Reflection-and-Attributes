


using Stealer;

Spy spy = new Spy();

//string result = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");
//Console.WriteLine(result);

//string otherResult = spy.AnalyzeAccessModifiers(typeof(Hacker).FullName);
//Console.WriteLine(otherResult);

string methodsinfo = spy.RevealPrivateMethods(typeof(Hacker).FullName);
Console.WriteLine(methodsinfo);

string gettersAndSetters = spy.CollectGettersAndSetters(typeof(Hacker).FullName);
Console.WriteLine(gettersAndSetters);