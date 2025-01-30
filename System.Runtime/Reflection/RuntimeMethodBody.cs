using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal class RuntimeMethodBody : MethodBody
{

    private RuntimeLocalVariableInfo[] _localVariables;
    private RuntimeExceptionHandlingClause[] _exceptionHandlingClauses;
    private UIntPtr _il;
    private uint _ilSize;
    private int _localSignatureMetadataToken;
    private int _maxStackSize;
    private bool _initLocals;

}