using System;
using System.Diagnostics.CodeAnalysis;

namespace NullableByExample {

    public class Program {

        //--- Class Methods ---
        public static void Main(string[] args) {

            // fetch with ID
            var r1 = Fetch("123");
            Store(r1);

            // fetch with null
            var r2 = Fetch(null);
            if(IsValid(r2)) {
                var id_r2_2 = r2.Id;
                Record r2_2 = r2;
                Store(r2);
            } else {
                var id_r2_1 = r2!.Id;
                Record r2_1 = r2!;
            }

            // try-fetch success
            if(TryFetch("123", out var r3)) {
                Store(r3);
            }

            // try-fetch failure
            if(!TryFetch("123", out var r4) && IsValid(r4)) {
                Store(r4);
            }
        }

        public static void Store(Record record) { /* ... */ }

        [return: NotNullIfNotNull("id") ]
        public static Record? Fetch(string? id) {
            if(id == null) {
                return null;
            }
            return new Record {
                Id = id
            };
        }

        public static bool TryFetch(string? id, [NotNullWhen(true)] out Record? record) {
            if(id == null) {
                record = null;
                return false;
            }
            record = new Record {
                Id = id
            };
            return true;
        }


        public static bool IsValid([NotNullWhen(true)] Record? record) => record != null;

        [return: MaybeNull]
        public static T FindOrDefault<T>(string? id) => default;
    }
}
