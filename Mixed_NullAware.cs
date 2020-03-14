namespace NullableByExample {

    public class Mixed_NullAware {

        //--- Class Methods ---
        public static string ToLower(string value) => value.ToLower();

        public static void Invoke_NullUnaware_Method(string? value) {

            // NOTE: calling null-unaware code provides no warnings since the compiler
            //  has no hints on the target method.
            var upper = Mixed_NullUnaware.ToUpper(value);
        }
    }
}
