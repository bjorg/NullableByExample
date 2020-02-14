namespace NullableByExample {

    public partial class Program {

        //--- Class Methods ---
        public static void Main(string[] args) { }

        public static void FetchWithString() {
            var record = Fetch("123");
            Store(record);
        }

        public static void FetchWithStringOrNullUseIsValid() {
            var record = Fetch(GetId());
            if(IsValid(record)) {

                // no need to check for null
                Record otherRecord = record;
                var id = record.Id;

                // non-nullable just works
                Store(record);
            }
        }

        public static void FetchWithStringOrNullUseAssert() {
            var record = Fetch(GetId());
            AssertNotNull(record);
            Record otherRecord = record;
            var id = record.Id;
        }

        public static void TryFetchSuccess() {
            if(TryFetch("123", out var record)) {
                Store(record);
            }
        }

        public static void TryFetchAndIsValid() {
            if(!TryFetch("123", out var record) && IsValid(record)) {
                Store(record);
            }
        }

        public static void FetchWithStringOrNullUseNullForgivingOperator() {
            var record = Fetch(GetId());
            Record otherRecord = record!;
            var id = record!.Id;
        }
    }
}
