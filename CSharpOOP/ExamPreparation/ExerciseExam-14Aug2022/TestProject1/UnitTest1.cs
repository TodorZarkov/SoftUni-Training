using System;
using PlanetWars;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

public class Tests_200
{
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void ZeroTest_GivenExample()
    {
        var controller = CreateObjectInstance(GetType("Controller"));

        var planetArguments1 = new object[] { "Zomitune", 300 };
        var validExpectedOutput1 = "Successfully added Planet: Zomitune";
        var actualOutput1 = InvokeMethod(controller, "CreatePlanet", planetArguments1);
        Assert.AreEqual(validExpectedOutput1, actualOutput1);

        var planetArguments2 = new object[] { "Cippe-C77T", 270 };
        var validExpectedOutput2 = "Successfully added Planet: Cippe-C77T";
        var actualOutput2 = InvokeMethod(controller, "CreatePlanet", planetArguments2);
        Assert.AreEqual(validExpectedOutput2, actualOutput2);

        var planetArguments3 = new object[] { "Xunrichi", 20.52 };
        var validExpectedOutput3 = "Successfully added Planet: Xunrichi";
        var actualOutput3 = InvokeMethod(controller, "CreatePlanet", planetArguments3);
        Assert.AreEqual(validExpectedOutput3, actualOutput3);

        var validExpectedOutput4 = "Planet Dotrienides does not exist!";
        var actualOutput4 = InvokeMethod(controller, "AddUnit", new object[] { "StormTroopers", "Dotrienides" });
        Assert.AreEqual(validExpectedOutput4, actualOutput4);

        var validExpectedOutput5 = "SpaceForces added successfully to the Army of Zomitune!";
        var actualOutput5 = InvokeMethod(controller, "AddUnit", new object[] { "SpaceForces", "Zomitune" });
        Assert.AreEqual(validExpectedOutput5, actualOutput5);

        var validExpectedOutput6 = "SpaceForces already added to the Army of Zomitune!";
        var actualOutput6 = InvokeMethod(controller, "AddUnit", new object[] { "SpaceForces", "Zomitune" });
        Assert.AreEqual(validExpectedOutput6, actualOutput6);

        var validExpectedOutput7 = "Xunrichi purchased SpaceMissiles!";
        var actualOutput7 = InvokeMethod(controller, "AddWeapon", new object[] { "Xunrichi", "SpaceMissiles", 2 });
        Assert.AreEqual(validExpectedOutput7, actualOutput7);

        var validExpectedOutput8 = "Xunrichi purchased BioChemicalWeapon!";
        var actualOutput8 = InvokeMethod(controller, "AddWeapon", new object[] { "Xunrichi", "BioChemicalWeapon", 6 });
        Assert.AreEqual(validExpectedOutput8, actualOutput8);

        var validExpectedOutput9 = "Budget too low!";
        var actualOutput9 = InvokeMethod(controller, "AddWeapon", new object[] { "Xunrichi", "NuclearWeapon", 8 });
        Assert.AreEqual(validExpectedOutput9, actualOutput9);

        var validExpectedOutput10 = "Destruction level cannot exceed 10 power points.";
        var actualOutput10 = InvokeMethod(controller, "AddWeapon", new object[] { "Cippe-C77T", "NuclearWeapon", 11 });
        //Assert.AreEqual(validExpectedOutput10, actualOutput10);

        var validExpectedOutput11 = "Cippe-C77T purchased NuclearWeapon!";
        var actualOutput11 = InvokeMethod(controller, "AddWeapon", new object[] { "Cippe-C77T", "NuclearWeapon", 10 });
        Assert.AreEqual(validExpectedOutput11, actualOutput11);

        var validExpectedOutput12 = "Zomitune has upgraded its forces!";
        var actualOutput12 = InvokeMethod(controller, "SpecializeForces", new object[] { "Zomitune" });
        Assert.AreEqual(validExpectedOutput12, actualOutput12);

        var validExpectedOutput13 = "Budget too low!";
        var actualOutput13 = InvokeMethod(controller, "AddUnit", new object[] { "AnonymousImpactUnit", "Xunrichi" });
        Assert.AreEqual(validExpectedOutput13, actualOutput13);

        var validExpectedOutput14 = "StormTroopers added successfully to the Army of Xunrichi!";
        var actualOutput14 = InvokeMethod(controller, "AddUnit", new object[] { "StormTroopers", "Xunrichi" });
        Assert.AreEqual(validExpectedOutput14, actualOutput14);

        var validExpectedOutput15 = "Xunrichi destructed Zomitune!";
        var actualOutput15 = InvokeMethod(controller, "SpaceCombat", new[] { "Xunrichi", "Zomitune" });
        Assert.AreEqual(validExpectedOutput15, actualOutput15);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
        sb.AppendLine("Planet: Cippe-C77T");
        sb.AppendLine("--Budget: 255 billion QUID");
        sb.AppendLine("--Forces: No units");
        sb.AppendLine("--Combat equipment: NuclearWeapon");
        sb.AppendLine("--Military Power: 14.5");
        sb.AppendLine("Planet: Xunrichi");
        sb.AppendLine("--Budget: 157.91 billion QUID");
        sb.AppendLine("--Forces: StormTroopers");
        sb.AppendLine("--Combat equipment: SpaceMissiles, BioChemicalWeapon");
        sb.AppendLine("--Military Power: 9");

        var validReport = sb.ToString().TrimEnd();
        var expectedReport = InvokeMethod(controller, "ForcesReport", null);
        Assert.AreEqual(validReport, expectedReport);

    }

    private static object InvokeMethod(object obj, string methodName, object[] parameters)
    {
        try
        {
            var result = obj.GetType()
                .GetMethod(methodName)
                .Invoke(obj, parameters);

            return result;
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            var desiredConstructor = type.GetConstructors()
                .FirstOrDefault(x => x.GetParameters().Any());

            if (desiredConstructor == null)
            {
                return Activator.CreateInstance(type, parameters);
            }

            var instances = new List<object>();

            foreach (var parameterInfo in desiredConstructor.GetParameters())
            {
                var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                instances.Add(currentInstance);
            }

            return Activator.CreateInstance(type, instances.ToArray());
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name.Contains(name));

        return type;
    }
}