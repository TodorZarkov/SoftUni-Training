using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ChristmasPastryShop;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Delicacies;
using NUnit.Framework;
using static NUnit.Framework.Constraints.Tolerance;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

public class Tests_000_024
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void LeaveBooth_ValidParameters()
    {
        var controller = CreateObjectInstance(GetType("Controller"));

        StringBuilder sbActual = new StringBuilder();
        StringBuilder sbExpected = new StringBuilder();


        var boothArgs = new object[] { 5 };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddBooth", boothArgs)}");
        var boothArgs2 = new object[] { 3 };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddBooth", boothArgs2)}");
        var boothArgs3 = new object[] { 3 };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddBooth", boothArgs3)}");

        var delicacyArgs = new object[] { 1, "Stolen", "Sugarcookie" };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddDelicacy", delicacyArgs)}");
        var delicacyArgs2 = new object[] { 2, "Gingerbread", "Dwarfhat" };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddDelicacy", delicacyArgs2)}");

        var cocktailArgs = new object[] { 3, "Hibernation", "Bluewater", "Large" };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddCocktail", cocktailArgs)}");
        var cocktailArgs2 = new object[] { 3, "Hibernation", "Bluewater", "Small" };
        sbActual.AppendLine($"{InvokeMethod(controller, "AddCocktail", cocktailArgs2)}");

        var reserveBoothArgs = new object[] { 2 };
        sbActual.AppendLine($"{InvokeMethod(controller, "ReserveBooth", reserveBoothArgs)}");
        var reserveBoothArgs2 = new object[] { 6 };
        sbActual.AppendLine($"{InvokeMethod(controller, "ReserveBooth", reserveBoothArgs2)}");
        var reserveBoothArgs3 = new object[] { 3 };
        sbActual.AppendLine($"{InvokeMethod(controller, "ReserveBooth", reserveBoothArgs3)}");

        var orderArgs = new object[] { 3, "Hibernation/Bluewater/3/Middle" };
        sbActual.AppendLine($"{InvokeMethod(controller, "TryOrder", orderArgs)}");
        var orderArgs2 = new object[] { 2, "Stolen/Sugarcookie/1" };
        sbActual.AppendLine($"{InvokeMethod(controller, "TryOrder", orderArgs2)}");

        sbActual.AppendLine($"{InvokeMethod(controller, "LeaveBooth", new object[] { 3 })}");
        sbActual.AppendLine($"{InvokeMethod(controller, "LeaveBooth", new object[] { 2 })}");

        sbActual.AppendLine($"{InvokeMethod(controller, "BoothReport", new object[] { 1 })}");
        sbActual.AppendLine($"{InvokeMethod(controller, "BoothReport", new object[] { 2 })}");
        sbActual.AppendLine($"{InvokeMethod(controller, "BoothReport", new object[] { 3 })}");

        sbExpected.AppendLine($"Added booth number 1 with capacity 5 in the pastry shop!");
        sbExpected.AppendLine($"Added booth number 2 with capacity 3 in the pastry shop!");
        sbExpected.AppendLine($"Added booth number 3 with capacity 3 in the pastry shop!");
        sbExpected.AppendLine($"Stolen Sugarcookie added to the pastry shop!");
        sbExpected.AppendLine($"Gingerbread Dwarfhat added to the pastry shop!");
        sbExpected.AppendLine($"Large Bluewater Hibernation added to the pastry shop!");
        sbExpected.AppendLine($"Small Bluewater Hibernation added to the pastry shop!");
        sbExpected.AppendLine($"Booth 3 has been reserved for 2 people!");
        sbExpected.AppendLine($"No available booth for 6 people!");
        sbExpected.AppendLine($"Booth 2 has been reserved for 3 people!");
        sbExpected.AppendLine($"There is no Middle Bluewater available!");
        sbExpected.AppendLine($"There is no Stolen Sugarcookie available!");
        sbExpected.AppendLine($"Bill 0.00 lv");
        sbExpected.AppendLine($"Booth 3 is now available!");
        sbExpected.AppendLine($"Bill 0.00 lv");
        sbExpected.AppendLine($"Booth 2 is now available!");
        sbExpected.AppendLine($"Booth: 1");
        sbExpected.AppendLine($"Capacity: 5");
        sbExpected.AppendLine($"Turnover: 0.00 lv");
        sbExpected.AppendLine($"-Cocktail menu:");
        sbExpected.AppendLine($"-Delicacy menu:");
        sbExpected.AppendLine($"--Sugarcookie - 3.50 lv");
        sbExpected.AppendLine($"Booth: 2");
        sbExpected.AppendLine($"Capacity: 3");
        sbExpected.AppendLine($"Turnover: 0.00 lv");
        sbExpected.AppendLine($"-Cocktail menu:");
        sbExpected.AppendLine($"-Delicacy menu:");
        sbExpected.AppendLine($"--Dwarfhat - 4.00 lv");
        sbExpected.AppendLine($"Booth: 3");
        sbExpected.AppendLine($"Capacity: 3");
        sbExpected.AppendLine($"Turnover: 0.00 lv");
        sbExpected.AppendLine($"-Cocktail menu:");
        sbExpected.AppendLine($"--Bluewater (Large) - 10.50 lv");
        sbExpected.AppendLine($"--Bluewater (Small) - 3.50 lv");
        sbExpected.AppendLine($"-Delicacy menu:");

        Assert.AreEqual(sbExpected.ToString().TrimEnd(), sbActual.ToString().TrimEnd());
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