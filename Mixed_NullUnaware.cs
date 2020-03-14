#nullable disable

namespace NullableByExample {

    public class Mixed_NullUnaware {

        //--- Class Methods ---
        public static string ToUpper(string value) => value.ToUpper();

        public static void Invoke_NullAware_Method(string value) {

            // NOTE: calling null-aware code from a null-unaware context provides no warnings
            // since the compiler has no hints about the source method.
            var lower = Mixed_NullAware.ToLower(value);
        }
    }
}
