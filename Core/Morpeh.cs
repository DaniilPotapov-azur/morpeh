#if UNITY_EDITOR
#define MORPEH_DEBUG
#endif
#if !MORPEH_DEBUG
#define MORPEH_DEBUG_DISABLED
#endif

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Morpeh.Editor")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Morpeh.TestSuite")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Morpeh.TestSuite.Editor")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Morpeh.Native")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Morpeh.Workaround")]

namespace Morpeh {
    //System
    using System;
    using UnityEngine;

    public interface IComponent {
    }
    
    public interface IInitializer : IDisposable {
        World World { get; set; }

        void OnAwake();
    }
    
    public interface ISystem : IInitializer {
        void OnUpdate(float deltaTime);
    }
    
    public interface IFixedSystem : ISystem {
    }
    
    public interface ILateSystem : ISystem {
    }
    
    public interface IValidatable {
        void OnValidate();
    }
    
    public interface IValidatableWithGameObject {
        void OnValidate(GameObject gameObject);
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class CacheSizeAttribute : Attribute {
        internal int size;
        public CacheSizeAttribute(int size) {
            this.size = size;
        }
    }
}

namespace Unity.IL2CPP.CompilerServices {
    using System;

#if !EXTERNAL_IL2CPP_ATTRS
    public enum Option {
#else
    internal enum Option {
#endif
        NullChecks         = 1,
        ArrayBoundsChecks  = 2,
        DivideByZeroChecks = 3
    }
    

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
#if !EXTERNAL_IL2CPP_ATTRS
    public class Il2CppSetOptionAttribute : Attribute {
#else
    internal class Il2CppSetOptionAttribute : Attribute {
#endif
        public Option Option { get; }
        public object Value  { get; }

        public Il2CppSetOptionAttribute(Option option, object value) {
            this.Option = option;
            this.Value  = value;
        }
    }
}

#if !UNITY_2019_1_OR_NEWER
namespace UnityEngine {
    public sealed class SerializeField : System.Attribute { }
    public sealed class GameObject : System.Object { }
}

namespace UnityEngine.Scripting {
    public sealed class Preserve : System.Attribute { }
}

namespace JetBrains.Annotations {
    using System;
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate)]
    public sealed class NotNullAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate)]
    public sealed class CanBeNullAttribute : Attribute { }
}
#endif

#if !ODIN_INSPECTOR
namespace Sirenix.OdinInspector {
    using System;
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public class ShowInInspectorAttribute : Attribute { }
}
#endif
