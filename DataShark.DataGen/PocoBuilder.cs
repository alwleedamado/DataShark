using System.Reflection;
using System.Reflection.Emit;
using DataShark.DataGen.Models;

namespace DataShark.DataGen;

internal static class PocoBuilder
{
    public static void DefineProperty(TypeBuilder type, string name, Type propType)
    {
        var field = type.DefineField($"_{name}", propType, FieldAttributes.Private);
        var prop = type.DefineProperty(name, PropertyAttributes.HasDefault, propType, null);
        var getAccessor = type.DefineMethod($"get_{name}",
            MethodAttributes.SpecialName | MethodAttributes.Public | MethodAttributes.HideBySig,
            propType, Type.EmptyTypes);
        var getMethodIL = getAccessor.GetILGenerator();
        getMethodIL.Emit(OpCodes.Ldarg_0);
        getMethodIL.Emit(OpCodes.Ldfld, field);
        getMethodIL.Emit(OpCodes.Ret);

        var setAccessor = type.DefineMethod($"set_{name}",
            MethodAttributes.SpecialName | MethodAttributes.Public | MethodAttributes.HideBySig,
            null, [propType]);
        var setMethodIL = setAccessor.GetILGenerator();
        setMethodIL.Emit(OpCodes.Ldarg_0);
        setMethodIL.Emit(OpCodes.Ldarg_1);
        setMethodIL.Emit(OpCodes.Stfld, field);
        setMethodIL.Emit(OpCodes.Ret);
        prop.SetGetMethod(getAccessor);
        prop.SetSetMethod(setAccessor);
    }
    public static void DefineProperty(TypeBuilder type, string name, ClrType clrType)
    {
        DefineProperty(type, name, GetClTypeType(clrType));
    }

    private static Type GetClTypeType(ClrType clrType)
    {
        return clrType switch
        {
            ClrType.Int => typeof(int),
            ClrType.Double => typeof(double),
            ClrType.Decimal => typeof(decimal),
            ClrType.String => typeof(string),
            ClrType.DateTime => typeof(DateTime),
            ClrType.DateOnly => typeof(DateOnly),
            ClrType.TimeOnly => typeof(TimeOnly),
            _ => throw new ArgumentException("unsupported type")
        };
    }

}
