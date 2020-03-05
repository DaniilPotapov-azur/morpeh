namespace Morpeh.Globals {
    using System.Collections.Generic;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Globals/Variable List Object")]
    public class GlobalVariableListObject : BaseGlobalVariable<List<Object>> {
        public override bool CanBeSerialized => false;
        
        protected override List<Object> Load(string serializedData) => null;

        protected override string Save() => string.Empty;
    }
}